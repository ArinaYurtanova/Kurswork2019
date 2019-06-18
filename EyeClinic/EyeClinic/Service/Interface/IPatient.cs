using EyeClinic.Model;
using EyeClinic.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EyeClinic.Service.Interface
{
    public interface IPatient
    {
         
        List<PatientView> GetList();

        List<PatientView> GetGroup(string GroupName);
        List<PatientView> GetStatus(string StatusName, string TherapyName);
        List<PatientView> GetStatus(string StatusName);
        List<PatientView> GetList(int id);
        
        PatientView GetElement(int id);

        void AddElement(PatientView model);

        void UpdElement(PatientView model);

        void DelElement(int id);
    }
}
