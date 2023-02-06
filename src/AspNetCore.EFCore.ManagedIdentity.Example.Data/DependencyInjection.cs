using AspNetCore.CRUD.Example.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCore.CRUD.Example.Data;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureEntityFramework(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BooksDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString(nameof(BooksDbContext));
            options.UseSqlServer(connectionString, op => op.MigrationsAssembly(typeof(BooksDbContext).Assembly.FullName));
        });

        return services;
    }

    public static IServiceCollection ConfigureDataDependencies(this IServiceCollection services)
    {
        services.AddScoped<IBooksRepository, BooksRepository>();

        return services;
    }
}
