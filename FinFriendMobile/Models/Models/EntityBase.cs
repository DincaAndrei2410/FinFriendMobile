using SQLite;

namespace Models.Models
{
    public class EntityBase
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
    }
}