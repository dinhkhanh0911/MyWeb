using DatabaseIO;
using DatabaseProvider;
using DatabaseProvider.Models;
using MyProject.Common;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebHocTiengAnh.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private DBIO dBIO = new DBIO();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (dBIO.checkUserName(model.useName))
                {
                    if (dBIO.checkPassword(Encryptor.MD5Hash(model.Password)))
                    {
                        User u = dBIO.GetByUserName(model.useName);
                        var userSession = new LoginModel();
                        userSession.useName = u.userName;
                        userSession.id = u.idUser;
                        Session.Add(CommonConstrant.USER_SESSION, userSession);
                        return RedirectToAction("Index", "Home");
                    }
                    else ModelState.AddModelError("", "Sai mật khẩu");
                }
                else ModelState.AddModelError("", "Sai tài khoản");
            }
            
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (dBIO.checkUserName(model.userName)){
                    ModelState.AddModelError("", "Tài khoản đã tồn tại");
                }
                else
                {
                    var u = new User();
                    u.userName = model.userName;
                    u.fullName = model.fullName;
                    u.age = model.age;
                    u.userPassword = Encryptor.MD5Hash(model.Password);
                    dBIO.addObject(u);
                    dBIO.save();
                }
            }
            return View();
        }
        
        public ActionResult dangXuat()
        {
            Session[CommonConstrant.USER_SESSION] = null;
            return RedirectToAction("login", "Login");
        }
    }
}