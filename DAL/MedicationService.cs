using EF;
using Microsoft.EntityFrameworkCore;
using Service;
using SmartMedAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public class MedicationService : IMedicationService
    {
        private readonly SmartMedContext _context;
        public MedicationService(SmartMedContext context)
        {
            _context = context;
        }

        public async Task<ServiceResult> CreateMedicationAsync(MedicationDTO medicationDTO)
        {
            var medication = new Medication
            {
                Name = medicationDTO.Name,
                Quantity = medicationDTO.Quantity,
                CreationDate = DateTime.Now
            };

            await _context.Medications.AddAsync(medication);
            var saved = await _context.SaveChangesAsync();

            if (saved > 0)
                return new ServiceResult();

            return new ServiceResult { Errors = new List<string> { "Error while creating a new Medication!" } };

        }

        public async Task<ServiceResult> DeleteMedicationAsync(int id)
        {

            var medicationToRemove = await _context.Medications.FirstOrDefaultAsync(t => t.Id == id);

            if (medicationToRemove == null)
                return new ServiceResult { Errors = new List<string> { "The seleted Medication was not found!" } };

            _context.Medications.Remove(medicationToRemove);
            var saved = await _context.SaveChangesAsync();

            if (saved > 0)
                return new ServiceResult();

            return new ServiceResult { Errors = new List<string> { "Error while deleting the Medication!" } };

        }

        public async Task<List<MedicationDTO>> GetMedicationListAsync()
        {
            var result = new List<MedicationDTO>();

            result = await _context.Medications.Select(t => new MedicationDTO
            {
                Name = t.Name,
                CreationDate = t.CreationDate,
                Quantity = t.Quantity
            }).ToListAsync();

            return result;
        }
    }
}
