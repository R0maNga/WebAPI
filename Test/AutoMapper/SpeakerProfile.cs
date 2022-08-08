using AutoMapper;
using Test.Request.EventRequest;
using Test.Response.SpeakerResponse;

namespace Test.AutoMapper
{
    public class SpeakerProfile
    {
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {

                CreateMap<PostSpeakerRequest, BLL.Entities.Speaker>();
                CreateMap<PutSpeakerRequest, BLL.Entities.Speaker>();
                CreateMap<DeleteSpeakerRequest, BLL.Entities.Speaker>();
                CreateMap<BLL.Entities.Speaker, GetSpeakerResponse>();

            }
        }
    }
}
