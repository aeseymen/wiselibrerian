using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseLibrarian.Business.ViewModels
{
    public class AdminViewModel:IViewModel
    {
        public int AdminId { get; set; }
        public int AdminServiceNumber { get; set; }
        public string AdminFirstName { get; set; }
        public string AdminLastName { get; set; }
        public string AdminBirthDate { get; set; }
        public string AdminPassword { get; set; }
        public string AdminMail { get; set; }
        public string AdminPhoneNumber { get; set; }
        public int GenderId { get; set; }
    }
}
