using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Rest_Api.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Buildings = new HashSet<Buildings>();
        }

        public long Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyContactFullName { get; set; }
        public string CompanyContactEmail { get; set; }
        public string CompanyContactPhone { get; set; }
        public string CompanyDescription { get; set; }
        public string ServiceTechnicalAuthorityFullName { get; set; }
        public string ServiceTechnicalAuthorityEmail { get; set; }
        public string ServiceTechnicalAuthorityPhone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long? UserId { get; set; }
        public long? QuoteId { get; set; }

        public virtual Quotes Quote { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<Buildings> Buildings { get; set; }
    }
}
