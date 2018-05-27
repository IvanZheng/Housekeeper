using System;
using System.Collections.Generic;
using System.Text;
using IFramework.Domain;

namespace Housekeeper.Domain.Models
{
    public class Address: ValueObject<Address>
    {
        public string Country { get; protected set; }
        public string Province { get; protected set; }
        public string City { get; protected set; }
        public string Detail { get; protected set; }

        protected Address()
        {

        }

        public Address(string country, string province, string city, string detail)
        {
            Country = country;
            Province = province;
            City = city;
            Detail = detail;
        }
    }
}
