using AutoMapper;
using Test.Request.EventRequest;
using Test.Response.PlaceResponse;

namespace Test.AutoMapper
{
    public class PlaceProfile
    {
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {

                CreateMap<PostPlaceRequest, BLL.Entities.Place>();
                CreateMap<PutPlaceRequest, BLL.Entities.Place>();
                CreateMap<DeletePlaceRequest, BLL.Entities.Place>();
                CreateMap<BLL.Entities.Place, GetPlaceResponse>();

            }
        }
    }
}
