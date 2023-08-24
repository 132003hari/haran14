using Gamestore.api.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamestore.api.Data.Configurations;

public class GameConfiguartion : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.Property(game =>game.Price)
        .HasPrecision(5,2);
    }
}