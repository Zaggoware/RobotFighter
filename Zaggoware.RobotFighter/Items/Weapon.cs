namespace Zaggoware.RobotFighter.Items
{
    public class Weapon : Item
    {
        internal Weapon(string name, WeaponType type, int damageRate, int speedRate)
            : base(name)
        {
            Type = type;
            DamageRate = damageRate;
            SpeedRate = speedRate;
        }

        public WeaponType Type { get; }
        public int DamageRate { get; }
        public int SpeedRate { get; }

        public override bool IsWeapon => true;
    }
}
