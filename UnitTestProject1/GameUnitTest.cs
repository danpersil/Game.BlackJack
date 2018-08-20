using CAPCO.Game.BackJack.Application.App;
using CAPCO.Game.BackJack.Domain.Enum;
using CAPCO.Game.BackJack.Domain.Model;
using CAPCO.Game.BackJack.Infra.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CAPCO.Game.UnitTests
{
    [TestClass]
    public class GameUnitTest
    {
        private Mock<ICacheInfra> _mockCache;
        private GameApp _target;

        public GameUnitTest()
        {
            _mockCache = new Mock<ICacheInfra>();
            _target = new GameApp(_mockCache.Object);
        }


        #region "Player"

        [TestMethod]
        public void PlayerShouldHaveTwoCards()
        {
            GameInfo gameinfo = _target.NewGame("Teste");
            Assert.AreEqual(gameinfo.GameTable.Player.Cards.Count, 2);
        }

        [TestMethod]
        public void PlayerShouldDrawWithDealer()
        {
            GameInfo gameinfo = _target.NewGame("Teste");
            bool match = false;

            while (!match)
            {
                gameinfo = _target.NewGame("Teste");

                if (gameinfo.GameTable.Dealer.GetCurrentScore() == gameinfo.GameTable.Player.GetCurrentScore() && gameinfo.GameTable.Dealer.GetCurrentScore() == 21)
                    match = true;
            }


            Assert.AreEqual(gameinfo.GameTable.GameResult, GameResultEnum.DRAW);
        }

        [TestMethod]
        public void PlayerShouldLoseToDealer()
        {
            GameInfo gameinfo = _target.NewGame("Teste");
            bool match = false;

            while (!match)
            {
                gameinfo = _target.NewGame("Teste");

                if (gameinfo.GameTable.Dealer.GetCurrentScore() == 21 && gameinfo.GameTable.Player.GetCurrentScore() < 21)
                    match = true;
            }


            Assert.AreEqual(gameinfo.GameTable.GameResult, GameResultEnum.LOSE);
        }

        [TestMethod]
        public void PlayerShouldAddMoreCards()
        {
            GameInfo gameinfo = _target.NewGame("Teste");
            bool endmatch = false;

            while (!endmatch)
            {
                if (gameinfo.GameTable.Player.Cards.Count > 2)
                    endmatch = true;

                if (!endmatch)
                {
                    gameinfo.GameTable = _target.NextTurn(gameinfo.GameTable, gameinfo.CurrentDeck, true);

                    if (gameinfo.GameTable.Dealer.GetCurrentScore() >= 21 || gameinfo.GameTable.Player.GetCurrentScore() >= 21)
                        gameinfo = _target.NewGame("Teste");
                }
            }

            Assert.IsTrue(gameinfo.GameTable.Player.Cards.Count > 2);
        }

        [TestMethod]
        public void PlayerShouldWinIfDealerExceedsPoints()
        {
            GameInfo gameinfo = _target.NewGame("Teste");
            bool endmatch = false;

            while (!endmatch)
            {
                if (gameinfo.GameTable.Dealer.GetCurrentScore() > 21 && gameinfo.GameTable.Player.GetCurrentScore() < 21)
                    endmatch = true;

                if (!endmatch)
                {
                    gameinfo.GameTable = _target.NextTurn(gameinfo.GameTable, gameinfo.CurrentDeck, true);

                    if (gameinfo.GameTable.Dealer.GetCurrentScore() <= 21)
                        gameinfo = _target.NewGame("Teste");
                }
            }

            Assert.IsTrue(gameinfo.GameTable.GameResult == GameResultEnum.WIN);
        }

        [TestMethod]
        public void PlayerShouldLoseIfScores21OrMore()
        {
            GameInfo gameinfo = _target.NewGame("Teste");
            bool endmatch = false;

            while (!endmatch)
            {
                if (gameinfo.GameTable.Player.GetCurrentScore() > 21 && gameinfo.GameTable.Dealer.GetCurrentScore() < 21)
                    endmatch = true;

                if (!endmatch)
                {
                    gameinfo.GameTable = _target.NextTurn(gameinfo.GameTable, gameinfo.CurrentDeck, true);

                    if (gameinfo.GameTable.Dealer.GetCurrentScore() > 20)
                        gameinfo = _target.NewGame("Teste");
                }
            }

            Assert.IsTrue(gameinfo.GameTable.GameResult == GameResultEnum.LOSE);
        }

        #endregion "Player"

        #region "Dealer"

        [TestMethod]
        public void DealerShouldHaveTwoCards()
        {
            GameInfo gameinfo = _target.NewGame("Teste");
            Assert.AreEqual(gameinfo.GameTable.Dealer.Cards.Count, 2);
        }

        [TestMethod]
        public void DealerShouldShowOneCardOnly()
        {
            GameInfo gameinfo = _target.NewGame("Teste");
            while (gameinfo.GameTable.Dealer.Cards.FindAll(x => x.Shown).Count == 2)
                gameinfo = _target.NewGame("Teste");

            Assert.IsTrue(gameinfo.GameTable.Dealer.Cards.FindAll(x => x.Shown).Count == 1);
        }

        [TestMethod]
        public void DealerShouldShowSecondCardIs_A_Or_10()
        {
            GameInfo gameinfo = _target.NewGame("Teste");
            bool match = false;

            while (!match)
            {
                gameinfo = _target.NewGame("Teste");
                if (gameinfo.GameTable.Dealer.Cards
                    .Exists(x => x.Type == CardTypeEnum.Card_A || x.Type == CardTypeEnum.Card_10))
                    match = true;
            }

            Assert.IsTrue(gameinfo.GameTable.Dealer.Cards.FindAll(x => x.Shown).Count == 2);
        }

        [TestMethod]
        public void DealerShouldOpenOnly5Cards()
        {
            GameInfo gameinfo = _target.NewGame("Teste");
            bool endmatch = false;

            while (!endmatch)
            {
                if (gameinfo.GameTable.Dealer.Cards.Count == 5
                    && gameinfo.GameTable.Dealer.GetCurrentScore() < 17)
                    endmatch = true;

                if (!endmatch)
                {
                    gameinfo.GameTable = _target.NextTurn(gameinfo.GameTable, gameinfo.CurrentDeck, true);

                    if (gameinfo.GameTable.Dealer.GetCurrentScore() >= 21 || gameinfo.GameTable.Player.GetCurrentScore() >= 21)
                        gameinfo = _target.NewGame("Teste");
                }
            }

            Assert.IsTrue(gameinfo.GameTable.Dealer.GetCurrentScore() < 17);
        }

        #endregion "Dealer"

        #region "Gameplay"

        [TestMethod]
        public void GameShouldContinuetillFinalResult()
        {
            GameInfo gameinfo = _target.NewGame("Teste");
            bool endmatch = false;

            while (!endmatch)
            {
                if (gameinfo.GameTable.Dealer.GetCurrentScore() >= 21 || gameinfo.GameTable.Player.GetCurrentScore() >= 21)
                    endmatch = true;

                if (!endmatch)
                    gameinfo.GameTable = _target.NextTurn(gameinfo.GameTable, gameinfo.CurrentDeck, true);
            }

            Assert.IsTrue(gameinfo.GameTable.GameResult != GameResultEnum.NORESULT);
        }




        #endregion "Gameplay"
    }
}
