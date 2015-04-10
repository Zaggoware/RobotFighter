using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaggoware.RobotFighter.Items
{
	using System.Collections;

	using Zaggoware.RobotFighter.Entities;

    public class Inventory : ICollection<Item>
	{
		private List<Item> items;

        internal Robot Robot { get; set; }

		internal Inventory(Robot robot)
		{
            this.items = new List<Item>();
            this.Robot = robot;
		}

		public Item this[int index]
		{
			get
			{
				return items[index];
			}
		}

	    public int Count
	    {
	        get
	        {
	            return items.Count;
	        }
	    }

	    public bool IsReadOnly
	    {
	        get
	        {
	            return false;
	        }
	    }

		internal void Add(Item item)
		{
			
		}

		void ICollection<Item>.Add(Item item)
		{
			throw new NotSupportedException();
		}

		public void Clear()
		{
			this.items.Clear();
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

		bool ICollection<Item>.Remove(Item item)
		{
		    this.Drop(item);

		    return true;
		}

		public IEnumerator<Item> GetEnumerator()
		{
			return items.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}
