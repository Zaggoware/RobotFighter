using Zaggoware.RobotFighter.Environment;

namespace Zaggoware.RobotFighter
{
    public class Game
    {
        internal Game()
        {
        }

        public WorldDescriptor WorldDescriptor { get; private set; }

        internal World World { get; private set; }

        internal void Initialize()
        {
            World = new World(this, 32, 32);
            WorldDescriptor = new WorldDescriptor(this.World);

            // TODO: Read/Load/Create World config
        }

        internal void Start()
        {
        }

        public void Update()
        {
            World.Update();
        }
    }
}
