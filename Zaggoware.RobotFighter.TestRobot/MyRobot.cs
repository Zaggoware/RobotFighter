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

		    var tile = this.InspectTile(Direction.Left | Direction.Up);

		    if (this.ticks % 100 == 0)
		    {
		        if (this.moves < 5)
		        {
		            this.Move();
		            this.moves++;
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
