using BuberDinner.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

{
  // adding application layer dependencies using an extension method
  builder.Services.
  AddApplication().
  AddInfrastructure();
  builder.Services.AddControllers();
}

var app = builder.Build();

{
  app.UseHttpsRedirection();

  app.MapControllers();

  app.Run();
}

