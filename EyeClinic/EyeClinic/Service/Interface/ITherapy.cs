using EyeClinic.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeClinic.Service.Interface
{
    public interface ITherapy
    {
        List<TherapyView> GetList();

        TherapyView GetElement(int id);

        void AddElement(TherapyView model);

        void UpdElement(TherapyView model);

        void DelElement(int id);
    }
}
