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
            RenameOnlyCheckBox = new CheckBox();
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
            SpikePic.Location = new Point(429, 39);
            SpikePic.Margin = new Padding(3, 2, 3, 2);
            SpikePic.Name = "SpikePic";
            SpikePic.Size = new Size(140, 140);
            SpikePic.SizeMode = PictureBoxSizeMode.StretchImage;
            SpikePic.TabIndex = 0;
            SpikePic.TabStop = false;
            // 
            // InputTextBox
            // 
            InputTextBox.Font = new Font("Baskerville Old Face", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InputTextBox.Location = new Point(46, 46);
            InputTextBox.Margin = new Padding(3, 2, 3, 2);
            InputTextBox.Name = "InputTextBox";
            InputTextBox.Size = new Size(338, 21);
            InputTextBox.TabIndex = 1;
            // 
            // InputLabel
            // 
            InputLabel.AutoSize = true;
            InputLabel.Font = new Font("Baskerville Old Face", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InputLabel.Location = new Point(44, 31);
            InputLabel.Name = "InputLabel";
            InputLabel.Size = new Size(58, 16);
            InputLabel.TabIndex = 2;
            InputLabel.Text = "Xlsx File:";
            // 
            // StartBtn
            // 
            StartBtn.BackColor = Color.FromArgb(64, 64, 64);
            StartBtn.Font = new Font("Baskerville Old Face", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StartBtn.Location = new Point(116, 113);
            StartBtn.Margin = new Padding(3, 2, 3, 2);
            StartBtn.Name = "StartBtn";
            StartBtn.Size = new Size(194, 41);
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
            MainTableLayoutPanel.Margin = new Padding(3, 2, 3, 2);
            MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            MainTableLayoutPanel.RowCount = 2;
            MainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 180F));
            MainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            MainTableLayoutPanel.Size = new Size(581, 344);
            MainTableLayoutPanel.TabIndex = 4;
            // 
            // UserControlsPanel
            // 
            UserControlsPanel.Controls.Add(RenameOnlyCheckBox);
            UserControlsPanel.Controls.Add(SpikePic);
            UserControlsPanel.Controls.Add(InputTextBox);
            UserControlsPanel.Controls.Add(StartBtn);
            UserControlsPanel.Controls.Add(InputLabel);
            UserControlsPanel.Dock = DockStyle.Fill;
            UserControlsPanel.Location = new Point(3, 2);
            UserControlsPanel.Margin = new Padding(3, 2, 3, 0);
            UserControlsPanel.Name = "UserControlsPanel";
            UserControlsPanel.Size = new Size(575, 178);
            UserControlsPanel.TabIndex = 1;
            // 
            // RenameOnlyCheckBox
            // 
            RenameOnlyCheckBox.AutoSize = true;
            RenameOnlyCheckBox.Font = new Font("Baskerville Old Face", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RenameOnlyCheckBox.Location = new Point(46, 76);
            RenameOnlyCheckBox.Name = "RenameOnlyCheckBox";
            RenameOnlyCheckBox.Size = new Size(98, 18);
            RenameOnlyCheckBox.TabIndex = 4;
            RenameOnlyCheckBox.Text = "Rename Only";
            RenameOnlyCheckBox.UseVisualStyleBackColor = true;
            // 
            // LogRTB
            // 
            LogRTB.BackColor = Color.FromArgb(32, 32, 32);
            LogRTB.BorderStyle = BorderStyle.None;
            LogRTB.Dock = DockStyle.Fill;
            LogRTB.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LogRTB.ForeColor = Color.FromArgb(224, 224, 224);
            LogRTB.Location = new Point(9, 180);
            LogRTB.Margin = new Padding(9, 0, 9, 8);
            LogRTB.Name = "LogRTB";
            LogRTB.ReadOnly = true;
            LogRTB.Size = new Size(563, 156);
            LogRTB.TabIndex = 2;
            LogRTB.Text = "";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(581, 344);
            Controls.Add(MainTableLayoutPanel);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimumSize = new Size(597, 220);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
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
        private Panel UserControlsPanel;
        private RichTextBox LogRTB;
        private CheckBox RenameOnlyCheckBox;
    }
}
