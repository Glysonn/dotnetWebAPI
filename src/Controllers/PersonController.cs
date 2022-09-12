//  Importing ASP.Net Core
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//  Importing Models namespace
using src.Models;
using src.Persistence;

namespace src.Controllers;

//  Saying the class bellow (PersonController) is an API
[ApiController]
/* Creating a new Route. The "[controller]" will be replaced by
the controller class name (PersonController)  */
[Route("[controller]")]
public class PersonController : ControllerBase
{

    private DatabaseContext _context { get; set; }

    public PersonController(DatabaseContext context)
    {
        this._context = context;
    }

    //  Using the Get HTTP method
    [HttpGet]
    //  Creating a Person (model class) method type
    public List<Person> GetPessoa()
    {
        _context.Pessoas.ToList();
        //  Returning the object is only possible 'cause the method type is Person (model class)
        return _context.Pessoas.Include( p => p.Contracts).ToList();
    }

    [HttpPost]
    public Person PostPessoa(Person pessoa)
    {
        _context.Pessoas.Add(pessoa);
        _context.SaveChanges();
        return pessoa;
    }

    [HttpPut("{id}")]
    public string UpdatePessoa([FromRoute]int id, [FromBody]Person pessoa)
    {
        _context.Update(pessoa);
        _context.SaveChanges();
        return $"ID {id} from Person {pessoa.Name} status: updated.";
    }

    [HttpDelete ("{id}")]
    public string DeletePessoa([FromRoute]int id)
    {
        var result = _context.Pessoas.SingleOrDefault( e => e.Id == id);
        _context.Remove(result);
        _context.SaveChanges();
        return $"The person which ID was {id} was deleted.";
    }

}
