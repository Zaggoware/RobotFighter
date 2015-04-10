using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaggoware.RobotFighter.Environment
{
    using Zaggoware.RobotFighter.Entities;
    using Zaggoware.RobotFighter.Items;

    internal class World
	{
        internal RobotManager RobotManager { get; private set; }

        internal ItemManager ItemManager { get; private set; }

        internal int Width
        {
            get
            {
                return this.width;
            }
        }

        internal int Height
        {
            get
            {
                return this.height;
            }
        }

        internal Tile[,] Tiles
        {
            get
            {
                return this.tiles;
            }
        }

        private readonly Game game;

        private readonly int width;

        private readonly int height;

        private readonly Tile[,] tiles;

		public World(Game game, int width, int height)
		{
            this.game = game;
            this.width = width;
            this.height = height;

            this.RobotManager = new RobotManager(game);
            this.ItemManager = new ItemManager(game);
		    this.tiles = new Tile[width, height];

		    var r = new Random();

		    for (var x = 0; x < width; x++)
		    {
		        for (var y = 0; y < height; y++)
		        {
		            var isObstacle = r.Next(0, 10) % 4 == 0;

                    this.tiles[x, y] = new Tile(x, y, isObstacle);
		        }
		    }
		}

        public void Update()
        {
            this.RobotManager.Update();
            this.RobotManager.Update();
        }

        public bool MoveRobot(Robot robot)
        {
            var newTile = robot.CurrentTile;

            switch (robot.FacingDirection)
            {
                case Direction.Up:
                    if (robot.CurrentTile.Y > 0)
                    {
                        newTile = tiles[robot.CurrentTile.X, robot.CurrentTile.Y - 1];
                    }
                    break;

                case Direction.Right:
                    if (robot.CurrentTile.Y < this.height - 1)
                    {
                        newTile = tiles[robot.CurrentTile.X + 1, robot.CurrentTile.Y];
                    }
                    break;

                case Direction.Down:
                    if (robot.CurrentTile.Y < this.height - 1)
                    {
                        newTile = tiles[robot.CurrentTile.X, robot.CurrentTile.Y + 1];
                    }
                    break;

                case Direction.Left:
                    if (robot.CurrentTile.X > 0)
                    {
                        newTile = tiles[robot.CurrentTile.X - 1, robot.CurrentTile.Y];
                    }
                    break;
            }

            if (!newTile.IsObstacle)
            {
                robot.CurrentTile = newTile;
            }

            return newTile != robot.CurrentTile;
        }

        public Robot CreateRobot<T>() where T : Robot
        {
            var robot = this.RobotManager.CreateRobot<T>();
            robot.Spawn(this);

            var r = new Random();
            var x = r.Next(0, this.width);
            var y = r.Next(0, this.Height);

            this.tiles[x, y] = new Tile(x, y, false);

            robot.CurrentTile = this.tiles[x, y];

            return robot;
        }

        public bool IsObstacle(int x, int y)
        {
            return this.tiles[x, y].IsObstacle;
        }
	}
}
