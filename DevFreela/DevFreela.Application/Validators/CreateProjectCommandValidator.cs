﻿using DevFreela.Application.Commands.CreateProject;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
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
