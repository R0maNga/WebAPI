namespace BLL.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Discription { get; set; } = String.Empty;
        public string Plan { get; set; } = String.Empty;
        public DateTime CreatedDate { get; set; }
        public Organizer Organizer { get; set; }
        public int OrganizerId { get; set; }
        public Speaker Speaker { get; set; }
        public int SpeakerId { get; set; }
        public Place Place { get; set; }
        public int PlaceId { get; set; }

    }
}
