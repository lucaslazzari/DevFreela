using DevFreela.Application.Commands.UpdateProject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Validators
{
    public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator()
        {
            RuleFor(p => p.Title)
                .MaximumLength(30)
                .WithMessage("Tamanho maximo do titulo é de 30 caracteres");
            RuleFor(p => p.Title)
                .NotEmpty()
                .WithMessage("Titulo não pode ser vazio");

            RuleFor(p => p.Description)
                .MaximumLength(255)
                .WithMessage("Tamanho maximo da descrição é de 255 caracteres");
        }
    }
}
