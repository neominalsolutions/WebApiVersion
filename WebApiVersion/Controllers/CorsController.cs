using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiVersion.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [EnableCors("TestCors")]
  public class CorsController : ControllerBase
  {

    [HttpGet]
    public IActionResult GET()
    {
      return Ok();
    }

    [HttpPost]
    public IActionResult POST()
    {
      return Ok();
    }

    [HttpPut]
    public IActionResult PUT()
    {
      return Ok();
    }

    [HttpDelete]
    public IActionResult DELETE()
    {
      return Ok();
    }
  }
}
