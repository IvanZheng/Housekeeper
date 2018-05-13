using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Housekeeper.Domain.Models
{
    public class House: AggregateRoot
    {
        public string Id { get; protected set; }
        public string Name { get; protected set; }
        public HouseOwner Owner { get; protected set; }
        public Address Address { get; protected set; }
        public Status Status { get; protected set; }
    }
}
