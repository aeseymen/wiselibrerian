using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WiseLibrarian.Business.Managers;
using WiseLibrarian.Business.ViewModels;
using WiseLibrarian.DataAccess.Entities;

namespace WiseLibrarian.WebUI.Controllers
{
    [RoutePrefix("api/Member")]
    public class MemberController : ApiController
    {
        private readonly MemberManager _memberManager;
        public MemberController()
        {
            _memberManager = new MemberManager();
        }
        [Route("GetMember/{id}")]
        [HttpGet]
        public HttpResponseMessage GetMember(int id)
        {
            // var _memberManager=new MemberManager();
            var member = _memberManager.GetMember(id);
            if (member == null) 
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Id'si {id} olan çalışan bulunamadı."); 
            }
            

            return Request.CreateResponse(HttpStatusCode.OK, member);
         }
        [Route("GetMembers")]
        [HttpGet]
        public HttpResponseMessage GetMembers()
        {
            var members = _memberManager.GetMembers();
            if (members == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Üyeler yüklenemedi.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, members);
        }

        [Route("InsertMember")]
        [HttpPost]
        public HttpResponseMessage InsertMember(Member member)
        {
         int result = _memberManager.InsertMember(member);
            if (result == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Ekleme işlemi başarısız.");
            }

            return Request.CreateResponse(HttpStatusCode.Created, $"Ekleme işlemi başarılı.");
            
        }

        [Route("UpdateMember")]
        [HttpPost]
        public HttpResponseMessage UpdateMember(Member member)
        {
            int result = _memberManager.UpdateMember(member);
            if (result == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Güncelleme başarısız, lütfen verileri kontrol ediniz!");
            }

            return Request.CreateResponse(HttpStatusCode.OK, $"Güncelleme başarılı.");
        }

        [Route("DeleteMember")]
        [HttpPost]
        public HttpResponseMessage DeleteMember(Member member)
        {
            int result = _memberManager.DeleteMember(member);
            if(result == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Silme işlemi yapılamadı!");
            }

            return Request.CreateResponse(HttpStatusCode.OK, $"Silme başarılı.");
        }

        [Route("DeleteAllMembers")]
        [HttpPost]
        public HttpResponseMessage DeleteAllMembers()
        {
            var deletedDatas = _memberManager.DeleteAllMembers();
            if (deletedDatas == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Toplu Silme işlemi başarısız");
            }

            return Request.CreateResponse(HttpStatusCode.OK, $"Toplam {deletedDatas} tane veri silindi.");
        }

    }
}
