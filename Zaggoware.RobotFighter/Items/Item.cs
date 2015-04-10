using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaggoware.RobotFighter.Items
{
	using Zaggoware.RobotFighter.Entities;

	public abstract class Item : IItem
	{
		public string Name { get; private set; }

		protected Item(string name)
		{
			this.Name = name;
		}

		public virtual bool IsWeapon
		{
			get
			{
				return false;
			}
		}

		public virtual bool IsArmor
		{
			get
			{
				return false;
			}
		}

		public virtual bool IsFood
		{
			get
			{
				return false;
			}
		}

		public virtual bool CanHeal
		{
			get
			{
				return false;
			}
		}

		public virtual bool IsJunk
		{
			get
			{
				return !IsWeapon && !IsArmor && !IsFood && !CanHeal;
			}
		}

        internal Inventory Inventory { get; set; }
	}
}
