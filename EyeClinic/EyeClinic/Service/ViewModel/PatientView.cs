using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeClinic.Service.ViewModel
{
    public class PatientView
    {
        public int Id { set; get; }

        
        public string Surname { get; set; }

        
        public string Name { get; set; }

        public string Otchestvo { get; set; }

        public string Group { get; set; }

        public string Insurance { get; set; }

        
        public string Illness { get; set; }


        public string Therapy { get; set; }

        public string Status { get; set; }

        public string Day { get; set; }

        public string Month { get; set; }

        public string Year { get; set; }
    }
}
