
using DatabaseIO;
using DatabaseProvider;
using MyProject.Common;
using MyProject.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebHocTiengAnh.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
           
            return View();
        }
    }
}