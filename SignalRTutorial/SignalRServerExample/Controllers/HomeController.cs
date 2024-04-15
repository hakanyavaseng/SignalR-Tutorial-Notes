using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRServerExample.Business;

namespace SignalRServerExample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly MyBusiness myBusiness;

        public HomeController(MyBusiness myBusiness)
        {
            this.myBusiness = myBusiness;
        }

        [HttpGet("{message}")]
        public async Task<IActionResult> Index([FromRoute] string message)
        {
            await myBusiness.SendMessageAsync("Hello!");
            return Ok();
        }
    }
}
