using DatabaseIO;
using DatabaseProvider.Models;
using MyProject.Common;
using MyProject.Controllers;
using MyProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
namespace WebHocTiengAnh.Controllers
{
    public class HocPhanController : BaseController
    {
        // GET: HocPhan
        private DBIO dBIO = new DBIO();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HocPhanTuTao()
        {
            
            return View();
        }
        public ActionResult HocPhanNgoaiTao()
        {
            return View();
        }

        public ActionResult Detail()
        {

            return View();
        }
        public ActionResult EditTerm(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int idHocPhan = 0;
            if (id != null)
            {
                idHocPhan = (int)id;
            }
            var hocPhan = dBIO.getHocPhan(idHocPhan);
            if (hocPhan == null)
            {
                return HttpNotFound();
            }
            
            return View(hocPhan);
        }
        [HttpGet]
        public JsonResult DsLop()
        {
            try
            {
                var userSession = (LoginModel) Session[CommonConstrant.USER_SESSION];
                var dsLop = dBIO.getListHocPhanbyID(userSession.id);
                
                
                return Json(new { code = 200, dsLop = dsLop, msg = "Lấy danh sách thành công"}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Lấy danh sách thất bại "+e.Message}, JsonRequestBehavior.AllowGet);
            }
            
        }
        [HttpGet]
        public JsonResult loadHocPhanNgoaiTao()
        {
            try
            {
                
                var userSession = (LoginModel)Session[CommonConstrant.USER_SESSION];
                
                var dsHocPhan = dBIO.getListHocPhanNgoaiTaobyID(userSession.id);
                return Json(new { code = 200 ,dsHocPhan =dsHocPhan,msg = "Lấy thành công"}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Lấy danh sách thất bại " + e.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public JsonResult AddHocPhan(string inputHocPhan)
        {
            try
            {

                var User = (LoginModel)Session[CommonConstrant.USER_SESSION];
                var h = dBIO.createHocPhan(inputHocPhan,User.id);
                dBIO.addObject(h);
                dBIO.save();

                return Json(new { code = 200,h=h,msg = "Thêm danh sách thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Thêm danh sách thất bại " + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult searchHP (string inputSearch)
        {
            try
            {
                var listHocPhan = dBIO.getListHocPhanbyName(inputSearch);

                return Json(new { code = 200,inputSearch,listHocPhan=listHocPhan, msg = "Thêm danh sách thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { code = 500, inputSearch,msg = "Thêm danh sách thất bại " + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult addHocPhanNgoaiTao (int idHocPhan)
        {
            try
            {
                var userSession = (LoginModel)Session[CommonConstrant.USER_SESSION];
                dBIO.addHocPhanNgoaiTao(idHocPhan, userSession.id);
                return Json(new { code = 200,msg = "Thêm thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Thêm thất bại " + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}