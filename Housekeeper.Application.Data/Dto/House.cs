using Housekeeper.Application.Contracts.Dto;
using System;

namespace Housekeeper.Application.Contracts.Dto
{
    public class House
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IdName Owner { get; set; }
        public Address Address { get; set; }
        public Room[] Rooms { get; set; }
        public EnumValue Status { get; set; }

        public House(string id,
                     string name,
                     IdName owner,
                     Address address,
                     Room[] rooms,
                     EnumValue status)
        {
            Id = id;
            Name = name;
            Owner = owner;
            Address = address;
            Rooms = rooms;
            Status = status;
        }

        public House() { }


    }


}
