using AutoMapper;
using FoodAppApi.CQRS.Users.Commands;
using FoodAppApi.ViewModels.UsersVMs;

namespace FoodAppApi.ViewModels.Profiles
{
    public class UsersProfile:Profile
    {
        public UsersProfile()
        {
            CreateMap<LoginVM,UserLoginCommand>();
            
        }
    }
}
