using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using WebAppCompanyRegistration.Models;
using System.Text;

namespace WebAppCompanyRegistration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
   
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignUp()
        {

            return View();
        }
        public ActionResult ProductList()
        {
            return View();
        }
        public string InsertProduct(Product product)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            product.ReferenceNo = ComputeSha256Hash(Convert.ToString(dbContext.Products.Count()+1));

            //product.ReferenceNo = "";
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            return "Product Insert Successfully!";
        }

        public string RemoveProduct(string id)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            int pid = Convert.ToInt32(id);
            Product product = dbContext.Products.FirstOrDefault(e => e.Id == pid);
            if (product != null)
            {
                dbContext.Products.Remove(product);
                dbContext.SaveChanges();
            }

            return "Product Remove Successfully!";
        }

        public string InsertCompany(Company company)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            var countryList = dbContext.Country.ToList();

            dbContext.Companies.Add(company);
            dbContext.SaveChanges();
            return "Company Insert Successfully!";
        }

        public JsonResult GetAllProducts()
        {
            ApplicationDbContext dbContext2 = new ApplicationDbContext();
            var products = dbContext2.Products.ToList();
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCountry()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            var country = dbContext.Country.ToList();
            return Json(country, JsonRequestBehavior.AllowGet);
        }


        static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
  
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}