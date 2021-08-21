using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using final_exam_app.Models.EF;
using final_exam_app.Models.DAO;
using System.Text.RegularExpressions;

namespace final_exam_app.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {
            return View("DisplayAuth");
        }

        public ActionResult Login(string email_, string pass_)
        {
            Auth authDao = new Auth();
            Users us = authDao.Login(email_, pass_);
            if (us!=null)
            {
                int id =us.user_id;
                return Json(id, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult Regsiter(string email_,string pass_)
        {
            Auth authDao = new Auth();
            bool checkRes = authDao.Res(email_,pass_);
            if (checkRes)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DisplayAuth()
        {
            return View();
        }
        public JsonResult getEmail(string email)
        {
            Auth authDao = new Auth();
            Users us = authDao.getUserByEmails(email);
            if (us != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}