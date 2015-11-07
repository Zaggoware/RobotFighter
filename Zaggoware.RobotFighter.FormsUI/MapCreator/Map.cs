using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaggoware.RobotFighter.FormsUI.MapCreator
{
    public class Map
    {
        public Map(string name)
            : this(name, 32, 32)
        {
        }

        public Map(string name, int size)
            : this(name, size, size)
        {
        }

        public Map(string name, int width, int height)
        {
            Name = name;
            Width = width;
            Height = height;
        }

        public string Name { get; set; }

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

        public void Save(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            var sb = new StringBuilder();
            sb.AppendLine(Name);
            sb.AppendLine($"{width}x{height}");

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    sb.Append(tiles[y][x] ? 1 : 0);
                }

                sb.AppendLine();
            }

            File.WriteAllText(fileName, sb.ToString());
        }

        public static Map Load(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return null;
            }

            var lines = File.ReadAllLines(fileName);

            var name = lines.FirstOrDefault() ?? string.Empty;
            var size = (lines.ElementAtOrDefault(1) ?? "0x0").ToLower();
            var sizeParts = size.Split(new[] { 'x' }, 2);
            var width = 0;
            var height = 0;

            int.TryParse(sizeParts.FirstOrDefault(), out width);
            int.TryParse(sizeParts.LastOrDefault(), out height);

            var map = new Map(name, width, height);
            var y = 0;

            foreach (var line in lines.Skip(2))
            {
                if (string.IsNullOrEmpty(line))
                {
                    y++;
                    continue;
                }

                var x = 0;

                foreach (var c in line)
                {
                    if (c == '1')
                    {
                        map.AddObstacle(y, x);
                    }

                    x++;
                }

                y++;
            }

            return map;
        }
    }
}
