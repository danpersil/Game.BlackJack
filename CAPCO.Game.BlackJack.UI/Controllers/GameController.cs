using CAPCO.Game.BackJack.Application.Interface;
using CAPCO.Game.BackJack.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace CAPCO.Game.BlackJack.UI.Controllers
{
    [Route("api/GameController")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ICacheSetting _cache;

        public GameController(ICacheSetting cache)
        {
            _cache = cache;
        }

        [HttpGet("NewGame/user")]
        public IActionResult NewGame(string user)
        {

            GameSession gameData = new GameSession("Dados Jogo", "01", user);
            string key = _cache.CreateCache(gameData);

            return Ok(_cache.GetCache(key));
        }


    }
}