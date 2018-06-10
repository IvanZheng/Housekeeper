using System.Collections.Generic;
using System.Linq;
using IFramework.Domain;
using IFramework.Infrastructure;
using Dto = Housekeeper.Application.Contracts.Dto;

namespace Housekeeper.Domain.Models
{
    public class Room : Entity
    {
        public Room(string name,
                    string floor = null,
                    float area = 0,
                    float @long = 0,
                    float width = 0,
                    float height = 0,
                    Status status = Status.Normal)
        {
            Id = ObjectId.GenerateNewId()
                         .ToString();
            Name = name;
            Floor = floor;
            Area = area;
            Long = @long;
            Width = width;
            Height = height;
            Status = status;
        }

        public string Id { get; protected set; }
        public string Name { get; protected set; }
        public string Floor { get; protected set; }

        /// <summary>
        ///     面积
        /// </summary>
        public float Area { get; protected set; }

        public float Long { get; protected set; }
        public float Width { get; protected set; }
        public float Height { get; protected set; }
        public Status Status { get; protected set; }


        public static implicit operator Dto.Room(Room room) => new Dto.Room(room.Id,
                                                                            room.Name, 
                                                                            room.Floor,
                                                                            room.Area,
                                                                            room.Long,
                                                                            room.Width,
                                                                            room.Height,
                                                                            room.Status);
    }
}