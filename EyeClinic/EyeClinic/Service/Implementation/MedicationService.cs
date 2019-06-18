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
    public class MedicationService: IMedication
    {
        private EyeClinicDBContext context;

        public MedicationService(EyeClinicDBContext context)
        {
            this.context = context;
        }

        public List<MedicationView> GetList()
        {
            List<MedicationView> result = context.Medications
                .Select(rec => new MedicationView
                {
                    Id = rec.Id,
                    MedicationName = rec.MedicationName
                })
                .ToList();
            return result;
        }

        public MedicationView GetElement(int id)
        {
            Medication element = context.Medications.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new MedicationView
                {
                    Id = element.Id,
                    MedicationName = element.MedicationName
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(MedicationView model)
        {
            Medication element = context.Medications.FirstOrDefault(rec => rec.MedicationName == model.MedicationName);
            if (element != null)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            context.Medications.Add(new Medication
            {
                MedicationName = model.MedicationName
            });
            context.SaveChanges();
        }

        public void UpdElement(MedicationView model)
        {
            Medication element = context.Medications.FirstOrDefault(rec =>
                                        rec.MedicationName == model.MedicationName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            element = context.Medications.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.MedicationName = model.MedicationName;
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Medication element = context.Medications.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Medications.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public void PutComponentOnStock(StorageMedicationView model)
        {
            StorageMedication element = context.StorageMedications
                                                .FirstOrDefault(rec => rec.StorageId == model.StorageId &&
                                                                    rec.MedicationId == model.MedicationId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                context.StorageMedications.Add(new StorageMedication
                {
                    StorageId = model.StorageId,
                    MedicationId = model.MedicationId,
                    Count = model.Count
                });
            }
            context.SaveChanges();
        }
    }
}
