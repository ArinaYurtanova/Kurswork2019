using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeClinic.Model
{
    public class Patient
    {
        public int Id { set; get; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Name { get; set; }

        public string Otchestvo { get; set; }

        [Required]
        public string Insurance { get; set; }

        [Required]
        public string Illness { get; set; }

        public string Group { get; set; }

        public string Therapy { get; set; }

        public string Status { get; set; }

        public string Day { get; set; }

        public string Month { get; set; }

        public string Year { get; set; }

        [ForeignKey("PatientId")]
        public virtual List<MedicalHistory> MedicalHistorys { get; set; }

        /* [ForeignKey("TherapyId")]
         public virtual List<Therapy> Therapys { get; set; }*/
    }
}
