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
    public class StatusService: IStatus
    {
        private EyeClinicDBContext context;

        public StatusService(EyeClinicDBContext context)
        {
            this.context = context;
        }

        public List<StatusView> GetList()
        {
            List<StatusView> result = context.Statuses
                .Select(rec => new StatusView
                {
                    Id = rec.Id,
                    StatusName = rec.StatusName
                })
                .ToList();
            return result;
        }

        public List<StatusView> GetList(int id)
        {
            List<StatusView> result = context.Statuses
                 .Where(rec => rec.Id == id)
                 .Select(rec => new StatusView
                 {
                     Id = rec.Id,
                    
                 })
                 .ToList();
            return result;
        }

        public StatusView GetElement(int id)
        {
            Status element = context.Statuses.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new StatusView
                {
                    Id = element.Id,
                    StatusName=element.StatusName

                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(StatusView model)
        {
            Status element = context.Statuses.FirstOrDefault(rec => rec.StatusName == model.StatusName);
            if (element != null)
            {
                throw new Exception("Уже есть такой статус ");
            }
            context.Statuses.Add(new Status
            {
                StatusName = model.StatusName,
                
            });
            context.SaveChanges();
        }

        public void UpdElement(StatusView model)
        {
            Status element = context.Statuses.FirstOrDefault(rec =>
                                        rec.StatusName == model.StatusName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть такой статус ");
            }
            element = context.Statuses.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.StatusName = model.StatusName;
           
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Status element = context.Statuses.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Statuses.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Пациент не найден");
            }
        }
    }
}

