namespace CowboyBipBoup.View
{
    partial class LoadingScreen
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
            MainTableLayoutPanel = new TableLayoutPanel();
            OldProgressBar = new OldProgressBar();
            GifPictureBox = new PictureBox();
            MainTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GifPictureBox).BeginInit();
            SuspendLayout();
            // 
            // MainTableLayoutPanel
            // 
            MainTableLayoutPanel.ColumnCount = 1;
            MainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            MainTableLayoutPanel.Controls.Add(OldProgressBar, 0, 1);
            MainTableLayoutPanel.Controls.Add(GifPictureBox, 0, 0);
            MainTableLayoutPanel.Dock = DockStyle.Fill;
            MainTableLayoutPanel.Location = new Point(0, 0);
            MainTableLayoutPanel.Margin = new Padding(0);
            MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            MainTableLayoutPanel.RowCount = 2;
            MainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 420F));
            MainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            MainTableLayoutPanel.Size = new Size(500, 462);
            MainTableLayoutPanel.TabIndex = 0;
            // 
            // OldProgressBar
            // 
            OldProgressBar.BackColor = Color.Black;
            OldProgressBar.Dock = DockStyle.Fill;
            OldProgressBar.ForeColor = Color.Green;
            OldProgressBar.Location = new Point(3, 423);
            OldProgressBar.Name = "OldProgressBar";
            OldProgressBar.Size = new Size(494, 36);
            OldProgressBar.TabIndex = 0;
            // 
            // GifPictureBox
            // 
            GifPictureBox.Dock = DockStyle.Fill;
            GifPictureBox.Image = Properties.Resources.ed_bipboup;
            GifPictureBox.Location = new Point(0, 0);
            GifPictureBox.Margin = new Padding(0);
            GifPictureBox.Name = "GifPictureBox";
            GifPictureBox.Size = new Size(500, 420);
            GifPictureBox.TabIndex = 1;
            GifPictureBox.TabStop = false;
            // 
            // LoadingScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(500, 462);
            Controls.Add(MainTableLayoutPanel);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoadingScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoadingScreen";
            Shown += LoadingScreen_Shown;
            MainTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)GifPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel MainTableLayoutPanel;
        private OldProgressBar OldProgressBar;
        private PictureBox GifPictureBox;
    }
}