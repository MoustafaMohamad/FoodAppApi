using FoodAppApi.Models;
using FoodAppApi.Repositories;
using MediatR;

namespace FoodAppApi.DTO
{
    public class RequestParameters<T> where T : BaseModel
    {
        public IMediator Mediator { get; set; }
        public UserState UserState { get; set; }
        public IBaseRepository<T> Repository { get; set; }

        public RequestParameters(IMediator mediator,
            UserState userState,IBaseRepository<T> repository )
        {
            Mediator = mediator;
            UserState = userState;
            Repository = repository;
        }
    }
}
