using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WiseLibrarian.Business.ViewModels;
using WiseLibrarian.DataAccess.Entities;
using WiseLibrarian.DataAccess.Entities.Repository;

namespace WiseLibrarian.Business.Managers
{
    public class SubscriptionManager
    {
        public List<SubscriptionViewModel> GetSubscriptions()
        {
            using (var db = new DapperRepository())
            {
                var subscription = new Subscription();
                subscription.SetRepository(db);
                var sql = "Select * From Subscriptions";
                var subscriptionsData = subscription.Repository.GetAll<Subscription>(sql).Select(s => new SubscriptionViewModel()
                {
                    SubscriptionId = s.SubscriptionId,
                    SubscriptionStartingDate = s.SubscriptionStartingDate.ToString("dd/MM/yyyy"),
                    SubscriptionEndingDate = s.SubscriptionEndingDate.ToString("dd/MM/yyyy"),
                    SubscriptionPrice = s.SubscriptionPrice
                }).ToList();
                return subscriptionsData;
            }
        }

        public SubscriptionViewModel GetSubscription(int id)
        {
            using (var db = new DapperRepository())
            {
                var subscription = new Subscription();
                subscription.SetRepository(db);
                var sql = "Select * From Subscriptions where SubscriptionId=@id";
                var subscriptionData = subscription.Repository.GetById<Subscription>(sql, new {id}).Select(s=> new SubscriptionViewModel() 
                { 
                     SubscriptionId = s.SubscriptionId,
                     SubscriptionStartingDate = s.SubscriptionStartingDate.ToString("dd/MM/yyyy"),
                     SubscriptionEndingDate = s.SubscriptionEndingDate.ToString("dd/MM/yyyy"),
                     SubscriptionPrice = s.SubscriptionPrice

                }).FirstOrDefault();
                return subscriptionData;
            }
        }

        public int DeleteSubscription(Subscription subscription)
        {
            using (var db = new DapperRepository())
            {
                subscription.SetRepository(db);
                var sql = $"Delete from Subscriptions where SubscriptionId ={subscription.SubscriptionId}";
                return subscription.Repository.Delete(sql);
            }
        }

        public int DeleteAllSubscriptions()
        {
            using (var db = new DapperRepository())
            {
                var subscription = new Subscription();
                subscription.SetRepository(db);
                var sql = "DELETE FROM Subscriptions";
                var deletedDatas = subscription.Repository.DeleteAll<Subscription>(sql);
                return deletedDatas;
            }
        }


        public int InsertSubscription(Subscription subscription)
        {
            using (var db = new DapperRepository())
            {
                subscription.SetRepository(db);
                var sql = $"Insert into Subscriptions (SubscriptionStartingDate, SubscriptionEndingDate, SubscriptionPrice) values ('{subscription.SubscriptionStartingDate}','{subscription.SubscriptionEndingDate}','{subscription.SubscriptionPrice}')";
                return subscription.Repository.Insert(sql);
            }
        }

        public int UpdateSubscription(Subscription subscription)
        {
            using (var db = new DapperRepository())
            {
                subscription.SetRepository(db);
                var sql = $"Update Subscriptions set SubscriptionStartingDate='{subscription.SubscriptionStartingDate}', SubscriptionEndingDate='{subscription.SubscriptionEndingDate}', SubscriptionPrice='{subscription.SubscriptionPrice}' Where SubscriptionId={subscription.SubscriptionId}";
                return subscription.Repository.Update(sql);
            }
        }

    }
}
