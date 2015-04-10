
namespace Zaggoware.RobotFighter
{
	using Zaggoware.RobotFighter.Entities;
	using Zaggoware.RobotFighter.Environment;
	using Zaggoware.RobotFighter.Items;

	public class Game
	{
        internal Game()
		{
		}

        public WorldDescriptor WorldDescriptor
	    {
	        get
	        {
	            return this.worldDescriptor;
	        }
	    }

        internal World World { get; private set; }

	    private WorldDescriptor worldDescriptor;
        
	    internal void Initialize()
	    {
	        this.World = new World(this, 32, 32);
            this.worldDescriptor = new WorldDescriptor(this.World);

            // TODO: Read/Load/Create World config


	    }

	    internal void Start()
	    {
	        
	    }

	    public void Update()
	    {
	        this.World.Update();
	    }
	}
}
