using System;
using System.Threading;
using Zaggoware.RobotFighter.Entities;

namespace Zaggoware.RobotFighter.TestRobot
{
    public class MyRobot : Robot
    {
        private Random rand = new Random();

        protected override void Spawn()
        {
        }

        protected override void Update()
        {
            while (!CanMove)
            {
                if (rand.Next(2) % 2 == 0)
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
