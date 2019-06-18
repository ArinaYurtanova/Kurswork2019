using EyeClinic.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeClinic.Service.Interface
{
    public interface IGroup
    {
        List<GroupView> GetList();

        GroupView GetElement(int id);

        void AddElement(GroupView model);

        void UpdElement(GroupView model);

        void DelElement(int id);
    }
}
