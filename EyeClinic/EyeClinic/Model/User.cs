using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeClinic.Model
{
    public class User
    {
        public int Id { get; set; }

        public string Role { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        [ForeignKey("UserId")]
        public virtual List<MedicalHistory> MedicalHistorys { get; set; }
    }
}
