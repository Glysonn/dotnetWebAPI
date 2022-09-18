using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using src.Models;
using src.Persistence;


namespace src.Controllers;

[ApiController]

[Route("[controller]")]
public class PersonController : ControllerBase
{

    private DatabaseContext _context { get; set; }

    public PersonController(DatabaseContext context)
    {
        this._context = context;
    }

    [HttpGet]
    public ActionResult<List<Person>> GetPessoa()
    {
        var result = _context.Pessoas.Include( p => p.Contracts).ToList();
        return (result.Any()) ? Ok(result) : NoContent();
    }

    [HttpPost]
    public ActionResult<Person> PostPessoa(Person pessoa)
    {
        try
        {
        _context.Pessoas.Add(pessoa);
        _context.SaveChanges();
        }
        catch
        {
            return BadRequest(new{
                Status = "ERROR: You did a bad request!",
                Status_Code = HttpStatusCode.BadRequest });
        }
        return Created("Your request was successful", pessoa);
    }

    [HttpPut("{id}")]
    public ActionResult<Object> UpdatePessoa([FromRoute]int id, [FromBody]Person pessoa)
    {
        var result = _context.Pessoas.SingleOrDefault( e => e.Id == id);
        if (result is null) return NotFound(new{
            Status="ERROR: Your ID doesn't existis!",
            Status_Code = HttpStatusCode.NotFound});
        try
        {
        _context.Update(pessoa);
        _context.SaveChanges();
        }
        catch
        {
            return BadRequest(new{
                Status = "Error: You did a bad request!",
                Status_Code = HttpStatusCode.BadRequest});
        }

        return Accepted(new{
            Status = $"ID {id} from Person {pessoa.Name} was: updated.",
            Status_Code = HttpStatusCode.Accepted});
    }

    

    [HttpDelete ("{id}")]
    public ActionResult<Object> DeletePessoa([FromRoute]int id)
    {
        var result = _context.Pessoas.SingleOrDefault( e => e.Id == id);
        if (result is null) return BadRequest(new {
            Status = "Error: You did a bad request!",
            Status_Code = HttpStatusCode.BadRequest});

        _context.Remove(result);
        _context.SaveChanges();

        return Ok(new{Status= $"The ID {id} person was deleted.",
        Status_Code = HttpStatusCode.OK});

    }
    
}
