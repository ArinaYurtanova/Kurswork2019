using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeClinic.Model
{
    public class MedicalHistory
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int UserId { get; set; }

        public int StatusId { get; set; }

        public int TherapyId { get; set; }

        public int IllnessId { get; set; }

        public DateTime DateCreate { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual User User { get; set; }

        public virtual Therapy Therapy { get; set; }

        public virtual Status Status { get; set; }

        public virtual Illness Illness { get; set; }


    }
}
