namespace FinFriend.Models
{
    public class Neighborhood
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static Neighborhood EMPTY = new Neighborhood() { Id = 0, Name = "" };
    }
}
