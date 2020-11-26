﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace web_platform.Models
{
    public class SecurityIssuePost
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string IssueDescription { get; set; }
        [Required]
        public string IssueReproduction { get; set; }

        // Navigation Properties - Used by DBContext when 'GETTING' entities
        public CMSComponentVersion CMSComponentVersion { get; set; }


        public SecurityIssuePost()
        {

        }
        public SecurityIssuePost(string title, string issueDescription, string issueReproduction)
        {
            Title = title;
            IssueDescription = issueDescription;
            IssueReproduction = issueReproduction;
        }
    }
}
