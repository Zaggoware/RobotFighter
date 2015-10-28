using System.Threading;
using Zaggoware.RobotFighter.Entities;

namespace Zaggoware.RobotFighter.TestRobot
{
    public class MyRobot : Robot
    {
        private int moves;

        protected override void Spawn()
        {
        }

        protected override void Update()
        {
            if (FacingDirection == Direction.Left)
            {
                var tile = InspectTile(Direction.Left);

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
                    for (var i=0; i<4; i++)
                    {
                        TurnRight();
                        Wait(100);
                    }
                    TurnRight();
                    Move();
                    moves++;
                }
            }
            else
            {
                TurnRight();
                Move();
                moves++;
            }
        }
    }
}
