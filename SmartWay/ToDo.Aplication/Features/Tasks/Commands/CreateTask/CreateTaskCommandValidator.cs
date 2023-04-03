using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Application.Features.Tasks.Commands.CreateTask
{
    internal class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(p => p.Title).NotEmpty().WithMessage("{Title} no puede estar en blanco")
                .NotNull()
                .MaximumLength(50)
                .WithMessage("{Title} no puede exceder los 50 caracteres");

            RuleFor(p => p.Description).NotEmpty().WithMessage("La {Description} no puede estar en blanco");
        }
    }
}
