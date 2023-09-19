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
    public class HoldManager
    {
        public List<HoldViewModel> GetHolds()
        {
            using (var db = new DapperRepository())
            {
                var hold = new Hold();
                hold.SetRepository(db);
                var sql = "Select * From Holds";
                var holdsData = hold.Repository.GetAll<Hold>(sql).Select(s=> new HoldViewModel()
                {
                    
                    HoldId = s.HoldId,
                    BookId = s.BookId,
                    TakenTime = s.TakenTime.ToString("dd/MM/yyyy"),
                    BroughtTime = s.BroughtTime.ToString("dd/MM/yyyy"),
                    HoldStatus = s.HoldStatus,
                    PenaltyAmount = s.PenaltyAmount,
                    AdminId = s.AdminId,
                    MemberId = s.MemberId

                }).ToList();
                return holdsData;
            }
        }

        public HoldViewModel GetHold(int id)
        {
            using (var db = new DapperRepository())
            {
                var hold = new Hold();
                hold.SetRepository(db);
                var sql = "Select * From Holds where HoldId = @id";
                var holdData = hold.Repository.GetById<Hold>(sql, new {id}).Select(s=> new HoldViewModel() 
                {
                
                    HoldId=s.HoldId,
                    BookId=s.BookId,
                    TakenTime = s.TakenTime.ToString("dd/MM/yyyy"),
                    BroughtTime=s.BroughtTime.ToString("dd/MM/yyyy"),
                    HoldStatus = s.HoldStatus,
                    PenaltyAmount=s.PenaltyAmount,
                    AdminId = s.AdminId,
                    MemberId = s.MemberId

                }).FirstOrDefault();
                return holdData;
            }
        }

        public int DeleteHold(Hold hold)
        {
            using (var db = new DapperRepository())
            {
                hold.SetRepository(db);
                var sql = $"Delete from Holds where HoldId ={hold.HoldId}";
                return hold.Repository.Delete(sql);
            }
        }

        public int DeleteAllHolds()
        {
            using (var db = new DapperRepository())
            {
                var hold = new Hold();
                hold.SetRepository(db);
                var sql = "DELETE FROM Holds";
                var deletedDatas = hold.Repository.DeleteAll<Hold>(sql);
                return deletedDatas;
            }
        }

        public int InsertHold(Hold hold)
        {
            using (var db = new DapperRepository())
            {
                hold.SetRepository(db);
                var sql = $"Insert into Holds (BookId, TakenTime, BroughtTime, HoldStatus, PenaltyAmount, AdminId, MemberId) values ({hold.BookId}, '{hold.TakenTime}','{hold.BroughtTime}', '{hold.HoldStatus}', {hold.PenaltyAmount},{hold.AdminId},{hold.MemberId})";
                return hold.Repository.Insert(sql);
            }
        }

        public int UpdateHold(Hold hold)
        {
            using (var db = new DapperRepository())
            {
                hold.SetRepository(db);
                var sql = $"Update Holds set BookId={hold.BookId}, TakenTime='{hold.TakenTime}', BroughtTime='{hold.BroughtTime}', HoldStatus='{hold.HoldStatus}', PenaltyAmount={hold.PenaltyAmount} Where HoldId={hold.HoldId}";
                return hold.Repository.Update(sql);
            }
        }

    }
}
