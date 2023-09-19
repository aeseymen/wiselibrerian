using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseLibrarian.DataAccess.Entities.Interface;
using WiseLibrarian.DataAccess.Entities.Repository;

namespace WiseLibrarian.DataAccess.Entities
{
    public class Hold:IDbModel
    {
        public int HoldId { get; set; }
        public DateTime TakenTime { get; set; }
        public DateTime BroughtTime { get; set; }
        public string HoldStatus { get; set; }
        public decimal PenaltyAmount { get; set; }
        public int BookId { get; set; }
        public int AdminId { get; set; }
        public int MemberId { get; set; }
        
        
        
        #region Implement IDbModel 
        public AbstractDapperRepository Repository { get; set; }

        public void SetRepository(AbstractDapperRepository dapperRepository)
        {
            Repository = dapperRepository;
        } 
        #endregion
    }
}
