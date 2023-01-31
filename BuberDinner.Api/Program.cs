using BuberDinner.Api.Middleware;
using BuberDinner.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

{
    // adding application layer dependencies using an extension method
    builder.Services.
    AddApplication().
    AddInfrastructure(builder.Configuration);

    builder.Services.AddControllers();

}

var app = builder.Build();

{
    app.UseMiddleware<ErrorHandlingMiddleware>();

    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}

