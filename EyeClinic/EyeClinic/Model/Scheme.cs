using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeClinic.Model
{
    public class Scheme
    {
        public int Id { get; set; }

        [Required]
        public string SchemeName { get; set; }
 
        [Required]
        public decimal PriceScheme { get; set; }

        [ForeignKey("SchemeId")]
        public virtual List<TherapyScheme> TherapySchemes { get; set; }
    }
}
