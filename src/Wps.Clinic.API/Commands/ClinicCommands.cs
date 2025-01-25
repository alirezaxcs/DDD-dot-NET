using Wps.Clinic.Domain.ValueObject;

namespace Wps.Clinic.API.Commands
{
   

    public record StartConsultationCommand(Guid PatientId);

    public record EndConsultationCommand(Guid ConsultationId);

    public record SetDiagnosisCommand(Guid ConsultationId, string Diagnosis);

    public record SetTreatmentCommand(Guid ConsultationId, string Treatment);

    public record SetWeightCommand(Guid ConsultationId, decimal Weight);

    public record AdministerDrugCommand(Guid ConsultationId, Guid DrugId, decimal Quantity,UnitofMeasure UnitofMeasure);

    public record RegisterVitalSignsCommand(Guid ConsultationId, IEnumerable<VitalSignsReading> Readings);

    public record VitalSignsReading(DateTime ReadingDateTime,
                                     decimal Temperature,
                                     int HeartRate,
                                     int RespiratoryRate);
}
