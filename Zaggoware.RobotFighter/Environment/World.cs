using System;

using Zaggoware.RobotFighter.Entities;
using Zaggoware.RobotFighter.Items;

namespace Zaggoware.RobotFighter.Environment
{
    internal class World
    {
        public World(Game game, int width, int height)
        {
            this.game = game;
            Width = width;
            Height = height;

            RobotManager = new RobotManager(game);
            ItemManager = new ItemManager(game);
            Tiles = new Tile[width, height];

            var r = new Random();

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    var isObstacle = r.Next(0, 10) % 4 == 0;

                    Tiles[x, y] = new Tile(x, y, isObstacle);
                }
            }
        }

        internal RobotManager RobotManager { get; }
        internal ItemManager ItemManager { get; private set; }
        internal int Width { get; }
        internal int Height { get; }
        internal Tile[,] Tiles { get; }

        private readonly Game game;

        public void Update()
        {
            //RobotManager.Update();
        }

        public bool MoveRobot(Robot robot)
        {
            var newTile = robot.CurrentTile;

            switch (robot.FacingDirection)
            {
                case Direction.Up:
                    if (robot.CurrentTile.Y > 0)
                    {
                        newTile = Tiles[robot.CurrentTile.X, robot.CurrentTile.Y - 1];
                    }
                    break;

                case Direction.Right:
                    if (robot.CurrentTile.Y < Height - 1)
                    {
                        newTile = Tiles[robot.CurrentTile.X + 1, robot.CurrentTile.Y];
                    }
                    break;

                case Direction.Down:
                    if (robot.CurrentTile.Y < Height - 1)
                    {
                        newTile = Tiles[robot.CurrentTile.X, robot.CurrentTile.Y + 1];
                    }
                    break;

                case Direction.Left:
                    if (robot.CurrentTile.X > 0)
                    {
                        newTile = Tiles[robot.CurrentTile.X - 1, robot.CurrentTile.Y];
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
            var robot = RobotManager.CreateRobot<T>();
            robot.Spawn(this);

            var r = new Random();
            var x = r.Next(0, Width);
            var y = r.Next(0, Height);

            Tiles[x, y] = new Tile(x, y, false);

            robot.CurrentTile = Tiles[x, y];

            return robot;
        }

        public bool IsObstacle(int x, int y)
        {
            return Tiles[x, y].IsObstacle;
        }
    }
}
