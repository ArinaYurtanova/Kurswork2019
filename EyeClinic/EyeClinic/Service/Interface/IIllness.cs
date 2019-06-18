using EyeClinic.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeClinic.Service.Interface
{
    public interface IIllness
    {
        List<IllnessView> GetList();

        IllnessView GetElement(int id);

        void AddElement(IllnessView model);

        void UpdElement(IllnessView model);

        void DelElement(int id);
    }
}
