using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zaggoware.RobotFighter.FormsUI
{
	using Zaggoware.RobotFighter.Entities;
	using Zaggoware.RobotFighter.TestRobot;

    public partial class GameForm : Form
    {
        private Game game;

        private bool isPaused = false;

        private int ticks = 0;

        public GameForm()
        {
            InitializeComponent();
        }


        private void CreateGame()
        {
            this.game = GameManager.StartNewGame();
            this.game.WorldDescriptor.CreateRobot<MyRobot>();
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            if (this.game == null)
            {
                return;
            }

            const int OffsetX = 10;
            const int OffsetY = 50;
            const int TileSize = 16;

            for (var x = 0; x < this.game.WorldDescriptor.Width; x++)
            {
                for (var y = 0; y < this.game.WorldDescriptor.Height; y++)
                {
                    e.Graphics.DrawRectangle(
                        Pens.Black,
                        OffsetX + (x * TileSize),
                        OffsetY + (y * TileSize),
                        TileSize,
                        TileSize);

                    if (this.game.WorldDescriptor.IsObstacle(x, y))
                    {
                        e.Graphics.FillRectangle(
                            Brushes.Black,
                            OffsetX + (x * TileSize),
                            OffsetY + (y * TileSize),
                            TileSize,
                            TileSize);
                    }
                }
            }

            foreach (var robot in this.game.WorldDescriptor.GetRobots())
            {
                if (!robot.IsAlive || robot.X < 0 || robot.Y < 0 || robot.X >= this.game.WorldDescriptor.Width
                    || robot.Y >= this.game.WorldDescriptor.Height)
                {
                    continue;
                }

                e.Graphics.FillRectangle(
                    Brushes.Brown,
                    OffsetX + (robot.X * TileSize),
                    OffsetY + (robot.Y * TileSize),
                    TileSize,
                    TileSize);

	            RectangleF? facingBounds = null;
	            float fbWidth = TileSize / 2;
	            float fbHeight = TileSize / 4;

	            switch (robot.FaceDirection)
	            {
					case Direction.Up:
			            facingBounds = new RectangleF(
				            OffsetX + (robot.X * TileSize) + (fbWidth / 2),
				            OffsetY + (robot.Y * TileSize),
				            fbWidth,
				            fbHeight);
			            break;

					case Direction.Right:
						facingBounds = new RectangleF(
							OffsetX + (robot.X * TileSize) + TileSize - fbHeight,
							OffsetY + (robot.Y * TileSize) + (fbWidth / 2),
							fbHeight,
							fbWidth);
						break;

					case Direction.Down:
						facingBounds = new RectangleF(
				            OffsetX + (robot.X * TileSize) + (fbWidth / 2),
				            OffsetY + (robot.Y * TileSize) + TileSize - fbHeight,
				            fbWidth,
				            fbHeight);
			            break;

		            case Direction.Left:
			            facingBounds = new RectangleF(
				            OffsetX + (robot.X * TileSize),
							OffsetY + (robot.Y * TileSize) + (fbWidth / 2),
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
                "Ticks: " + this.ticks,
                new Font("Arial", 14f, FontStyle.Regular),
                Brushes.Black,
                180,
                13);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (this.game == null)
            {
                this.CreateGame();
            }

            this.gameTimer.Enabled = true;

            this.isPaused = false;
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            this.isPaused = true;
            this.gameTimer.Enabled = false;
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (this.game == null || this.isPaused)
            {
                return;
            }

            this.ticks++;

            this.game.Update();
            this.Invalidate();
        }
    }
}
