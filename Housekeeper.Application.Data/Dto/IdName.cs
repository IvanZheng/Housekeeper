using System;
using System.Collections.Generic;
using System.Text;

namespace Housekeeper.Application.Contracts.Dto
{
    public class IdName
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public IdName() { }
        public IdName(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
