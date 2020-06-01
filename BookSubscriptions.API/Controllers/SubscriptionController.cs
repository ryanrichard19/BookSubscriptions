using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookSubscriptions.Api.Presenters;
using BookSubscriptions.Core.Dto.UseCaseRequests;
using BookSubscriptions.Core.Interfaces.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BookSubscriptions.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    [AllowAnonymous]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscribeToBookUseCase _subscribeToBookUseCase;
        private readonly SubscribeToBookPresenter _subscribeToBookPresenter;
        public SubscriptionController(ISubscribeToBookUseCase subscribeToBookUseCase, SubscribeToBookPresenter subscribeToBookPresenter)
        {
            _subscribeToBookUseCase = subscribeToBookUseCase;
            _subscribeToBookPresenter = subscribeToBookPresenter;
        }

        [HttpPost]
        public async Task<ActionResult> BookSubscription([FromBody] Api.Models.Request.BookSubscriptionRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _subscribeToBookUseCase.Handle(new BookSubscriptionRequest(request.UserId, request.BookId), _subscribeToBookPresenter);
            return _subscribeToBookPresenter.ContentResult;
        }
    }
}