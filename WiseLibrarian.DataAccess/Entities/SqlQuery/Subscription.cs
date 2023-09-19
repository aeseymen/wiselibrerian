using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseLibrarian.DataAccess.Entities.Interface;
using WiseLibrarian.DataAccess.Entities.Repository;

namespace WiseLibrarian.DataAccess.Entities
{
    public class Subscription:IDbModel
    {
        public int SubscriptionId { get; set; }
        public decimal SubscriptionPrice { get; set; }
        public DateTime SubscriptionStartingDate { get; set; }
        public DateTime SubscriptionEndingDate { get; set;}

        #region Implement IDbModel
        public AbstractDapperRepository Repository { get; set; }

        public void SetRepository(AbstractDapperRepository dapperRepository)
        {
            Repository = dapperRepository;
        } 
        #endregion
    }
}
