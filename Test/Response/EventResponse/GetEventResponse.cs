using Test.Response.EventResponse.Additional;

namespace Test.Response.EventResponse
{
    public class GetEventResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Discription { get; set; } = String.Empty;
        public string Plan { get; set; } = String.Empty;
        public DateTime CreatedDate { get; set; }
        public OrganizerAdditional? Organizer { get; set; }
        public int OrganizerId { get; set; }
        public SpeakerAdditional? Speaker { get; set; }
        public int SpeakerId { get; set; }
        public PlaceAdditional? Place { get; set; }
        public int PlaceId { get; set; }
    }
}
