using System.Drawing;
using System.Windows.Forms;

namespace TypeClipboard
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chkHotkey = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.chkEnter = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(201, 22);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(219, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 22);
            this.button1.TabIndex = 1;
            this.button1.Text = "Type (2s delay)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkHotkey
            // 
            this.chkHotkey.AutoSize = true;
            this.chkHotkey.Location = new System.Drawing.Point(102, 98);
            this.chkHotkey.Name = "chkHotkey";
            this.chkHotkey.Size = new System.Drawing.Size(73, 17);
            this.chkHotkey.TabIndex = 2;
            this.chkHotkey.Text = "F8 hotkey";
            this.toolTip1.SetToolTip(this.chkHotkey, "Enables the F8 hotkey");
            this.chkHotkey.UseVisualStyleBackColor = true;
            this.chkHotkey.CheckedChanged += new System.EventHandler(this.chkHotkey_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(219, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 22);
            this.button2.TabIndex = 4;
            this.button2.Text = "Type (2s delay)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(12, 65);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(201, 22);
            this.textBox2.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 39);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(154, 22);
            this.button3.TabIndex = 6;
            this.button3.Text = "Copy clipboard to buffer";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // chkEnter
            // 
            this.chkEnter.AutoSize = true;
            this.chkEnter.Location = new System.Drawing.Point(177, 98);
            this.chkEnter.Name = "chkEnter";
            this.chkEnter.Size = new System.Drawing.Size(78, 17);
            this.chkEnter.TabIndex = 7;
            this.chkEnter.Text = "Type Enter";
            this.toolTip1.SetToolTip(this.chkEnter, "If set, Type will type newline (\\n) as Enter, which is useful for large blobs of " +
        "text.\r\n\r\nIf unset, Type will stop before the first newline, which is useful for " +
        "passwords.");
            this.chkEnter.UseVisualStyleBackColor = true;
            this.chkEnter.CheckedChanged += new System.EventHandler(this.chkEnter_CheckedChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "SendInput",
            "SendKeys"});
            this.comboBox1.Location = new System.Drawing.Point(12, 95);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(82, 21);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(293, 98);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(29, 13);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Help";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 124);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.chkEnter);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.chkHotkey);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Type Clipboard";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Enter += new System.EventHandler(this.Form1_Enter);
            this.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private ComboBox comboBox1;
        private LinkLabel linkLabel1;
    }
}
