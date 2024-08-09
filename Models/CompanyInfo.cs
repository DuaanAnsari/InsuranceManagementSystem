using System.ComponentModel.DataAnnotations;

namespace Modules.Models
{
    public class CompanyInfo
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public Int64 Tell_No { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
