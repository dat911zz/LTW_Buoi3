using _2001202045_VuNgoDat_Buoi3.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2001202045_VuNgoDat_Buoi3.Controllers
{
    public class HomeController : Controller
    {
        private DAL _data = new DAL(); 
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.SL = _data.SL();
            return View(_data.GetEmpList());
        }
        public ActionResult Detail(string id)
        {
            return View(_data.GetEmp(id));
        }
    }
}