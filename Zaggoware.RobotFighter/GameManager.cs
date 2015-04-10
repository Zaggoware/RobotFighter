using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaggoware.RobotFighter
{
	public class GameManager
	{
	    private static readonly List<Game> games = new List<Game>();

	    public static IEnumerable<Game> Games
	    {
	        get
	        {
	            return games.AsEnumerable();
	        }
	    }

	    public static Game StartNewGame()
	    {
	        var game = new Game();

	        games.Add(game);

	        game.Initialize();
            game.Start();

	        return game;
	    }
	}
}
