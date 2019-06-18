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
    public class GroupService: IGroup
    {
        private EyeClinicDBContext context;

        public GroupService(EyeClinicDBContext context)
        {
            this.context = context;
        }

        public List<GroupView> GetList()
        {
            List<GroupView> result = context.Groups
                .Select(rec => new GroupView
                {
                    Id = rec.Id,
                    GroupName = rec.GroupName
                })
                .ToList();
            return result;
        }

        public List<GroupView> GetList(int id)
        {
            List<GroupView> result = context.Groups
                 .Where(rec => rec.Id == id)
                 .Select(rec => new GroupView
                 {
                     Id = rec.Id,

                 })
                 .ToList();
            return result;
        }

        public GroupView GetElement(int id)
        {
            Group element = context.Groups.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new GroupView
                {
                    Id = element.Id,
                    GroupName = element.GroupName

                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(GroupView model)
        {
            Group element = context.Groups.FirstOrDefault(rec => rec.GroupName == model.GroupName);
            if (element != null)
            {
                throw new Exception("Уже есть такой статус ");
            }
            context.Groups.Add(new Group
            {
                GroupName = model.GroupName,

            });
            context.SaveChanges();
        }

        public void UpdElement(GroupView model)
        {
            Group element = context.Groups.FirstOrDefault(rec =>
                                        rec.GroupName == model.GroupName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть такой статус ");
            }
            element = context.Groups.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.GroupName = model.GroupName;

            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Group element = context.Groups.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Groups.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Пациент не найден");
            }
        }
    }
}

