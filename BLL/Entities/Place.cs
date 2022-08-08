namespace BLL.Entities
{
    public class Place
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public List<Event> Events { get; set; } = null;


    }
}
