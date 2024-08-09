using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Modules.Models
{
    public class DbContextClass : IdentityDbContext
    {
        //creating constructor // function having same name as class
        public DbContextClass(DbContextOptions options) : base(options)
            {
                
            }
        public DbSet<CompanyInfo> companyInfos { get; set; }
        public DbSet<EmployeeInfo> employeeInfos { get; set; }
        public DbSet<HospitalInfo> hospitalInfos { get; set; }
        public DbSet<InsuredInfo> insuredInfos { get; set; }
        public DbSet<PoliciesInfo> policiesInfos { get; set; }
        public DbSet<ContactUs>  ContactUss { get; set; }
        public DbSet<AppUser> appUsers { get; set; }
    }
}
