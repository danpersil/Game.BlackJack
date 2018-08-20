using CAPCO.Game.BackJack.Application.Interface;
using CAPCO.Game.BackJack.Domain.Enum;
using CAPCO.Game.BackJack.Domain.Model;
using CAPCO.Game.BackJack.Infra.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CAPCO.Game.BlackJack.UI.Controllers
{
    [Route("api/GameController")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ICacheInfra _cache;
        private readonly IGameApp _gameApp;

        public GameController(ICacheInfra cache, IGameApp gameApp)
        {
            _cache = cache;
            _gameApp = gameApp;
        }

        [HttpGet("NewGame/user")]
        public IActionResult NewGame(string user)
        {
            var currentGame = _gameApp.NewGame(user);

            if (currentGame.GameTable.GameResult != GameResultEnum.NORESULT)
                return Ok(currentGame.GameTable.GetEndGameMessage());

            return Ok(currentGame);
        }


        [HttpGet("NextTurn/key/newCard")]
        public IActionResult NextTurn(string key, bool needCard)
        {
            GameSession currentGame = _cache.GetCache(key);

            if (currentGame != null)
            {
                if (currentGame.GameInfo.GameTable.GameResult == GameResultEnum.NORESULT)
                {
                    currentGame.GameInfo.GameTable = _gameApp
                        .NextTurn(currentGame.GameInfo.GameTable, currentGame.GameInfo.CurrentDeck, needCard);

                    _cache.UpdateCache(currentGame);
                }

                if (currentGame.GameInfo.GameTable.GameResult != GameResultEnum.NORESULT)
                {
                    return Ok(currentGame.GameInfo.GameTable.GetEndGameMessage());
                }

                return Ok(currentGame.GameInfo);
            }
            else
                return BadRequest("Reinicie o jogo");
        }

    }
}