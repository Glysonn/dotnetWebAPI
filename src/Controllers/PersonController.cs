// Importing ASP.Net Core
using Microsoft.AspNetCore.Mvc;

namespace src.Controllers;

//  Saying the class bellow (PersonController) is an API
[ApiController]
/* Creating a new Route. The "[controller]" will be replaced by
the controller class name (PersonController)  */
[Route("[controller]")]
public class PersonController
{

    //  Using the Get HTTP method
    [HttpGet]
    public string hello()
    {
        return "Hello!";
    }
}