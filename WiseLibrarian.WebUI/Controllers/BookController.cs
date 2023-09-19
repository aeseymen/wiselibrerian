using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WiseLibrarian.Business;
using WiseLibrarian.Business.Managers;
using WiseLibrarian.DataAccess.Entities;

namespace WiseLibrarian.WebUI.Controllers
{
    [RoutePrefix("api/Book")]
    public class BookController : ApiController
    {
        private readonly BookManager _bookManager;
        public BookController()
        {
            _bookManager = new BookManager();
        }
        [Route("GetBook/{id}")]
        [HttpGet]
        public HttpResponseMessage GetBook(int id)
        {
            var book = _bookManager.GetBook(id);
            if (book == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Id'si {id} olan çalışan bulunamadı.");
            }


            return Request.CreateResponse(HttpStatusCode.OK, book);
        }
        [Route("GetBooks")]
        [HttpGet]
        public HttpResponseMessage GetBooks()
        {
            var books = _bookManager.GetBooks();
            if (books == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Kitaplar yüklenemedi.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, books);
        }

        [Route("InsertBook")]
        [HttpPost]
        public HttpResponseMessage InsertBook(Book book)
        {
            int result = _bookManager.InsertBook(book);
            if (result == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Ekleme işlemi başarısız.");
            }

            return Request.CreateResponse(HttpStatusCode.Created, $"Ekleme işlemi başarılı.");

        }

        [Route("UpdateBook")]
        [HttpPost]
        public HttpResponseMessage UpdateBook(Book book)
        {
            int result = _bookManager.UpdateBook(book);
            if (result == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Güncelleme başarısız, lütfen verileri kontrol ediniz!");
            }

            return Request.CreateResponse(HttpStatusCode.OK, $"Güncelleme başarılı.");
        }

        [Route("DeleteBook")]
        [HttpPost]
        public HttpResponseMessage DeleteBook(Book book)
        {
            int result = _bookManager.DeleteBook(book);
            if (result == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Silme işlemi yapılamadı!");
            }

            return Request.CreateResponse(HttpStatusCode.OK, $"Silme başarılı.");
        }

        [Route("DeleteAllBooks")]
        [HttpPost]
        public HttpResponseMessage DeleteAllBooks()
        {
            var deletedDatas = _bookManager.DeleteAllBooks();
            if (deletedDatas == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Toplu Silme işlemi başarısız");
            }

            return Request.CreateResponse(HttpStatusCode.OK, $"Toplam {deletedDatas} tane veri silindi.");
        }


    }
}
