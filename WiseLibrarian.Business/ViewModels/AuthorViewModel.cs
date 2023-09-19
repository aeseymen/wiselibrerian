using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseLibrarian.Business.ViewModels;

namespace WiseLibrarian.Business
{
    public class AuthorViewModel:IViewModel
    {
        public int AuthorId { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorFullName { get; set; }
    }
}
