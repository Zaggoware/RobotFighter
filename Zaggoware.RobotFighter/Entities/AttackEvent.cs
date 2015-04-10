// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttackEvent.cs" company="">
//   
// </copyright>
// <summary>
//   The attack event handler.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Zaggoware.RobotFighter.Entities
{
    #region

    using System;

    using Zaggoware.RobotFighter.Environment;
    using Zaggoware.RobotFighter.Items;

    #endregion

    /// <summary>
    /// The attack event handler.
    /// </summary>
    /// <param name="args">
    /// The args.
    /// </param>
    public delegate void AttackEventHandler(AttackEventArgs args);

    /// <summary>
    /// The attack event args.
    /// </summary>
    public class AttackEventArgs : EventArgs
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AttackEventArgs"/> class.
        /// </summary>
        /// <param name="attackerTile">
        /// The attacker tile.
        /// </param>
        /// <param name="targetTile">
        /// The target tile.
        /// </param>
        /// <param name="weapon">
        /// The weapon.
        /// </param>
        /// <param name="damageDealt">
        /// The damage dealt.
        /// </param>
        internal AttackEventArgs(Tile attackerTile, Tile targetTile, Weapon weapon, int damageDealt)
        {
            this.AttackerTile = attackerTile;
            this.Attacker = attackerTile.Robot;
            this.TargetTile = targetTile;
            this.Target = targetTile.Robot;
            this.Weapon = weapon;
            this.DamageDealt = damageDealt;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the attacker.
        /// </summary>
        public Robot Attacker { get; private set; }

        /// <summary>
        /// Gets the attacker tile.
        /// </summary>
        public Tile AttackerTile { get; private set; }

        /// <summary>
        /// Gets the damage dealt.
        /// </summary>
        public int DamageDealt { get; private set; }

        /// <summary>
        /// Gets the target.
        /// </summary>
        public Robot Target { get; private set; }

        /// <summary>
        /// Gets the target tile.
        /// </summary>
        public Tile TargetTile { get; private set; }

        /// <summary>
        /// Gets the weapon.
        /// </summary>
        public Weapon Weapon { get; private set; }

        #endregion
    }
}