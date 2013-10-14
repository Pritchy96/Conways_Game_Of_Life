namespace Base_Project__Always_Copy__
{
    partial class Screen
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
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.LoadStrip = new System.Windows.Forms.MenuStrip();
            this.StillLifeforms = new System.Windows.Forms.ToolStripMenuItem();
            this.Block = new System.Windows.Forms.ToolStripMenuItem();
            this.Beehive = new System.Windows.Forms.ToolStripMenuItem();
            this.oscillatorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spaceShipsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yourSavesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.DrawScreen = new Base_Project__Always_Copy__.DBPanel();
            this.ControlPanel.SuspendLayout();
            this.LoadStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControlPanel
            // 
            this.ControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ControlPanel.Controls.Add(this.LoadStrip);
            this.ControlPanel.Controls.Add(this.btnSave);
            this.ControlPanel.Controls.Add(this.btnClear);
            this.ControlPanel.Controls.Add(this.btnPause);
            this.ControlPanel.Location = new System.Drawing.Point(0, 660);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(799, 122);
            this.ControlPanel.TabIndex = 2;
            // 
            // LoadStrip
            // 
            this.LoadStrip.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.LoadStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.LoadStrip.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StillLifeforms,
            this.oscillatorsToolStripMenuItem,
            this.spaceShipsToolStripMenuItem,
            this.yourSavesToolStripMenuItem});
            this.LoadStrip.Location = new System.Drawing.Point(7, 16);
            this.LoadStrip.Name = "LoadStrip";
            this.LoadStrip.Size = new System.Drawing.Size(433, 24);
            this.LoadStrip.TabIndex = 4;
            this.LoadStrip.Text = "menuStrip1";
            this.LoadStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.LoadStripClick);
            // 
            // StillLifeforms
            // 
            this.StillLifeforms.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Block,
            this.Beehive});
            this.StillLifeforms.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.StillLifeforms.Name = "StillLifeforms";
            this.StillLifeforms.Size = new System.Drawing.Size(94, 20);
            this.StillLifeforms.Text = "Still Lifeforms";
            // 
            // Block
            // 
            this.Block.Name = "Block";
            this.Block.Size = new System.Drawing.Size(152, 22);
            this.Block.Text = "Block";
            // 
            // Beehive
            // 
            this.Beehive.Name = "Beehive";
            this.Beehive.Size = new System.Drawing.Size(152, 22);
            this.Beehive.Text = "Beehive";
            // 
            // oscillatorsToolStripMenuItem
            // 
            this.oscillatorsToolStripMenuItem.Name = "oscillatorsToolStripMenuItem";
            this.oscillatorsToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.oscillatorsToolStripMenuItem.Text = "Oscillators";
            // 
            // spaceShipsToolStripMenuItem
            // 
            this.spaceShipsToolStripMenuItem.Name = "spaceShipsToolStripMenuItem";
            this.spaceShipsToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.spaceShipsToolStripMenuItem.Text = "SpaceShips";
            // 
            // yourSavesToolStripMenuItem
            // 
            this.yourSavesToolStripMenuItem.Name = "yourSavesToolStripMenuItem";
            this.yourSavesToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.yourSavesToolStripMenuItem.Text = "Your Saves";
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(533, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 40);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(662, 62);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(123, 40);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Visible = false;
            // 
            // btnPause
            // 
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPause.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.Location = new System.Drawing.Point(662, 16);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(123, 40);
            this.btnPause.TabIndex = 1;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            // 
            // DrawScreen
            // 
            this.DrawScreen.BackColor = System.Drawing.Color.White;
            this.DrawScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawScreen.Location = new System.Drawing.Point(0, 0);
            this.DrawScreen.Name = "DrawScreen";
            this.DrawScreen.Size = new System.Drawing.Size(799, 781);
            this.DrawScreen.TabIndex = 0;
            this.DrawScreen.Paint += new System.Windows.Forms.PaintEventHandler(this.Redraw);
            this.DrawScreen.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick);
            this.DrawScreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.DrawScreen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoved);
            // 
            // Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 781);
            this.Controls.Add(this.ControlPanel);
            this.Controls.Add(this.DrawScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.LoadStrip;
            this.MaximizeBox = false;
            this.Name = "Screen";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnExit);
            this.SizeChanged += new System.EventHandler(this.ResizeWindow);
            this.ControlPanel.ResumeLayout(false);
            this.ControlPanel.PerformLayout();
            this.LoadStrip.ResumeLayout(false);
            this.LoadStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DBPanel DrawScreen;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.MenuStrip LoadStrip;
        private System.Windows.Forms.ToolStripMenuItem StillLifeforms;
        private System.Windows.Forms.ToolStripMenuItem Block;
        private System.Windows.Forms.ToolStripMenuItem Beehive;
        private System.Windows.Forms.ToolStripMenuItem oscillatorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spaceShipsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yourSavesToolStripMenuItem;

    }
}

