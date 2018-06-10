using System;
using System.Collections.Generic;
using System.Text;
using IFramework.Domain;

namespace Housekeeper.Domain.Models
{
    public class Media: ValueObject<Media>
    {
        public string Name { get; protected set; }
        public string Url { get; protected set; }
        public MediaType Type { get; protected set; }

        protected Media(){}
        public Media(string name, string url, MediaType type)
        {
            Name = name;
            Url = url;
            Type = type;
        }
    }
}
