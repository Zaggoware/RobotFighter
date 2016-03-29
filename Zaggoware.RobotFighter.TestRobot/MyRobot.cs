using Zaggoware.RobotFighter.Entities;

namespace Zaggoware.RobotFighter.TestRobot
{
    public class MyRobot : Robot
    {
        public override string Name => "My Robot";
        public override string ColorCode => "#880000";

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

                    if (tile?.Robot != null && tile?.Robot != this)
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

            if (robot != null && robot.IsAlive)
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
