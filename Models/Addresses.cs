using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Rest_Api.Models
{
    public partial class Addresses
    {
        public long Id { get; set; }
        public string AddressType { get; set; }
        public string AddressStatus { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string SuiteOrApartment { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string AddressNotes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string EntityType { get; set; }
        public long? EntityId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
