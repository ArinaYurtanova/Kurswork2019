using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeClinic.Model
{
    public class Medication
    {
        public int Id { get; set; }
        [Required]
        public string MedicationName { get; set; }
    
        [ForeignKey("MedicationId")]
        public virtual List<StorageMedication> StorageMedications { get; set; }
    }
}
