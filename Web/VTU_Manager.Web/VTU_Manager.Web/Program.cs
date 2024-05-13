using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VTU_Manager.Domain.Entities;
using VTU_Manager.Persistance.Data;
using VTU_Manager.Web;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureServices();

WebApplication app = builder.Build();

app.ConfigureApplication();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dataContext.Database.Migrate();

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<VTUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<VTRole>>();

    await ApplicationDbContextSeed.SeedDefaultUserAsync(userManager, roleManager);
    //await ApplicationDbContextSeed.SeedSampleDataAsync(context);
    await ApplicationDbContextSeed.SeedEligibleEmails(dataContext);
    await ApplicationDbContextSeed.SeedDepartments(dataContext);
    await ApplicationDbContextSeed.SeedRerervedDropdowns(dataContext);
}

await app.RunAsync();
