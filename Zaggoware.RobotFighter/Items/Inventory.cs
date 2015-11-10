using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Zaggoware.RobotFighter.Entities;
using Zaggoware.RobotFighter.Environment;
using Zaggoware.RobotFighter.Items.Weapons;

namespace Zaggoware.RobotFighter.Items
{
    public class Inventory : ICollection<Item>
    {
        internal Inventory(Robot robot)
        {
            items = new List<Item>();
            Robot = robot;
        }

        public Item this[int index] => items[index];
        public int Count => items.Count;
        public bool IsReadOnly => false;

        public Weapon CurrentWeapon { get { return currentWeapon; } }

        internal Robot Robot { get; set; }

        private readonly List<Item> items;
        private Weapon currentWeapon;

        internal void Add(Item item)
        {
            if (item.Inventory != null)
            {
                return;
            }

            items.Add(item);
            item.Inventory = this;

            if (item is Weapon)
            {
                if (!items.OfType<Weapon>().Any())
                {
                    currentWeapon = (Weapon)item;
                }
            }
        }

        void ICollection<Item>.Add(Item item)
        {
            throw new NotSupportedException();
        }

        public void Clear()
        {
            items.Clear();
        }

        public bool Contains(Item item)
        {
            return items.Contains(item);
        }

        public void CopyTo(Item[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public void Drop(Item item)
        {
            if (!items.Contains(item))
            {
                return;
            }

            if (Robot.CurrentTile.Item != null)
            {
                return;
            }

            items.Remove(item);
            item.Inventory = null;

            var tile = Robot.CurrentTile;
            Robot.CurrentTile = new Tile(tile.World.World, tile.X, tile.Y, tile.IsObstacle, tile.Robot, item);
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        bool ICollection<Item>.Remove(Item item)
        {
            Drop(item);

            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
