using Microsoft.AspNetCore.Mvc;
using Modules.Models;

namespace Modules.Controllers
{
    public class WebController : Controller
    {
        private readonly DbContextClass dbContextClass;
        private readonly IWebHostEnvironment web;
        public WebController(DbContextClass dbContextClass, IWebHostEnvironment web)
        {
            this.dbContextClass = dbContextClass;
            this.web = web;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Policy(int? id)
        {
            var select_rec = dbContextClass.policiesInfos.Find(id);
            return View(select_rec);
        }
    }
}
