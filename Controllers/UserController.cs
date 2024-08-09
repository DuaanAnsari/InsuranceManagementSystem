using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modules.Models;

namespace Modules.Controllers
{
  //  [Authorize(Roles = Static.Role_User)]
    //[Authorize(Roles = Static.Role_Admin)]
    public class UserController : Controller
    {
        private readonly DbContextClass dbContextClass;
        private readonly IWebHostEnvironment web;

        public UserController(DbContextClass dbContextClass, IWebHostEnvironment web)
        {
            this.dbContextClass = dbContextClass;
            this.web = web;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Aboutus()
        {
            return View();
        }
        public IActionResult Contactus()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contactus(ContactUs c)
        {
            dbContextClass.ContactUss.Add(c);
            dbContextClass.SaveChanges();
            return RedirectToAction("Index", "User");
          
        }
        public IActionResult Register()
        {
            ViewBag.Data = dbContextClass.companyInfos.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Register(EmployeeInfo e)
        {
            dbContextClass.employeeInfos.Add(e);
            dbContextClass.SaveChanges();
            return RedirectToAction("Index", "User");
        }
        public IActionResult Policy(int? id)
        {
            var select_rec = dbContextClass.policiesInfos.Find(id);
            return View(select_rec);
        }
        public IActionResult Insurance()
        {
            return View();
        }

    }
}
