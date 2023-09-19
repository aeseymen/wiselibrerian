using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseLibrarian.DataAccess.Entities.Repository;

namespace WiseLibrarian.DataAccess.Entities.Interface
{
    public interface IDbModel
    {
        AbstractDapperRepository Repository { get; set; }
        void SetRepository(AbstractDapperRepository dapperRepository);
    }
}
