using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseLibrarian.DataAccess.Entities.Interface;
using WiseLibrarian.DataAccess.Entities.Repository;

namespace WiseLibrarian.DataAccess.Entities
{
    public class Member:IDbModel
    {
        public int MemberId { get; set; }
        public string MemberFirstName { get; set; }
        public string MemberLastName { get; set; }
        public string MemberUserName { get; set; }
        public string MemberEmail { get; set; }
        public DateTime MemberBirthDate { get; set; }
        public string MemberPhoneNumber { get; set; }
        public string MemberPassword { get; set; }
        public int GenderId { get; set; }
        public int SubscriptionId { get; set; }
        public int AdminId { get; set; }



        #region Implement IDbModel 
        public AbstractDapperRepository Repository { get; set; }

        public void SetRepository(AbstractDapperRepository dapperRepository)
        {
            Repository = dapperRepository;
        } 
        #endregion
    }
}
