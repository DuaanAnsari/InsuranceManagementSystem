using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modules.Models;
using System.Data;

namespace Modules.Controllers
{
    //[Authorize(Roles = Static.Role_Admin)]
    public class AdminController : Controller
    {
        private readonly DbContextClass dbContextClass;
        private readonly IWebHostEnvironment web;

        public AdminController(DbContextClass dbContextClass, IWebHostEnvironment web)
        {
            this.dbContextClass = dbContextClass;
            this.web = web;
        }
        public IActionResult Index()
        {
            return View();
        }
        ////////////////////////////////////Employee Info START//////////////////////////////////////
        // Create
        public IActionResult CreateEmployee()
        {
            ViewBag.Data = dbContextClass.companyInfos.ToList();
            return View(); 
        }
        [HttpPost]
        public IActionResult CreateEmployee(EmployeeInfo e)
        {
            dbContextClass.employeeInfos.Add(e);
            dbContextClass.SaveChanges();
            return RedirectToAction("Employee", "Admin");
        }
        //List
        public IActionResult Employee(string search)
        {
            var select = dbContextClass.employeeInfos.Include(x=>x.CompanyInfo).Where(x => x.joindate.Contains(search) || x.EmployeeName.Contains(search) || x.Designation.Contains(search) || x.CompanyInfo.CompanyName.Contains(search) || search == null).ToList();
            return View(select);

        }
              // Action method for approving an employee
        public IActionResult Approval(int? id)
        {
            var employee = dbContextClass.employeeInfos.FirstOrDefault(e => e.EmployeeId == id);
            employee.Insured = Insured.Approved;             
            dbContextClass.SaveChanges();
            return RedirectToAction("Employee", "Admin");
        }
        // Action method for denying an employee
        public IActionResult Denied(int? id)
        {
            var employee = dbContextClass.employeeInfos.FirstOrDefault(e => e.EmployeeId == id);
            employee.Insured = Insured.Denied;
            dbContextClass.SaveChanges();
            return RedirectToAction("Employee" , "Admin");
        }
  

    //Edit
    public IActionResult EditEmployee(int? id)
        {
            ViewBag.Data=dbContextClass.companyInfos.ToList();
            var select_record = dbContextClass.employeeInfos.Find(id);
            return View(select_record);
        }
        [HttpPost]
        public IActionResult EditEmployee(EmployeeInfo e)
        {
            ViewBag.Data = dbContextClass.companyInfos.ToList();
            dbContextClass.employeeInfos.Update(e);
            dbContextClass.SaveChanges();
            return RedirectToAction("Employee" , "Admin");
        }
        //Details
        public IActionResult EmployeeDetails(int? id)
        { 
			var select_record = dbContextClass.employeeInfos.Find(id);
			return View(select_record);
        }
		//Delete
		public IActionResult DeleteEmployee(int id)
		{
			var select_record = dbContextClass.employeeInfos.Find(id);
            dbContextClass.employeeInfos.Remove(select_record);
            dbContextClass.SaveChanges();
			return RedirectToAction("Employee" , "Admin");
		}



		////////////////////////////////////Employee Info END//////////////////////////////////////

		////////////////////////////////////Company Info START//////////////////////////////////////
		//Create Get Method
		public IActionResult CreateCompany()
        {
            return View();
        }
        //Create Post Method
        [HttpPost]
        public IActionResult CreateCompany(CompanyInfo c)
        {
            dbContextClass.companyInfos.Add(c);
            dbContextClass.SaveChanges();
            return RedirectToAction("Company", "Admin");
        }
        //List
        public IActionResult Company()
        {
            var select_record = dbContextClass.companyInfos.ToList();
            return View(select_record);
        }
        //Edit
        public IActionResult EditCompany(int id)
        {
            var show_rec = dbContextClass.companyInfos.Find(id);
            return View(show_rec);
        }
        [HttpPost]
        public IActionResult EditCompany(CompanyInfo ci)
        {
            dbContextClass.companyInfos.Update(ci);
            dbContextClass.SaveChanges();
            return RedirectToAction("Company", "Admin");
        }
        //Details
        public IActionResult CompanyDetails(int id)
        {
            var show_rec = dbContextClass.companyInfos.Find(id);
            return View(show_rec);
        }
        //Delete
        public IActionResult DeleteCompany( int id)
        {
            var del_rec = dbContextClass.companyInfos.FirstOrDefault(c=> c.CompanyId==id);
            dbContextClass.companyInfos.Remove(del_rec);
            return RedirectToAction("Company" , "Admin");
        }
      


        ////////////////////////////////////Company Info END//////////////////////////////////////

        ////////////////////////////////////Hospital Info START//////////////////////////////////////

