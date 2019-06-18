using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeClinic.Model
{
    public class Status
    {
        public int Id { get; set; }

        public string StatusName { get; set; }

        [ForeignKey("StatusId")]
        public virtual List<MedicalHistory> MedicalHistorys { get; set; }

    }
}
