﻿namespace Zaggoware.RobotFighter.Items
{
    public interface IItem
    {
        string Name { get; }
        bool IsWeapon { get; }
    }
}