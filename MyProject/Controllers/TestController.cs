using DatabaseIO;
using DatabaseProvider.Models;
using MyProject.Common;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Controllers
{
    public class TestController : BaseController
    {
        // GET: Test
        private DBIO dBIO = new DBIO();
        public ActionResult Index()
        {
            //var userSession = (LoginModel)Session[CommonConstrant.USER_SESSION];
            //var dsLop = dBIO.getListHocPhanNgoaiTaobyID(userSession.id);
            return View();
        }
    }
}