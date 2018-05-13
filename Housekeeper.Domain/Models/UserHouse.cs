using System;
using System.Collections.Generic;
using System.Text;

namespace Housekeeper.Domain.Models
{
    public class UserHouse
    {
        public string UserId { get; protected set; }
        public string HouseId { get; protected set; }

        protected UserHouse()
        {

        }

        public UserHouse(string userId, string houseId)
        {
            UserId = userId;
            HouseId = houseId;
        }
    }
}
