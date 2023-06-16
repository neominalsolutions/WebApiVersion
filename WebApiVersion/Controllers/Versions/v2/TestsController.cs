using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiVersion.Controllers.Versions.v2
{


  [ApiController]
  [Route("api/[controller]")]
  [ApiVersion("0.9", Deprecated = true)]
  [ApiVersion("2.0")]
  public class TestsController : ControllerBase
  {
    [HttpGet()]
    public IActionResult Get()
    {
      return Ok(HttpContext.GetRequestedApiVersion().ToString());
    }
  }



}
