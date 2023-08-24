using System.Numerics;
using Gamestore.api.entities;

namespace Gamestore.api.Repositaries;
public class InMemGamesRepositary:IGamesRepositary
    {
private readonly List<Game> games = new()
{
new Game()
{
Id   =1,
Name ="street fighting",
Price=99.9M,
Releasedate=new DateTime(1991,9,2),
Imageuri="http://placehold.co/100"
}, 

new Game()
{
Id   =3,
Name ="street fighting",
Price=99.9M,
Releasedate=new DateTime(1991,12,21),
Imageuri="http://placehold.co/100"
},
new Game()
{
Id   =3,
Name ="street fighting",
Price=99.9M,
Releasedate=new DateTime(1991,4,12),
Imageuri="http://placehold.co/100"
}
};
    public async Task <IEnumerable<Game>> GetAllAsync()
    {
        return await Task.FromResult(games);
    }
    public async Task <Game?> GetAsync(int id)
    {
        return await Task.FromResult (games.Find(games => games.Id == id));
    }
    public  async Task  CreateAsync(Game game)
    {
        game.Id = games.Max(game => game.Id) + 1;
        games.Add(game);
        await Task.CompletedTask;

    }
    public  async Task UpdateAsync(Game updategame)
    {
        var index = games.FindIndex(game => game.Id == updategame.Id);
        games[index] = updategame;
        await Task.CompletedTask;

    }
    public async Task DeleteAsync(int id)
    {
        var index = games.FindIndex(game => game.Id == id);
        games.RemoveAt(index);
        await Task.CompletedTask ;


    }
}



