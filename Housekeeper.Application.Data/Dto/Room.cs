using System;
using System.Collections.Generic;
using System.Text;

namespace Housekeeper.Application.Contracts.Dto
{
    public class Room
    {
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
        public EnumValue Status { get; protected set; }

        public Room(){}
        
        public Room(string id, string name, string floor, float area, float @long, float width, float height, EnumValue status)
        {
            Id = id;
            Name = name;
            Floor = floor;
            Area = area;
            Long = @long;
            Width = width;
            Height = height;
            Status = status;
        }
    }
}
