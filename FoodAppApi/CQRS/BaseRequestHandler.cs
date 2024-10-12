using FoodAppApi.DTO;
using FoodAppApi.Models;
using FoodAppApi.Repositories;
using MediatR;

namespace FoodAppApi.CQRS
{
    public abstract class BaseRequestHandler<TEntity,TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse> where TEntity:BaseModel
    {
        protected readonly IMediator _mediator;
        protected readonly UserState _userState;
        protected readonly IBaseRepository<TEntity> _baseRepository;
        public BaseRequestHandler(RequestParameters<TEntity> requestParameters)
        {
            _baseRepository=requestParameters.Repository;
            _mediator = requestParameters.Mediator;
            _userState = requestParameters.UserState;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
