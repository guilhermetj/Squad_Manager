using Microsoft.EntityFrameworkCore;
using Squad_Manager.Model.Entity;
using Task = Squad_Manager.Model.Entity.Task;

namespace Squad_Manager.Data;

public class SquadManagerContext : DbContext
{
    public SquadManagerContext(DbContextOptions<SquadManagerContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Squad> Squads { get; set; }
    public DbSet<Task> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


        builder.Entity<User>().Property(x => x.Email).IsRequired();
        builder.Entity<User>().Property(x => x.Password).IsRequired();

        builder.Entity<Person>().Property(x => x.User_id).IsRequired();
        builder.Entity<Person>().HasOne(x => x.User).WithOne(p => p.Person).HasForeignKey<User>(x => x.Id);
        builder.Entity<Person>().HasOne(x => x.Squad).WithMany(p => p.Person).HasForeignKey(x => x.Squad_Id);

        builder.Entity<Person>().Property(x => x.Squad_Id).IsRequired();

        builder.Entity<Task>().HasOne(x => x.Squad).WithMany(p => p.Task).HasForeignKey(x => x.Squad_id);
    }
    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {
        configuration.Properties<string>().HaveMaxLength(100);
    }
}