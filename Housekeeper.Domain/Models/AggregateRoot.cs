using System;
using System.Collections.Generic;
using System.Text;

namespace Housekeeper.Domain.Models
{
    public abstract class AggregateRoot: IFramework.Domain.AggregateRoot, IUpdatable
    {
        public DateTime CreatedTime { get; protected set; }
        public DateTime ModifiedTime { get; protected set; }


        public void UpdateCreation()
        {
            CreatedTime = ModifiedTime = DateTime.Now;
        }

        public void UpdateModification()
        {
            ModifiedTime = DateTime.Now;
        }
    }
}
