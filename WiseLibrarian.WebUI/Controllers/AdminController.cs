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
    [RoutePrefix("api/Admin")]

    public class AdminController : ApiController
    {
            private readonly AdminManager _adminManager;
            public AdminController()
            {
            _adminManager = new AdminManager();
            }
            [Route("GetAdmin/{id}")]
            [HttpGet]
            public HttpResponseMessage GetAdmin(int id)
            {
                var admin = _adminManager.GetAdmin(id);
                if (admin == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Id'si {id} olan admin bulunamadı.");
                }


                return Request.CreateResponse(HttpStatusCode.OK, admin);
            }
            [Route("GetAdmins")]
            [HttpGet]
            public HttpResponseMessage GetAdmins()
            {
                var admins = _adminManager.GetAdmins();
                if (admins == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Adminler yüklenemedi.");
                }

                return Request.CreateResponse(HttpStatusCode.OK, admins);
            }

            [Route("InsertAdmin")]
            [HttpPost]
            public HttpResponseMessage InsertAdmin(Admin admin)
            {
                int result = _adminManager.InsertAdmin(admin);
                if (result == 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Ekleme işlemi başarısız.");
                }

                return Request.CreateResponse(HttpStatusCode.Created, $"Ekleme işlemi başarılı.");

            }

            [Route("UpdateAdmin")]
            [HttpPost]
            public HttpResponseMessage UpdateAdmin(Admin admin)
            {
                int result = _adminManager.UpdateAdmin(admin);
                if (result == 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Güncelleme başarısız, lütfen verileri kontrol ediniz!");
                }

                return Request.CreateResponse(HttpStatusCode.OK, $"Güncelleme başarılı.");
            }

            [Route("DeleteAdmin")]
            [HttpPost]
            public HttpResponseMessage DeleteAdmin(Admin admin)
            {
                int result = _adminManager.DeleteAdmin(admin);
                if (result == 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Silme işlemi yapılamadı!");
                }

                return Request.CreateResponse(HttpStatusCode.OK, $"Silme başarılı.");
            }

            [Route("DeleteAllAdmins")]
            [HttpPost]
            public HttpResponseMessage DeleteAllAdmins()
            {
                var deletedDatas = _adminManager.DeleteAllAdmins();
                if (deletedDatas == 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Toplu Silme işlemi başarısız");
                }

                return Request.CreateResponse(HttpStatusCode.OK, $"Toplam {deletedDatas} tane veri silindi.");
            }


    }
}
