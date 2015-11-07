using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaggoware.RobotFighter.FormsUI.MapCreator
{
    public struct TileData
    {
        public int X { get; }
        public int Y { get; }
        public bool IsObstacle { get; }

        public TileData(int x, int y, bool isObstacle)
        {
            X = x;
            Y = y;
            IsObstacle = isObstacle;
        }
    }
}
