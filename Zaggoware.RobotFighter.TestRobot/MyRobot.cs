using System;
using System.Threading;
using Zaggoware.RobotFighter.Entities;

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
