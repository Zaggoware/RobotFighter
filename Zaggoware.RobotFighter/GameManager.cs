using System.Collections.Generic;
using System.Linq;

namespace Zaggoware.RobotFighter
{
    public class GameManager
    {
        public static IEnumerable<Game> Games => games.AsEnumerable();

        private static readonly List<Game> games = new List<Game>();

        public static Game StartNewGame()
        {
            var game = new Game();

            games.Add(game);

            game.Initialize();
            game.Start();

            MemoryLogger.Log("Game started.");

            return game;
        }
    }
}
