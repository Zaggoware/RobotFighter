﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

using Zaggoware.RobotFighter.Items;

namespace Zaggoware.RobotFighter.Entities
{
    internal class RobotManager
    {
        public RobotManager(Game game)
        {
            this.game = game;
            robots = new List<Robot>();
        }

        public ReadOnlyCollection<Robot> Robots => this.robots.AsReadOnly();

        private readonly Game game;
        private readonly List<Robot> robots;

        public Robot CreateRobot<T>() where T : Robot
        {
            var robot = Activator.CreateInstance<T>();

            if (robot.State == RobotState.Disconnected || robot.State == RobotState.Alive)
            {
                // TODO: throw exception?
                return null;
            }

            robot.Inventory = new Inventory(robot);

            robots.Add(robot);

            return robot;
        }

        public void Update()
        {
            var robotsToUpdate = this.robots.ToList();

            while (robotsToUpdate.Count > 0)
            {
                robotsToUpdate.First().Update(this);
                robotsToUpdate.RemoveAt(0);
            }
        }
    }
}