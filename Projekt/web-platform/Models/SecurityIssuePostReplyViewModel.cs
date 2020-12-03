using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using web_platform.Data.Models;

namespace web_platform.Models
{
    public class SecurityIssuePostReplyViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
