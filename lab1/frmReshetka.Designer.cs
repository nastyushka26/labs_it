namespace laba1IT
{
    partial class frmReshetka
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtStartResh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnInitMatrix = new System.Windows.Forms.Button();
            this.btnCreateTemplate = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnEncipher = new System.Windows.Forms.Button();
            this.btnDecipher = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(49, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1053, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Метод поворачивающейся решетки (английский)";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(643, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(447, 58);
            this.button1.TabIndex = 1;
            this.button1.Text = "Прочитать из файла";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtStartResh
            // 
            this.txtStartResh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtStartResh.Location = new System.Drawing.Point(44, 143);
            this.txtStartResh.Name = "txtStartResh";
            this.txtStartResh.Size = new System.Drawing.Size(543, 50);
            this.txtStartResh.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(51, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 37);
            this.label2.TabIndex = 3;
            this.label2.Text = "Исходный текст";
            // 
            // btnInitMatrix
            // 
            this.btnInitMatrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnInitMatrix.Location = new System.Drawing.Point(44, 235);
            this.btnInitMatrix.Name = "btnInitMatrix";
            this.btnInitMatrix.Size = new System.Drawing.Size(543, 55);
            this.btnInitMatrix.TabIndex = 4;
            this.btnInitMatrix.Text = "Построить матрицу";
            this.btnInitMatrix.UseVisualStyleBackColor = true;
            this.btnInitMatrix.Click += new System.EventHandler(this.btnInitMatrix_Click);
            // 
            // btnCreateTemplate
            // 
            this.btnCreateTemplate.Enabled = false;
            this.btnCreateTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCreateTemplate.Location = new System.Drawing.Point(44, 324);
            this.btnCreateTemplate.Name = "btnCreateTemplate";
            this.btnCreateTemplate.Size = new System.Drawing.Size(543, 55);
            this.btnCreateTemplate.TabIndex = 5;
            this.btnCreateTemplate.Text = "Построить ключ";
            this.btnCreateTemplate.UseVisualStyleBackColor = true;
            this.btnCreateTemplate.Click += new System.EventHandler(this.btnCreateTemplate_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnEncipher
            // 
            this.btnEncipher.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEncipher.Location = new System.Drawing.Point(44, 521);
            this.btnEncipher.Name = "btnEncipher";
            this.btnEncipher.Size = new System.Drawing.Size(310, 89);
            this.btnEncipher.TabIndex = 6;
            this.btnEncipher.Text = "Шифровать";
            this.btnEncipher.UseVisualStyleBackColor = true;
            this.btnEncipher.Click += new System.EventHandler(this.btnEncipher_Click);
            // 
            // btnDecipher
            // 
            this.btnDecipher.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDecipher.Location = new System.Drawing.Point(381, 521);
            this.btnDecipher.Name = "btnDecipher";
            this.btnDecipher.Size = new System.Drawing.Size(294, 89);
            this.btnDecipher.TabIndex = 7;
            this.btnDecipher.Text = "Дешифровать";
            this.btnDecipher.UseVisualStyleBackColor = true;
            this.btnDecipher.Click += new System.EventHandler(this.btnDecipher_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClear.Location = new System.Drawing.Point(700, 521);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(337, 89);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtResult
            // 
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtResult.Location = new System.Drawing.Point(44, 438);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(543, 50);
            this.txtResult.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(643, 235);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(447, 253);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "Введите текст в поле или выберите \"прочитать из файла\". Затем нажмите \"построить " +
    "матрицу\", после чего \"построить ключ\", выберите клетки шаблона и нажмите \"сохран" +
    "ить\". Далее \"Шифровать\"/\"Дешифровать\"";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(51, 398);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(272, 37);
            this.label3.TabIndex = 11;
            this.label3.Text = "Полученный текст";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // frmReshetka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 736);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDecipher);
            this.Controls.Add(this.btnEncipher);
            this.Controls.Add(this.btnCreateTemplate);
            this.Controls.Add(this.btnInitMatrix);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStartResh);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "frmReshetka";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReshetka";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtStartResh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnInitMatrix;
        private System.Windows.Forms.Button btnCreateTemplate;

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnEncipher;
        private System.Windows.Forms.Button btnDecipher;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
    }
}