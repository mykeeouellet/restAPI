using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Rest_Api.Models
{
    public partial class Batteries
    {
        public Batteries()
        {
            Columns = new HashSet<Columns>();
        }

        public long Id { get; set; }
        public string BuildingType { get; set; }
        public string BatteryStatus { get; set; }
        public DateTime? BatteryCommissioningDate { get; set; }
        public DateTime? BatteryLastInspectionDate { get; set; }
        public string BatteryOperationCertificate { get; set; }
        public string BatteryInformation { get; set; }
        public string BatteryNotes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long? BuildingId { get; set; }
        public long? EmployeeId { get; set; }

        public virtual Buildings Building { get; set; }
        public virtual Employees Employee { get; set; }
        public virtual ICollection<Columns> Columns { get; set; }
    }
}
