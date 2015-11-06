using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zaggoware.RobotFighter.FormsUI.MapCreator;

namespace Zaggoware.RobotFighter.FormsUI
{
    public partial class MapCreatorForm : Form
    {
        private const int TileWidth = 16;
        private const int TileHeight = 16;

        private Map map;
        private bool hasUnsavedChanges;
        private bool isMouseDown;

        public MapCreatorForm()
        {
            InitializeComponent();

            NewMap();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewMap();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MapCreator_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (hasUnsavedChanges)
            {
                e.Cancel =
                    MessageBox.Show(
                        "There are unsaved changes. Are you sure you want to exit?",
                        "Unsaved changes",
                        MessageBoxButtons.YesNo) == DialogResult.No;
            }
        }

        private void MapPanel_Paint(object sender, PaintEventArgs e)
        {
            if (map == null)
            {
                return;
            }

            for (var y = 0; y < map.Height; y++)
            {
                for (var x = 0; x < map.Width; x++)
                {
                    if (map.IsObstacle(y, x))
                    {
                        e.Graphics.FillRectangle(Brushes.Black, x * TileWidth, y * TileHeight, TileWidth + 1, TileHeight + 1);
                    }
                    else
                    {
                        e.Graphics.DrawRectangle(Pens.Black, x * TileWidth, y * TileHeight, TileWidth, TileHeight);
                    }
                }
            }

            // TODO Draw x and y numbers.
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            ResizeMap();
        }

        private void NewMap()
        {
            var width = int.Parse(widthBox.Text);
            var height = int.Parse(heightBox.Text);

            map = new Map { Width = width, Height = height };

            hasUnsavedChanges = true;

            ResizeMap();
        }

        private void ResizeMap()
        {
            if (map == null)
            {
                return;
            }

            map.Width = int.Parse(widthBox.Text);
            map.Height = int.Parse(heightBox.Text);

            mapPanel.Size = new Size((map.Width * TileWidth) + 1, (map.Height * TileHeight) + 1);
            mapPanel.Invalidate();
        }

        private void AddOrRemoveObstacle(MouseEventArgs e)
        {
            var x = e.X / TileWidth;
            var y = e.Y / TileHeight;

            if (e.Button == MouseButtons.Left)
            {
                map.AddObstacle(y, x);
                mapPanel.Invalidate();
            }
            else if (e.Button == MouseButtons.Right)
            {
                map.RemoveObstacle(y, x);
                mapPanel.Invalidate();
            }
        }

        private void mapPanel_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            AddOrRemoveObstacle(e);
        }

        private void mapPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                AddOrRemoveObstacle(e);
            }
        }

        private void mapPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }
    }
}
