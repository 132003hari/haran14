using System.Security.Cryptography.X509Certificates;
using Gamestore.api.Dtos;
using Gamestore.api.entities;
using Gamestore.api.Repositaries;

namespace Gamestore.api.ENDPOINTS;

public static class GamesEndpoints 
{
     const string GetGameendpointName="GetGame";
      public static RouteGroupBuilder MapgameEndpoints(this IEndpointRouteBuilder routes)
    {
 
   var group=routes.MapGroup("/games")
        .WithParameterValidation();

        group.MapGet("/", async(IGamesRepositary repositary) => 
      (await  repositary.GetAllAsync()).Select(game=>game.AsDto()));
        group.MapGet("/{id}",async(IGamesRepositary repositary,int id) =>

        {
            Game? game =await repositary.GetAsync(id);
                       return game is not null? Results.Ok(game.AsDto()):Results.NotFound();    
                            })
        .WithName(GetGameendpointName);
        group.MapPost("/",async(IGamesRepositary repositary,CreateGameDto gameDto)=>
        {
             Game game=new()
             {
                Name=gameDto.Name,
                Price=gameDto.Price,
                Releasedate=gameDto.Releasedate,
                Imageuri=gameDto.Imageuri
              };
            await repositary.CreateAsync(game);
                return Results.CreatedAtRoute(GetGameendpointName,new{id=game.Id},game);
        });

        group.MapPut("/{id}",async(IGamesRepositary repositary,int id,UpdateGameDto updateGameDto )=>
        {
             Game? existingame = await repositary.GetAsync(id);
            if (existingame == null)
            {
               return Results.NotFound();
            }
            existingame.Name=updateGameDto.Name;
            existingame.Price=updateGameDto.Price;
            existingame.Releasedate=updateGameDto.Releasedate;
            existingame.Imageuri=updateGameDto.Imageuri;
         await repositary.UpdateAsync(existingame);
            return Results.NoContent();

        });
        group.MapDelete("/{id}",async (IGamesRepositary repositary,int id)=>
        {
  Game? game =await repositary.GetAsync(id); 
            if (game is not null)
            {
              await  repositary.DeleteAsync(id);
            }
            return Results.NoContent();
        });
        return group;
    }


}
