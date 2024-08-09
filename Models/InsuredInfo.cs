using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Modules.Models
{
    public class InsuredInfo
    {
        [Key]
        public int InsureId { get; set; } 
        public int EmpId { get; set; }
        [ForeignKey("EmpId")]
        public EmployeeInfo Employee { get; set; }
        public int PolicyId { get; set; }
        [ForeignKey("PolicyId")]
        public PoliciesInfo Policy { get; set; } 
        public string StartDate { get; set; }
        public string PolicyStatus { get; set; } = "Pending";
    }
}
