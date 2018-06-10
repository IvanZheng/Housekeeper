using System;
using System.Collections.Generic;
using System.Linq;
using IFramework.Infrastructure;
using Dto = Housekeeper.Application.Contracts.Dto;

namespace Housekeeper.Domain.Models
{
    public class House : AggregateRoot
    {
        protected House() { }

        public House(string name, HouseOwner owner, Address address = null, Status status = Status.Normal)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
            }

            
            if (string.IsNullOrWhiteSpace(owner?.Id))
            {
                throw new NullReferenceException(nameof(owner.Id));
            }

            Id = ObjectId.GenerateNewId()
                         .ToString();
            Name = name;
            Owner = owner;
            Address = address ?? Address.Null;
            Status = status;
        }

        public string Id { get; protected set; }
        public string Name { get; protected set; }
        public HouseOwner Owner { get; protected set; }
        public Address Address { get; protected set; }
        public ICollection<Room> Rooms { get; protected set; } = new HashSet<Room>();
        public Status Status { get; protected set; }

        public static implicit operator Dto.House(House house)
        {
            return new Dto.House(house.Id,
                                 house.Name,
                                 house.Owner,
                                 house.Address,
                                 house.Rooms
                                      .Select(room => new Dto.Room(room.Id,
                                                                   room.Name,
                                                                   room.Floor,
                                                                   room.Area,
                                                                   room.Long,
                                                                   room.Width,
                                                                   room.Height,
                                                                   room.Status))
                                      .ToArray(),
                                 house.Status
                                );
        }
    }
}