using Wps.Clinic.API.Commands;
using Wps.Clinic.API.Infrustructure;
using Wps.Clinic.Domain.ValueObject;
using Wps.Clinic.Domain;
using Wps.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace Wps.Clinic.API.Application
{
    public class ClinicApplicationService(ClinicDbContext dbContext)
    {
        public async Task<Guid> Handle(StartConsultationCommand command)
        {
            var newConsultation = new Consultant(command.PatientId);
            await dbContext.Consultations.AddAsync(newConsultation);
            await dbContext.SaveChangesAsync();
            return newConsultation.Id;
        }

        public async Task Handle(EndConsultationCommand command)
        {
            var consultation = await dbContext.Consultations.FindAsync(command.ConsultationId);
            if (consultation != null)
            {
                consultation.End();
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Handle(SetDiagnosisCommand command)
        {
            var consultation = await dbContext.Consultations.FindAsync(command.ConsultationId);
            if (consultation != null)
            {
                consultation.SetDiagnosis(new Text(command.Diagnosis));
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Handle(SetTreatmentCommand command)
        {
            var consultation = await dbContext.Consultations.FindAsync(command.ConsultationId);
            if (consultation != null)
            {
                consultation.SetTreatmen(new Text(command.Treatment));
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Handle(SetWeightCommand command)
        {
            var consultation = await dbContext.Consultations.FindAsync(command.ConsultationId);
            if (consultation != null)
            {
                consultation.SetWeight(new Weight(command.Weight));
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Handle(AdministerDrugCommand command)
        {
            var consultation = await dbContext.Consultations.FindAsync(command.ConsultationId);
            if (consultation != null)
            {
                consultation.AdministerDrug(command.DrugId, new Dose(command.Quantity, command.UnitofMeasure));
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Handle(RegisterVitalSignsCommand command)
        {
            var consultation = await dbContext.Consultations.FindAsync(command.ConsultationId);
            if (consultation != null)
            {
                consultation.RegisterVitalsigns(command.Readings.Select(m=>     
                    new VitalSigns(consultation.Id, m.ReadingDateTime,m.Temperature,m.RespiratoryRate,m.HeartRate)));
               await dbContext.VitalSigns.AddRangeAsync(consultation.VitalSignsReading);
                // Assuming readings is a variable holding the IEnumerable<VitalSignsReading>
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
