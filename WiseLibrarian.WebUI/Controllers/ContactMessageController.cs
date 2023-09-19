using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WiseLibrarian.Business.Managers;
using WiseLibrarian.DataAccess.Entities;

namespace WiseLibrarian.WebUI.Controllers
{
    [RoutePrefix("api/ContactMessage")]

    public class ContactMessageController : ApiController
    {
        private readonly ContactMessageManager _contactMessageManager;
        public ContactMessageController()
        {
            _contactMessageManager = new ContactMessageManager();
        }
        [Route("GetContactMessage/{id}")]
        [HttpGet]
        public HttpResponseMessage GetContactMessage(int id)
        {
            var contactMessage = _contactMessageManager.GetContactMessage(id);
            if (contactMessage == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Id'si {id} olan mesaj bulunamadı.");
            }


            return Request.CreateResponse(HttpStatusCode.OK, contactMessage);
        }
        [Route("GetContactMessages")]
        [HttpGet]
        public HttpResponseMessage GetContactMessages()
        {
            var contactMessages = _contactMessageManager.GetContactMessages();
            if (contactMessages == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Mesajlar yüklenemedi.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, contactMessages);
        }

        [Route("InsertContactMessage")]
        [HttpPost]
        public HttpResponseMessage InsertContactMessage(ContactMessage contactMessage)
        {
            int result = _contactMessageManager.InsertContactMessage(contactMessage);
            if (result == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Ekleme işlemi başarısız.");
            }

            return Request.CreateResponse(HttpStatusCode.Created, $"Ekleme işlemi başarılı.");

        }

        [Route("UpdateContactMessage")]
        [HttpPost]
        public HttpResponseMessage UpdateContactMessage(ContactMessage contactMessage)
        {
            int result = _contactMessageManager.UpdateContactMessage(contactMessage);
            if (result == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Güncelleme başarısız, lütfen verileri kontrol ediniz!");
            }

            return Request.CreateResponse(HttpStatusCode.OK, $"Güncelleme başarılı.");
        }

        [Route("DeleteContactMessage")]
        [HttpPost]
        public HttpResponseMessage DeleteContactMessage(ContactMessage contactMessage)
        {
            int result = _contactMessageManager.DeleteContactMessage(contactMessage);
            if (result == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Silme işlemi yapılamadı!");
            }

            return Request.CreateResponse(HttpStatusCode.OK, $"Silme başarılı.");
        }

        [Route("DeleteAllContactMessages")]
        [HttpPost]
        public HttpResponseMessage DeleteAllContactMessages()
        {
            var deletedDatas = _contactMessageManager.DeleteAllContactMessages();
            if (deletedDatas == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Toplu Silme işlemi başarısız");
            }

            return Request.CreateResponse(HttpStatusCode.OK, $"Toplam {deletedDatas} tane veri silindi.");
        }

    }
}
