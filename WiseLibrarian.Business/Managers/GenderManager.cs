using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseLibrarian.Business.ViewModels;
using WiseLibrarian.DataAccess.Entities;
using WiseLibrarian.DataAccess.Entities.Repository;

namespace WiseLibrarian.Business.Managers
{
    public class GenderManager
    {
        public List<GenderViewModel> GetGenders()
        {
            using (var db = new DapperRepository())
            {
                var gender = new Gender();
                gender.SetRepository(db);
                var sql = "Select * From Genders";
                var gendersData = gender.Repository.GetAll<Gender>(sql).Select(s=> new GenderViewModel() 
                {
                  GenderId = s.GenderId,
                  GenderType = s.GenderType,
                }).ToList();
                return gendersData;
            }
        }

        public GenderViewModel GetGender(int id)
        {
            using (var db = new DapperRepository())
            {
                var gender = new Gender();
                gender.SetRepository(db);
                var sql = "Select * From Genders where GenderId = @id";
                var genderData = gender.Repository.GetById<Gender>(sql, new {id}).Select(s=> new GenderViewModel()
                {

                    GenderId = s.GenderId,
                    GenderType = s.GenderType,

                }).FirstOrDefault();
                return genderData;
            }
        }

    }
}
