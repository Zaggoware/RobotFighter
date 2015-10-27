using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Zaggoware.RobotFighter.Items
{
    internal class ItemManager
    {
        public ItemManager(Game game)
        {
            this.game = game;
        }

        public ReadOnlyCollection<Item> Items => items.AsReadOnly();

        private readonly Game game;
        private readonly List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }

        public bool ContainsItem(Item item)
        {
            return items.Contains(item);
        }
    }
}
