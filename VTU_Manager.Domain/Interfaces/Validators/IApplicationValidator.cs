using FluentValidation;
using FluentValidation.Results;

namespace VTU_Manager.Domain.Interfaces.Validators
{
    public interface IApplicationValidator<in TRequest>
    {
        Task ValidateAndThrowAsync(TRequest request, CancellationToken token = default);

        Task<ValidationResult> ValidateAsync(IValidationContext validationContext, CancellationToken token = default);
    }
}
