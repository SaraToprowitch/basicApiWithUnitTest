namespace Basic_API
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateOnly Start { get; set; }

        public Event(int id, string title, DateOnly start)
        {
            Id = id;
            Title = title;
            Start = start;
        }
        public Event()
        {

        }
    }
}
