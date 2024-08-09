using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modules.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Designation { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
       
        public string joindate { get; set; }

    }
}
