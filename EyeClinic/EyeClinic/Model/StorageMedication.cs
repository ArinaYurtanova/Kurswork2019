using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeClinic.Model
{
    public class StorageMedication
    {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public int MedicationId { get; set; }
        public int Count { get; set; }
        public virtual Storage Storage { get; set; }
        public virtual Medication Medication { get; set; }
    }
}
