using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Text;

namespace Housekeeper.Domain.Models
{
    public class Item
    {
        public string Id { get; protected set; }
        public string Name { get; protected set; }
        public string Tags { get; protected set; }
        public ItemType Type { get; protected set; }
        public DateTime ProductionDate { get; protected set; }
        public DateTime ExpireDate { get; protected set; }
        public Media[] Medias { get; protected set; }
    }
}
