using Zaggoware.RobotFighter.Entities;

namespace Zaggoware.RobotFighter.TestRobot
{
    public class MyRobot : Robot
    {
        private int ticks;
        private int moves;

        protected override void Spawn()
        {
        }

        protected override void Update()
        {
            ticks++;

            if (ticks % 50 == 0)
            {
                if (FacingDirection == Direction.Left)
                {
                    var tile = InspectTile(Direction.Up | Direction.Left);

                    if (!tile.HasValue)
                    {
                        return;
                    }

                    if (moves < 5 && !tile.Value.IsObstacle)
                    {
                        Move();
                        moves++;
                    }
                    else 
                    {
                        TurnRight();
                        Move();
                        moves++;
                    }
                }
                else
                {
                    TurnRight();
                    Move();
                }
            }
        }
    }
}
