using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeClinic.Model
{
    public class TherapyScheme
    {
        public int Id { get; set; }

        public int TherapyId { get; set; }

        public int SchemeId { get; set; }

        public decimal SchemePrice { get; set; }

        public virtual Therapy Therapy { get; set; }

        public virtual Scheme Scheme { get; set; }
    }
}
