using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modules.Models
{
    public enum Insured
    {
        Approved,
        Denied
    }
    public class EmployeeInfo
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public int salary { get; set; }       
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public CompanyInfo CompanyInfo { get; set; }      
        public string joindate { get; set; }
        public Insured? Insured { get; set; } 
    }
}
