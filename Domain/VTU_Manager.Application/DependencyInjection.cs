using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using VTU_Manager.Application.Handlers;
using VTU_Manager.Domain.Interfaces.Validators;

namespace VTU_Manager.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayerDependencies(
            this IServiceCollection services,
            Action<IServiceCollection> registerMediatrProcessors)
        {
            services.AddValidatorsFromAssemblyContaining(typeof(ApplicationValidator<>));
            services.AddTransient(typeof(IApplicationValidator<>), typeof(ApplicationValidator<>));

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ApplicationHandler).Assembly);
            });

            registerMediatrProcessors(services);

            return services;
        }
    }
}
