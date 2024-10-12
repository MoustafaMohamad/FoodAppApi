using FoodAppApi.CQRS.Users.Queries;
using FoodAppApi.DTO;
using FoodAppApi.Helpers;
using FoodAppApi.Models;
using FoodAppApi.ViewModels;
using MediatR;
using Org.BouncyCastle.Crypto.Generators;

namespace FoodAppApi.CQRS.Users.NewFolder
{
    public record RegisterUserCommand(string Email,string UserName,string Password,string Phone,string Country): IRequest<ResultVM<bool>>;

    public class RegisterUserHandler : BaseRequestHandler<User,RegisterUserCommand, ResultVM<bool>>
    {

        public RegisterUserHandler(RequestParameters<User> requestParameters) : base(requestParameters)
        {

        }

        public override async Task<ResultVM<bool>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var result=await _mediator.Send(new GetByUserNameQuery(request.UserName));
            if (!result.IsSuccess)
            {
                return ResultVM<bool>.Failure(result.ErrorCode,"Error happened while register this user ");
            }
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.password);
            var user = request.MapOne<User>();
            user.Password = hashedPassword;
            user.Otp = OTPHelper.GenerateOtp();
            user.OtpExpiry = OTPHelper.SetOtpExpiry();

            _repository.Add(user);

            await EmailService.SendEmailAsync(user.Email, user.Name, user.Otp);
            _repository.SaveChanges();

            return ResultDTO<bool>.Sucess(true, "User Registered successfully");
        }
    }
}
