using Microsoft.AspNetCore.Mvc;

namespace SanrioMarket.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error(){
        return Problem();
    }
}