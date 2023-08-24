using System.ComponentModel.DataAnnotations;

namespace Gamestore.api.entities
{
    public class Game
    {
       
     public int Id { get; set; }  
      [Required]
        [StringLength (30)]
     public required string Name { get; set; } 
     [Range (1,100)]
          public decimal Price { get; set; }
     public DateTime Releasedate { get; set; }
     [Url]
     [StringLength(50)]
     public required string Imageuri  { get; set; }

       
    }
    
}