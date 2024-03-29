using System;

namespace SQLDapper.Model
{
    public class Customer
    {
        public long? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public int? BirthYear { get; set; }

        public override string ToString()
        {
            return $"{LastName} {FirstName} - {BirthYear}";
        }
    }
}