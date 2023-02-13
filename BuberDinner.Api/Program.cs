using BuberDinner.Api.Middleware;
using BuberDinner.Application;
using BuberDinner.Api.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

{
  // adding application layer dependencies using an extension method
  builder.Services.
  AddApplication().
  AddInfrastructure(builder.Configuration);

  builder.Services.AddControllers();

  builder.Services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();

}

var app = builder.Build();

{
  // app.UseMiddleware<ErrorHandlingMiddleware>();
  app.UseExceptionHandler("/error");

  app.UseHttpsRedirection();

  app.MapControllers();

  app.Run();
}

