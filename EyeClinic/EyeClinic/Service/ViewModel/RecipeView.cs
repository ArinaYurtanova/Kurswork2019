using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeClinic.Service.ViewModel
{
    public class RecipeView
    {
        public int Id { get; set; }
        

        public string Surname { get; set; }
        

        public string Login { get; set; }

        public string IllnessName { get; set; }
        

        public string TherapyName { get; set; }

        public string StatusName { get; set; }

        public DateTime DateCreate { get; set; }
    }
}
