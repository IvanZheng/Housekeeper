using System;
using System.Collections.Generic;
using System.Text;

namespace Housekeeper.Application.Contracts.Dto
{
    public class Address
    {
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }

        public Address()
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
