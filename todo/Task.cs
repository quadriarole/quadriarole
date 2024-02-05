namespace todo
{
    public class Task
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public Task(int id, string name, DateTime date)
        {
            Id = id;
            Name = name;
            Date = date;
        }
    }
}