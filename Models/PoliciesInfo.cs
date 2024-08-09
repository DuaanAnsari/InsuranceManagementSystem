using System.ComponentModel.DataAnnotations;

namespace Modules.Models
{
    public class PoliciesInfo
    {
        [Key]
        public int PolicyId { get; set; }
        public string PolicyName { get; set; }
        public string PolicyHolder_Info { get; set; }
        public string Policy_Term { get; set; }
        public string Coverage_Details { get; set; }
        public string Coverage_Limits { get; set; }
        public string Conditions { get; set; }
        public int Amount { get; set; }
        public int EMI { get; set; }
    }
}
