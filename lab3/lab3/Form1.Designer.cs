namespace lab3
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
            label1 = new Label();
            openFileDialog1 = new OpenFileDialog();
            tabControl1 = new TabControl();
            tbpgEncipher = new TabPage();
            richTextBox1 = new RichTextBox();
            label5 = new Label();
            rtxtbxEnciphered = new RichTextBox();
            btnEbcipher = new Button();
            label4 = new Label();
            txtbxKc = new TextBox();
            txtbxQ = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtbxP = new TextBox();
            btnOpenFile = new Button();
            tbpgDecipher = new TabPage();
            richTextBox2 = new RichTextBox();
            label8 = new Label();
            rtxtbxDeciphered = new RichTextBox();
            btnDecipher = new Button();
            label7 = new Label();
            txtbxKcClosed = new TextBox();
            label6 = new Label();
            txtbxR = new TextBox();
            btnOpenFileDecipher = new Button();
            tabControl1.SuspendLayout();
            tbpgEncipher.SuspendLayout();
            tbpgDecipher.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(385, 10);
            label1.Name = "label1";
            label1.Size = new Size(747, 90);
            label1.TabIndex = 0;
            label1.Text = "Шифрование/Дешифрование с использованием \r\n                          алгоритма RSA";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tbpgEncipher);
            tabControl1.Controls.Add(tbpgDecipher);
            tabControl1.Location = new Point(12, 103);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1460, 790);
            tabControl1.TabIndex = 1;
            // 
            // tbpgEncipher
            // 
            tbpgEncipher.Controls.Add(richTextBox1);
            tbpgEncipher.Controls.Add(label5);
            tbpgEncipher.Controls.Add(rtxtbxEnciphered);
            tbpgEncipher.Controls.Add(btnEbcipher);
            tbpgEncipher.Controls.Add(label4);
            tbpgEncipher.Controls.Add(txtbxKc);
            tbpgEncipher.Controls.Add(txtbxQ);
            tbpgEncipher.Controls.Add(label3);
            tbpgEncipher.Controls.Add(label2);
            tbpgEncipher.Controls.Add(txtbxP);
            tbpgEncipher.Controls.Add(btnOpenFile);
            tbpgEncipher.Font = new Font("Segoe UI", 12F);
            tbpgEncipher.Location = new Point(8, 46);
            tbpgEncipher.Name = "tbpgEncipher";
            tbpgEncipher.Padding = new Padding(3);
            tbpgEncipher.Size = new Size(1444, 736);
            tbpgEncipher.TabIndex = 0;
            tbpgEncipher.Text = "Шифровать";
            tbpgEncipher.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.Font = new Font("Segoe UI", 10F);
            richTextBox1.Location = new Point(35, 478);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(455, 227);
            richTextBox1.TabIndex = 11;
            richTextBox1.Text = "";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(709, 28);
            label5.Name = "label5";
            label5.Size = new Size(583, 45);
            label5.TabIndex = 9;
            label5.Text = "Содержимое зашифрованного файла:";
            // 
            // rtxtbxEnciphered
            // 
            rtxtbxEnciphered.Font = new Font("Courier New", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtxtbxEnciphered.Location = new Point(559, 83);
            rtxtbxEnciphered.Name = "rtxtbxEnciphered";
            rtxtbxEnciphered.ReadOnly = true;
            rtxtbxEnciphered.Size = new Size(863, 634);
            rtxtbxEnciphered.TabIndex = 8;
            rtxtbxEnciphered.Text = "";
            // 
            // btnEbcipher
            // 
            btnEbcipher.Location = new Point(35, 389);
            btnEbcipher.Name = "btnEbcipher";
            btnEbcipher.Size = new Size(455, 59);
            btnEbcipher.TabIndex = 7;
            btnEbcipher.Text = "Шифровать!";
            btnEbcipher.UseVisualStyleBackColor = true;
            btnEbcipher.Click += btnEbcipher_Click;
            btnEbcipher.KeyDown += btnEbcipher_KeyDown;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 292);
            label4.Name = "label4";
            label4.Size = new Size(237, 45);
            label4.TabIndex = 6;
            label4.Text = "Введите Кс (d):";
            // 
            // txtbxKc
            // 
            txtbxKc.Location = new Point(290, 292);
            txtbxKc.Name = "txtbxKc";
            txtbxKc.Size = new Size(200, 50);
            txtbxKc.TabIndex = 5;
            // 
            // txtbxQ
            // 
            txtbxQ.Location = new Point(290, 204);
            txtbxQ.Name = "txtbxQ";
            txtbxQ.Size = new Size(200, 50);
            txtbxQ.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 204);
            label3.Name = "label3";
            label3.Size = new Size(174, 45);
            label3.TabIndex = 3;
            label3.Text = "Введите q:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 121);
            label2.Name = "label2";
            label2.Size = new Size(174, 45);
            label2.TabIndex = 2;
            label2.Text = "Введите p:";
            // 
            // txtbxP
            // 
            txtbxP.Location = new Point(290, 121);
            txtbxP.Name = "txtbxP";
            txtbxP.Size = new Size(200, 50);
            txtbxP.TabIndex = 1;
            txtbxP.KeyPress += txtbxP_KeyPress;
            // 
            // btnOpenFile
            // 
            btnOpenFile.Location = new Point(26, 28);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(464, 58);
            btnOpenFile.TabIndex = 0;
            btnOpenFile.Text = "Выбрать файл";
            btnOpenFile.UseVisualStyleBackColor = true;
            btnOpenFile.Click += btnOpenFile_Click;
            // 
            // tbpgDecipher
            // 
            tbpgDecipher.Controls.Add(richTextBox2);
            tbpgDecipher.Controls.Add(label8);
            tbpgDecipher.Controls.Add(rtxtbxDeciphered);
            tbpgDecipher.Controls.Add(btnDecipher);
            tbpgDecipher.Controls.Add(label7);
            tbpgDecipher.Controls.Add(txtbxKcClosed);
            tbpgDecipher.Controls.Add(label6);
            tbpgDecipher.Controls.Add(txtbxR);
            tbpgDecipher.Controls.Add(btnOpenFileDecipher);
            tbpgDecipher.Font = new Font("Segoe UI", 12F);
            tbpgDecipher.Location = new Point(8, 46);
            tbpgDecipher.Name = "tbpgDecipher";
            tbpgDecipher.Padding = new Padding(3);
            tbpgDecipher.Size = new Size(1444, 736);
            tbpgDecipher.TabIndex = 1;
            tbpgDecipher.Text = "Дешифровать";
            tbpgDecipher.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            richTextBox2.Font = new Font("Segoe UI", 10F);
            richTextBox2.Location = new Point(34, 414);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.ReadOnly = true;
            richTextBox2.Size = new Size(436, 294);
            richTextBox2.TabIndex = 8;
            richTextBox2.Text = "";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(672, 41);
            label8.Name = "label8";
            label8.Size = new Size(603, 45);
            label8.TabIndex = 7;
            label8.Text = "Содержимое расшифрованного файла:";
            // 
            // rtxtbxDeciphered
            // 
            rtxtbxDeciphered.Font = new Font("Courier New", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            rtxtbxDeciphered.Location = new Point(546, 89);
            rtxtbxDeciphered.Name = "rtxtbxDeciphered";
            rtxtbxDeciphered.ReadOnly = true;
            rtxtbxDeciphered.Size = new Size(879, 619);
            rtxtbxDeciphered.TabIndex = 6;
            rtxtbxDeciphered.Text = "";
            // 
            // btnDecipher
            // 
            btnDecipher.Location = new Point(34, 311);
            btnDecipher.Name = "btnDecipher";
            btnDecipher.Size = new Size(436, 59);
            btnDecipher.TabIndex = 5;
            btnDecipher.Text = "Расшифровать!";
            btnDecipher.UseVisualStyleBackColor = true;
            btnDecipher.Click += btnDecipher_Click;
            btnDecipher.KeyDown += btnDecipher_KeyDown;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(34, 217);
            label7.Name = "label7";
            label7.Size = new Size(189, 45);
            label7.TabIndex = 4;
            label7.Text = "Введите Кс:";
            // 
            // txtbxKcClosed
            // 
            txtbxKcClosed.Location = new Point(270, 217);
            txtbxKcClosed.Name = "txtbxKcClosed";
            txtbxKcClosed.Size = new Size(200, 50);
            txtbxKcClosed.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(34, 128);
            label6.Name = "label6";
            label6.Size = new Size(166, 45);
            label6.TabIndex = 2;
            label6.Text = "Введите r:";
            // 
            // txtbxR
            // 
            txtbxR.Location = new Point(270, 128);
            txtbxR.Name = "txtbxR";
            txtbxR.Size = new Size(200, 50);
            txtbxR.TabIndex = 1;
            // 
            // btnOpenFileDecipher
            // 
            btnOpenFileDecipher.Location = new Point(34, 34);
            btnOpenFileDecipher.Name = "btnOpenFileDecipher";
            btnOpenFileDecipher.Size = new Size(436, 58);
            btnOpenFileDecipher.TabIndex = 0;
            btnOpenFileDecipher.Text = "Выбрать файл";
            btnOpenFileDecipher.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1484, 905);
            Controls.Add(tabControl1);
            Controls.Add(label1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Шифратор-Дешифратор RSA";
            tabControl1.ResumeLayout(false);
            tbpgEncipher.ResumeLayout(false);
            tbpgEncipher.PerformLayout();
            tbpgDecipher.ResumeLayout(false);
            tbpgDecipher.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private OpenFileDialog openFileDialog1;
        private TabControl tabControl1;
        private TabPage tbpgEncipher;
        private TabPage tbpgDecipher;
        private Label label2;
        private TextBox txtbxP;
        private Button btnOpenFile;
        private Label label4;
        private TextBox txtbxKc;
        private TextBox txtbxQ;
        private Label label3;
        private Label label5;
        private RichTextBox rtxtbxEnciphered;
        private Button btnEbcipher;
        private Button btnOpenFileDecipher;
        private Label label8;
        private RichTextBox rtxtbxDeciphered;
        private Button btnDecipher;
        private Label label7;
        private TextBox txtbxKcClosed;
        private Label label6;
        private TextBox txtbxR;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
    }
}
