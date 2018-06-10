using System;
using System.Collections.Generic;
using System.Text;

namespace Housekeeper.Domain.Models
{
    public interface IUpdatable
    {
        void UpdateModification();
        void UpdateCreation();
    }
}
