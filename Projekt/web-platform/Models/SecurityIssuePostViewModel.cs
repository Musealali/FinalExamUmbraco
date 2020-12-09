using System.Collections.Generic;
using web_platform.Data.Models;

namespace web_platform.Models
{
    public class SecurityIssuePostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string IssueDescription { get; set; }
        public string ComponentName { get; set; }
        public string ComponentVersion { get; set; }
        public string ComponentType { get; set; }
        public State State { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        
        public List<SecurityIssuePostReplyViewModel> SecurityIssuePostReplies { get; set; }
        public SecurityIssuePostReplyViewModel securityIssuePostReplyViewModel { get; set; }
       
    }
}
