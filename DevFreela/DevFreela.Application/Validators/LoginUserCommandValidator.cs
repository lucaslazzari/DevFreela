using DevFreela.Application.Commands.LoginUser;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("Você deve digitar um e-mail");

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("Você deve digitar uma senha");
        }
    }
}
