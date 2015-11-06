using System;
using System.Threading;
using Zaggoware.RobotFighter.Entities;

namespace Zaggoware.RobotFighter.TestRobot
{
    public class OtherRobot : Robot
    {
        public OtherRobot(string name) : base(name)
        {
        }

        protected override void Spawn()
        {
        }

        protected override void Update()
        {
            if (Randomizer.Between(0, 10) % 3 == 0)
            {
                if (Randomizer.Between(0, 2) % 2 == 0)
                {
                    TurnRight();

                    if (Randomizer.Between(0, 20) == 3)
                    {
                        TurnRight();
                    }
                }
                else
                {
                    TurnLeft();

                    if (Randomizer.Between(0, 20) == 3)
                    {
                        TurnLeft();
                    }
                }
            }
            else
            {
                Move();
            }
        }
    }
}
