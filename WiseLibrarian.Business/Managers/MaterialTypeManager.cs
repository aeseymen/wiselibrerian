using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using WiseLibrarian.Business.ViewModels;
using WiseLibrarian.DataAccess.Entities;
using WiseLibrarian.DataAccess.Entities.Repository;

namespace WiseLibrarian.Business.Managers
{
    public class MaterialTypeManager
    {
        public List<MaterialTypeViewModel> GetMaterialTypes()
        {
            using (var db = new DapperRepository())
            {

                var materialType = new MaterialType();
                materialType.SetRepository(db);
                var sql = "Select * From MaterialTypes";
                var materialTypesData = materialType.Repository.GetAll<MaterialType>(sql).Select(s=> new MaterialTypeViewModel()
                {

                    MaterialTypeId = s.MaterialTypeId,
                    MaterialTypeName = s.MaterialTypeName

                }).ToList();
                return materialTypesData;
            
            }
            
        }

        public MaterialTypeViewModel GetMaterialType(int id)
        {
            using (var db = new DapperRepository())
            {
                var materialType = new MaterialType();
                materialType.SetRepository(db);
                var sql = "Select * From MaterialTypes where MaterialTypeId = @id";
                var materialTypeData = materialType.Repository.GetById<MaterialType>(sql, new {id}).Select(s=> new MaterialTypeViewModel()
                {

                    MaterialTypeId=s.MaterialTypeId,
                    MaterialTypeName = s.MaterialTypeName

                }).FirstOrDefault();
                return materialTypeData;
            }
        }

    }
}
