using Zaggoware.RobotFighter.Items;
using Zaggoware.RobotFighter.Items.Weapons;

namespace Zaggoware.RobotFighter.Entities
{
    public interface IRobot
    {
        int Health { get; }
        bool IsAlive { get; }

        int Attack(Weapon weapon);
    }
}