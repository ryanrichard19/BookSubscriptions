using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookSubscriptions.Api.Presenters;
using BookSubscriptions.Core.Interfaces.UseCases;
using BookSubscriptions.Core.Dto.UseCaseRequests;
using Microsoft.AspNetCore.Cors;

namespace BookSubscriptions.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class AccountsController : ControllerBase
    {
        private readonly IRegisterUserUseCase _registerUserUseCase;
        private readonly RegisterUserPresenter _registerUserPresenter;

        public AccountsController(IRegisterUserUseCase registerUserUseCase, RegisterUserPresenter registerUserPresenter)
        {
            _registerUserUseCase = registerUserUseCase;
            _registerUserPresenter = registerUserPresenter;
        }

        // POST api/accounts
        [HttpPost]
        
        public async Task<ActionResult> Post([FromBody] Models.Request.RegisterUserRequest request)
        {
            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState);
            }
            await _registerUserUseCase.Handle(new RegisterUserRequest(request.FirstName,request.LastName,request.Email, request.Email, request.Password), _registerUserPresenter);
            return _registerUserPresenter.ContentResult;
        }
    }
}
