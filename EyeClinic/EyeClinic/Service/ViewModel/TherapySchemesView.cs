using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeClinic.Service.ViewModel
{
    public class TherapySchemesView
    {
        public int Id { get; set; }

        public int TherapyId { get; set; }

        public int SchemeId { get; set; }

        public string SchemeName { get; set; }

        public decimal SchemePrice { get; set; }

    }
}
