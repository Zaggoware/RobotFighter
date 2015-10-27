using Zaggoware.RobotFighter.Items;

namespace Zaggoware.RobotFighter.Entities
{
    public interface IRobot
    {
        int Health { get; }
        bool IsAlive { get; }

        int Attack(Weapon weapon);
    }
}