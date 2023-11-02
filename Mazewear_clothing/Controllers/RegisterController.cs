using Mazewear_clothing.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mazewear_clothing.Controllers
{
    public class RegisterController : Controller
    {
        MazewearEntities db = new MazewearEntities();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult SaveData(Tbl_Admin model)
        {
            db.Tbl_Admin.Add(model);
            db.SaveChanges();
            return Json("Registration Successfull",JsonRequestBehavior.AllowGet);
        }
    }
}