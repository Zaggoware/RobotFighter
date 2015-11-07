using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaggoware.RobotFighter.FormsUI.MapCreator
{
    public struct MapState
    {
        private string name;
        private int width;
        private int height;
        private List<TileData> tiles;

        public MapState(Map map)
        {
            name = map.Name;
            width = map.Width;
            height = map.Height;
            tiles = new List<TileData>();
        }
    }
}
