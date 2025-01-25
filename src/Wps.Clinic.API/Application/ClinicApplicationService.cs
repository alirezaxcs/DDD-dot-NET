using Wps.Clinic.API.Commands;
using Wps.Clinic.API.Infrustructure;
using Wps.Clinic.Domain.ValueObject;
using Wps.Clinic.Domain;
using Wps.SharedKernel;

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
                consultation.Diagnosis = new Diagnosis(command.Diagnosis);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Handle(SetTreatmentCommand command)
        {
            var consultation = await dbContext.Consultations.FindAsync(command.ConsultationId);
            if (consultation != null)
            {
                consultation.Treatment = new Treatment(command.Treatment);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Handle(SetWeightCommand command)
        {
            var consultation = await dbContext.Consultations.FindAsync(command.ConsultationId);
            if (consultation != null)
            {
                consultation.Weight = new Weight(command.Weight);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Handle(AdministerDrugCommand command)
        {
            var consultation = await dbContext.Consultations.FindAsync(command.ConsultationId);
            if (consultation != null)
            {
                consultation.Drug = new Drug(command.DrugId, command.Quantity);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Handle(RegisterVitalSignsCommand command)
        {
            var consultation = await dbContext.Consultations.FindAsync(command.ConsultationId);
            if (consultation != null)
            {
                consultation.VitalSigns = new VitalSigns(DateTime.Now, readings.FirstOrDefault().Temperature, readings.FirstOrDefault().HeartRate, readings.FirstOrDefault().RespiratoryRate);
                // Assuming readings is a variable holding the IEnumerable<VitalSignsReading>
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
