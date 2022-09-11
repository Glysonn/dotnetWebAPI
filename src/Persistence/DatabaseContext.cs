using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Persistence;

public class DatabaseContext : DbContext
{
    public DatabaseContext (DbContextOptions<DatabaseContext> options)
    {

    }
    //  declaring what are the entities in a Data Base context
    public DbSet<Contract> Contratos { get; set; }
    public DbSet<Person> Pessoas { get; set; }


}