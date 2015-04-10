using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaggoware.RobotFighter.Environment
{
    using Zaggoware.RobotFighter.Entities;

    public class WorldDescriptor
    {
        internal WorldDescriptor(World world)
        {
            this.World = world;
        }

        public int Width
        {
            get
            {
                return this.World.Width;
            }
        }

        public int Height
        {
            get
            {
                return this.World.Height;
            }
        }

        internal World World { get; set; }

        public Robot CreateRobot<T>() where T : Robot
        {
            return this.World.CreateRobot<T>();
        }

        public IEnumerable<RobotDescriptor> GetRobots()
        {
            return this.World.RobotManager.Robots.Select(r => new RobotDescriptor(r));
        }

        public bool IsObstacle(int x, int y)
        {
            return this.World.IsObstacle(x, y);
        }
    }
}
