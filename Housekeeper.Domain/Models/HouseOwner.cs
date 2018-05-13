namespace Housekeeper.Domain.Models
{
    public class HouseOwner
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
    }
}