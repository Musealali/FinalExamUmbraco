using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace web_platform.Data.Models
{
    public class UserFile
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        [Required]
        public string FilePath { get; set; }

        public SecurityIssuePost SecurityIssuePost { get; set; }
    }
}
