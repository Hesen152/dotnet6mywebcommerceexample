using System.Collections;
using System.Net;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace testwebapplication.Controllers;


[ApiController]
[Route("api/[controller]")]
public class JsonTestController:ControllerBase

{
    
     TranscationContext _context;
     
    public JsonTestController(TranscationContext context)
    {
        _context = context;
    }
    
    const string url= "https://jsonplaceholder.typicode.com/posts";

    [HttpGet]
    public IEnumerable GetAll()
    {
        using (var transctioncontext=_context.Database.BeginTransaction())
        {
            try
            {
                transctioncontext.Commit();

            }
            catch 
            {
                transctioncontext.Rollback();
            
            }
            
        }



    }

}