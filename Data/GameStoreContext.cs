using System.Reflection;
using Gamestore.api.entities;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.api.Data;

public class GameStoreContext: DbContext
{
   public GameStoreContext(DbContextOptions<GameStoreContext>options)
   :base(options)
   {
    } 
    public DbSet <Game> Games=>Set<Game>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}