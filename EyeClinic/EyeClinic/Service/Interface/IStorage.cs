using EyeClinic.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeClinic.Service.Interface
{
    public interface IStorage
    {
        List<StorageView> GetList();

        StorageView GetElement(int id);

        void AddElement(StorageView model);

        void UpdElement(StorageView model);

        void DelElement(int id);

        List<StoragesLoadView> GetStoragesLoad();

        void SaveStoragesLoad(StorageView model);

        void PutComponentOnStock(StorageMedicationView model);
    }
}
