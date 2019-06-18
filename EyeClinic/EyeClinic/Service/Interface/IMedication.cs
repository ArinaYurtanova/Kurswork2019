using EyeClinic.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeClinic.Service.Interface
{
    public interface IMedication
    {
        List<MedicationView> GetList();

        MedicationView GetElement(int id);

        void AddElement(MedicationView model);

        void UpdElement(MedicationView model);

        void DelElement(int id);
        void PutComponentOnStock(StorageMedicationView model);
    }
}
