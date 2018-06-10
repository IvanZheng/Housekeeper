using IFramework.Domain;

namespace Housekeeper.Domain.Models
{
    public class Location : ValueObject<Location>
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public int Z { get; protected set; }

        protected Location()
        {

        }

        public Location(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}