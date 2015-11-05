﻿namespace Zaggoware.RobotFighter.Entities
{
    public class RobotDescriptor
    {
        internal RobotDescriptor(Robot robot)
        {
            Robot = robot;
        }

        public string Name => Robot.Name;
        public int X => Robot.CurrentTile.X;
        public int Y => Robot.CurrentTile.Y;
        public bool IsAlive => Robot.IsAlive;
        public Direction FaceDirection => Robot.FacingDirection;

        internal Robot Robot { get; set; }
    }
}
