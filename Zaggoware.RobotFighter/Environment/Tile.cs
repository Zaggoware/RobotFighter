using Zaggoware.RobotFighter.Entities;
using Zaggoware.RobotFighter.Items;

namespace Zaggoware.RobotFighter.Environment
{
    public struct Tile
    {
        internal Tile(int x, int y, bool isObstacle)
        {
            X = x;
            Y = y;
            Robot = null;
            Item = null;
            IsObstacle = isObstacle;
        }

        internal Tile(int x, int y, bool isObstacle, Robot robot, Item item)
            : this(x, y, isObstacle)
        {
            Robot = robot;
            Item = item;
        }

        public bool IsObstacle { get; }
        public Item Item { get; }
        public Robot Robot { get; }
        public int X { get; }
        public int Y { get; }

        internal static Tile Empty => new Tile(0, 0, false);

        public static bool operator ==(Tile a, Tile b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        public static bool operator !=(Tile a, Tile b)
        {
            return a.X != b.X || a.Y != b.Y;
        }

        public override bool Equals(object obj)
        {
            if (obj is Tile)
            {
                var other = (Tile)obj;

                return other.X == X && other.Y == Y;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}