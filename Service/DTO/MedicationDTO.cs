using System;
using System.ComponentModel.DataAnnotations;

namespace SmartMedAPI
{
    public class MedicationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int Quantity { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
