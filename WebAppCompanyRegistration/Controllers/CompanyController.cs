using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppCompanyRegistration.Models;

namespace WebAppCompanyRegistration.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetAllCompany()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            var companies = dbContext.Companies.ToList();
            return Json(companies, JsonRequestBehavior.AllowGet);
        }

    }
}