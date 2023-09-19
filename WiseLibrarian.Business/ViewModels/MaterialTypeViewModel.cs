using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseLibrarian.Business.ViewModels
{
    public class MaterialTypeViewModel:IViewModel
    {
        public int MaterialTypeId { get; set; }
        public string MaterialTypeName { get; set; }

    }
}
