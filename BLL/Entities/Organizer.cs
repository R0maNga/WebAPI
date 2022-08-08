namespace BLL.Entities
{
    public class Organizer
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
        public List<Event> Events { get; set; }
    }
}
