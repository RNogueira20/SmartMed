using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF
{
    [Table("Medication")]
    public class Medication
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string Name { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime CreationDate { get; set; }
    }
}
