using System;
using System.Collections.Generic;
using System.Text;

namespace Housekeeper.Domain.Models
{
    public class Media
    {
        public string Name { get; protected set; }
        public string Url { get; protected set; }
        public MediaType Type { get; protected set; }
    }
}
