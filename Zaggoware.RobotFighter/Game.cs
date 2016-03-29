using System;
using System.Linq;
using Zaggoware.RobotFighter.Environment;

namespace Zaggoware.RobotFighter
{
    public class Game : IGame
    {
        internal Game()
        {
            worldLoader = new WorldLoader(this);
        }

        public bool IsPaused { get; set; }
        public WorldDescriptor WorldDescriptor { get; private set; }

        internal World World { get; private set; }

        private WorldLoader worldLoader;

        internal void Initialize()
        {
            World = worldLoader.Load(worldLoader.Maps.FirstOrDefault());
            WorldDescriptor = new WorldDescriptor(World);
        }

        internal void Start()
        {
            World.SpawnItems();
        }

        public void Update()
        {
            if (World != null && !IsPaused)
            {
                World.Update();
            }
        }

        public void Dispose()
        {
            World.RobotManager.Clear();
            //World.ItemManager.Clear();

            WorldDescriptor = null;
            World = null;
        }
    }
}
