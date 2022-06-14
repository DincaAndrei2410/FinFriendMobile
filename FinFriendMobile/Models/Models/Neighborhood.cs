using Models.Models;

namespace FinFriend.Models
{
    public class Neighborhood : EntityBase
    {
        public string Name { get; set; }

        public static Neighborhood EMPTY = new Neighborhood() { Id = 0, Name = "" };
    }
}
