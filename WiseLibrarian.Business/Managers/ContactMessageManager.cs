using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseLibrarian.Business.ViewModels;
using WiseLibrarian.DataAccess.Entities.Repository;
using WiseLibrarian.DataAccess.Entities;

namespace WiseLibrarian.Business.Managers
{
    public class ContactMessageManager
    {
        public List<ContactMessageViewModel> GetContactMessages()
        {
            using (var db = new DapperRepository())
            {
                var contactMessage = new ContactMessage();
                contactMessage.SetRepository(db);
                var sql = "Select * From ContactMessages";
                var contactMessagesData = contactMessage.Repository.GetAll<ContactMessage>(sql).Select(s => new ContactMessageViewModel()
                {
                    MessageId = s.MessageId,
                    SenderName = s.SenderName,
                    SenderLastName = s.SenderLastName,
                    SenderEmail = s.SenderEmail,
                    SenderPhoneNumber = s.SenderPhoneNumber,
                    SenderMessage = s.SenderMessage
                }).ToList();
                return contactMessagesData;
            }
        }

        public ContactMessageViewModel GetContactMessage(int id)
        {
            using (var db = new DapperRepository())
            {
                var contactMessage = new ContactMessage();
                contactMessage.SetRepository(db);
                var sql = "Select * From ContactMessages where MessageId=@id";
                var contactMessageData = contactMessage.Repository.GetById<ContactMessage>(sql, new { id }).Select(s => new ContactMessageViewModel()
                {
                    MessageId = s.MessageId,
                    SenderName = s.SenderName,
                    SenderLastName = s.SenderLastName,
                    SenderEmail = s.SenderEmail,
                    SenderPhoneNumber = s.SenderPhoneNumber,
                    SenderMessage = s.SenderMessage
                }).FirstOrDefault();
                return contactMessageData;
            }
        }

        public int DeleteContactMessage(ContactMessage contactMessage)
        {
            using (var db = new DapperRepository())
            {
                contactMessage.SetRepository(db);
                var sql = $"Delete from ContactMessages where MessageId ={contactMessage.MessageId}";
                return contactMessage.Repository.Delete(sql);
            }
        }

        public int DeleteAllContactMessages()
        {
            using (var db = new DapperRepository())
            {
                var contactMessage = new ContactMessage();
                contactMessage.SetRepository(db);
                var sql = "DELETE FROM ContactMessages";
                var deletedDatas = contactMessage.Repository.DeleteAll<ContactMessage>(sql);
                return deletedDatas;
            }
        }

        public int InsertContactMessage(ContactMessage contactMessage)
        {
            using (var db = new DapperRepository())
            {
                contactMessage.SetRepository(db);
                var sql = $"Insert into ContactMessages (SenderName, SenderLastName, SenderEmail, SenderPhoneNumber, SenderMessage) values ('{contactMessage.SenderName}','{contactMessage.SenderLastName}','{contactMessage.SenderEmail}', '{contactMessage.SenderPhoneNumber}', '{contactMessage.SenderMessage}')";
                return contactMessage.Repository.Insert(sql);
            }
        }

        public int UpdateContactMessage(ContactMessage contactMessage)
        {
            using (var db = new DapperRepository())
            {
                contactMessage.SetRepository(db);
                var sql = $"Update Subscriptions set SenderName='{contactMessage.SenderName}', SenderLastName='{contactMessage.SenderLastName}', SenderEmail='{contactMessage.SenderEmail}', SenderPhoneNumber='{contactMessage.SenderPhoneNumber}', SenderMessage='{contactMessage.SenderMessage}' Where MessageId={contactMessage.MessageId}";
                return contactMessage.Repository.Update(sql);
            }
        }

    }
}
