using FoodAppApi.CQRS.Users.Commands;
using FoodAppApi.DTO;
using FoodAppApi.Helpers;
using FoodAppApi.ViewModels;
using FoodAppApi.ViewModels.UsersVMs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        public UserController(ControllerParameters controllerParameters ):base(controllerParameters)
        {
            
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            var test=loginVM.MapOne<UserLoginCommand>();
            var result=await _mediator.Send(loginVM.MapOne<UserLoginCommand>());
            if(result.IsSuccess )
            {
                return Ok( ResultVM<string>.Success(result.Data,""));
            }
            return Ok(ResultVM<string>.Failure(result.ErrorCode,result.Message));
        }
    }
}
