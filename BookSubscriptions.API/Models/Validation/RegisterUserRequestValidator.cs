using FluentValidation;
using BookSubscriptions.Api.Models.Request;

namespace BookSubscriptions.Api.Models.Validation
{
    public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserRequestValidator()
        {
            RuleFor(x => x.FirstName).Length(2, 30);
            RuleFor(x => x.LastName).Length(2, 30);
            RuleFor(x => x.Password).Length(6, 15);
        }
    }
}
