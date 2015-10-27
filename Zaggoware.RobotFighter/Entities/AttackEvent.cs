using System;

using Zaggoware.RobotFighter.Environment;
using Zaggoware.RobotFighter.Items;

namespace Zaggoware.RobotFighter.Entities
{
    public delegate void AttackEventHandler(AttackEventArgs args);

    public class AttackEventArgs : EventArgs
    {
        internal AttackEventArgs(Tile attackerTile, Tile targetTile, Weapon weapon, int damageDealt)
        {
           AttackerTile = attackerTile;
           Attacker = attackerTile.Robot;
           TargetTile = targetTile;
           Target = targetTile.Robot;
           Weapon = weapon;
           DamageDealt = damageDealt;
        }

        public Robot Attacker { get; private set; }
        public Tile AttackerTile { get; private set; }
        public int DamageDealt { get; private set; }
        public Robot Target { get; private set; }
        public Tile TargetTile { get; private set; }
        public Weapon Weapon { get; private set; }
    }
}