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
    public class MedicalHistoryService: IMedicalHistory
    {
        private EyeClinicDBContext context;

        public MedicalHistoryService(EyeClinicDBContext context)
        {
            this.context = context;
        }

        public List<MedicalHistoryView> GetList()
        {
            List<MedicalHistoryView> result = context.MedicalHistorys
                .Select(rec => new MedicalHistoryView
                {
                    Id = rec.Id,
                    PatientId = rec.PatientId,
                    Surname=rec.Patient.Surname,
                    UserId = rec.UserId,
                    Login = rec.User.Login,
                    IllnessId = rec.IllnessId,
                    IllnessName = rec.Illness.IllnessName,
                    TherapyId = rec.TherapyId,
                    TherapyName=rec.Therapy.TherapyName,
                    StatusId = rec.StatusId,
                    StatusName=rec.Status.StatusName,
                    DateCreate = rec.DateCreate,
                    

                })
                .ToList();
            return result;
        }

        public List<MedicalHistoryView> GetList(int id)
        {
            List<MedicalHistoryView> result = context.MedicalHistorys
                 .Where(rec => rec.PatientId == id || rec.UserId == id )
                 .Select(rec => new MedicalHistoryView
                 {
                     Id = rec.Id,
                     PatientId = rec.PatientId,
                     Surname = rec.Patient.Surname,
                     UserId = rec.UserId,
                     Login = rec.User.Login,
                     IllnessId = rec.IllnessId,
                     IllnessName = rec.Illness.IllnessName,
                     TherapyId = rec.TherapyId,
                     TherapyName = rec.Therapy.TherapyName,
                     StatusId = rec.StatusId,
                     StatusName = rec.Status.StatusName,
                     DateCreate = rec.DateCreate,

                 })
                 .ToList();
            return result;
        }

        public List<RecipeView> GetListRecipe(int id)
        {
            List<RecipeView> result = context.MedicalHistorys
                 .Where(rec => rec.Id == id )
                 .Select(rec => new RecipeView
                 {
                     Id = rec.Id,
                     //PatientId = rec.PatientId,
                     Surname = rec.Patient.Surname,
                     //UserId = rec.UserId,
                     Login = rec.User.Login,
                     //IllnessId = rec.IllnessId,
                     IllnessName = rec.Illness.IllnessName,
                     //TherapyId = rec.TherapyId,
                     TherapyName = rec.Therapy.TherapyName,
                     //StatusId = rec.StatusId,
                     StatusName = rec.Status.StatusName,
                     DateCreate = rec.DateCreate,

                 })
                 .ToList();
            return result;
        }

        public MedicalHistoryView GetElement(int id)
        {
            MedicalHistory element = context.MedicalHistorys.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new MedicalHistoryView
                {
                    Id = element.Id,
                    PatientId = element.PatientId,
                    UserId = element.UserId,
                    IllnessId = element.IllnessId,
                    TherapyId = element.TherapyId,
                    StatusId = element.StatusId,
                    DateCreate = element.DateCreate

                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(MedicalHistoryView model)
        {
            MedicalHistory element = context.MedicalHistorys.FirstOrDefault(rec => rec.PatientId == model.PatientId && rec.IllnessId == model.IllnessId && rec.UserId == model.UserId && rec.TherapyId == model.TherapyId && rec.StatusId == model.StatusId);
            if (element != null)
            {
                throw new Exception("Уже есть такая запись ");
            }
            context.MedicalHistorys.Add(new MedicalHistory
            {
                PatientId = model.PatientId,
                UserId = model.UserId,
                IllnessId = model.IllnessId,
                TherapyId = model.TherapyId,
                StatusId = model.StatusId,
                DateCreate = DateTime.Now

            });
            context.SaveChanges();
        }

        public void UpdElement(MedicalHistoryView model)
        {
            MedicalHistory element = context.MedicalHistorys.FirstOrDefault(rec => rec.PatientId == model.PatientId && rec.IllnessId == model.IllnessId && rec.UserId == model.UserId && rec.TherapyId == model.TherapyId && rec.StatusId == model.StatusId);
            if (element != null)
            {
                throw new Exception("Уже есть такая запись ");
            }
            element = context.MedicalHistorys.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.PatientId = model.PatientId;
            element.UserId = model.UserId;
            element.IllnessId = model.IllnessId;
            element.TherapyId = model.TherapyId;
            element.StatusId = model.StatusId;
            element.DateCreate = DateTime.Now;

            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            MedicalHistory element = context.MedicalHistorys.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.MedicalHistorys.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Запись не найдена");
            }
        }

        
    }
}

