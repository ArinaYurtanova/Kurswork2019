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
    public class SchemeService: IScheme
    {
        private EyeClinicDBContext context;

        public SchemeService(EyeClinicDBContext context)
        {
            this.context = context;
        }

        public List<SchemeView> GetList()
        {
            List<SchemeView> result = context.Schemes
                .Select(rec => new SchemeView
                {
                    Id = rec.Id,
                    SchemeName = rec.SchemeName,
                    PriceScheme = rec.PriceScheme
                })
                .ToList();
            return result;
        }

        public SchemeView GetElement(int id)
        {
            Scheme element = context.Schemes.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new SchemeView
                {
                    Id = element.Id,
                    SchemeName = element.SchemeName,
                    PriceScheme = element.PriceScheme
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(SchemeView model)
        {
            Scheme element = context.Schemes.FirstOrDefault(rec => rec.SchemeName == model.SchemeName);
            if (element != null)
            {
                throw new Exception("Уже есть программа с таким названием");
            }
            context.Schemes.Add(new Scheme
            {
                SchemeName = model.SchemeName,
                PriceScheme = model.PriceScheme
            });
            context.SaveChanges();
        }

        public void UpdElement(SchemeView model)
        {
            Scheme element = context.Schemes.FirstOrDefault(rec =>
                                        rec.SchemeName == model.SchemeName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть программа с таким названием");
            }
            element = context.Schemes.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.SchemeName = model.SchemeName;
            element.PriceScheme = model.PriceScheme;
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Scheme element = context.Schemes.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Schemes.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
