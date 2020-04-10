using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Rest_Api.Models
{
    public partial class Quotes
    {
        public Quotes()
        {
            Customers = new HashSet<Customers>();
        }

        public long Id { get; set; }
        public string BuildingType { get; set; }
        public int? NbrAppt { get; set; }
        public string NbrFloors { get; set; }
        public int? NbrBassements { get; set; }
        public int? NbrElevators { get; set; }
        public string ElevatorQuality { get; set; }
        public float? ElevatorCost { get; set; }
        public float? InstallationPrice { get; set; }
        public float? TotalPrice { get; set; }
        public int? NbrBusinesses { get; set; }
        public int? NbrParking { get; set; }
        public int? NbrRentalCompagnies { get; set; }
        public int? NbrOccupanrtPerFloor { get; set; }
        public DateTime? WorkingHours { get; set; }
        public long? UserId { get; set; }
        public string Email { get; set; }
        public long? LeadId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Leads Lead { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<Customers> Customers { get; set; }
    }
}
