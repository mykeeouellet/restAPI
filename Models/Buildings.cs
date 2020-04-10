using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Rest_Api.Models
{
    public partial class Buildings
    {
        public Buildings()
        {
            Batteries = new HashSet<Batteries>();
            BuildingDetails = new HashSet<BuildingDetails>();
        }

        public long Id { get; set; }
        public string BuildingAdministratorFullName { get; set; }
        public string BuildingAdministratorEmail { get; set; }
        public string BuildingAdministratorPhone { get; set; }
        public string BuildingTechnicalContactFullName { get; set; }
        public string BuildingTechnicalContactEmail { get; set; }
        public string BuildingTechnicalContactPhone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long? CustomerId { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual ICollection<Batteries> Batteries { get; set; }
        public virtual ICollection<BuildingDetails> BuildingDetails { get; set; }
    }
}
