// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tile.cs" company="">
//   
// </copyright>
// <summary>
//   The tile.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Zaggoware.RobotFighter.Environment
{
    #region

    using Zaggoware.RobotFighter.Entities;
    using Zaggoware.RobotFighter.Items;

    #endregion

    /// <summary>
    /// The tile.
    /// </summary>
    public struct Tile
    {
        #region Fields

        /// <summary>
        /// The is obstacle.
        /// </summary>
        private readonly bool isObstacle;

        /// <summary>
        /// The item.
        /// </summary>
        private readonly Item item;

        /// <summary>
        /// The robot.
        /// </summary>
        private readonly Robot robot;

        /// <summary>
        /// The x.
        /// </summary>
        private readonly int x;

        /// <summary>
        /// The y.
        /// </summary>
        private readonly int y;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Tile"/> struct.
        /// </summary>
        /// <param name="x">
        /// The x.
        /// </param>
        /// <param name="y">
        /// The y.
        /// </param>
        /// <param name="isObstacle">
        /// The is obstacle.
        /// </param>
        internal Tile(int x, int y, bool isObstacle)
        {
            this.x = x;
            this.y = y;
            this.robot = null;
            this.item = null;
            this.isObstacle = isObstacle;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tile"/> struct.
        /// </summary>
        /// <param name="x">
        /// The x.
        /// </param>
        /// <param name="y">
        /// The y.
        /// </param>
        /// <param name="isObstacle">
        /// The is obstacle.
        /// </param>
        /// <param name="robot">
        /// The robot.
        /// </param>
        /// <param name="item">
        /// The item.
        /// </param>
        internal Tile(int x, int y, bool isObstacle, Robot robot, Item item)
            : this(x, y, isObstacle)
        {
            this.robot = robot;
            this.item = item;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Determines wether is obstacle.
        /// </summary>
        public bool IsObstacle
        {
            get
            {
                return this.isObstacle;
            }
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        public Item Item
        {
            get
            {
                return this.item;
            }
        }

        /// <summary>
        /// Gets the robot.
        /// </summary>
        public Robot Robot
        {
            get
            {
                return this.robot;
            }
        }

        /// <summary>
        /// Gets the x.
        /// </summary>
        public int X
        {
            get
            {
                return this.x;
            }
        }

        /// <summary>
        /// Gets the y.
        /// </summary>
        public int Y
        {
            get
            {
                return this.y;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the empty.
        /// </summary>
        internal static Tile Empty
        {
            get
            {
                return new Tile(0, 0, false);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The ==.
        /// </summary>
        /// <param name="a">
        /// The a.
        /// </param>
        /// <param name="b">
        /// The b.
        /// </param>
        /// <returns>
        /// </returns>
        public static bool operator ==(Tile a, Tile b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        /// <summary>
        /// The !=.
        /// </summary>
        /// <param name="a">
        /// The a.
        /// </param>
        /// <param name="b">
        /// The b.
        /// </param>
        /// <returns>
        /// </returns>
        public static bool operator !=(Tile a, Tile b)
        {
            return a.X != b.X || a.Y != b.Y;
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is Tile)
            {
                var other = (Tile)obj;

                return other.X == this.X && other.Y == this.Y;
            }

            return false;
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}