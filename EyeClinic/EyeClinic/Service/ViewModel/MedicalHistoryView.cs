using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeClinic.Service.ViewModel
{
    public class MedicalHistoryView
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public string Surname { get; set; }

        public int UserId { get; set; }

        public string Login { get; set; }

        public int IllnessId { get; set; }

        public string IllnessName { get; set; }

        public int TherapyId { get; set; }

        public string TherapyName { get; set; }

        public int StatusId { get; set; }

        public string StatusName { get; set; }

        public DateTime DateCreate { get; set; }

       
    }
}
