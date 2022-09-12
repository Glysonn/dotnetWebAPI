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
        builder.Entity<Contract> (tabela =>{
            //  HasKey() means "tabela" has a primary key (it's Id).
            //  "e" is just a representation of my model class (Contract). It could be named anyway.
            tabela.HasKey(e => e.Id);
        });

        //  Person model now is a Table
        builder.Entity<Person> (tabela=>{
            tabela.HasKey(e=>e.Id);

            //  relating table Person to Contract
            tabela
            .HasMany(e => e.Contracts)  //  (one person can have many contracts)
            .WithOne()  //  for each contract
            .HasForeignKey(c => c.PersonID);    //  using the foreign key which relate them
        });
    }
}