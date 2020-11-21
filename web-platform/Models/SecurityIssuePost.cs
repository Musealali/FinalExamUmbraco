﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_platform.Models
{
    public class SecurityIssuePost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public User User { get; set; }
        public CMSComponent Component { get; set; }
        public string IssueDescription { get; set; }
        public string IssueReproduction { get; set; }
        //TODO public HttpPostedFileBase AttachedFiles { get; set; }

        public SecurityIssuePost()
        {

        }
        public SecurityIssuePost(int id, string title, User user, CMSComponent component, string issueDescription, string issueReproduction)
        {
            Id = id;
            Title = title;
            User = user;
            Component = component;
            IssueDescription = issueDescription;
            IssueReproduction = issueReproduction;
        }
    }
}
