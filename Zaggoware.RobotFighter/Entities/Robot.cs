using System;
using System.Threading;
using Zaggoware.RobotFighter.Environment;
using Zaggoware.RobotFighter.Items;
using Zaggoware.RobotFighter.Items.Weapons;

namespace Zaggoware.RobotFighter.Entities
{
    public abstract class Robot
    {
        protected Robot(string name)
        {
            Name = name;
        }

        public event AttackEventHandler Attacking;
        public event AttackEventHandler BeingAttacked;

        public const int FullHealth = 100;

        public string Name { get; private set; }

        public int Health
        {
            get { return health; }
            private set
            {
                if (value == health)
                {
                    return;
                }

                health = value < 0 ? 0 : (value > 100 ? 100 : value);

                if (health == 0)
                {
                    State = RobotState.Dead;
                }
            }
        }

        public bool IsAlive => State == RobotState.Alive && Health > 0;

        internal RobotState State { get; set; }

        protected internal Tile CurrentTile { get; internal set; }
        protected internal Inventory Inventory { get; internal set; }
        protected internal Direction FacingDirection { get; internal set; }

        protected bool CanMove
        {
            get
            {
                switch (FacingDirection)
                {
                    case Direction.Up:
                        return CurrentTile.Y > 0
                               && !world.IsObstacle(CurrentTile.X, CurrentTile.Y - 1);

                    case Direction.Right:
                        return CurrentTile.X < world.Width - 1
                            && !world.IsObstacle(CurrentTile.X + 1, CurrentTile.Y);

                    case Direction.Down:
                        return CurrentTile.Y < world.Height - 1
                            && !world.IsObstacle(CurrentTile.X, CurrentTile.Y + 1);

                    case Direction.Left:
                        return CurrentTile.X > 0
                            && !world.IsObstacle(CurrentTile.X - 1, CurrentTile.Y);
                }

                return false;
            }
        }

        private World world;
        private object healthObject;
        private int health;

        protected int Attack(Robot target)
        {
            var damageRate = 7;

            if (Inventory?.CurrentWeapon != null)
            {
                damageRate = Inventory.CurrentWeapon.DamageRate;
            }

            if (!IsInRange(target))
            {
                return 0;
            }

            var damage = Randomizer.Between(0, damageRate);

            lock (healthObject)
            {
                target.Health -= damage;
            }

            return damage;
        }

        internal void Spawn(World world)
        {
            this.world = world;
            Health = FullHealth;
            FacingDirection = Direction.Left;
            State = RobotState.Alive;
            Spawn();
        }

        internal void Update(RobotManager manager)
        {
            Update();
        }

        internal bool IsInRange(Robot target)
        {
            return false;
        }

        protected abstract void Spawn();
        protected abstract void Update();

        protected bool Move()
        {
            return Move(1) > 0;
        }

        protected int Move(int steps)
        {
            if (!CanMove)
            {
                return 0;
            }

            world.MoveRobot(this);
            Wait(1000);

            return steps;
        }

        protected void TurnLeft()
        {
            switch (FacingDirection)
            {
                case Direction.Up:
                    FacingDirection = Direction.Left;
                    break;

                case Direction.Right:
                    FacingDirection = Direction.Up;
                    break;

                case Direction.Down:
                    FacingDirection = Direction.Right;
                    break;

                case Direction.Left:
                    FacingDirection = Direction.Down;
                    break;
            }

            Wait(1000);
        }

        protected void TurnLeft(int times)
        {
            for (var i = 0; i < times; i++)
            {
                TurnLeft();
            }
        }

        protected void TurnRight()
        {
            switch (FacingDirection)
            {
                case Direction.Up:
                    FacingDirection = Direction.Right;
                    break;

                case Direction.Right:
                    FacingDirection = Direction.Down;
                    break;

                case Direction.Down:
                    FacingDirection = Direction.Left;
                    break;

                case Direction.Left:
                    FacingDirection = Direction.Up;
                    break;
            }

            Wait(1000);
        }

        protected void TurnRight(int times)
        {
            for (var i = 0; i < times; i++)
            {
                TurnRight();
            }
        }

        protected Tile? InspectTile(Direction direction)
        {
            // Tiles available to inspect (R = current robot)
            // T T T
            // T R T
            // T T T

            var x = CurrentTile.X;
            var y = CurrentTile.Y;

            if (direction.HasFlag(Direction.Up))
            {
                y--;
            }

            if (direction.HasFlag(Direction.Right))
            {
                x++;
            }

            if (direction.HasFlag(Direction.Down))
            {
                y++;
            }

            if (direction.HasFlag(Direction.Left))
            {
                x--;
            }

            if (x < 0 || y < 0)
            {
                return null;
            }

            return world.Tiles[x, y];
        }

        protected void Wait(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }

        protected virtual void OnAttacking(AttackEventArgs args)
        {
            Attacking?.Invoke(args);
        }

        protected virtual void OnBeingAttacked(AttackEventArgs args)
        {
            BeingAttacked?.Invoke(args);
        }
    }
}
