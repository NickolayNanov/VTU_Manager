using FluentValidation;
using FluentValidation.Results;
using MediatR;
using VTU_Manager.Domain.Interfaces.Validators;

namespace VTU_Manager.Web.MediatR.RequestBehaviours
{
    public class AutoValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class, IRequest
    {
        private readonly IEnumerable<IApplicationValidator<TRequest>> validators;

        public AutoValidationBehavior(IEnumerable<IApplicationValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var validationFailures = await Task.WhenAll(
                this.validators.Select(validator => validator.ValidateAsync(context)));

            var errors = validationFailures
                .Where(validationResult => !validationResult.IsValid)
                .SelectMany(validationResult => validationResult.Errors)
                .Select(validationFailure => new ValidationFailure(
                    validationFailure.PropertyName,
                    validationFailure.ErrorMessage))
                .ToList();

            if (errors.Any())
            {
                throw new ValidationException(errors);
            }

            var response = await next();

            return response;
        }
    }
}
