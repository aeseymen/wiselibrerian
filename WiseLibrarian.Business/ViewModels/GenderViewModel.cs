using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseLibrarian.Business.ViewModels
{
    public class GenderViewModel:IViewModel
    {
        public int GenderId { get; set; }
        public string GenderType { get; set; }
    }
}
