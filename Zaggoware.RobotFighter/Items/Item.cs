
namespace Zaggoware.RobotFighter.Items
{
    public abstract class Item : IItem
    {
        protected Item(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public virtual bool IsWeapon => false;
        public virtual bool IsArmor => false;
        public virtual bool IsFood => false;
        public virtual bool CanHeal => false;
        public virtual bool IsJunk => !IsWeapon && !IsArmor && !IsFood && !CanHeal;

        internal Inventory Inventory { get; set; }
    }
}
