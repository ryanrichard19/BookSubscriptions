using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using BookSubscriptions.Api.Presenters;
using BookSubscriptions.Core.Dto;
using BookSubscriptions.Core.Dto.UseCaseResponses;
using Newtonsoft.Json;
using Xunit;

namespace BookSubscriptions.API.UnitTests.Presenters
{
    public class LoginPresenterUnitTests
    {
        [Fact]
        public void Contains_Ok_Status_Code_When_Use_Case_Succeeds()
        {
            // arrange
            var presenter = new LoginPresenter();

            // act
            presenter.Handle(new LoginResponse(new Token("", "", 0), true));

            // assert
            Assert.Equal((int)HttpStatusCode.OK, presenter.ContentResult.StatusCode);
        }

        [Fact]
        public void Contains_Errors_When_Use_Case_Fails()
        {
            // arrange
            var presenter = new LoginPresenter();

            // act
            presenter.Handle(new LoginResponse(new[] { new Error("", "Invalid email/password") }));

            // assert
            var data = JsonConvert.DeserializeObject<IEnumerable<Error>>(presenter.ContentResult.Content);
            Assert.Equal((int)HttpStatusCode.Unauthorized, presenter.ContentResult.StatusCode);
            Assert.Equal("Invalid email/password", data.First().Description);
        }
    }
}
