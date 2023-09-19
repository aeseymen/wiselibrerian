using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseLibrarian.Business.ViewModels
{
    public class MemberViewModel:IViewModel
    {
        public int MemberId { get; set; }
        public string MemberFirstName { get; set; }
        public string MemberLastName { get; set; }
        public string MemberUserName { get; set; }
        public string MemberEmail { get; set; }
        public string MemberBirthDate { get; set; }
        public string MemberPhoneNumber { get; set; }
        public string MemberPassword { get; set; }
        public int GenderId { get; set; }
        public int SubscriptionId { get; set; }
        public int AdminId { get; set; }
    }
}
