using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (m_valid)
            {
                m_textBox.AppendText("> " + txt + "\n");
            }
        }

        public void Error(string txt)
        {
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
