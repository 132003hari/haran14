using System.ComponentModel.DataAnnotations;

namespace Gamestore.api.Dtos;
public record GameDto(
    int Id,
    String Name,
    decimal Price,
    DateTime Releasedate,
    String Imageuri
);
public record CreateGameDto(
   [Required] [StringLength (30)]String Name,
   [Range (1,100)] decimal Price,
    DateTime Releasedate,
    [Url] [StringLength(50)] String Imageuri
);
public record UpdateGameDto(
   [Required] [StringLength (30)]String Name,
   [Range (1,100)] decimal Price,
    DateTime Releasedate,
    [Url] [StringLength(50)] String Imageuri
);

