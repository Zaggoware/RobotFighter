using System;
using Zaggoware.RobotFighter.Entities;
using Zaggoware.RobotFighter.Environment;

namespace Zaggoware.RobotFighter.TestRobot
{
    public class MyRobot : Robot
    {
        public MyRobot(string name) : base(name)
        {
        }

        protected override void Spawn()
        {
        }

        protected override void Update()
        {
            Robot robot = null;
            var dirs = new[] { Direction.Up, Direction.Right, Direction.Down, Direction.Left };

            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    var tile = dirs[i] == dirs[j]
                        ? InspectTile(dirs[i]) 
                        : InspectTile(dirs[i] | dirs[j]);

                    if (tile?.Robot != null)
                    {
                        robot = tile.Value.Robot;
                        break;
                    }
                }

                if (robot != null)
                {
                    break;
                }
            }

            if (robot != null)
            {
                Attack(robot);
            }
            else
            {
                while (!CanMove)
                {
                    if (Randomizer.Between(0, 2) % 2 == 0)
                    {
                        TurnRight();
                    }
                    else
                    {
                        TurnLeft();
                    }
                }

                Move();
            }
        }
    }
}
