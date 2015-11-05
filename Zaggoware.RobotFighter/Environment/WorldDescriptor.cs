using System.Collections.Generic;
using System.Linq;

using Zaggoware.RobotFighter.Entities;

namespace Zaggoware.RobotFighter.Environment
{
    public class WorldDescriptor
    {
        internal WorldDescriptor(World world)
        {
            World = world;
        }

        public int Width => World.Width;
        public int Height => World.Height;

        internal World World { get; set; }

        public Robot CreateRobot<T>(string robotName) where T : Robot
        {
            return World.CreateRobot<T>(robotName);
        }

        public IEnumerable<RobotDescriptor> GetRobots()
        {
            return World.RobotManager.Robots.Select(r => new RobotDescriptor(r));
        }

        public bool IsObstacle(int x, int y)
        {
            return World.IsObstacle(x, y);
        }
    }
}
