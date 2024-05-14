using MediatR;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using VTU_Manager.Application;
using VTU_Manager.Domain.Entities;
using VTU_Manager.Domain.Interfaces.Repositories;
using VTU_Manager.Domain.Interfaces.Services.Utility;
using VTU_Manager.Persistance;
using VTU_Manager.Persistance.Data;
using VTU_Manager.Persistance.Read;
using VTU_Manager.Persistance.Write;
using VTU_Manager.Web.Components;
using VTU_Manager.Web.Components.Account;
using VTU_Manager.Web.MappingProfiles;
using VTU_Manager.Web.MediatR.RequestBehaviours;
using VTU_Manager.Web.MediatR.ResponseBehaviours;
using VTU_Manager.Web.Services;

namespace VTU_Manager.Web
{
    public static class DependencyInjection
    {
        public static IHostApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            var services = builder.Services;

            // Add services to the container.
            services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();

            services.AddMudServices().AddMudBlazorDialog();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddAutoMapper(typeof(ApplicationProfile));
            
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            builder.Services.AddApplicationAuthentication();

            builder.Services.AddDatabase(builder.Configuration);

            builder.Services.AddIdentity();

            builder.Services.AddApplicationLayerDependencies(cs =>
            {
                AddRequestsHandlerProcessors(cs);
            });

            return builder;
        }

        public static WebApplication ConfigureApplication(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error", createScopeForErrors: true);
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            return app;
        }

        public static IServiceCollection AddApplicationAuthentication(this IServiceCollection services)
        {
            services.AddCascadingAuthenticationState();
            services.AddScoped<IdentityUserAccessor>();
            services.AddScoped<IdentityRedirectManager>();
            services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            }).AddIdentityCookies();

            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistance(configuration, serviceCollection =>
            {
                serviceCollection.AddScoped(typeof(IReadOnlyRepository<,>), typeof(ReadOnlyRepository<,>));
                serviceCollection.AddScoped(typeof(IMutatableRepository<,>), typeof(MutatableRepository<,>));
            });

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentityCore<VTUser>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequiredLength = 6;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.SignIn.RequireConfirmedEmail = false;
            }).AddRoles<VTRole>()
              .AddEntityFrameworkStores<ApplicationDbContext>()
              .AddSignInManager()
              .AddDefaultTokenProviders();

            return services;
        }

        private static IServiceCollection AddRequestsHandlerProcessors(this IServiceCollection services)
        {
            return services
                .PreProcessorOrder()
                .PostProcessorOrder();
        }

        private static IServiceCollection PreProcessorOrder(this IServiceCollection services)
        {
            return services
                .AddAutoValidationBehaviour();
        }

        private static IServiceCollection AddAutoValidationBehaviour(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(AutoValidationBehavior<,>));
        }

        private static IServiceCollection PostProcessorOrder(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
        }
    }
}
