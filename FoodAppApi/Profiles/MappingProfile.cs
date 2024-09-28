using AutoMapper;

namespace FoodAppApi.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<string, string>();
            
        }
    }
}
