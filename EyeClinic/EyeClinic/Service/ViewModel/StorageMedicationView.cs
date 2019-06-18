using EyeClinic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeClinic.Service.ViewModel
{
    public class StorageMedicationView
    {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public int MedicationId { get; set; }
        public string MedicationName { get; set; }
        public int Count { get; set; }
        public virtual Storage Storage { get; set; }
        public virtual Medication Medication { get; set; }
    }
}
