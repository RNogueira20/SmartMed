using SmartMedAPI;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public interface IMedicationService 
    {
        public Task<ServiceResult> CreateMedicationAsync(MedicationDTO medication);

        public Task<ServiceResult> DeleteMedicationAsync(int id);

        public Task<List<MedicationDTO>> GetMedicationListAsync();
    }
}
