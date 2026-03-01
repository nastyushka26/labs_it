namespace laba1IT
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnReshetka = new System.Windows.Forms.Button();
            this.btnVizhener = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnReshetka
            // 
            this.btnReshetka.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnReshetka.Location = new System.Drawing.Point(43, 135);
            this.btnReshetka.Name = "btnReshetka";
            this.btnReshetka.Size = new System.Drawing.Size(402, 212);
            this.btnReshetka.TabIndex = 0;
            this.btnReshetka.Text = "Метод поворачивающейся решетки";
            this.btnReshetka.UseVisualStyleBackColor = true;
            this.btnReshetka.Click += new System.EventHandler(this.btnReshetka_Click);
            // 
            // btnVizhener
            // 
            this.btnVizhener.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnVizhener.Location = new System.Drawing.Point(469, 135);
            this.btnVizhener.Name = "btnVizhener";
            this.btnVizhener.Size = new System.Drawing.Size(427, 212);
            this.btnVizhener.TabIndex = 1;
            this.btnVizhener.Text = "Алгоритм Виженера, прогрессивный ключ";
            this.btnVizhener.UseVisualStyleBackColor = true;
            this.btnVizhener.Click += new System.EventHandler(this.btnVizhener_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(116, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(671, 51);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите способ шифрования";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 406);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVizhener);
            this.Controls.Add(this.btnReshetka);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReshetka;
        private System.Windows.Forms.Button btnVizhener;
        private System.Windows.Forms.Label label1;
    }
}

