using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EyeClinic.Model
{
    public class Therapy 
    {
        public int Id { get; set; }

        [Required]
        public string TherapyName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey("TherapyId")]
        public virtual List<MedicalHistory> MedicalHistorys { get; set; }

        [ForeignKey("TherapyId")]
        public virtual List<TherapyScheme> TherapySchemes { get; set; }
    }
}
