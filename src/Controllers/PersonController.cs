//  Importing ASP.Net Core
using Microsoft.AspNetCore.Mvc;
//  Importing Models namespace
using src.Models;

namespace src.Controllers;

//  Saying the class bellow (PersonController) is an API
[ApiController]
/* Creating a new Route. The "[controller]" will be replaced by
the controller class name (PersonController)  */
[Route("[controller]")]
public class PersonController : ControllerBase
{

    //  Using the Get HTTP method
    [HttpGet]
    //  Creating a Person (model class) method type
    public Person GetPessoa()
    {
        Person pessoa = new Person("Glyson", 17, 10, true);
        Contract newContract = new Contract(15.5, "ABC321");

        pessoa.Contracts.Add(newContract);
        //  Returning the object is only possible 'cause the method type is Person (model class)
        return pessoa;
    }

    [HttpPost]
    public Person PostPessoa(Person pessoa)
    {
        return pessoa;
    }

    [HttpPut("{id}")]
    public string UpdatePessoa([FromRoute]int id, [FromBody]Person pessoa)
    {
        return $"ID {id} from Person {pessoa.Name} status: updated.";
    }

    [HttpDelete ("{id}")]
    public string DeletePessoa([FromRoute]int id)
    {
        return $"The person which ID was {id} was deleted.";
    }

}
