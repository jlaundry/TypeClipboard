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
            label1 = new Label();
            comboBox1 = new ComboBox();
            linkLabel1 = new LinkLabel();
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 94);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 8;
            label1.Text = "Mode:";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "SendInput", "SendKeys" });
            comboBox1.Location = new Point(59, 93);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 9;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(186, 94);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(32, 15);
            linkLabel1.TabIndex = 10;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Help";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 123);
            Controls.Add(linkLabel1);
            Controls.Add(comboBox1);
            Controls.Add(label1);
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
        private Label label1;
        private ComboBox comboBox1;
        private LinkLabel linkLabel1;
    }
}
