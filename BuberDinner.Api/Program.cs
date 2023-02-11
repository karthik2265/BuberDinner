using BuberDinner.Api.Middleware;
using BuberDinner.Application;
using BuberDinner.Api.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

{
  // adding application layer dependencies using an extension method
  builder.Services.
  AddApplication().
  AddInfrastructure(builder.Configuration);

  builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());

}

var app = builder.Build();

{
  // app.UseMiddleware<ErrorHandlingMiddleware>();

  app.UseHttpsRedirection();

  app.MapControllers();

  app.Run();
}

