using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Persistence;

public class DatabaseContext : DbContext
{

        // "base" means the base class (the class it was inherited from, in this case DbContext).
        // I'm passing the var options as parameter
    public DatabaseContext (DbContextOptions<DatabaseContext> options) : base(options)
    {

    }

    //  declaring what are the entities in a Data Base context
    public DbSet<Contract> Contratos { get; set; }
    public DbSet<Person> Pessoas { get; set; }


    // OnModelCreating is a method that defines configurations when it's turning to a database context 
    protected override void OnModelCreating(ModelBuilder builder)
    {
        //  Contract model now is a Table
        builder.Entity<Contract> (e =>{});

        //  Person model now is a Table
        builder.Entity<Person> (e=>{});
    }
}