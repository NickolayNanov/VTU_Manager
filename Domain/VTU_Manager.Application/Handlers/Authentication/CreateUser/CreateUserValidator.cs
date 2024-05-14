using FluentValidation;

namespace VTU_Manager.Application.Handlers.Authentication.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            this.RuleFor(x => x.Email)
                        .NotNull()
                            .WithMessage("Can't be null Email")
                        .NotEmpty()
                            .WithMessage("Email can't be Email");

            this.RuleFor(x => x.Password)
                        .NotNull()
                            .WithMessage("Can't be null Password")
                        .NotEmpty()
                            .WithMessage("Email can't be Password");
        }
    }
}
