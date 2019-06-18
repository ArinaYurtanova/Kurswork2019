using EyeClinic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeClinic.Service.ViewModel
{
    public class MedicationView
    {
        public int Id { get; set; }
        
        public string MedicationName { get; set; }

        public virtual List<StorageMedication> StorageMedications { get; set; }
    }
}
