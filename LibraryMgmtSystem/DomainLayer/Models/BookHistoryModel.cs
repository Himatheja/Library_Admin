using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class BookIssueModel
    {
        public int BookID { get; set; }

        public string BookName{get;set;}

        public string UserID { get; set; }

        public DateTime OperationPerformedAt { get; set; }

        public DateTime? ReturnedAt { get; set; }

        public String PerformedByID { get; set; }
    }
}
