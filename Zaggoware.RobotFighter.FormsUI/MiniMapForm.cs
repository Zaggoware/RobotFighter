using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zaggoware.RobotFighter.FormsUI.MapCreator;

namespace Zaggoware.RobotFighter.FormsUI
{
    public partial class MiniMapForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public Map Map
        {
            get { return map; }
            set
            {
                map = value;

                Invalidate();
            }
        }

        private Map map;

        public MiniMapForm(Map map)
        {
            InitializeComponent();

            Map = map;
        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            base.OnInvalidated(e);

            if (map != null)
            {
                Size = new Size(map.Width + 2, map.Height + 2);
            }
        }

        private void MiniMapForm_Paint(object sender, PaintEventArgs e)
        {
            if (Map == null)
            {
                return;
            }

            e.Graphics.DrawRectangle(Pens.Black, 0, 0, map.Width + 1, map.Height + 1);

            foreach (var tile in Map.TileData)
            {
                if (tile.IsObstacle)
                {
                    e.Graphics.FillRectangle(Brushes.Black, tile.X + 1, tile.Y + 1, 1, 1);
                }
            }
        }

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
