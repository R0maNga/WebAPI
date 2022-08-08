using AutoMapper;
using Test.Request.EventRequest;
using Test.Response.EventResponse;
using Test.Response.EventResponse.Additional;

namespace Test.AutoMapper
{
    public class EventProfile
    {
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {

                CreateMap<PostEventRequest, BLL.Entities.Event>();
                CreateMap<DeleteEventRequest, BLL.Entities.Event>();
                CreateMap<PutEventRequest, BLL.Entities.Event>();
                CreateMap<BLL.Entities.Event, GetEventResponse>();
                CreateMap<BLL.Entities.Place, PlaceAdditional>();
                CreateMap<BLL.Entities.Speaker, SpeakerAdditional>();
                CreateMap<BLL.Entities.Organizer, OrganizerAdditional>();
                CreateMap<BLL.Entities.Person, PersonAdditional>();
            }
        }
    }
}
