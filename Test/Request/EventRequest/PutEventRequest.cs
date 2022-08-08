namespace Test.Request.EventRequest
{
    public class PutEventRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public string Plan { get; set; }
        public DateTime CreatedDate { get; set; }
        
        public int SpeakerId { get; set; }
        
        public int PlaceId { get; set; }
        public int OrganizerId { get; set; }
    }
}
