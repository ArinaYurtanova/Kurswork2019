using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeClinic.Model
{
    public class Illness
    {
        public int Id { get; set; }

        public string IllnessName { get; set; }

        [ForeignKey("IllnessId")]
        public virtual List<MedicalHistory> MedicalHistorys { get; set; }
    }
}
