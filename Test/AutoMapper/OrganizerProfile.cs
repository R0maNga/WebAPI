using AutoMapper;
using Test.Request.OrganizerRequest;
using Test.Response.OrganizerResponse;

namespace Test.AutoMapper
{
    public class OrganizerProfile
    {
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {

                CreateMap<PostOrganizerRequest, BLL.Entities.Organizer>();
                CreateMap<PutOrganizerRequest, BLL.Entities.Organizer>();
                CreateMap<DeleteOrganizerRequest, BLL.Entities.Organizer>();
                CreateMap<BLL.Entities.Organizer, GetOrganizerResponse>();

            }
        }
    }
}
