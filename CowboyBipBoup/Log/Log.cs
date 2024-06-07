namespace CowboyBipBoup.Log
{
    public class Log
    {
        protected RichTextBox? m_textBox = null;
        protected bool m_valid = false;

        public Log(RichTextBox textBox)
        {
            m_textBox = textBox;

            if (m_textBox != null) m_valid = true;
        }

        public void Message(string txt)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            if (m_textBox.InvokeRequired)
            {
                m_textBox.Invoke(delegate
                {
                    Message(txt);
                });

                return;
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            if (m_valid)
            {
                m_textBox.AppendText("> " + txt + "\n");
            }
        }

        public void Error(string txt)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            if (m_textBox.InvokeRequired)
            {
                m_textBox.Invoke(delegate
                {
                    Error(txt);
                });

                return;
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            if (m_valid)
            {
                m_textBox.SelectionStart = m_textBox.TextLength;
                m_textBox.SelectionLength = 0;

                m_textBox.SelectionColor = Color.Red;
                m_textBox.AppendText("> " + txt + "\n");
                m_textBox.SelectionColor = m_textBox.ForeColor;
            }
        }

        public void Warning(string txt)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            if (m_textBox.InvokeRequired)
            {
                m_textBox.Invoke(delegate
                {
                    Warning(txt);
                });

                return;
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            if (m_valid)
            {
                m_textBox.SelectionStart = m_textBox.TextLength;
                m_textBox.SelectionLength = 0;

                m_textBox.SelectionColor = Color.Orange;
                m_textBox.AppendText("> " + txt + "\n");
                m_textBox.SelectionColor = m_textBox.ForeColor;
            }
        }

        public void Valid(string txt)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            if (m_textBox.InvokeRequired)
            {
                m_textBox.Invoke(delegate
                {
                    Valid(txt);
                });

                return;
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            if (m_valid)
            {
                m_textBox.SelectionStart = m_textBox.TextLength;
                m_textBox.SelectionLength = 0;

                m_textBox.SelectionColor = Color.Green;
                m_textBox.AppendText("> " + txt + "\n");
                m_textBox.SelectionColor = m_textBox.ForeColor;
            }
        }
    }
}
