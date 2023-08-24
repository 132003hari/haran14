using Gamestore.api.Dtos;

namespace Gamestore.api.entities;

public static  class EntityExtension
{
 public static GameDto AsDto(this Game game)

 {
return new GameDto(
    game.Id,
    game.Name,
    game.Price,
    game.Releasedate,
    game.Imageuri

);
 }  
}