using FluentValidation;
using FluentValidation.Results;
using VTU_Manager.Domain.Interfaces.Validators;

namespace VTU_Manager.Application
{
    public class ApplicationValidator<TRequest> : AbstractValidator<TRequest>, IApplicationValidator<TRequest>
    {
        private readonly IValidator<TRequest> validator;

        public ApplicationValidator(IValidator<TRequest> validator)
        {
            this.validator = validator;
        }

        public async Task ValidateAndThrowAsync(TRequest request, CancellationToken token = default)
        {
            await this.validator.ValidateAndThrowAsync(request, token);
        }

        public async Task<ValidationResult> ValidateAsync(IValidationContext validationContext, CancellationToken token = default)
        {
            return await this.validator.ValidateAsync(validationContext, token);
        }
    }
}
