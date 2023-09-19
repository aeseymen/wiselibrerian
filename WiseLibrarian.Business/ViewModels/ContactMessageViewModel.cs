using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseLibrarian.Business.ViewModels
{
    public class ContactMessageViewModel
    {
        public int MessageId { get; set; }
        public string SenderName { get; set; }
        public string SenderLastName { get; set; }
        public string SenderEmail { get; set; }
        public string SenderPhoneNumber { get; set; }
        public string SenderMessage { get; set; }
    }
}
