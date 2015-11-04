using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

using Zaggoware.RobotFighter.Items;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Threading;

namespace Zaggoware.RobotFighter.Entities
{
    internal class RobotManager
    {
        public RobotManager(Game game)
        {
            this.game = game;
        }

        public IEnumerable<Robot> Robots => robots.Keys.AsEnumerable();

        private readonly Game game;
        private readonly Dictionary<Robot, Thread> robots = new Dictionary<Robot, Thread>();

        public Robot CreateRobot<T>() where T : Robot
        {
            var robot = Activator.CreateInstance<T>();

            if (robot.State == RobotState.Disconnected || robot.State == RobotState.Alive)
            {
                // TODO: throw exception?
                return null;
            }

            robot.Inventory = new Inventory(robot);

            var threadStart = new ThreadStart(() =>
            {
                while (robot.State == RobotState.Alive)
                {
                    UpdateRobot(robot);
                    Thread.Sleep(25);
                }
            });
            var thread = new Thread(threadStart);
            thread.IsBackground = true;
            thread.Start();

            robots.Add(robot, thread);

            return robot;
        }

        internal void Clear()
        {
            while (Robots.Any())
            {
                var robot = Robots.FirstOrDefault();

                if (robot != null)
                {
                    var thread = robots[robot];
                    thread.Abort();

                    robot.State = RobotState.Disconnected;
                    robots.Remove(robot);
                }
            }
        }

        private void UpdateRobot(Robot robot)
        {
            try
            {
                robot.Update(this);
            }
            catch (Exception exception)
            {
                MemoryLogger.Log(exception.Message);
            }
        }
    }
}