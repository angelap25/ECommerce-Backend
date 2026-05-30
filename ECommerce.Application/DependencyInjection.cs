using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ECommerce.Application.Behaviors;

namespace ECommerce.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(
        typeof(DependencyInjection).Assembly);

    cfg.AddOpenBehavior(
        typeof(ValidationBehavior<,>));

    cfg.AddOpenBehavior(
        typeof(LoggingBehavior<,>));
});

services.AddValidatorsFromAssembly(
    typeof(DependencyInjection).Assembly);

        return services;
    }
}