using Microsoft.EntityFrameworkCore;
using Squad_Manager.Model.Entity;

namespace Squad_Manager.Data;

public class SquadManagerContext : DbContext
{
    public SquadManagerContext(DbContextOptions<SquadManagerContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


        var place = builder.Entity<User>();

        place.Property(x => x.Name).IsRequired();
        place.Property(x => x.Email).IsRequired();
        place.Property(x => x.Password).IsRequired();
    }
    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {
        configuration.Properties<string>().HaveMaxLength(100);
    }
}