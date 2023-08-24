using Gamestore.api.Data;
using Gamestore.api.entities;
using Gamestore.api.Repositaries;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.api.repositary;

public class EntityFrameworkrepositary : IGamesRepositary
{
    private readonly GameStoreContext  dbContext;

    public EntityFrameworkrepositary(GameStoreContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<Game>> GetAllAsync()
    {
       return  await dbContext.Games.AsNoTracking(). ToListAsync();
    }
    public async Task CreateAsync(Game game)
    {
        dbContext.Games.Add(game);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
       await dbContext.Games.Where(game=>game.Id==id)
       .ExecuteDeleteAsync();
    }

    public async Task<Game?> GetAsync(int id)
    {
        return  await dbContext.Games.FindAsync(id);
    }

    
    public async Task UpdateAsync(Game updateGame)
    {
        dbContext.Update(updateGame);
        await dbContext.SaveChangesAsync();

    }
}