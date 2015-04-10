using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaggoware.RobotFighter.Entities
{
    using Zaggoware.RobotFighter.Environment;
    using Zaggoware.RobotFighter.Items;

    public abstract class Robot : IRobot
    {
        public event AttackEventHandler Attacking;

        public event AttackEventHandler BeingAttacked;

        public const int FullHealth = 100;

        public int Health
        {
            get
            {
                return this.health;
            }
        }

        public bool IsAlive
        {
            get
            {
                return this.State == RobotState.Alive && this.health > 0;
            }
        }

        public int Attack(Weapon weapon)
        {
            if (weapon.Inventory == null || weapon.Inventory.Robot == null)
            {
                return 0;
            }

            var attacker = weapon.Inventory.Robot;

            if (!attacker.IsInRange(this))
            {
                return 0;
            }

            var r = new Random();
            var damage = r.Next(0, weapon.DamageRate);



            return damage;
        }

        internal RobotState State { get; set; }

        protected internal Tile CurrentTile { get; internal set; }

        protected internal Inventory Inventory { get; internal set; }

        protected internal Direction FacingDirection { get; internal set; }

        protected bool CanMove
        {
            get
            {
                switch (this.FacingDirection)
                {
                    case Direction.Up:
                        return this.CurrentTile.Y > 0
                               && !this.world.IsObstacle(this.CurrentTile.X, this.CurrentTile.Y - 1);

                    case Direction.Right:
                        return this.CurrentTile.X < this.world.Width - 1
                            && !this.world.IsObstacle(this.CurrentTile.X + 1, this.CurrentTile.Y);

                    case Direction.Down:
                        return this.CurrentTile.Y < this.world.Height - 1
                            && !this.world.IsObstacle(this.CurrentTile.X, this.CurrentTile.Y + 1);

                    case Direction.Left:
                        return this.CurrentTile.X > 0
                            && !this.world.IsObstacle(this.CurrentTile.X - 1, this.CurrentTile.Y);
                }

                return false;
            }
        }

        private World world;

        private int health;

        internal void Spawn(World world)
        {
            this.world = world;
            this.health = FullHealth;
            this.FacingDirection = Direction.Left;
            this.State = RobotState.Alive;
            this.Spawn();
        }

        internal void Update(RobotManager manager)
        {
            this.Update();
        }

        internal bool IsInRange(Robot target)
        {
            return false;
        }

        protected abstract void Spawn();

        protected abstract void Update();

        protected bool Move()
        {
            return this.Move(1) > 0;
        }

        protected int Move(int steps)
        {
            if (this.CanMove)
            {
                this.world.MoveRobot(this);

                return steps;
            }

            return 0;
        }

        protected void TurnLeft()
        {
            switch (this.FacingDirection)
            {
                case Direction.Up:
                    this.FacingDirection = Direction.Left;
                    break;

                case Direction.Right:
                    this.FacingDirection = Direction.Up;
                    break;

                case Direction.Down:
                    this.FacingDirection = Direction.Right;
                    break;

                case Direction.Left:
                    this.FacingDirection = Direction.Down;
                    break;
            }
        }

        protected void TurnLeft(int times)
        {
            for (var i = 0; i < times; i++)
            {
                this.TurnLeft();
            }
        }

        protected void TurnRight()
        {
            switch (this.FacingDirection)
            {
                case Direction.Up:
                    this.FacingDirection = Direction.Right;
                    break;

                case Direction.Right:
                    this.FacingDirection = Direction.Down;
                    break;

                case Direction.Down:
                    this.FacingDirection = Direction.Left;
                    break;

                case Direction.Left:
                    this.FacingDirection = Direction.Up;
                    break;
            }
        }

        protected void TurnRight(int times)
        {
            for (var i = 0; i < times; i++)
            {
                this.TurnRight();
            }
        }

        protected Tile InspectTile(Direction direction)
        {
            // Tiles to inspect (R = current robot)
            // T T T
            // T R T
            // T T T

            return new Tile(0, 0, false, null, null);
        }

        protected virtual void OnAttacking(AttackEventArgs args)
        {
            if (this.Attacking != null)
            {
                this.Attacking(args);
            }
        }

        protected virtual void OnBeingAttacked(AttackEventArgs args)
        {
            if (this.BeingAttacked != null)
            {
                this.BeingAttacked(args);
            }
        }
    }
}
