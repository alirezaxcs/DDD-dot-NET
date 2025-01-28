using Wps.Clinic.API.Commands;
using Wps.Clinic.API.Infrustructure;
using Wps.Clinic.Domain.ValueObject;
using Wps.Clinic.Domain;
using Wps.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Wps.Clinic.API.Application
{
    public class ClinicApplicationService(ClinicDbContext dbContext)
    {
        public async Task<Guid> Handle(StartConsultationCommand command)
        {
            var newConsultation = new Consultation(command.PatientId);
           // await dbContext.Consultations.AddAsync(newConsultation);
           // await dbContext.SaveChangesAsync();
           await SaveAsync(newConsultation);
            return newConsultation.Id;
        }

        public async Task Handle(EndConsultationCommand command)
        {
            var consultation = await dbContext.Consultations.FindAsync(command.ConsultationId);
            if (consultation != null)
            {
              //  consultation.End();
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Handle(SetDiagnosisCommand command)
        {
            var consultation = await LoadAsync(command.ConsultationId);// await dbContext.Consultations.FindAsync(command.ConsultationId);
            if (consultation != null)
            {
                consultation.SetDiagnosis(command.Diagnosis);
                await SaveAsync(consultation);

                //    consultation.SetDiagnosis(new Text(command.Diagnosis));
                // await dbContext.SaveChangesAsync();
            }
        }

        public async Task Handle(SetTreatmentCommand command)
        {
            var consultation = await LoadAsync(command.ConsultationId);  //await dbContext.Consultations.FindAsync(command.ConsultationId);
            if (consultation != null)
            {
                consultation.SetTreatmen(command.Treatment);
             //   consultation.SetTreatmen(new Text(command.Treatment));
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Handle(SetWeightCommand command)
        {
            var consultation = await dbContext.Consultations.FindAsync(command.ConsultationId);
            if (consultation != null)
            {
               // consultation.SetWeight(new Weight(command.Weight));
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Handle(AdministerDrugCommand command)
        {
            var consultation = await dbContext.Consultations.FindAsync(command.ConsultationId);
            if (consultation != null)
            {
             //   consultation.AdministerDrug(command.DrugId, new Dose(command.Quantity, command.UnitofMeasure));
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Handle(RegisterVitalSignsCommand command)
        {
            var consultation = await dbContext.Consultations.FindAsync(command.ConsultationId);
            if (consultation != null)
            {
              //  consultation.RegisterVitalsigns(command.Readings.Select(m=>     
               //     new VitalSigns(m.ReadingDateTime,m.Temperature,m.RespiratoryRate,m.HeartRate)));
               
                // Assuming readings is a variable holding the IEnumerable<VitalSignsReading>
                await dbContext.SaveChangesAsync();
            }
        }
        public async Task SaveAsync(Consultation consultation)
        {
            var aggregateId = $"Consultation-{consultation.Id}";
            var changes = consultation.GetChanges()
                                       .Select(e => new ConsultationEventData(Guid.NewGuid(),
                                                                             aggregateId,
                                                                             e.GetType().Name,
                                                                             JsonConvert.SerializeObject(e),
                                                                             e.GetType().AssemblyQualifiedName));

            if (!changes.Any())
            {
                return;
            }

            foreach (var change in changes)
            {
                await dbContext.Consultations.AddAsync(change);
            }
            await dbContext.SaveChangesAsync();
            consultation.ClearChanges();
        }
        public async Task<Consultation> LoadAsync(Guid id)
        {
            var aggregateId = $"Consultation-{id}";
            var result = await dbContext.Consultations
              .Where(a => a.AggregateId == aggregateId)
              .ToListAsync();

            var domainEvents = result.Select(e =>
            {
                var assemblyQualifiedName = e.AssemblyQualifiedName;
                var eventType = Type.GetType(assemblyQualifiedName);
                var data = JsonConvert.DeserializeObject(e.Data, eventType!);
                return data as IDomainEvent;
            });

            var aggregate = new Consultation(domainEvents!);
            return aggregate;
        }
    }
}
