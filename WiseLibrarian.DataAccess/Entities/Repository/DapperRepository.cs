using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseLibrarian.DataAccess.Entities.Repository
{
    // Abstract dapperrepositorye ihtiyaç oldu
    public class DapperRepository:AbstractDapperRepository
    {
        public DapperRepository():base()
        {
                
        }
        public DapperRepository(string connectionName): base(connectionName)    
        {
                
        }

        public DapperRepository(IDbConnection dbConnection):base(dbConnection) 
        {
               
        }
    }
}
