using DevFreela.Application.Commands.CreateComment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Validators
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(c => c.Content)
                .MaximumLength(255)
                .WithMessage("Comentario nao deve conter mais de 255 caracteres");
            RuleFor(c => c.Content)
                .NotEmpty()
                .WithMessage("Comentario nao pode ser vazio");

            RuleFor(c => c.IdProject)
                .NotNull()
                .WithMessage("Id do projeto nao pode ser nulo");

            RuleFor(c => c.IdUser)
                .NotNull()
                .WithMessage("Id do usuario nao pode ser nulo");
        }
    }
}
