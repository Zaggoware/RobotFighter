using System;
using Zaggoware.RobotFighter.Environment;

namespace Zaggoware.RobotFighter
{
    public class Game : IGame
    {
        internal Game()
        {
        }

        public WorldDescriptor WorldDescriptor { get; private set; }

        internal World World { get; private set; }

        internal void Initialize()
        {
            World = new World(this, 32, 32);
            WorldDescriptor = new WorldDescriptor(World);

            // TODO: Read/Load/Create World config
        }

        internal void Start()
        {
        }

        public void Update()
        {
            World.Update();
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
