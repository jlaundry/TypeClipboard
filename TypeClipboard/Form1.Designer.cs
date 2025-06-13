namespace TypeClipboard
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            textBox1 = new TextBox();
            button1 = new Button();
            chkHotkey = new CheckBox();
            button2 = new Button();
            textBox2 = new TextBox();
            button3 = new Button();
            chkEnter = new CheckBox();
            toolTip1 = new ToolTip(components);
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(211, 22);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(229, 12);
            button1.Name = "button1";
            button1.Size = new Size(103, 22);
            button1.TabIndex = 1;
            button1.Text = "Type (2s delay)";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // chkHotkey
            // 
            chkHotkey.AutoSize = true;
            chkHotkey.Location = new Point(172, 42);
            chkHotkey.Name = "chkHotkey";
            chkHotkey.Size = new Size(77, 19);
            chkHotkey.TabIndex = 2;
            chkHotkey.Text = "F8 hotkey";
            toolTip1.SetToolTip(chkHotkey, "Enables the F8 hotkey");
            chkHotkey.UseVisualStyleBackColor = true;
            chkHotkey.CheckedChanged += chkHotkey_CheckedChanged;
            // 
            // button2
            // 
            button2.Location = new Point(229, 65);
            button2.Name = "button2";
            button2.Size = new Size(103, 22);
            button2.TabIndex = 4;
            button2.Text = "Type (2s delay)";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(12, 65);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(211, 22);
            textBox2.TabIndex = 5;
            // 
            // button3
            // 
            button3.Location = new Point(12, 39);
            button3.Name = "button3";
            button3.Size = new Size(154, 22);
            button3.TabIndex = 6;
            button3.Text = "Copy clipboard to buffer";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // chkEnter
            // 
            chkEnter.AutoSize = true;
            chkEnter.Location = new Point(251, 42);
            chkEnter.Name = "chkEnter";
            chkEnter.Size = new Size(81, 19);
            chkEnter.TabIndex = 7;
            chkEnter.Text = "Type Enter";
            toolTip1.SetToolTip(chkEnter, "If set, Type will type newline (\\n) as Enter, which is useful for large blobs of text.\r\n\r\nIf unset, Type will stop before the first newline, which is useful for passwords.");
            chkEnter.UseVisualStyleBackColor = true;
            chkEnter.CheckedChanged += chkEnter_CheckedChanged;
            // 
            // toolTip1
            // 
            toolTip1.ShowAlways = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 99);
            Controls.Add(chkEnter);
            Controls.Add(button3);
            Controls.Add(textBox2);
            Controls.Add(button2);
            Controls.Add(chkHotkey);
            Controls.Add(button1);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Form1";
            ShowIcon = false;
            Text = "Type Clipboard";
            TopMost = true;
            Activated += Form1_Activated;
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            Enter += Form1_Enter;
            MouseEnter += Form1_MouseEnter;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private CheckBox chkHotkey;
        private Button button2;
        private TextBox textBox2;
        private Button button3;
        private CheckBox chkEnter;
        private ToolTip toolTip1;
    }
}
