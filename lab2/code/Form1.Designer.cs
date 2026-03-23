namespace code
{
    partial class frmMain
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
            btnLoadFile = new Button();
            rtxtboxPlainText = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            rtxtboxGenerKey = new RichTextBox();
            btnKeyEnter = new Button();
            label3 = new Label();
            rtxtboxCipherText = new RichTextBox();
            btnEncipher = new Button();
            btnDecipher = new Button();
            label4 = new Label();
            rtxtboxKey = new RichTextBox();
            openFileDialog1 = new OpenFileDialog();
            btnClear = new Button();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            lblEnterLeft = new Label();
            SuspendLayout();
            // 
            // btnLoadFile
            // 
            btnLoadFile.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnLoadFile.Location = new Point(1094, 470);
            btnLoadFile.Name = "btnLoadFile";
            btnLoadFile.Size = new Size(305, 75);
            btnLoadFile.TabIndex = 0;
            btnLoadFile.Text = "Выбрать файл";
            btnLoadFile.UseVisualStyleBackColor = true;
            btnLoadFile.Click += btnLoadFile_Click;
            // 
            // rtxtboxPlainText
            // 
            rtxtboxPlainText.Font = new Font("Segoe UI", 14F);
            rtxtboxPlainText.Location = new Point(52, 470);
            rtxtboxPlainText.Name = "rtxtboxPlainText";
            rtxtboxPlainText.ReadOnly = true;
            rtxtboxPlainText.Size = new Size(992, 58);
            rtxtboxPlainText.TabIndex = 1;
            rtxtboxPlainText.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(52, 422);
            label1.Name = "label1";
            label1.Size = new Size(254, 45);
            label1.TabIndex = 2;
            label1.Text = "Исходный текст";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(52, 264);
            label2.Name = "label2";
            label2.Size = new Size(377, 45);
            label2.TabIndex = 3;
            label2.Text = "Сгенерированный ключ";
            // 
            // rtxtboxGenerKey
            // 
            rtxtboxGenerKey.Font = new Font("Segoe UI", 14F);
            rtxtboxGenerKey.Location = new Point(52, 312);
            rtxtboxGenerKey.Name = "rtxtboxGenerKey";
            rtxtboxGenerKey.ReadOnly = true;
            rtxtboxGenerKey.Size = new Size(992, 67);
            rtxtboxGenerKey.TabIndex = 4;
            rtxtboxGenerKey.Text = "";
            // 
            // btnKeyEnter
            // 
            btnKeyEnter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnKeyEnter.Location = new Point(1094, 178);
            btnKeyEnter.Name = "btnKeyEnter";
            btnKeyEnter.Size = new Size(305, 64);
            btnKeyEnter.TabIndex = 5;
            btnKeyEnter.Text = "ОК";
            btnKeyEnter.UseVisualStyleBackColor = true;
            btnKeyEnter.Click += btnKeyEnter_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(52, 562);
            label3.Name = "label3";
            label3.Size = new Size(290, 45);
            label3.TabIndex = 6;
            label3.Text = "Полученный текст";
            // 
            // rtxtboxCipherText
            // 
            rtxtboxCipherText.Font = new Font("Segoe UI", 14F);
            rtxtboxCipherText.Location = new Point(52, 620);
            rtxtboxCipherText.Name = "rtxtboxCipherText";
            rtxtboxCipherText.ReadOnly = true;
            rtxtboxCipherText.Size = new Size(992, 62);
            rtxtboxCipherText.TabIndex = 7;
            rtxtboxCipherText.Text = "";
            // 
            // btnEncipher
            // 
            btnEncipher.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnEncipher.Location = new Point(179, 733);
            btnEncipher.Name = "btnEncipher";
            btnEncipher.Size = new Size(305, 71);
            btnEncipher.TabIndex = 8;
            btnEncipher.Text = "Шифровать";
            btnEncipher.UseVisualStyleBackColor = true;
            btnEncipher.Click += btnEncipher_Click;
            // 
            // btnDecipher
            // 
            btnDecipher.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnDecipher.Location = new Point(556, 733);
            btnDecipher.Name = "btnDecipher";
            btnDecipher.Size = new Size(305, 71);
            btnDecipher.TabIndex = 9;
            btnDecipher.Text = "Расшифровать";
            btnDecipher.UseVisualStyleBackColor = true;
            btnDecipher.Click += btnDecipher_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(52, 126);
            label4.Name = "label4";
            label4.Size = new Size(230, 45);
            label4.TabIndex = 10;
            label4.Text = "Ключ (26 бит):";
            // 
            // rtxtboxKey
            // 
            rtxtboxKey.Font = new Font("Segoe UI", 14F);
            rtxtboxKey.Location = new Point(52, 178);
            rtxtboxKey.Name = "rtxtboxKey";
            rtxtboxKey.Size = new Size(992, 64);
            rtxtboxKey.TabIndex = 11;
            rtxtboxKey.Text = "";
            rtxtboxKey.KeyDown += rtxtboxKey_KeyDown;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI", 12F);
            btnClear.Location = new Point(929, 733);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(305, 71);
            btnClear.TabIndex = 12;
            btnClear.Text = "Очистить";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.Location = new Point(291, 126);
            label5.Name = "label5";
            label5.Size = new Size(0, 45);
            label5.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(206, 9);
            label6.Name = "label6";
            label6.Size = new Size(1054, 45);
            label6.TabIndex = 14;
            label6.Text = "Добро пожаловать в шифратор/дешифратор с использованием LFSR!";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F);
            label7.Location = new Point(221, 63);
            label7.Name = "label7";
            label7.Size = new Size(1013, 41);
            label7.TabIndex = 15;
            label7.Text = "Выберите файл, введите ключ и нажмите \"шифровать\"/\"расшифровать\"";
            // 
            // lblEnterLeft
            // 
            lblEnterLeft.AutoSize = true;
            lblEnterLeft.Font = new Font("Segoe UI", 11F);
            lblEnterLeft.Location = new Point(1094, 130);
            lblEnterLeft.Name = "lblEnterLeft";
            lblEnterLeft.Size = new Size(345, 41);
            lblEnterLeft.TabIndex = 16;
            lblEnterLeft.Text = "Осталось ввести: 26 бит";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1465, 844);
            Controls.Add(lblEnterLeft);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(btnClear);
            Controls.Add(rtxtboxKey);
            Controls.Add(label4);
            Controls.Add(btnDecipher);
            Controls.Add(btnEncipher);
            Controls.Add(rtxtboxCipherText);
            Controls.Add(label3);
            Controls.Add(btnKeyEnter);
            Controls.Add(rtxtboxGenerKey);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(rtxtboxPlainText);
            Controls.Add(btnLoadFile);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Шифратор/Дешифратор";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLoadFile;
        private RichTextBox rtxtboxPlainText;
        private Label label1;
        private Label label2;
        private RichTextBox rtxtboxGenerKey;
        private Button btnKeyEnter;
        private Label label3;
        private RichTextBox rtxtboxCipherText;
        private Button btnEncipher;
        private Button btnDecipher;
        private Label label4;
        private RichTextBox rtxtboxKey;
        private OpenFileDialog openFileDialog1;
        private Button btnClear;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label lblEnterLeft;
    }
}
