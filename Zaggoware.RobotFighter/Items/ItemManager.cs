using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaggoware.RobotFighter.Items
{
	using System.Collections.ObjectModel;

	internal class ItemManager
	{
		private readonly Game game;

		private readonly List<Item> items;

		public ItemManager(Game game)
		{
			this.game = game;
			this.items = new List<Item>();
		}

		public ReadOnlyCollection<Item> Items
		{
			get
			{
				return this.items.AsReadOnly();
			}
		}

		public void AddItem(Item item)
		{
			this.items.Add(item);
		}

		public void RemoveItem(Item item)
		{
			this.items.Remove(item);
		}

		public bool ContaisnItem(Item item)
		{
			return this.items.Contains(item);
		}
	}
}
