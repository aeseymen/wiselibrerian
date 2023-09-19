using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseLibrarian.Business.ViewModels
{
    public class CategoryViewModel:IViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
