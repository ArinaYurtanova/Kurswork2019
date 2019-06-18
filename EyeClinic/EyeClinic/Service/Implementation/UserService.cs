using EyeClinic.Model;
using EyeClinic.Service.Interface;
using EyeClinic.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeClinic.Service.Implementation
{
    public class UserService: IUser
    {
        private EyeClinicDBContext context;

        public UserService(EyeClinicDBContext context)
        {
            this.context = context;
        }

        public List<UserView> GetList()
        {
            List<UserView> result = context.Users
                .Select(rec => new UserView
                {
                    Id = rec.Id,
                    Role = rec.Role,
                    Login=rec.Login,
                    Password=rec.Password
                })
                .ToList();
            return result;
        }

        public List<UserView> GetList(int id)
        {
            List<UserView> result = context.Users
                 .Where(rec => rec.Id == id)
                 .Select(rec => new UserView
                 {
                     Id = rec.Id,

                 })
                 .ToList();
            return result;
        }

        public UserView GetElement(int id)
        {
            User element = context.Users.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new UserView
                {
                    Id = element.Id,
                    Role = element.Role,
                    Login = element.Login,
                    Password = element.Password

                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(UserView model)
        {
            User element = context.Users.FirstOrDefault(rec => rec.Role == model.Role && rec.Login == model.Login);
            if (element != null)
            {
                throw new Exception("Уже есть такой пользователь ");
            }
            context.Users.Add(new User
            {
                Role = model.Role,
                Login = model.Login,
                Password = model.Password
            });
            context.SaveChanges();
        }

        public void UpdElement(UserView model)
        {
            User element = context.Users.FirstOrDefault(rec =>
                                        rec.Login == model.Login && rec.Id != model.Id && rec.Role == model.Role);
            if (element != null)
            {
                throw new Exception("Уже есть такой пользователь ");
            }
            element = context.Users.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.Role = model.Role;
            element.Login = model.Login;
            element.Password = model.Password;

            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            User element = context.Users.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Users.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Пользователь не найден");
            }
        }

        public List<UserView> GetList(string roleName)
        {
            List<UserView> result = context.Users
                 .Where(rec => rec.Role == roleName)
                 .Select(rec => new UserView
                 {
                     Id = rec.Id,
                     Role = rec.Role,
                     Login = rec.Login,
                     Password = rec.Password

                 })
                 .ToList();
            return result;
        }

        
    }
}


