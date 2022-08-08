namespace Test.Request.EventRequest
{
    public class PostEventRequest
    {
        
        public string Name { get; set; }
        public string Discription { get; set; }
        public string Plan { get; set; }
        public string Head { get; set; }
        public DateTime CreatedDate { get; set; }
        
        public int SpeakerId { get; set; }
        
        public int PlaceId { get; set; }
        public int OrganizerId { get; set; }
    }
}
