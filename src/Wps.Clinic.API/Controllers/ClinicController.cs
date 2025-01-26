using Microsoft.AspNetCore.Mvc;

namespace Wps.Clinic.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Wps.Clinic.API.Application;
    using Wps.Clinic.API.Commands;
    using Wps.Clinic.Domain.ValueObject;

    namespace Wms.Clinic.Api.Controllers
    {
        [ApiController]
        [Route("[controller]")]
        public class ClinicController : ControllerBase
        {
            private readonly ClinicApplicationService _applicationService;
            private readonly ILogger<ClinicController> _logger;

            public ClinicController(ClinicApplicationService applicationService, ILogger<ClinicController> logger)
            {
                _applicationService = applicationService;
                _logger = logger;
            }

            [HttpPost]
            public async Task<IActionResult> StartConsultation(StartConsultationCommand command)
            {
                try
                {
                    var id = await _applicationService.Handle(command);
                    return Ok(id);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while starting a consultation.");
                    return BadRequest("An error occurred while starting a consultation.");
                }
            }

            [HttpPut("{consultationId}/end")]
            public async Task<IActionResult> EndConsultation(Guid consultationId)
            {
                try
                {
                    await _applicationService.Handle(new EndConsultationCommand(consultationId));
                    return NoContent();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"An error occurred while ending consultation with ID: {consultationId}.");
                    return BadRequest($"An error occurred while ending consultation with ID: {consultationId}.");
                }
            }

            [HttpPut("{consultationId}/diagnosis")]
            public async Task<IActionResult> SetDiagnosis(Guid consultationId, string diagnosis)
            {
                try
                {
                    await _applicationService.Handle(new SetDiagnosisCommand(consultationId, diagnosis));
                    return NoContent();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"An error occurred while setting diagnosis for consultation with ID: {consultationId}.");
                    return BadRequest($"An error occurred while setting diagnosis for consultation with ID: {consultationId}.");
                }
            }

            [HttpPut("{consultationId}/treatment")]
            public async Task<IActionResult> SetTreatment(Guid consultationId, string treatment)
            {
                try
                {
                    await _applicationService.Handle(new SetTreatmentCommand(consultationId, treatment));
                    return NoContent();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"An error occurred while setting treatment for consultation with ID: {consultationId}.");
                    return BadRequest($"An error occurred while setting treatment for consultation with ID: {consultationId}.");
                }
            }

            [HttpPut("{consultationId}/weight")]
            public async Task<IActionResult> SetWeight(Guid consultationId, decimal weight)
            {
                try
                {
                    await _applicationService.Handle(new SetWeightCommand(consultationId, weight));
                    return NoContent();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"An error occurred while setting weight for consultation with ID: {consultationId}.");
                    return BadRequest($"An error occurred while setting weight for consultation with ID: {consultationId}.");
                }
            }

            [HttpPut("{consultationId}/drug")]
            public async Task<IActionResult> AdministerDrug(Guid consultationId, Guid drugId, decimal quantity, UnitofMeasure unitofMeasure)
            {
                try
                {
                    await _applicationService.Handle(new AdministerDrugCommand(consultationId, drugId, quantity, unitofMeasure));
                    return NoContent();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"An error occurred while administering drug to consultation with ID: {consultationId}.");
                    return BadRequest($"An error occurred while administering drug to consultation with ID: {consultationId}.");
                }
            }

            [HttpPut("{consultationId}/vital-signs")]
            public async Task<IActionResult> RegisterVitalSigns(Guid consultationId, [FromBody] VitalSignsReading[] readings)
            {
                try
                {
                    await _applicationService.Handle(new RegisterVitalSignsCommand(consultationId, readings));
                    return NoContent();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"An error occurred while registering vital signs for consultation with ID: {consultationId}.");
                    return BadRequest($"An error occurred while registering vital signs for consultation with ID: {consultationId}.");
                }
            }
        }
    }
}
