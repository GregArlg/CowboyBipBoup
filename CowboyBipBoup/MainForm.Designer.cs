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
            ((System.ComponentModel.ISupportInitialize)SpikePic).BeginInit();
            SuspendLayout();
            // 
            // SpikePic
            // 
            SpikePic.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SpikePic.Image = Properties.Resources.SpikeNeg;
            SpikePic.ImageLocation = "";
            SpikePic.Location = new Point(495, 62);
            SpikePic.Name = "SpikePic";
            SpikePic.Size = new Size(170, 170);
            SpikePic.SizeMode = PictureBoxSizeMode.StretchImage;
            SpikePic.TabIndex = 0;
            SpikePic.TabStop = false;
            // 
            // InputTextBox
            // 
            InputTextBox.Location = new Point(40, 62);
            InputTextBox.Name = "InputTextBox";
            InputTextBox.Size = new Size(386, 27);
            InputTextBox.TabIndex = 1;
            // 
            // InputLabel
            // 
            InputLabel.AutoSize = true;
            InputLabel.Location = new Point(40, 39);
            InputLabel.Name = "InputLabel";
            InputLabel.Size = new Size(65, 20);
            InputLabel.TabIndex = 2;
            InputLabel.Text = "Xlsx File:";
            // 
            // StartBtn
            // 
            StartBtn.BackColor = Color.FromArgb(64, 64, 64);
            StartBtn.Font = new Font("Baskerville Old Face", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StartBtn.Location = new Point(128, 124);
            StartBtn.Name = "StartBtn";
            StartBtn.Size = new Size(222, 55);
            StartBtn.TabIndex = 3;
            StartBtn.Text = "See you in space, cowboy";
            StartBtn.UseVisualStyleBackColor = false;
            StartBtn.Click += StartBtn_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(663, 231);
            Controls.Add(StartBtn);
            Controls.Add(InputLabel);
            Controls.Add(InputTextBox);
            Controls.Add(SpikePic);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            Text = "CowboyBipBoup";
            ((System.ComponentModel.ISupportInitialize)SpikePic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox SpikePic;
        private TextBox InputTextBox;
        private Label InputLabel;
        private Button StartBtn;
    }
}
