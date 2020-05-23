using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookSubscriptions.Core.Dto.UseCaseRequests;
using BookSubscriptions.Core.Interfaces.UseCases;
using BookSubscriptions.Api.Presenters;

namespace BookSubscriptions.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginUseCase _loginUseCase;
        private readonly LoginPresenter _loginPresenter;

        public AuthController(ILoginUseCase loginUseCase, LoginPresenter loginPresenter)
        {
            _loginUseCase = loginUseCase;
            _loginPresenter = loginPresenter;
        }

        // POST api/auth/login
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] Models.Request.LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _loginUseCase.Handle(new LoginRequest(request.UserName, request.Password), _loginPresenter);
            return _loginPresenter.ContentResult;
        }
    }
}
