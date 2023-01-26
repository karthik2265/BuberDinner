using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Infrastructure.Authentication;
using BuberDinner.Infrastructure.Services;
// packages
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace BuberDinner.Application;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configManger)
  {
    services.Configure<JwtSettings>(configManger.GetSection(JwtSettings.SectionName));
    services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
    services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
    return services;
  }
}