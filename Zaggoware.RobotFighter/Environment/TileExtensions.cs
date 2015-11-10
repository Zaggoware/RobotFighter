using Zaggoware.RobotFighter.Entities;
using Zaggoware.RobotFighter.Items;

namespace Zaggoware.RobotFighter.Environment
{
    internal static class TileExtensions
    {
        public static Tile UpdateRobot(this Tile tile, Robot robot)
        {
            return new Tile(tile.World.World, tile.X, tile.Y, tile.IsObstacle, robot, tile.Item);
        }

        public static Tile UpdateItem(this Tile tile, Item item)
        {
            return new Tile(tile.World.World, tile.X, tile.Y, tile.IsObstacle, tile.Robot, item);
        }
    }
}
