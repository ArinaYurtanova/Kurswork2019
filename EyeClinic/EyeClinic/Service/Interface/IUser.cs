using EyeClinic.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeClinic.Service.Interface
{
    public interface IUser
    {
        List<UserView> GetList();

        UserView GetElement(int id);

        void AddElement(UserView model);

        void UpdElement(UserView model);

        void DelElement(int id);

        List<UserView> GetList(string roleName);
    }
}
