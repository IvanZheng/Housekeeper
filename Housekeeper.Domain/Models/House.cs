using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using IFramework.Infrastructure;

namespace Housekeeper.Domain.Models
{
    public class House: AggregateRoot
    {
        public string Id { get; protected set; }
        public string Name { get; protected set; }
        public HouseOwner Owner { get; protected set; }
        public Address Address { get; protected set; }
        public ICollection<Room> Rooms { get; protected set; } = new HashSet<Room>();
        public Status Status { get; protected set; }

        protected House()
        {

        }

        public House(string name, HouseOwner owner, Address address = null, Status status = Status.Normal)
        {
            Id = ObjectId.GenerateNewId()
                         .ToString();
            Name = name;
            Owner = owner;
            Address = address ?? Address.Null;
            Status = status;
        }
    }

}
