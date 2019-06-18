using EyeClinic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeClinic.Service.ViewModel
{
    public class StorageView
    {
        public int Id { get; set; }
       
        public string StorageName { get; set; }

        public virtual List<StorageMedicationView> StorageMedications { get; set; }

        public string FileName { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }
    }
}
