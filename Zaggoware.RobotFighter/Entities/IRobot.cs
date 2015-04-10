// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRobot.cs" company="Zaggoware">
//   
// </copyright>
// <summary>
//   The Robot interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Zaggoware.RobotFighter.Entities
{
    using Zaggoware.RobotFighter.Items;

    /// <summary>
    /// The Robot interface.
    /// </summary>
    public interface IRobot
    {
        #region Public Properties

        /// <summary>
        /// Gets the health.
        /// </summary>
        int Health { get; }

        /// <summary>
        /// Gets a value indicating whether is alive.
        /// </summary>
        bool IsAlive { get; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The attack.
        /// </summary>
        /// <param name="weapon">
        /// The weapon.
        /// </param>
        /// <returns>
        /// The damage dealt.
        /// </returns>
        int Attack(Weapon weapon);

        #endregion
    }
}