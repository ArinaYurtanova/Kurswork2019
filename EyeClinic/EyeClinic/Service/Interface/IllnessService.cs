using EyeClinic.Model;
using EyeClinic.Service.Interface;
using EyeClinic.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeClinic.Service.Interface
{
    public class IllnessService: IIllness
    {
        private EyeClinicDBContext context;

        public IllnessService(EyeClinicDBContext context)
        {
            this.context = context;
        }

        public List<IllnessView> GetList()
        {
            List<IllnessView> result = context.Illnesses
                .Select(rec => new IllnessView
                {
                    Id = rec.Id,
                    IllnessName = rec.IllnessName
                })
                .ToList();
            return result;
        }

        public List<IllnessView> GetList(int id)
        {
            List<IllnessView> result = context.Illnesses
                 .Where(rec => rec.Id == id)
                 .Select(rec => new IllnessView
                 {
                     Id = rec.Id,

                 })
                 .ToList();
            return result;
        }

        public IllnessView GetElement(int id)
        {
            Illness element = context.Illnesses.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new IllnessView
                {
                    Id = element.Id,
                    IllnessName = element.IllnessName

                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(IllnessView model)
        {
            Illness element = context.Illnesses.FirstOrDefault(rec => rec.IllnessName == model.IllnessName);
            if (element != null)
            {
                throw new Exception("Уже есть такое заболевание ");
            }
            context.Illnesses.Add(new Illness
            {
                IllnessName = model.IllnessName,

            });
            context.SaveChanges();
        }

        public void UpdElement(IllnessView model)
        {
            Illness element = context.Illnesses.FirstOrDefault(rec =>
                                        rec.IllnessName == model.IllnessName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть такое заболевание ");
            }
            element = context.Illnesses.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.IllnessName = model.IllnessName;

            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Illness element = context.Illnesses.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Illnesses.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Пациент не найден");
            }
        }
    }
}
