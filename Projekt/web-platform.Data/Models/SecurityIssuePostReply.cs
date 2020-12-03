using System;
using System.Collections.Generic;
using System.Text;

namespace web_platform.Data.Models
{
   public class SecurityIssuePostReply
    {
        public int Id { get; set; }
        public string Content { get; set; }
        
        public ApplicationUser ApplicationUser { get; set; }
        public SecurityIssuePost SecurityIssuePost { get; set; }
    }
}