        //Create Get Method
        public IActionResult CreateHospital()
        {
            return View();
        }
        //Create Post Method
        [HttpPost]
        public IActionResult CreateHospital(HospitalInfo h)
        {
            dbContextClass.hospitalInfos.Add(h);
            dbContextClass.SaveChanges();
            return RedirectToAction("Hospital", "Admin");
        }
        //List
        public IActionResult Hospital()
        { 
            var select_record = dbContextClass.hospitalInfos.ToList();
            return View(select_record);
        }
        //Edit
        public IActionResult EditHospital(int id)
        {
            var show_rec = dbContextClass.hospitalInfos.Find(id);
            return View(show_rec);
        }
        [HttpPost]
        public IActionResult EditHospital(HospitalInfo hos)
        {
             dbContextClass.hospitalInfos.Update(hos);
            dbContextClass.SaveChanges();
            return RedirectToAction("Hospital" , "Admin");
        }
        //Details
        public IActionResult HospitalDetails(int id)
        {
            var show_rec = dbContextClass.hospitalInfos.Find(id);
            return View(show_rec);
        }
        //Delete
        public IActionResult DeleteHospital(int id)
        {
            var del_rec = dbContextClass.hospitalInfos.FirstOrDefault(c => c.HospitalId == id);
            dbContextClass.hospitalInfos.Remove(del_rec);
            return RedirectToAction("Hospital", "Admin");
        }

        ////////////////////////////////////Hospital Info END//////////////////////////////////////

        ////////////////////////////////////Insured Info START//////////////////////////////////////

        //Create Get Method
        //public IActionResult CreateInsurance()
        //{
        //    return View();
        //}
        ////Create Post Method
        //[HttpPost]
        //public IActionResult CreateInsurance(InsuredInfo i)
        //{
        //    dbContextClass.insuredInfos.Add(i);
        //    dbContextClass.SaveChanges();
        //    return RedirectToAction("Insured", "Admin");
        //}
        ////List
        //public IActionResult Insurance()
        //{
        //    var select_record = dbContextClass.insuredInfos.ToList();
        //    return View(select_record);
        //}
        public IActionResult InsuredEmp()
        {
            var select = dbContextClass.employeeInfos.Include(c => c.CompanyInfo).
                Where(e => e.Insured == Insured.Approved).ToList();
            return View(select);
        }
        //Delete
        //public IActionResult DeleteInsurance(int id)
        //{
        //    var del_rec = dbContextClass.insuredInfos.FirstOrDefault(c => c.InsureId == id);
        //    dbContextClass.insuredInfos.Remove(del_rec);
        //    return RedirectToAction("Insurance", "Admin");
        //}
        ////////////////////////////////////Insured Info END//////////////////////////////////////

        ///////////////////////////////////////Policy Info START//////////////////////////////////////

        //Create Get Method
        public IActionResult CreatePolicy()
        {
   
            return View();
        }
        //Create Post Method
        [HttpPost]
        public IActionResult CreatePolicy(PoliciesInfo h)
        {
            dbContextClass.policiesInfos.Add(h);
            dbContextClass.SaveChanges();
            return RedirectToAction("Policy", "Admin");
        }
        //List
        public IActionResult Policy()
        {
            var select_record = dbContextClass.policiesInfos.ToList();
            return View(select_record);
        }
        //Edit
        public IActionResult EditPolicy(int id)
        {
        
            var rec_edit = dbContextClass.policiesInfos.Find(id);
            return View(rec_edit);
        }
        [HttpPost]
        public IActionResult EditPolicy(PoliciesInfo pi)
        {
            
            dbContextClass.policiesInfos.Update(pi);
            dbContextClass.SaveChanges();
            return RedirectToAction("Policy" , "Admin");
        }
        //Details
        public IActionResult PolicyDetail(int? id)
        { 
            var show_rec = dbContextClass.policiesInfos.Find(id);
            return View(show_rec);
        }
        //Delete
        public IActionResult DeletePolicy(int id)
        {
            var del_rec = dbContextClass.policiesInfos.FirstOrDefault(c => c.PolicyId == id);
            dbContextClass.policiesInfos.Remove(del_rec);
            return RedirectToAction("Policy", "Admin");
        }

        ////////////////////////////////////Policy Info END//////////////////////////////////////
        ///
        ////////////////////////////////////ContactUs//////////////////////////////////////
        //List
        public IActionResult ContactUs()
        {
            var select_record = dbContextClass.ContactUss.ToList();
            return View(select_record);
        }
        public IActionResult ContactDetails(int? id)
        {
            var show_rec = dbContextClass.ContactUss.Find(id);
            return View(show_rec);
        }
        public IActionResult DeleteContact(int id)
        {
            var del_rec = dbContextClass.ContactUss.FirstOrDefault(c => c.ContactId == id);
            dbContextClass.ContactUss.Remove(del_rec);
            return RedirectToAction("ContactUs", "Admin");
        }
    }
}
