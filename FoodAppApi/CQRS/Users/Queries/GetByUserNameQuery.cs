using FoodAppApi.DTO;
using FoodAppApi.Exceptions;
using FoodAppApi.Models;
using FoodAppApi.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FoodAppApi.CQRS.Users.Queries
{
    public record GetByUserNameQuery(string UserName):IRequest<ResultVM<User>>;
    public class GetUserByNameHandler : BaseRequestHandler<User,GetByUserNameQuery, ResultVM<User>>
    {
        public GetUserByNameHandler(RequestParameters<User> requestParameters):base(requestParameters) { }
       
        public override async Task<ResultVM<User>> Handle(GetByUserNameQuery request, CancellationToken cancellationToken)
        {
            var user =await _baseRepository.GetAll().FirstOrDefaultAsync(u=>u.UserName==request.UserName);
            if(user == null)
            {
                return ResultVM<User>.Failure(ErrorCode.InvalidUserName,"invalid user name");
            }
            return ResultVM<User>.Success(user);

        }
    }
}
