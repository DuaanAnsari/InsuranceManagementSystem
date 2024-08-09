using System.ComponentModel.DataAnnotations;

namespace Modules.Models
{
    public class HospitalInfo
    {
        [Key]
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public Int64 Tell_No { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
    }
}
