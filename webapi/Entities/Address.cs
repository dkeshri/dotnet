using System;

namespace Webapi.Entities
{
    public class Address
    {
        public Guid AddressId { get; init; }
        public string HNO { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Pincode { get; set; }
        public string  State { get; set; }  
        public string Country { get; set; }
    }
}