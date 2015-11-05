namespace Zaggoware.RobotFighter.FormsUI
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.startButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.loggerBox = new System.Windows.Forms.TextBox();
            this.regenerateButton = new System.Windows.Forms.Button();
            this.robotsListBox = new System.Windows.Forms.ListBox();
            this.mapCreatorButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 10;
            this.gameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(52, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(70, 12);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(52, 23);
            this.pauseButton.TabIndex = 1;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // loggerBox
            // 
            this.loggerBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loggerBox.Location = new System.Drawing.Point(620, 12);
            this.loggerBox.Multiline = true;
            this.loggerBox.Name = "loggerBox";
            this.loggerBox.Size = new System.Drawing.Size(144, 168);
            this.loggerBox.TabIndex = 2;
            // 
            // regenerateButton
            // 
            this.regenerateButton.Location = new System.Drawing.Point(128, 12);
            this.regenerateButton.Name = "regenerateButton";
            this.regenerateButton.Size = new System.Drawing.Size(75, 23);
            this.regenerateButton.TabIndex = 3;
            this.regenerateButton.Text = "Regenerate";
            this.regenerateButton.UseVisualStyleBackColor = true;
            this.regenerateButton.Click += new System.EventHandler(this.regenerateButton_Click);
            // 
            // robotsListBox
            // 
            this.robotsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.robotsListBox.FormattingEnabled = true;
            this.robotsListBox.Location = new System.Drawing.Point(620, 186);
            this.robotsListBox.Name = "robotsListBox";
            this.robotsListBox.Size = new System.Drawing.Size(144, 173);
            this.robotsListBox.TabIndex = 4;
            // 
            // mapCreatorButton
            // 
            this.mapCreatorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mapCreatorButton.Location = new System.Drawing.Point(515, 12);
            this.mapCreatorButton.Name = "mapCreatorButton";
            this.mapCreatorButton.Size = new System.Drawing.Size(99, 23);
            this.mapCreatorButton.TabIndex = 5;
            this.mapCreatorButton.Text = "Open MapCreator";
            this.mapCreatorButton.UseVisualStyleBackColor = true;
            this.mapCreatorButton.Click += new System.EventHandler(this.mapCreatorButton_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 596);
            this.Controls.Add(this.mapCreatorButton);
            this.Controls.Add(this.robotsListBox);
            this.Controls.Add(this.regenerateButton);
            this.Controls.Add(this.loggerBox);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.startButton);
            this.DoubleBuffered = true;
            this.Name = "GameForm";
            this.Text = "Robot Fighter";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.TextBox loggerBox;
        private System.Windows.Forms.Button regenerateButton;
        private System.Windows.Forms.ListBox robotsListBox;
        private System.Windows.Forms.Button mapCreatorButton;
    }
}

