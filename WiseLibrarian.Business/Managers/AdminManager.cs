using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseLibrarian.Business.ViewModels;
using WiseLibrarian.DataAccess.Entities;
using WiseLibrarian.DataAccess.Entities.Repository;

namespace WiseLibrarian.Business
{
    public class AdminManager
    {
        public List<AdminViewModel> GetAdmins() 
        {
            using (var db = new DapperRepository())
            {
                var admin = new Admin();
                admin.SetRepository(db);
                var sql = "Select * From Admins";
                var adminsData = admin.Repository.GetAll<Admin>(sql).Select(s => new AdminViewModel()
                {
                    AdminId = s.AdminId,
                    AdminServiceNumber = s.AdminServiceNumber,
                    AdminFirstName = s.AdminFirstName,
                    AdminLastName = s.AdminLastName,
                    AdminBirthDate = s.AdminBirthDate.ToString("dd/MM/yyyy"),
                    AdminPassword = s.AdminPassword,
                    AdminMail = s.AdminMail,
                    AdminPhoneNumber = s.AdminPhoneNumber,
                    GenderId = s.GenderId

                }).ToList();
                return adminsData;
                           
            }
        }

        public AdminViewModel GetAdmin(int id)
        {

            using (var db = new DapperRepository())
            {
                var admin = new Admin();
                admin.SetRepository(db);
                var sql = "Select * From Admins where AdminId = @id";
                var adminData = admin.Repository
                    .GetById<Admin>(sql, new { id })
                    .Select(s => new AdminViewModel()
                    {
                        AdminId = s.AdminId,
                        AdminServiceNumber = s.AdminServiceNumber,
                        AdminFirstName = s.AdminFirstName,
                        AdminLastName = s.AdminLastName,
                        AdminBirthDate = s.AdminBirthDate.ToString("dd/MM/yyyy"),
                        AdminPassword = s.AdminPassword,
                        AdminMail = s.AdminMail,
                        AdminPhoneNumber = s.AdminPhoneNumber,
                        GenderId = s.GenderId
                    }).FirstOrDefault();
                return adminData;

            }
        }                                           

        public int DeleteAdmin(Admin admin)
        {
            using (var db = new DapperRepository())
            {
                admin.SetRepository(db);
                var sql = $"Delete from Admins where AdminId = '{admin.AdminId}'";
                return admin.Repository.Delete(sql);
            }
        }

        public int DeleteAllAdmins()
        {
            using (var db = new DapperRepository())
            {
                var admin = new Admin();
                admin.SetRepository(db);
                var sql = "DELETE FROM Admins";
                var deletedDatas = admin.Repository.DeleteAll<Admin>(sql);
                return deletedDatas;
            }
        }


        public int InsertAdmin(Admin admin)
        {
            using (var db = new DapperRepository())
            {
                admin.SetRepository(db);
                var sql = $"Insert into Admins (AdminFirstName, AdminLastName, AdminBirthDate, AdminPassword, AdminMail, AdminPhoneNumber, GenderId) values ('{admin.AdminFirstName}','{admin.AdminLastName}', '{admin.AdminBirthDate}','{admin.AdminBirthDate.ToString("yyyy-MM-dd")}','{admin.AdminPassword}','{admin.AdminMail}','{admin.AdminPhoneNumber}', {admin.GenderId})";
                return admin.Repository.Insert(sql);
            }
        }

        public int UpdateAdmin(Admin admin)
        {
            using (var db = new DapperRepository())
            {
                admin.SetRepository(db);
                var sql = $"Update Admins set AdminFirstName= '{admin.AdminFirstName}', AdminLastName='{admin.AdminLastName}', AdminBirthDate='{admin.AdminBirthDate.ToString("yyyy-MM-dd")}', AdminPassword='{admin.AdminPassword}', AdminPhoneNumber='{admin.AdminPhoneNumber}' Where AdminId={admin.AdminId}";
                return admin.Repository.Update(sql);
            }
        }

    }
}
