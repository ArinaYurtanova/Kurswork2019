using EyeClinic.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeClinic.Service.Interface
{
    public interface IStatus
    {

        List<StatusView> GetList();

        StatusView GetElement(int id);

        void AddElement(StatusView model);

        void UpdElement(StatusView model);

        void DelElement(int id);
    }
}
