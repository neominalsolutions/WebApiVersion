using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiVersion.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [ApiVersion("1.0")]
  [ApiVersion("2.0")]
  public class VersionsController : ControllerBase
  {
    [MapToApiVersion("1.0")]
    [HttpGet]
    public IActionResult Get()
    {
      return Ok("V1");
    }


    [HttpGet]
    [MapToApiVersion("2.0")]
    public IActionResult GetV2()
    {
      return Ok("V2");
    }
  }
}
