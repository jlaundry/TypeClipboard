using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TypeClipboard
{
    public partial class Form1 : Form
    {
        const int WS_EX_NOACTIVATE = 0x08000000;

        private LowLevelKeyboardListener _listener;
        private Typer _tc;

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

        private void button1_Click(object sender, EventArgs e)
        {
            _tc.TypeClipboard(2000);
        }

        public void UpdateTextbox(EventArgs e = null)
        {
            if (Clipboard.ContainsText(TextDataFormat.UnicodeText))
            {
                String clipboard = Clipboard.GetText(TextDataFormat.UnicodeText);
                StringBuilder sb = new StringBuilder();

                if (clipboard.Length <= 4)
                {
                    sb.Append(" (" + clipboard.Length.ToString() + " characters)");
                }
                else if (clipboard.Length <= 9)
                {
                    sb.Append(clipboard.Substring(0, 1));
                    sb.Append("...");
                    sb.Append(clipboard.Substring(clipboard.Length - 1));
                    sb.Append(" (" + clipboard.Length.ToString() + " characters)");
                }
                else
                {
                    sb.Append(clipboard.Substring(0, 3));
                    sb.Append("...");
                    sb.Append(clipboard.Substring(clipboard.Length - 3));
                    sb.Append(" (" + clipboard.Length.ToString() + " characters)");
                }


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

        private void Form1_Load(object sender, EventArgs e)
        {
            _tc = new Typer();
            _listener = new LowLevelKeyboardListener(_tc);
            // Changing the chkHotkey.Checked property also hooks the listener
            chkHotkey.Checked = Properties.Settings.Default.enableHotkey;

            // Changing the chkEnter.Checked property also changes _tc.TypeEnter property
            chkEnter.Checked = Properties.Settings.Default.enableEnter;

            comboBox1.SelectedItem = Properties.Settings.Default.typeMethod;

            ClipboardNotification.ClipboardUpdate += delegate (object cb_sender, EventArgs cb_e)
            {
                UpdateTextbox();
            };
            UpdateTextbox();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _listener.UnHookKeyboard();
        }

        private void chkHotkey_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.enableHotkey = chkHotkey.Checked;

            if (Properties.Settings.Default.enableHotkey)
            {
                _listener.HookKeyboard();
            }
            else
            {
                _listener.UnHookKeyboard();
            }

            Properties.Settings.Default.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _tc.Type(textBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String clipboard = Clipboard.GetText(TextDataFormat.UnicodeText);
            textBox2.Text = clipboard;
        }

        private void chkEnter_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.enableEnter = chkEnter.Checked;
            _tc.TypeEnter = chkEnter.Checked;
            Properties.Settings.Default.Save();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo { FileName = @"https://github.com/jlaundry/TypeClipboard/wiki/Help", UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open default browser. Go to https://github.com/jlaundry/TypeClipboard/wiki/Help");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.typeMethod = (string)comboBox1.SelectedItem;
            _tc.TypeMethod = (string)comboBox1.SelectedItem;
            Properties.Settings.Default.Save();
        }
    }
}
