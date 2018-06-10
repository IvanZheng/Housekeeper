using System;
using System.Collections.Generic;
using System.Text;
using IFramework.Domain;
using Dto = Housekeeper.Application.Contracts.Dto;

namespace Housekeeper.Domain.Models
{
    public class Address: ValueObject<Address>
    {
        public static Address Null = new Address();
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

        public static implicit operator Address(Dto.Address address) => new Address(address.Country,
                                                                                    address.Province,
                                                                                    address.City,
                                                                                    address.Detail);

        public static implicit operator Dto.Address(Address address) => new Dto.Address(address.Country,
                                                                                        address.Province,
                                                                                        address.City,
                                                                                        address.Detail);
    }
}
