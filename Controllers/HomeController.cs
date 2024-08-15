using Microsoft.AspNetCore.Mvc;

namespace ESGENDPOINTS.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new { message = "running " });
        }
    }
}
