﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_platform.Data.Models;

namespace web_platform.Models
{
    public class SecurityIssuePostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string IssueDescription { get; set; }
        public string CMSComponentName { get; set; }
        public string CMSVersionNumber { get; set; }
        public string ComponentType { get; set; }
        public string[] Packages { get; set; }
        public State State { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        
        public List<SecurityIssuePostReplyViewModel> SecurityIssuePostReplies { get; set; }
        public SecurityIssuePostReplyViewModel securityIssuePostReplyViewModel { get; set; }
       
    }
}
