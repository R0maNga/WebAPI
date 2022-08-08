using BLL.Entities;

namespace Test.Request.OrganizerRequest
{
    public class PutPersonRequest
    {
        public string Name { get; set; } = String.Empty;
        public List<Organizer>? Organizers { get; set; }
        public List<Speaker>? Speaker { get; set; }
    }
}
