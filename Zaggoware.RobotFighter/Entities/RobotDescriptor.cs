using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaggoware.RobotFighter.Entities
{
    public class RobotDescriptor
    {
        internal RobotDescriptor(Robot robot)
        {
            this.Robot = robot;
        }

        public int X
        {
            get
            {
                return Robot.CurrentTile.X;
            }
        }

        public int Y
        {
            get
            {
                return Robot.CurrentTile.Y;
            }
        }

        public bool IsAlive
        {
            get
            {
                return Robot.IsAlive;
            }
        }

	    public Direction FaceDirection
	    {
		    get
		    {
			    return Robot.FacingDirection;
		    }
	    }

        internal Robot Robot { get; set; }
    }
}
