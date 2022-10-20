using _2001202045_VuNgoDat_Buoi3.Core;
using _2001202045_VuNgoDat_Buoi3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2001202045_VuNgoDat_Buoi3.Controllers
{
    public class DepartmentController : Controller
    {
        private DAL _data = new DAL();
        // GET: Department
        public ActionResult Index()
        {
            return View(_data.GetDepList());
        }
        public ActionResult Detail(string id)
        {
            ViewBag.CountEpl = _data.CountEplInDep(id);
            ViewBag.ListEmpl = _data.GetEmplListInDept(id);
            return View(_data.GetDep(id));
        }
    }
}