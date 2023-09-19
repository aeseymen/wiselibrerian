using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WiseLibrarian.Business;
using WiseLibrarian.DataAccess.Entities;

namespace WiseLibrarian.WebUI.Controllers
{
    [RoutePrefix("api/Author")]

    public class AuthorController : ApiController
    {
        private readonly AuthorManager _authorManager;
        public AuthorController()
        {
            _authorManager = new AuthorManager();
        }
        [Route("GetAuthor/{id}")]
        [HttpGet]
        public HttpResponseMessage GetAuthor(int id)
        {
            var author = _authorManager.GetAuthor(id);
            if (author == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Id'si {id} olan author bulunamadı.");
            }


            return Request.CreateResponse(HttpStatusCode.OK, author);
        }
        [Route("GetAuthors")]
        [HttpGet]
        public HttpResponseMessage GetAuthors()
        {
            var authors = _authorManager.GetAuthors();
            if (authors == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Yazarlar yüklenemedi.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, authors);
        }

        [Route("InsertAuthor")]
        [HttpPost]
        public HttpResponseMessage InsertAuthor(Author author)
        {
            int result = _authorManager.InsertAuthor(author);
            if (result == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Ekleme işlemi başarısız.");
            }

            return Request.CreateResponse(HttpStatusCode.Created, $"Ekleme işlemi başarılı.");

        }

        [Route("UpdateAuthor")]
        [HttpPost]
        public HttpResponseMessage UpdateAuthor(Author author)
        {
            int result = _authorManager.UpdateAuthor(author);
            if (result == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Güncelleme başarısız, lütfen verileri kontrol ediniz!");
            }

            return Request.CreateResponse(HttpStatusCode.OK, $"Güncelleme başarılı.");
        }

        [Route("DeleteAuthor")]
        [HttpPost]
        public HttpResponseMessage DeleteAdmin(Author author)
        {
            int result = _authorManager.DeleteAuthor(author);
            if (result == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Silme işlemi yapılamadı!");
            }

            return Request.CreateResponse(HttpStatusCode.OK, $"Silme başarılı.");
        }

        [Route("DeleteAllAuthors")]
        [HttpPost]
        public HttpResponseMessage DeleteAllAuthors()
        {
            var deletedDatas = _authorManager.DeleteAllAuthors();
            if (deletedDatas == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Toplu Silme işlemi başarısız");
            }

            return Request.CreateResponse(HttpStatusCode.OK, $"Toplam {deletedDatas} tane veri silindi.");
        }

    }
}
