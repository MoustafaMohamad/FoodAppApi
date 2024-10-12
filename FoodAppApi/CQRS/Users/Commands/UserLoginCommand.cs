using FoodAppApi.CQRS.Users.Queries;
using FoodAppApi.DTO;
using FoodAppApi.Helpers;
using FoodAppApi.Models;
using FoodAppApi.ViewModels;
using MediatR;

namespace FoodAppApi.CQRS.Users.Commands
{

    public record UserLoginCommand(string UserName, string Password) :IRequest<ResultVM<string>>;

    public class UserLoginHandler : BaseRequestHandler<User,UserLoginCommand, ResultVM<string>>
    {
        public UserLoginHandler(RequestParameters<User> requestParameters):base(requestParameters) { }
        
        public override async Task<ResultVM<string>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
           var result=await _mediator.Send(new GetByUserNameQuery(request.UserName));
            if (result.IsSuccess)
            {
                var user = result.Data;
                if(user.Password==request.Password)
                {
                  var token= TokenHandler.GenerateToken(user);
                    return ResultVM<string>.Success(token);
                }
            }
            return ResultVM<string>.Failure(result.ErrorCode, "UserName or password are wrong");

        }
    }
}
