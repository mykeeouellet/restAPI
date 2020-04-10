using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Rest_Api.Models
{
    public partial class Elevators
    {
        public long Id { get; set; }
        public int? ElevatorSerialNumber { get; set; }
        public string ElevatorModel { get; set; }
        public string BuildingType { get; set; }
        public string ElevatorStatus { get; set; }
        public DateTime? ElevatorCommissioningDate { get; set; }
        public DateTime? ElevatorLastInspectionDate { get; set; }
        public string ElevatorInspectionCertificate { get; set; }
        public string ElevatorInformation { get; set; }
        public string ElevatorNotes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long? ColumnId { get; set; }

        public virtual Columns Column { get; set; }
    }
}
