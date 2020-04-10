using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Rest_Api.Models
{
    public partial class Leads
    {
        public Leads()
        {
            Quotes = new HashSet<Quotes>();
        }

        public long Id { get; set; }
        public string LeadFullName { get; set; }
        public string LeadCompanyName { get; set; }
        public string LeadEmail { get; set; }
        public string LeadPhone { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string DepartmentOfService { get; set; }
        public string LeadMessage { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public byte[] Attachment { get; set; }

        public virtual ICollection<Quotes> Quotes { get; set; }
    }
}
