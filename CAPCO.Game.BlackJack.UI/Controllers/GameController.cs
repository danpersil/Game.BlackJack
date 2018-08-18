using Microsoft.AspNetCore.Mvc;

namespace CAPCO.Game.BlackJack.UI.Controllers
{
    [Route("api/GameController")]
    [ApiController]
    public class GameController : ControllerBase
    {
        [HttpGet("NewGame")]
        public IActionResult NewGame()
        {
            return Ok();
        }
    }
}