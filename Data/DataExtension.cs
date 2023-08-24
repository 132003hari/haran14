using Gamestore.api.Repositaries;
using Gamestore.api.repositary;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.api.Data;

public static class DataExtension
{
    public static async Task InitializeDb(this IServiceProvider serviceProvider)
    {
        using var scope=serviceProvider.CreateScope();
         var dbContext=scope.ServiceProvider.GetRequiredService<GameStoreContext>();
    await dbContext.Database.MigrateAsync();

    }
    public static IServiceCollection Addreposiatrires(
        this IServiceCollection Services,
        IConfiguration Configuration
        
    )
    {
        var connString =Configuration.GetConnectionString("GameStoreContext");
         Services.AddSqlServer<GameStoreContext>(connString)
                 .AddScoped<IGamesRepositary, EntityFrameworkrepositary>();
                 return Services;
    }
}