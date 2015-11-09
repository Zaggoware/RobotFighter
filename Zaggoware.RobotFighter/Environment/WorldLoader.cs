using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaggoware.RobotFighter.Environment
{
    internal class WorldLoader
    {
        private const string mapsDir = "Maps";
        private const string mapsDataFile = mapsDir +"/Maps.data";
        private const string mapExtension = "rfmap";

        public WorldLoader(Game game)
        {
            this.game = game;
        }

        public IEnumerable<string> Maps
        {
            get
            {
                return maps.Value;
            }
        }

        private Lazy<IEnumerable<string>> maps = new Lazy<IEnumerable<string>>(() =>
        {
            if (!File.Exists(mapsDataFile))
            {
                return Enumerable.Empty<string>();
            }

            return File.ReadAllLines(mapsDataFile);
        });

        private Game game;

        public World Load(string mapFileName)
        {
            if (!Maps.Contains(mapFileName))
            {
                return null;
            }

            mapFileName = $"{mapsDir}/{mapFileName}.{mapExtension}";
            if (!File.Exists(mapFileName))
            {
                return null;
            }

            var lines = File.ReadAllLines(mapFileName);

            // TODO: use name?
            var name = lines.FirstOrDefault() ?? string.Empty;
            var size = (lines.ElementAtOrDefault(1) ?? "0x0").ToLower();
            var sizeParts = size.Split(new[] { 'x' }, 2);
            var width = 0;
            var height = 0;

            int.TryParse(sizeParts.FirstOrDefault(), out width);
            int.TryParse(sizeParts.LastOrDefault(), out height);

            var map = new World(game, width, height);
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
                    map.Tiles[x, y] = new Tile(x, y, c == '1');
                    x++;
                }

                y++;
            }

            return map;
        }
    }
}
