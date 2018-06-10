using IFramework.Domain;
using Housekeeper.Application.Contracts.Dto;

namespace Housekeeper.Domain.Models
{
    public class HouseOwner: ValueObject<HouseOwner>
    {
        public string Id { get; protected set; }
        public string Name { get; protected set; }

        protected HouseOwner()
        {

        }

        public HouseOwner(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public static implicit operator IdName(HouseOwner houseOwner) => new IdName(houseOwner.Id,
                                                                                    houseOwner.Name);

        public static implicit operator HouseOwner(IdName houseOwner) => new HouseOwner(houseOwner.Id,
                                                                                        houseOwner.Name);
    }
}