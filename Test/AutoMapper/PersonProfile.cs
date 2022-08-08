using AutoMapper;
using Test.Request.OrganizerRequest;
using Test.Response.EventResponse.PersonResponse;

namespace Test.AutoMapper
{
    public class PersonProfile
    {
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {

                CreateMap<PostPersonRequest, BLL.Entities.Person>();
                CreateMap<PutPersonRequest, BLL.Entities.Person>();
                CreateMap<DeletePersonRequest, BLL.Entities.Person>();
                CreateMap<BLL.Entities.Person, GetPersonResponse>();

            }
        }
    }
}
