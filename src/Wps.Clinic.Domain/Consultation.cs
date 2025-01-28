using Wps.Clinic.Domain.Events;
using Wps.Clinic.Domain.ValueObject;
using Wps.SharedKernel;


namespace Wps.Clinic.Domain
{
    public class Consultation : AggregateRoot
    {
        private readonly List<DrugAdministration> administerDrugs = new();
        private readonly List<VitalSigns> vitalSignsReading=new();
        public IReadOnlyCollection<VitalSigns> VitalSignsReading => vitalSignsReading;
        public IReadOnlyCollection<DrugAdministration> AdministeredDrugs => administerDrugs;

        public DateTimeRange When { get; private set; }
        public Text? Diagnosis { get; private set; }
        public Text? Treatment { get; private set; }
        public PatientId PatientId { get; private set; }

        public Weight? CurrentWeight { get; private set; }
        public ConsultationStatus ConsultationStatus { get; private set; }


        public Consultation(PatientId patientId) : base(Guid.NewGuid())
        {
            ApplyDomainEvent(new ConsultaionStarted(Id, patientId, DateTime.Now));

            //PatientId = patientId;
            //When = DateTime.UtcNow;
            //ConsultationStatus = ConsultationStatus.Open;
        }
        public Consultation(IEnumerable<IDomainEvent> domainEvents)
        {
            Load(domainEvents);
        }
        public void RegisterVitalsigns(IEnumerable<VitalSigns> vitalSigns)
        {
            ValidateConsultationStatus();
            vitalSignsReading.AddRange(vitalSigns);
        }
        public void AdministerDrug(DrugId drugId, Dose dose)
        {
            ValidateConsultationStatus();

            administerDrugs.Add(new(drugId, dose));
        }
        public void End()
        {
            //ValidateConsultationStatus();
            //if (Treatment == null && Diagnosis == null && CurrentWeight == null)
            //    throw new InvalidOperationException("one of valuse are null and cant ended");

            //ConsultationStatus = ConsultationStatus.Close;
            //this.When = new DateTimeRange(this.When.Start, DateTime.UtcNow);
            ApplyDomainEvent(new ConsultationEnded(Id, DateTime.UtcNow));

        }

        public void SetWeight(Weight weight)
        {
            //ValidateConsultationStatus();
            //CurrentWeight = weight;
            ApplyDomainEvent(new WeightUpdated(Id, weight));

        }
        public void SetTreatmen(Text text)
        {
            //ValidateConsultationStatus();
            //Treatment = text;
            ApplyDomainEvent(new TreatmentUpdated(Id, text));

        }
        public void SetDiagnosis(Text text)
        {
            //ValidateConsultationStatus();
            //Diagnosis = text;
            ApplyDomainEvent(new DiagnosisUpdated(Id,text));
        }
        public void ValidateConsultationStatus()
        {
            if (ConsultationStatus == ConsultationStatus.Close)
                throw new InvalidOperationException("Consultaion is closed");
        }

        protected override void ChangeStateByUsingDomainEvent(IDomainEvent domainEvent)
        {
            switch (domainEvent)
            {
                case ConsultaionStarted e:
                    Id = e.Id;
                    PatientId=e.PatientId;
                    ConsultationStatus= ConsultationStatus.Open;
                    When = e.StartedAt;
                    break;
                case DiagnosisUpdated e:
                    ValidateConsultationStatus();
                    Diagnosis = e.Diagnosis;
                    break;

                case WeightUpdated e:
                    ValidateConsultationStatus();
                    CurrentWeight = e.Weight;
                    break;
                case TreatmentUpdated e:
                    ValidateConsultationStatus();
                    Treatment = e.Treatment;
                    break;
                case ConsultationEnded e:
                    ValidateConsultationStatus();
                    if (Treatment == null && Diagnosis == null && CurrentWeight == null)
                        throw new InvalidOperationException("one of valuse are null and cant ended");

                    ConsultationStatus = ConsultationStatus.Close;
                    this.When = new DateTimeRange(this.When.Start, DateTime.UtcNow);
                    break;

            }
        }
    }
    public enum ConsultationStatus
    {
        Open,
        Close
    }
}
