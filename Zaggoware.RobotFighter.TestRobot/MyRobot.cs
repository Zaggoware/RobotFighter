using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaggoware.RobotFighter.TestRobot
{
	using Zaggoware.RobotFighter.Entities;

	public class MyRobot : Robot
	{
	    private int ticks = 0;

	    private int moves = 0;

		protected override void Spawn()
		{
			
		}

		protected override void Update()
		{
		    this.ticks++;

		    if (this.ticks % 100 == 0)
		    {
		        if (this.FacingDirection == Direction.Left)
		        {
		            var tile = this.InspectTile(Direction.Up | Direction.Left);

		            if (!tile.HasValue)
		            {
		                return;
		            }

		            if (this.moves < 5 && !tile.Value.IsObstacle)
		            {
		                this.Move();
		                this.moves++;
		            }
		            else 
		            {
                        this.TurnRight();
                        this.Move();
                        this.moves++;
		            }
		        }
		        else
		        {
		            this.TurnRight();
		            this.Move();
		        }
		    }
		}
    }
}
