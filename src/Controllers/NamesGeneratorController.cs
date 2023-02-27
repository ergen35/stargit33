using Microsoft.AspNetCore.Mvc;

namespace MinimalAPIS.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class NamesGeneratorController : ControllerBase
    {
        [HttpGet("get-name")]
        public IActionResult GetName()
        {
            return new ObjectResult(new { Name = "Hello, Barnabew" });
        }
    }
}
