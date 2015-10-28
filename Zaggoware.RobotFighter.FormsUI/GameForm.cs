using System;
using System.Drawing;
using System.Windows.Forms;

using Zaggoware.RobotFighter.Entities;
using Zaggoware.RobotFighter.TestRobot;

namespace Zaggoware.RobotFighter.FormsUI
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
        }

        private Game game;
        private bool isPaused;
        private int ticks;

        private void CreateGame()
        {
            game = GameManager.StartNewGame();
            game.WorldDescriptor.CreateRobot<MyRobot>();
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            if (game == null)
            {
                return;
            }

            const int offsetX = 10;
            const int offsetY = 50;
            const int tileSize = 16;

            for (var x = 0; x < game.WorldDescriptor.Width; x++)
            {
                for (var y = 0; y < game.WorldDescriptor.Height; y++)
                {
                    e.Graphics.DrawRectangle(
                        Pens.Black,
                        offsetX + (x * tileSize),
                        offsetY + (y * tileSize),
                        tileSize,
                        tileSize);

                    if (game.WorldDescriptor.IsObstacle(x, y))
                    {
                        e.Graphics.FillRectangle(
                            Brushes.Black,
                            offsetX + (x * tileSize),
                            offsetY + (y * tileSize),
                            tileSize,
                            tileSize);
                    }
                }
            }

            foreach (var robot in game.WorldDescriptor.GetRobots())
            {
                if (!robot.IsAlive || robot.X < 0 || robot.Y < 0 || robot.X >= game.WorldDescriptor.Width
                    || robot.Y >= game.WorldDescriptor.Height)
                {
                    continue;
                }

                e.Graphics.FillRectangle(
                    Brushes.Brown,
                    offsetX + (robot.X * tileSize),
                    offsetY + (robot.Y * tileSize),
                    tileSize,
                    tileSize);

                RectangleF? facingBounds = null;
                float fbWidth = tileSize / 2;
                float fbHeight = tileSize / 4;

                switch (robot.FaceDirection)
                {
                    case Direction.Up:
                        facingBounds = new RectangleF(
                            offsetX + (robot.X * tileSize) + (fbWidth / 2),
                            offsetY + (robot.Y * tileSize),
                            fbWidth,
                            fbHeight);
                        break;

                    case Direction.Right:
                        facingBounds = new RectangleF(
                            offsetX + (robot.X * tileSize) + tileSize - fbHeight,
                            offsetY + (robot.Y * tileSize) + (fbWidth / 2),
                            fbHeight,
                            fbWidth);
                        break;

                    case Direction.Down:
                        facingBounds = new RectangleF(
                            offsetX + (robot.X * tileSize) + (fbWidth / 2),
                            offsetY + (robot.Y * tileSize) + tileSize - fbHeight,
                            fbWidth,
                            fbHeight);
                        break;

                    case Direction.Left:
                        facingBounds = new RectangleF(
                            offsetX + (robot.X * tileSize),
                            offsetY + (robot.Y * tileSize) + (fbWidth / 2),
                            fbHeight,
                            fbWidth);
                        break;
                }

                if (facingBounds.HasValue)
                {
                    e.Graphics.FillRectangle(Brushes.GreenYellow, facingBounds.Value);
                }
            }

            e.Graphics.DrawString(
                "Ticks: " + ticks,
                new Font("Arial", 14f, FontStyle.Regular),
                Brushes.Black,
                180,
                13);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (game == null)
            {
                CreateGame();
            }

            gameTimer.Enabled = true;
            isPaused = false;
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            isPaused = true;
            gameTimer.Enabled = false;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (game == null || isPaused)
            {
                return;
            }

            ticks++;

            game.Update();

            loggerBox.Text = string.Join("\r\n", MemoryLogger.Logs);

            Invalidate();
        }
    }
}
