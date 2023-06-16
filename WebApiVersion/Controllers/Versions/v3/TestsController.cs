using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiVersion.Controllers.Versions.v3
{
  [Route("api/[controller]")]
  [ApiController]
  [ApiVersion("3.0")]
  [ApiVersion("4.0")]
  public class TestsController : ControllerBase
  {

    [HttpGet,MapToApiVersion("3.0")]
    public IActionResult GetV3()
    {
      return Ok(HttpContext.GetRequestedApiVersion().ToString());
    }


    [HttpGet,MapToApiVersion("4.0")]
    public IActionResult GetV4()
    {
      return Ok(HttpContext.GetRequestedApiVersion().ToString());
    }

  }
}
