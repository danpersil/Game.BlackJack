using CAPCO.Game.BackJack.Application.Interface;
using CAPCO.Game.BackJack.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace CAPCO.Game.BlackJack.UI.Controllers
{
    [Route("api/GameController")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ICache _cache;
        private readonly IGameApp _gameApp;

        public GameController(ICache cache, IGameApp gameApp)
        {
            _cache = cache;
            _gameApp = gameApp;
        }

        [HttpGet("NewGame/user")]
        public IActionResult NewGame(string user)
        {
            var currentGame = _gameApp.NewGame(user, _cache);
            return Ok(currentGame);
        }


        [HttpGet("NextTurn/key/newCard")]
        public IActionResult GetNewCard(string key, bool newCard)
        {
            GameSession currentGame = _cache.GetCache(key);
            currentGame.GameInfo.GameTable = _gameApp
                .NextTurn(currentGame.GameInfo.GameTable, currentGame.GameInfo.CurrentDeck);
            return Ok(currentGame);
        }
    }
}