using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseLibrarian.DataAccess.Entities.Interface;
using WiseLibrarian.DataAccess.Entities.Repository;

namespace WiseLibrarian.DataAccess.Entities
{
    public class MaterialType:IDbModel
    {
        public int MaterialTypeId { get; set; }
        public string MaterialTypeName { get; set; }


        #region Implement IDbModel
        public AbstractDapperRepository Repository { get; set; }

        public void SetRepository(AbstractDapperRepository dapperRepository)
        {
            Repository = dapperRepository;
        } 
        #endregion
    }
}
