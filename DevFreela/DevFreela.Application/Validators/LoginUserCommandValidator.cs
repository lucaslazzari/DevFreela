using DevFreela.Application.Commands.LoginUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
