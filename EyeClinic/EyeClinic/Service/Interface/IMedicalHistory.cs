using EyeClinic.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeClinic.Service.Interface
{
    public interface IMedicalHistory
    {
        List<MedicalHistoryView> GetList();

        MedicalHistoryView GetElement(int id);

        void AddElement(MedicalHistoryView model);

        void UpdElement(MedicalHistoryView model);

        void DelElement(int id);

        List<MedicalHistoryView> GetList(int id);

        List<RecipeView> GetListRecipe(int id);
    }
}
