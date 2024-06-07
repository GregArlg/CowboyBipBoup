namespace CowboyBipBoup.View
{
    public partial class OldProgressBar : ProgressBar
    {
        public OldProgressBar()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.UserPaint, true);

            Maximum = 100;
            Step = 1;

            this.ForeColor = Color.Green;
            this.BackColor = Color.Black;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // progress bar rectangle

            DrawProgressBar(pe);

            // draw separators

            DrawSeparators(pe);

            // progress value text

            DrawProgressValue(pe);
        }

        private void DrawSeparators(PaintEventArgs pe)
        {
            int intervalSize = 5;
            int intervalCount = Maximum / 5;
            var intervals = Enumerable.Range(1, intervalCount).Select(x => x * intervalSize * pe.ClipRectangle.Width / Maximum);

            int y = pe.ClipRectangle.Height;

            Pen pen = new Pen(Brushes.Black, 3);

            foreach (int x in intervals)
            {
                pe.Graphics.DrawLine(pen, x, 0, x, y);
            }
        }

        private void DrawProgressValue(PaintEventArgs pe)
        {
            string toDraw = $"{Value}%";
            var f = new Font("Consolas", 11f, FontStyle.Regular, GraphicsUnit.Point, 0);

            Size textSize = TextRenderer.MeasureText(toDraw, f);
            int x = (pe.ClipRectangle.Width - textSize.Width) / 2;
            int y = (pe.ClipRectangle.Height - textSize.Height) / 2;
            Point pt = new Point(x, y);

            TextRenderer.DrawText(pe, toDraw, f, pt, Color.White);
        }

        private void DrawProgressBar(PaintEventArgs pe)
        {
            Rectangle rec = pe.ClipRectangle;

            rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 4;
            rec.Height -= 4;

            Brush br = new SolidBrush(ForeColor);
            pe.Graphics.FillRectangle(br, 2, 2, rec.Width, rec.Height);
        }
    }
}
