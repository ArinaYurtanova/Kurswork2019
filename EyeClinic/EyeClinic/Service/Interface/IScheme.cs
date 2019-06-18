using EyeClinic.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeClinic.Service.Interface
{
    public interface IScheme
    {
        List<SchemeView> GetList();

        SchemeView GetElement(int id);

        void AddElement(SchemeView model);

        void UpdElement(SchemeView model);

        void DelElement(int id);
    }
}
