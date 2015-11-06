using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaggoware.RobotFighter.FormsUI.MapCreator
{
    public class Map
    {
        public int Width
        {
            get { return width; }
            set
            {
                width = value;
                Resize();
            }
        }
        public int Height
        {
            get { return height; }
            set
            {
                height = value;
                Resize();
            }
        }

        private int width;
        private int height;

        private readonly Dictionary<int, Dictionary<int, bool>> tiles = new Dictionary<int, Dictionary<int, bool>>();

        private void Resize()
        {
            for (var y = 0; y < height; y++)
            {
                if (!tiles.ContainsKey(y))
                {
                    tiles.Add(y, new Dictionary<int, bool>());
                }

                for (var x = 0; x < width; x++)
                {
                    if (!tiles[y].ContainsKey(x))
                    {
                        tiles[y].Add(x, false);
                    }
                }
            }
        }

        public bool IsObstacle(int y, int x)
        {
            return tiles.ContainsKey(y) && tiles[y].ContainsKey(x) && tiles[y][x];
        }

        public void AddObstacle(int y, int x)
        {
            if (!tiles.ContainsKey(y) || !tiles[y].ContainsKey(x))
            {
                return;
            }

            tiles[y][x] = true;
        }

        public void RemoveObstacle(int y, int x)
        {
            if (!tiles.ContainsKey(y) || !tiles[y].ContainsKey(x))
            {
                return;
            }

            tiles[y][x] = false;
        }

    }
}
