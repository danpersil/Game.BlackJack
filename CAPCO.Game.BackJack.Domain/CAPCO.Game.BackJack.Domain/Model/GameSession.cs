using System.IO;
using System.Runtime.Serialization;

namespace CAPCO.Game.BackJack.Domain.Model
{
    public class GameSession
    {
        [IgnoreDataMember]
        public string GameId { get; set; }

        [IgnoreDataMember]
        public string UserId { get; set; }

        public GameInfo GameInfo { get; set; }

        public GameSession(GameInfo gameInfo, string gameId, string userId)
        {
            GameInfo = gameInfo;
            GameId = gameId;
            UserId = userId;
        }


        public string GetConfigKey()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", "");
            UserId += "_" + path;

            path = Path.GetRandomFileName();
            path = path.Replace(".", "");
            GameId += "_" + path;

            return string.Format("{0}_{1}", GameId, UserId);
        }
    }
}
