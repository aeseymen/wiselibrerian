using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseLibrarian.Business.ViewModels;
using WiseLibrarian.DataAccess.Entities;
using WiseLibrarian.DataAccess.Entities.Repository;

namespace WiseLibrarian.Business.Managers
{
    public class MemberManager
    {
        public List<MemberViewModel> GetMembers() 
        {
            using (var db = new DapperRepository())
            {
                var member = new Member();
                member.SetRepository(db);
                var sql = "Select * From Members";
                var dataMembers = member.Repository.GetAll<Member>(sql).Select(s=> new MemberViewModel() 
                {
                    
                    MemberId = s.MemberId,
                    MemberFirstName = s.MemberFirstName,
                    MemberLastName = s.MemberLastName,
                    MemberUserName = s.MemberUserName,
                    MemberEmail = s.MemberEmail,
                    MemberBirthDate = s.MemberBirthDate.ToString("dd/MM/yyyy"),
                    MemberPhoneNumber = s.MemberPhoneNumber,
                    MemberPassword = s.MemberPassword,
                    GenderId = s.GenderId,
                    SubscriptionId = s.SubscriptionId
                }).ToList();
                return dataMembers;
            }
        }

        public MemberViewModel GetMember(int id)
        {
            using (var db = new DapperRepository())
            {
                var member = new Member();
                member.SetRepository(db);
                var sql = "Select * From Members where MemberId = @id";
                var dataMember = member.Repository.GetById<Member>(sql, new {id}).Select(s=> new MemberViewModel() 
                {
                  
                    MemberId=s.MemberId,
                    MemberFirstName = s.MemberFirstName,
                    MemberLastName = s.MemberLastName,
                    MemberUserName = s.MemberUserName,
                    MemberEmail = s.MemberEmail,
                    MemberBirthDate = s.MemberBirthDate.ToString("dd/MM/yyyy"),
                    MemberPhoneNumber = s.MemberPhoneNumber,
                    MemberPassword = s.MemberPassword,
                    AdminId = s.AdminId,
                    GenderId = s.GenderId,
                    SubscriptionId = s.SubscriptionId

                }).FirstOrDefault();
                return dataMember;
            }
        }

        public int DeleteMember(Member member)
        {
            using (var db = new DapperRepository())
            {
                member.SetRepository(db);
                var sql = $"Delete from Members where MemberId ={member.MemberId}";
                 return member.Repository.Delete(sql);
            }
        }

        public int DeleteAllMembers()
        {
            using (var db = new DapperRepository())
            {
                var member = new Member();
                member.SetRepository(db);
                var sql = "DELETE FROM Members";
                var deletedDatas = member.Repository.DeleteAll<Member>(sql);
                return deletedDatas;
            }
        }


        public int InsertMember(Member member)
        {       
            using (var db = new DapperRepository())
            {
                member.SetRepository(db);
                var sql = $"Insert into Members (MemberFirstName, MemberLastName, MemberUserName, MemberEmail, MemberBirthDate, MemberPhoneNumber, MemberPassword, GenderId) values ('{member.MemberFirstName}','{member.MemberLastName}','{member.MemberUserName}','{member.MemberEmail}','{member.MemberBirthDate.ToString("yyyy-MM-dd")}','{member.MemberPhoneNumber}','{member.MemberPassword}',{member.GenderId})";
                return member.Repository.Insert(sql);
            }
        }

        public int UpdateMember(Member member)
        {
            using (var db = new DapperRepository())
            {
                member.SetRepository(db);
                var sql = $"Update Members set MemberFirstName='{member.MemberFirstName}', MemberLastName='{member.MemberLastName}', MemberUserName='{member.MemberUserName}', MemberEmail='{member.MemberEmail}', MemberPhoneNumber='{member.MemberPhoneNumber}', MemberBirthDate='{member.MemberBirthDate.ToString("yyyy-MM-dd")}', GenderId={member.GenderId}, MemberPassword='{member.MemberPassword}' Where MemberId={member.MemberId}";
                return member.Repository.Update(sql);
            }
        }

    }
}

