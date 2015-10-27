using System;
using System.Collections;
using System.Collections.Generic;

using Zaggoware.RobotFighter.Entities;

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

        internal Robot Robot { get; set; }

        private readonly List<Item> items;

        internal void Add(Item item)
        {
            throw new NotSupportedException();
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
