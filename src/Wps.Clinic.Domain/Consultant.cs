using Wps.Clinic.Domain.ValueObject;
using Wps.SharedKernel;

namespace Wps.Clinic.Domain
{
    public class Consultant : AggregateRoot
    {
        public Text Diagnosis { get; private set; }
        public Text Treatment { get; private set; }
        public PatientId PatientId { get; init; }
        public DateTime StartedAt { get; init; }
        public Weight CurrentWeight { get; private set; }
        public ConsultationStatus ConsultationStatus { get; private set; }
        public DateTime? EndAt { get; private set; }

        public Consultant(PatientId patientId) : base(Guid.NewGuid())
        {

            PatientId = patientId;
            StartedAt = DateTime.UtcNow;
            ConsultationStatus = ConsultationStatus.Open;
        }
        public void End()
        {
            ValidateConsultationStatus();
            if (Treatment == null && Diagnosis == null && CurrentWeight == null)
                throw new InvalidOperationException("one of valuse are null and cant ended");

            ConsultationStatus =ConsultationStatus.Close;
            EndAt=DateTime.UtcNow;
        }
        public void SetWeight(Weight weight)
        {
            ValidateConsultationStatus();
            CurrentWeight = weight;
        }
        public void SetTreatmen(Text text)
        {
            ValidateConsultationStatus();
            Treatment = text;
        }
        public void SetDiagnosis(Text text)
        {
            ValidateConsultationStatus();
            Diagnosis = text;
        }
        public void ValidateConsultationStatus()
        {
            if (ConsultationStatus == ConsultationStatus.Close)
                throw new InvalidOperationException("Consultaion is closed");
        }

    }
    public enum ConsultationStatus
    {
        Open,
        Close
    }
}
