using AspNetCore.CRUD.Example.Services;
using AspNetCore.CRUD.Example.Services.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCore.CRUD.Example.Models;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureEntityMapping(this IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile<BooksMappingProfile>();
        });

        return services;
    }

    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {

        services.AddScoped<IBooksService, BookService>();

        return services;
    }
}
