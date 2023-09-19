using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseLibrarian.Business.ViewModels
{
    public class SubscriptionViewModel:IViewModel
    {
        public int SubscriptionId { get; set; }
        public decimal SubscriptionPrice { get; set; }
        public string SubscriptionStartingDate { get; set; }
        public string SubscriptionEndingDate { get; set; }
    }
}
