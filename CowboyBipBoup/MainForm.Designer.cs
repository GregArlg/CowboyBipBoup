namespace CowboyBipBoup
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            SpikePic = new PictureBox();
            InputTextBox = new TextBox();
            InputLabel = new Label();
            StartBtn = new Button();
            MainTableLayoutPanel = new TableLayoutPanel();
            UserControlsPanel = new Panel();
            LogRTB = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)SpikePic).BeginInit();
            MainTableLayoutPanel.SuspendLayout();
            UserControlsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // SpikePic
            // 
            SpikePic.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SpikePic.Image = Properties.Resources.SpikeNeg;
            SpikePic.ImageLocation = "";
            SpikePic.Location = new Point(480, 67);
            SpikePic.Name = "SpikePic";
            SpikePic.Size = new Size(170, 170);
            SpikePic.SizeMode = PictureBoxSizeMode.StretchImage;
            SpikePic.TabIndex = 0;
            SpikePic.TabStop = false;
            // 
            // InputTextBox
            // 
            InputTextBox.Font = new Font("Baskerville Old Face", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InputTextBox.Location = new Point(52, 62);
            InputTextBox.Name = "InputTextBox";
            InputTextBox.Size = new Size(386, 25);
            InputTextBox.TabIndex = 1;
            // 
            // InputLabel
            // 
            InputLabel.AutoSize = true;
            InputLabel.Font = new Font("Baskerville Old Face", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InputLabel.Location = new Point(50, 41);
            InputLabel.Name = "InputLabel";
            InputLabel.Size = new Size(72, 19);
            InputLabel.TabIndex = 2;
            InputLabel.Text = "Xlsx File:";
            // 
            // StartBtn
            // 
            StartBtn.BackColor = Color.FromArgb(64, 64, 64);
            StartBtn.Font = new Font("Baskerville Old Face", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StartBtn.Location = new Point(133, 132);
            StartBtn.Name = "StartBtn";
            StartBtn.Size = new Size(222, 55);
            StartBtn.TabIndex = 3;
            StartBtn.Text = "See you in space, cowboy";
            StartBtn.UseVisualStyleBackColor = false;
            StartBtn.Click += StartBtn_Click;
            // 
            // MainTableLayoutPanel
            // 
            MainTableLayoutPanel.ColumnCount = 1;
            MainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            MainTableLayoutPanel.Controls.Add(UserControlsPanel, 0, 0);
            MainTableLayoutPanel.Controls.Add(LogRTB, 0, 1);
            MainTableLayoutPanel.Dock = DockStyle.Fill;
            MainTableLayoutPanel.Location = new Point(0, 0);
            MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            MainTableLayoutPanel.RowCount = 2;
            MainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 240F));
            MainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            MainTableLayoutPanel.Size = new Size(662, 459);
            MainTableLayoutPanel.TabIndex = 4;
            // 
            // UserControlsPanel
            // 
            UserControlsPanel.Controls.Add(SpikePic);
            UserControlsPanel.Controls.Add(InputTextBox);
            UserControlsPanel.Controls.Add(StartBtn);
            UserControlsPanel.Controls.Add(InputLabel);
            UserControlsPanel.Dock = DockStyle.Fill;
            UserControlsPanel.Location = new Point(3, 3);
            UserControlsPanel.Margin = new Padding(3, 3, 3, 0);
            UserControlsPanel.Name = "UserControlsPanel";
            UserControlsPanel.Size = new Size(656, 237);
            UserControlsPanel.TabIndex = 1;
            // 
            // LogRTB
            // 
            LogRTB.BackColor = Color.FromArgb(32, 32, 32);
            LogRTB.BorderStyle = BorderStyle.None;
            LogRTB.Dock = DockStyle.Fill;
            LogRTB.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LogRTB.ForeColor = Color.ForestGreen;
            LogRTB.Location = new Point(10, 240);
            LogRTB.Margin = new Padding(10, 0, 10, 10);
            LogRTB.Name = "LogRTB";
            LogRTB.ReadOnly = true;
            LogRTB.Size = new Size(642, 209);
            LogRTB.TabIndex = 2;
            LogRTB.Text = "";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(662, 459);
            Controls.Add(MainTableLayoutPanel);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimumSize = new Size(680, 280);
            Name = "MainForm";
            Text = "CowboyBipBoup";
            ((System.ComponentModel.ISupportInitialize)SpikePic).EndInit();
            MainTableLayoutPanel.ResumeLayout(false);
            UserControlsPanel.ResumeLayout(false);
            UserControlsPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox SpikePic;
        private TextBox InputTextBox;
        private Label InputLabel;
        private Button StartBtn;
        private TableLayoutPanel MainTableLayoutPanel;
        private GroupBox UserControlsGB;
        private Panel UserControlsPanel;
        private RichTextBox LogRTB;
    }
}
