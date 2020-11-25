using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace web_platform.Models
{
    public class SecurityIssuePost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string IssueDescription { get; set; }
        public string IssueReproduction { get; set; }
        public DateTime Created { get; set; }

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
            Created = DateTime.Now;
        }
    }
}
