using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaggoware.RobotFighter.Items
{
	public class Weapon : Item
	{
		public WeaponType Type { get; private set; }

		public int DamageRate { get; private set; }

		public int SpeedRate { get; private set; }

		public override bool IsWeapon
		{
			get
			{
				return true;
			}
		}

		internal Weapon(string name, WeaponType type, int damageRate, int speedRate)
			: base(name)
		{
			this.Type = type;
			this.DamageRate = damageRate;
			this.SpeedRate = speedRate;
		}
	}
}
