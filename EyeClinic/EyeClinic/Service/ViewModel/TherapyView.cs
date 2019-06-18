using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeClinic.Service.ViewModel
{
    public class TherapyView
    {
        public int Id { get; set; }

        public string TherapyName { get; set; }

        public decimal Price { get; set; }

        public List<TherapySchemesView> TherapySchemes { get; set; }
    }
}
