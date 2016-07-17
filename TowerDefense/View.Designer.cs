namespace TowerDefense
{
    partial class View
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
            this.GameView = new DoubleBufferedPanel();
            this.PositionLabel = new System.Windows.Forms.Label();
            this.UnitView = new DoubleBufferedPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SpriteWindow = new DoubleBufferedPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GameView
            // 
            this.GameView.Location = new System.Drawing.Point(12, 140);
            this.GameView.Name = "GameView";
            this.GameView.Size = new System.Drawing.Size(1224, 503);
            this.GameView.TabIndex = 0;
            this.GameView.Paint += new System.Windows.Forms.PaintEventHandler(this.GameView_Paint);
            this.GameView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GameView_MouseMove);
            this.GameView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GameView_MouseUp);
            // 
            // PositionLabel
            // 
            this.PositionLabel.AutoSize = true;
            this.PositionLabel.Location = new System.Drawing.Point(960, 108);
            this.PositionLabel.Name = "PositionLabel";
            this.PositionLabel.Size = new System.Drawing.Size(0, 17);
            this.PositionLabel.TabIndex = 1;
            // 
            // UnitView
            // 
            this.UnitView.Location = new System.Drawing.Point(14, 14);
            this.UnitView.Name = "UnitView";
            this.UnitView.Size = new System.Drawing.Size(600, 110);
            this.UnitView.TabIndex = 2;
            this.UnitView.Paint += new System.Windows.Forms.PaintEventHandler(this.UnitView_Paint);
            this.UnitView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UnitView_MouseDown);
            this.UnitView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UnitView_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(750, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 110);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(620, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Currently Selected";
            // 
            // panel1
            // 
            this.SpriteWindow.Location = new System.Drawing.Point(1123, 12);
            this.SpriteWindow.Name = "panel1";
            this.SpriteWindow.Size = new System.Drawing.Size(113, 111);
            this.SpriteWindow.TabIndex = 6;
            this.SpriteWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.SpriteWindow_Paint);
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 655);
            this.Controls.Add(this.SpriteWindow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.UnitView);
            this.Controls.Add(this.PositionLabel);
            this.Controls.Add(this.GameView);
            this.DoubleBuffered = true;
            this.Name = "View";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "Tower Defense";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.View_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel GameView;
        private System.Windows.Forms.Label PositionLabel;
        private System.Windows.Forms.Panel UnitView;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel SpriteWindow;
    }
}

