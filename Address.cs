using System;
using System.Collections.Generic;
using System.Text;

namespace Hogwarts.Models
{
    class Address
    {
        public Address(string street, string city, string postCode)
        {
            Street = street;
            City = city;
            PostCode = postCode;
        }

        public int Id { get; protected set; }
        public string Street { get; protected set; }
        public string City { get; protected set; }
        public string PostCode { get; protected set; }
        public int StudentId { get; protected set; }
    }
}
