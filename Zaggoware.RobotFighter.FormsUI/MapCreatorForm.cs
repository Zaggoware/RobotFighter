﻿using System;
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
        private const string FileExtension = "rfmap";

        private string title = string.Empty;
        private bool hasUnsavedChanges;

        private const int TileWidth = 16;
        private const int TileHeight = 16;

        private Map map;
        private bool isMouseDown;
        private string fileName;

        private MiniMapForm miniMapForm;

        public MapCreatorForm()
        {
            InitializeComponent();

            title = Text;
            //NewMap();

            miniMapForm = new MiniMapForm(map);
            miniMapForm.Show();
        }

        #region Event Handlers

        private void Timer_Tick(object sender, EventArgs e)
        {
            var bytes = GC.GetTotalMemory(false);
            var kilobytes = 0d;
            var megabytes = 0d;
            var gigabytes = 0d;
            var memoryString = bytes.ToString("n0") +" B";

            if (bytes >= 1024)
            {
                kilobytes = bytes / 1024;
                memoryString = kilobytes.ToString("n0") + " KB";
            }

            if (kilobytes >= 1024)
            {
                megabytes = kilobytes / 1024;
                memoryString = megabytes.ToString("n") + " MB";
            }

            if (megabytes >= 1024)
            {
                gigabytes = megabytes / 1024;
                memoryString = gigabytes.ToString("n") + "GB";
            }



            memoryLabel.Text = memoryString;
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewMap();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMap();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveMap();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveMap(true);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MapCreator_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (hasUnsavedChanges && !RequestSave())
            {
                e.Cancel = true;
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

        private void WidthBox_Leave(object sender, EventArgs e)
        {
            resizeButton.PerformClick();
        }

        private void HeightBox_Leave(object sender, EventArgs e)
        {
            resizeButton.PerformClick();
        }

        private void ResizeButton_Click(object sender, EventArgs e)
        {
            var width = map.Width;
            var height = map.Height;

            int.TryParse(widthBox.Text, out width);
            int.TryParse(heightBox.Text, out height);

            map.Width = width;
            map.Height = height;

            ResizeMap();
            miniMapForm.Invalidate();
        }

        private void MapPanel_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            AddOrRemoveObstacle(e);
        }

        private void MapPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                AddOrRemoveObstacle(e);
            }
        }

        private void MapPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        #endregion

        private void SetTitle()
        {
            Text = (hasUnsavedChanges ? "*" : string.Empty)
                + (map != null ? map.Name + " - " + title : title);            
        }

        private bool RequestSave()
        {
            var result = MessageBox.Show("There are unchanged saves. Do you want to save these first?", "Unsaved changes", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Cancel)
            {
                return false;
            }

            if (result == DialogResult.Yes)
            {
                SaveMap();
            }

            return true;
        }

        private void NewMap()
        {
            if (hasUnsavedChanges && !RequestSave())
            {
                return;
            }  

            map = new Map("Map 1");
            hasUnsavedChanges = true;
            SetTitle();

            miniMapForm.Map = map;

            nameBox.Text = map.Name;
            widthBox.Text = map.Width.ToString();
            heightBox.Text = map.Height.ToString();

            container.Visible = true;
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;

            ResizeMap();
        }

        private void OpenMap(string fileName = null)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                var dialog = new OpenFileDialog
                {
                    AddExtension = true,
                    DefaultExt = FileExtension,
                    Filter = "Robot Fighter Map File (*.rfmap)|*.rfmap|All files|*.*"
                };
                var result = dialog.ShowDialog();

                if (result == DialogResult.Cancel)
                {
                    return;
                }

                if (result == DialogResult.OK)
                {
                    if (hasUnsavedChanges && !RequestSave())
                    {
                        return;
                    }

                    fileName = dialog.FileName;
                }
            }

            map = Map.Load(fileName);
            hasUnsavedChanges = false;
            SetTitle();

            miniMapForm.Map = map;

            nameBox.Text = map.Name;
            widthBox.Text = map.Width.ToString();
            heightBox.Text = map.Height.ToString();

            container.Visible = true;
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;

            ResizeMap();
        }

        private void SaveMap(bool forceSaveDialog = false)
        {
            if (map == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(fileName) || forceSaveDialog)
            {
                var dialog = new SaveFileDialog
                             {
                                 AddExtension = true,
                                 DefaultExt = FileExtension,
                                 Filter = "Robot Fighter Map File (*.rfmap)|*.rfmap|All files|*.*"
                             };
                var result = dialog.ShowDialog();

                if (result == DialogResult.Cancel)
                {
                    return;
                }

                if (result == DialogResult.OK)
                {
                    fileName = dialog.FileName;
                }
            }

            map.Save(fileName);
            hasUnsavedChanges = false;
            SetTitle();
        }
        
        private void ResizeMap()
        {
            if (map == null)
            {
                return;
            }

            mapPanel.Size = new Size((map.Width * TileWidth) + 1, (map.Height * TileHeight) + 1);
            mapPanel.Invalidate();

            if (!hasUnsavedChanges)
            {
                hasUnsavedChanges = true;
                SetTitle();
            }
        }

        private void AddOrRemoveObstacle(MouseEventArgs e)
        {
            var x = e.X / TileWidth;
            var y = e.Y / TileHeight;

            if (e.Button == MouseButtons.Left && !map.IsObstacle(y, x))
            {
                map.AddObstacle(y, x);
                mapPanel.Invalidate();
                miniMapForm.Invalidate();
            }
            else if (e.Button == MouseButtons.Right && map.IsObstacle(y, x))
            {
                map.RemoveObstacle(y, x);
                mapPanel.Invalidate();
                miniMapForm.Invalidate();
            }

            if (!hasUnsavedChanges)
            {
                hasUnsavedChanges = true;
                SetTitle();
            }
        }
    }
}
