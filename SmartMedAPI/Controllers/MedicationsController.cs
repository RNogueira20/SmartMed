using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Threading.Tasks;

namespace SmartMedAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicationsController : ControllerBase
    {

        private readonly IMedicationService _medicationService;

        public MedicationsController(IMedicationService medicationService)
        {
            _medicationService = medicationService;
        }

        [HttpGet]
        public async Task<List<MedicationDTO>> GetMedicationList()
        {
            return await _medicationService.GetMedicationListAsync();
        }

        [HttpPost]
        public async Task<ServiceResult> CreateMedication([FromBody]MedicationDTO medication)
        {
            if (!ModelState.IsValid)
            {
                var result = new ServiceResult();
                result.Errors = ModelState.SelectMany(x => x.Value.Errors.Select(t => t.ErrorMessage)).ToList();
            }

            return await _medicationService.CreateMedicationAsync(medication);

        }

        [HttpDelete]
        public async Task<ServiceResult>DeleteMedication(int id)
        {

            return await _medicationService.DeleteMedicationAsync(id);
        }
    }
}
