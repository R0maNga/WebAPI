namespace BLL.Entities
{
    public class Speaker
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
        public List<Event> Events { get; set; }
    }
}
