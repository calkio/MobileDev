using SQLite;

namespace Lab4.Model
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Title { get; set; }

        public bool IsCompleted { get; set; }
    }
}
