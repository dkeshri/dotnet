using System;

namespace Webapi.Entities
{
    public class Student
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}