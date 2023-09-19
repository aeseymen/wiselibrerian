using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseLibrarian.DataAccess.Entities.Interface;
using WiseLibrarian.DataAccess.Entities.Repository;

namespace WiseLibrarian.DataAccess.Entities
{
    public class ContactMessage:IDbModel
    {
        public int MessageId { get; set; }
        public string SenderName { get; set; }
        public string SenderLastName { get; set; }
        public string SenderEmail { get; set; }
        public string SenderPhoneNumber { get; set; }
        public string SenderMessage { get; set; }

        #region Implement IDbModel
        public AbstractDapperRepository Repository { get; set; }

        public void SetRepository(AbstractDapperRepository dapperRepository)
        {
            Repository = dapperRepository;
        } 
        #endregion
    }
}
