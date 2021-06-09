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
using System.Xml;

namespace WebHocTiengAnh.Controllers
{
    public class LopHocController : BaseController
    {
        // GET: LopHoc
        private DBIO dBIO = new DBIO();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LopHocTuTao()
        {
            return View();
        }
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int idLop = 0;
            if(id != null)
            {
                 idLop = (int)id;
            }
            var lopHoc = dBIO.getLopHoc_2(idLop);
            if (lopHoc == null)
            {
                return HttpNotFound();
            }
            return View(lopHoc);
        }
        [HttpGet]
        public JsonResult loadLopHoc()
        {
            try
            {




                var userSession = (LoginModel)Session[CommonConstrant.USER_SESSION];
                var dsLopHoc = dBIO.getListLopHoc(userSession.id);
                return Json(new { code = 200, dsLopHoc = dsLopHoc, msg = "Tai thanh cong" }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { code = 500, msg = "Tai that bai" + e.Message }, JsonRequestBehavior.AllowGet);
            }
        
        }
        [HttpPost]
        public JsonResult addLopHoc(string tenLopHoc,string descriptionClass)
        {
            try
            {
                var userSession = (LoginModel)Session[CommonConstrant.USER_SESSION];
                var lopHoc = dBIO.createLopHoc(tenLopHoc, descriptionClass, userSession.id);
                dBIO.addObject(lopHoc);
                dBIO.save();
                return Json(new { code = 200,msg = "Them thanh cong" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Them that bai"+ e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult searchClass(string inputSearch)
        {
            try
            {
                var userSession = (LoginModel)Session[CommonConstrant.USER_SESSION];
                var dsLopHoc = dBIO.getListLopHoc(userSession.id,inputSearch);
                return Json(new { code = 200,dsLopHoc=dsLopHoc, msg = "Them thanh cong" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Them that bai" + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult removeClass (int idLopHoc)
        {
            try
            {
                //var userSession = (LoginModel)Session[CommonConstrant.USER_SESSION];
                
                dBIO.removeLopHoc(idLopHoc,2);
                dBIO.save();
                return Json(new { code = 200, msg = "Xoa thanh cong" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Xoa that bai" + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult thamGiaLopHoc (int input)
        {
            try
            {
                LopHoc lopHoc = dBIO.getLopHoc_2(input);
                if(lopHoc == null)
                {
                    return Json(new { code = 404, msg = "Khong co lop hoc tuong ung" }, JsonRequestBehavior.AllowGet);
                }
                var userSession = (LoginModel)Session[CommonConstrant.USER_SESSION];
                var check = dBIO.checkHocsinh(userSession.id, input);
                if (check)
                {
                    return Json(new { code = 100 }, JsonRequestBehavior.AllowGet);
                }
                var hocSinh = dBIO.createHocSinh(userSession.id, lopHoc.idLopHoc);
                dBIO.addObject(hocSinh);
                dBIO.save();
                return Json(new { code = 200, msg = "Tham gia thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { code = 500, msg = "Tham gia thất bại" + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult loadDetailClass(int idLop)
        {
            try
            {
                var userSession = (LoginModel)Session[CommonConstrant.USER_SESSION];
                var listHocSinh = dBIO.getListHocSinh(idLop);
                var giaoVien = dBIO.GetByUserID(userSession.id);
                return Json(new { code = 200,listHocSinh = listHocSinh ,giaoVien = giaoVien, msg = "Lấy thành công" },JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Lấy thất bại" + e.Message}, JsonRequestBehavior.AllowGet);
            }
        }
    }
}