using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Persistence;

public class DatabaseContext : DbContext
{

    public DatabaseContext (DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<Contract> Contratos { get; set; } = default!;
    public DbSet<Person> Pessoas { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Contract> (tabela =>{
            tabela.HasKey(e => e.Id);
        });

        builder.Entity<Person> (tabela=>{
            tabela.HasKey(e=>e.Id);

            tabela
            .HasMany(e => e.Contracts)
            .WithOne()
            .HasForeignKey(c => c.PersonID);
        });
    }
}
