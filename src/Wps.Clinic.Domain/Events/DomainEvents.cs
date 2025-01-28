using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wps.Clinic.Domain.ValueObject;
using Wps.SharedKernel;

namespace Wps.Clinic.Domain.Events
{
    public record ConsultaionStarted(Guid Id,PatientId PatientId,DateTime StartedAt):IDomainEvent;

    public record DiagnosisUpdated(Guid Id, string Diagnosis) : IDomainEvent;

    public record TreatmentUpdated(Guid Id, string Treatment) : IDomainEvent;

    public record WeightUpdated(Guid Id, decimal Weight) : IDomainEvent;

    public record ConsultationEnded(Guid Id, DateTime EndedAt) : IDomainEvent;

}
