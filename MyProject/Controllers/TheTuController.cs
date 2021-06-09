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

namespace MyProject.Controllers
{
    public class TheTuController : Controller
    {
        // GET: TheTu
        private DBIO dBIO = new DBIO();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult loadTheTu(int idHocPhan)
        {

            try
            {
                var listTheTu = dBIO.getListTheTu(idHocPhan);

                return Json(new { code = 200, listTheTu = listTheTu }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { code = 500, msg = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult addTheTu(string engWord,string viWord,int idHocPhan)
        {

            try
            {
                dBIO.addTheTu(engWord, viWord, idHocPhan);
                dBIO.save();
                return Json(new { code = 200,msg = "ok"}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult editTheTu(string engWord, string viWord, int idTheTu)
        {

            try
            {
                dBIO.editTheTu(engWord, viWord, idTheTu);
                dBIO.save();
                return Json(new { code = 200, msg = "ok" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult deleteTheTu(int idTheTu)
        {

            try
            {
                dBIO.deleteTheTu(idTheTu);
                dBIO.save();
                return Json(new { code = 200, msg = "ok" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        
    }
}