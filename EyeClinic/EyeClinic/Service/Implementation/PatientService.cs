using EyeClinic.Model;
using EyeClinic.Service.Interface;
using EyeClinic.Service.ViewModel;
using System;
using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EyeClinic.Service.Implementation
{
    public class PatientService:  IPatient  
    {
        
        private EyeClinicDBContext context;

        public PatientService(EyeClinicDBContext context)
        {
            this.context = context;
        }

        public List<PatientView> GetList()
        {
            List<PatientView> result = context.Patients
                .Select(rec => new PatientView
                {
                    Id = rec.Id,
                    Surname = rec.Surname,
                    Name = rec.Name,
                    Otchestvo = rec.Otchestvo,
                    Insurance = rec.Insurance,
                    Illness = rec.Illness,
                    Group = rec.Group,
                    Therapy = rec.Therapy,
                    Status = rec.Status,
                    Day = rec.Day,
                    Month = rec.Month,
                    Year = rec.Year
                })
                .ToList();
            return result;
        }

        public List<PatientView> GetList(int id)
        {
            List<PatientView> result = context.Patients
                 .Where(rec => rec.Id == id)
                 .Select(rec => new PatientView
                 {
                     Id = rec.Id,
                     Surname = rec.Surname,
                     Name = rec.Name,
                     Otchestvo = rec.Otchestvo,
                     Insurance = rec.Insurance,
                     Illness = rec.Illness,
                     Group = rec.Group,
                     Therapy = rec.Therapy,
                     Status = rec.Status,
                     Day = rec.Day,
                     Month = rec.Month,
                     Year = rec.Year
                 })
                 .ToList();
            return result;
        }

        public List<PatientView> GetGroup(string GroupName)
        {
            List<PatientView> result = context.Patients
                 .Where(rec => rec.Group == GroupName)
                 .Select(rec => new PatientView
                 {
                     Id = rec.Id,
                     Surname = rec.Surname,
                     Name = rec.Name,
                     Otchestvo = rec.Otchestvo,
                     Insurance = rec.Insurance,
                     Illness = rec.Illness,
                     Group = rec.Group,
                     Therapy = rec.Therapy,
                     Status = rec.Status,
                     Day = rec.Day,
                     Month = rec.Month,
                     Year = rec.Year
                 })
                 .ToList();
            return result;
        }

        public List<PatientView> GetStatus(string StatusName, string TherapyName)
        {
            List<PatientView> result = context.Patients
                 .Where(rec => rec.Status == StatusName && rec.Therapy==TherapyName)
                 .Select(rec => new PatientView
                 {
                     Id = rec.Id,
                     Surname = rec.Surname,
                     Name = rec.Name,
                     Otchestvo = rec.Otchestvo,
                     Insurance = rec.Insurance,
                     Illness = rec.Illness,
                     Group = rec.Group,
                     Therapy = rec.Therapy,
                     Status = rec.Status,
                     Day = rec.Day,
                     Month = rec.Month,
                     Year = rec.Year
                 })
                 .ToList();
            return result;
        }

        public List<PatientView> GetStatus(string StatusName)
        {
            List<PatientView> result = context.Patients
                 .Where(rec => rec.Status == StatusName )
                 .Select(rec => new PatientView
                 {
                     Id = rec.Id,
                     Surname = rec.Surname,
                     Name = rec.Name,
                     Otchestvo = rec.Otchestvo,
                     Insurance = rec.Insurance,
                     Illness = rec.Illness,
                     Group = rec.Group,
                     Therapy = rec.Therapy,
                     Status = rec.Status,
                     Day = rec.Day,
                     Month = rec.Month,
                     Year = rec.Year
                 })
                 .ToList();
            return result;
        }

        public PatientView GetElement(int id)
        {
            Patient element = context.Patients.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new PatientView
                {
                    Id = element.Id,
                    Surname = element.Surname,
                    Name = element.Name,
                    Otchestvo = element.Otchestvo,
                    Insurance = element.Insurance,
                    Illness = element.Illness,
                    Group = element.Group,
                    Therapy = element.Therapy,
                    Status = element.Status,
                    Day = element.Day,
                    Month = element.Month,
                    Year = element.Year
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(PatientView model)
        {
            Patient element = context.Patients.FirstOrDefault(rec => rec.Insurance == model.Insurance);
            if (element != null)
            {
                throw new Exception("Уже есть такой пациент ");
            }
            context.Patients.Add(new Patient
            {
                Surname = model.Surname,
                Name = model.Name,
                Otchestvo = model.Otchestvo,
                Insurance = model.Insurance,
                Illness = model.Illness,
                Group = model.Group,
                Therapy = model.Therapy,
                Status = model.Status,
                Day = model.Day,
                Month = model.Month,
                Year = model.Year
            });
            context.SaveChanges();
        }

        public void UpdElement(PatientView model)
        {
            Patient element = context.Patients.FirstOrDefault(rec =>
                                        rec.Insurance == model.Insurance && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть такой пациент ");
            }
            element = context.Patients.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.Surname = model.Surname;
            element.Name = model.Name;
            element.Otchestvo = model.Otchestvo;
            element.Insurance = model.Insurance;
            element.Illness = model.Illness;
            element.Group = model.Group;
            element.Therapy = model.Therapy;
            element.Status = model.Status;
            element.Day = model.Day;
            element.Month = model.Month;
            element.Year = model.Year;
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Patient element = context.Patients.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Patients.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Пациент не найден");
            }
        }

        
    }
}
