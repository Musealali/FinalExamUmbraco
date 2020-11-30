using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace web_platform.Data.Models
{
    public class SecurityIssuePost
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string IssueDescription { get; set; }

        // Navigation Properties - Used by DBContext when 'GETTING' entities
        public CMSComponentVersion CMSComponentVersion { get; set; }


    }
}
