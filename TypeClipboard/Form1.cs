using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TypeClipboard
{
    public partial class Form1 : Form
    {
        const int WS_EX_NOACTIVATE = 0x08000000;

        public Form1()
        {
            InitializeComponent();
            Thread.Sleep(100);
        }

        //
        // https://stackoverflow.com/questions/2795558/c-sharp-sending-keyboard-events-to-last-selected-window
        // Chris Taylor, licenced under CC BY-SA 3.0
        //
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams param = base.CreateParams;
                param.ExStyle |= WS_EX_NOACTIVATE;
                return param;
            }
        }

        public void TypeClipboard()
        {
            if (Clipboard.ContainsText(TextDataFormat.UnicodeText))
            {
                String clipboard = Clipboard.GetText(TextDataFormat.UnicodeText);
                Thread.Sleep(2000);
                foreach (Char c in clipboard.ToCharArray())
                {
                    // Some characters have special meaning
                    // https://docs.microsoft.com/en-us/office/vba/language/reference/user-interface-help/sendkeys-statement
                    switch (c)
                    {
                        case '\n':
                            return;
                        case '\r':
                            return;
                        case '{':
                            SendKeys.Send("{{}");
                            break;
                        case '}':
                            SendKeys.Send("{}}");
                            break;
                        case '+':
                            SendKeys.Send("{+}");
                            break;
                        case '^':
                            SendKeys.Send("{^}");
                            break;
                        case '%':
                            SendKeys.Send("{%}");
                            break;
                        case '~':
                            SendKeys.Send("{~}");
                            break;
                        case '(':
                            SendKeys.Send("{(}");
                            break;
                        case ')':
                            SendKeys.Send("{)}");
                            break;
                        default:
                            SendKeys.Send(c.ToString());
                            break;
                    }
                    Thread.Sleep(10);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TypeClipboard();
        }

        public void UpdateTextbox()
        {
            if (Clipboard.ContainsText(TextDataFormat.UnicodeText))
            {
                String clipboard = Clipboard.GetText(TextDataFormat.UnicodeText);
                StringBuilder sb = new StringBuilder();
                sb.Append(clipboard.Substring(0, Math.Min(3, clipboard.Length)));
                sb.Append(" ... ");
                sb.Append(clipboard.Substring(clipboard.Length - Math.Min(clipboard.Length, 3)));
                sb.Append(" (" + clipboard.Length.ToString() + " characters)");
                textBox1.Text = sb.ToString();
            }
            else
            {
                textBox1.Text = "No UnicodeText in clipboard";
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            UpdateTextbox();
        }

        private void Form1_Enter(object sender, EventArgs e)
        {
            UpdateTextbox();
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            UpdateTextbox();
        }
    }
}
