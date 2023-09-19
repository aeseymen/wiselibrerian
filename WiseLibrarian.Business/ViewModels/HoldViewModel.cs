using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseLibrarian.Business.ViewModels
{
    public class HoldViewModel:IViewModel
    {
        public int HoldId { get; set; }
        public string TakenTime { get; set; }
        public string BroughtTime { get; set; }
        public string HoldStatus { get; set; }
        public decimal PenaltyAmount { get; set; }
        public int BookId { get; set; }
        public int AdminId { get; set; }
        public int MemberId { get; set; }
    }
}
