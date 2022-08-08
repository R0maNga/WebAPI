namespace BLL.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public List<Organizer> Organizers { get; set; }
        public List<Speaker> Speakers { get; set; }

    }
}
