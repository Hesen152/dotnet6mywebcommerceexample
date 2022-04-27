using System.Collections;
using System.Net;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace testwebapplication.Controllers;


[ApiController]
[Route("api/[controller]")]
public class JsonTestController:ControllerBase

{
    const string url= "https://jsonplaceholder.typicode.com/posts";

    [HttpGet]
    public IEnumerable GetAll()
    {




    }

}