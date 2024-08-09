﻿using System.ComponentModel.DataAnnotations;

namespace Modules.Models
{
    public class ContactUs
    {
        [Key]
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
