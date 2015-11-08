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
        private IEnumerable<TileData> tiles;

        public MapState(Map map)
        {
            name = map.Name;
            width = map.Width;
            height = map.Height;
            tiles = map.TileData.ToList();
        }

        public Map ToMap()
        {
            var map = new Map(name, width, height);

            foreach (var tile in tiles)
            {
                if (!tile.IsObstacle)
                {
                    map.RemoveObstacle(tile.Y, tile.X);
                    continue;
                }

                map.AddObstacle(tile.Y, tile.X);
            }

            return map;
        }
    }
}
