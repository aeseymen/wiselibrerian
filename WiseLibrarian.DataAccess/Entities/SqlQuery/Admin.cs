using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseLibrarian.DataAccess.Entities.Interface;
using WiseLibrarian.DataAccess.Entities.Repository;

namespace WiseLibrarian.DataAccess.Entities
{
    public class Admin:IDbModel
    {
        public int AdminId { get; set; }
        public int AdminServiceNumber { get; set; }
        public string AdminFirstName { get; set; }
        public string AdminLastName { get; set; }
        public DateTime AdminBirthDate { get; set; }
        public string AdminPassword { get; set; }
        public string AdminMail { get; set; }
        public string AdminPhoneNumber { get; set; }
        public int GenderId { get; set; }

        #region Implement IDbModel

        public AbstractDapperRepository Repository {get; set;}        

        public void SetRepository(AbstractDapperRepository dapperRepository)
        {
            Repository = dapperRepository;
        } 
        #endregion
    }
}
