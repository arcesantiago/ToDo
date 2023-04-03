using FluentValidation;
using ToDo.Application.Features.Tasks.Commands.CreateTask;

namespace ToDo.Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        public UpdateTaskCommandValidator()
        {
            RuleFor(p => p.Title).NotEmpty().WithMessage("{Title} no puede estar en blanco")
                .NotNull()
                .MaximumLength(50)
                .WithMessage("{Title} no puede exceder los 50 caracteres");

            RuleFor(p => p.Description).NotEmpty().WithMessage("La {Description} no puede estar en blanco");
        }
    }
}