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
    [RoutePrefix("api/Category")]

    public class CategoryController : ApiController
    {
        private readonly CategoryManager _categoryManager;
        public CategoryController()
        {
            _categoryManager = new CategoryManager();
        }
        [Route("GetCategory/{id}")]
        [HttpGet]
        public HttpResponseMessage GetCategory(int id)
        {
            var category = _categoryManager.GetCategory(id);
            if (category == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Id'si {id} olan kategori bulunamadı.");
            }


            return Request.CreateResponse(HttpStatusCode.OK, category);
        }
        [Route("GetCategories")]
        [HttpGet]
        public HttpResponseMessage GetCategories()
        {
            var categories = _categoryManager.GetCategories();
            if (categories == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Kategoriler yüklenemedi.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, categories);
        }

        [Route("InsertCategory")]
        [HttpPost]
        public HttpResponseMessage InsertCategory(Category category)
        {
            int result = _categoryManager.InsertCategory(category);
            if (result == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Ekleme işlemi başarısız.");
            }

            return Request.CreateResponse(HttpStatusCode.Created, $"Ekleme işlemi başarılı.");

        }

        [Route("UpdateCategory")]
        [HttpPost]
        public HttpResponseMessage UpdateCategory(Category category)
        {
            int result = _categoryManager.UpdateCategory(category);
            if (result == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Güncelleme başarısız, lütfen verileri kontrol ediniz!");
            }

            return Request.CreateResponse(HttpStatusCode.OK, $"Güncelleme başarılı.");
        }

        [Route("DeleteCategory")]
        [HttpPost]
        public HttpResponseMessage DeleteCategory(Category category)
        {
            int result = _categoryManager.DeleteCategory(category);
            if (result == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Silme işlemi yapılamadı!");
            }

            return Request.CreateResponse(HttpStatusCode.OK, $"Silme başarılı.");
        }

        [Route("DeleteAllCategories")]
        [HttpPost]
        public HttpResponseMessage DeleteAllCategories()
        {
            var deletedDatas = _categoryManager.DeleteAllCategories();
            if (deletedDatas == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Toplu Silme işlemi başarısız");
            }

            return Request.CreateResponse(HttpStatusCode.OK, $"Toplam {deletedDatas} tane veri silindi.");
        }

    }
}
