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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(663, 231);
            Controls.Add(SpikePic);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            Text = "CowboyBipBoup";
            ((System.ComponentModel.ISupportInitialize)SpikePic).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox SpikePic;
    }
}
