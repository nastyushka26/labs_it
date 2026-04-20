using System;
using System.ComponentModel.Design.Serialization;
using System.IO;

namespace lab3
{
    public partial class Form1 : Form
    {
        public struct Key // структура для полей ключа
        {
            public int e = 0;
            public int d = 0;
            public int r;
            public bool Open;
            public Key(int chislo, int r, bool Open)
            {
                if (Open)
                    this.e = chislo;
                else
                    this.d = chislo;
                this.r = r;
                this.Open = Open;
            }
        }

        byte[] bytesToModify, resultBytes;
        string OpenedFileName = "", encipheredFileName = "enciphered.bin", decipheredFileName = "deciphered.bin";
        string empty = "", prostye = "", menshe1bolshe2 = "", file_not_chosen = "", KclosedProstoye = "";
        Key KOpen, KClosed;
        int p, q, r, d, fi_x;  // сами секретные поля, вводимые пользователем

        public Form1()
        {
            InitializeComponent();
            txtbxP.KeyDown += btnEbcipher_KeyDown;
            txtbxQ.KeyDown += btnEbcipher_KeyDown;
            txtbxKc.KeyDown += btnEbcipher_KeyDown;

            txtbxR.KeyDown += btnDecipher_KeyDown;
            txtbxKcClosed.KeyDown += btnDecipher_KeyDown;

            txtbxQ.KeyPress += txtbxP_KeyPress;
            txtbxKc.KeyPress += txtbxP_KeyPress;
            txtbxKcClosed.KeyPress += txtbxP_KeyPress;
            txtbxR.KeyPress += txtbxP_KeyPress;

            btnOpenFileDecipher.Click += btnOpenFile_Click;
        }

        // функция для быстрого возведения в степень по модулю
        public int fastExp(int a, int z, int n)
        {
            int a1 = a, z1 = z, result = 1;
            while (z1 != 0)
            {
                while (z1 % 2 == 0)
                {
                    z1 = z1 / 2;
                    a1 = (a1 * a1) % n;
                }
                z1--;
                result = (result * a1) % n;
            }
            return result;
        }

        public void cipher_modify(Key key)
        {
            int bytes_count = bytesToModify.Length;
            if (!key.Open)
                bytes_count /= 2;
            //if (key.Open)
            //    resultBytes = new byte[bytesToModify.Length * 2]; // в зашифрованный файл - 16 бит
            //else
            //    resultBytes = new byte[bytesToModify.Length];
            if (key.Open)
                resultBytes = new byte[bytes_count * 2];
            else
                resultBytes = new byte[bytes_count];

            for (int i = 0; i < bytes_count; i++)
            {
                if (key.Open)  // получаем 2 байта на байт
                {
                    //resultBytes[i] = (byte)fastExp((int)(bytesToModify[i]), key.e, key.r);
                    ushort two_bytes = (ushort)fastExp((int)(bytesToModify[i]), key.e, key.r);     // получаем 16 бит
                    resultBytes[2 * i] = (byte)(two_bytes >> 8);       // получаем старшие 8 бит
                    resultBytes[2 * i + 1] = (byte)(two_bytes & 0xff); // получаем младшие 8 бит
                }
                else // из 2 байт получаем 1
                {                        // зануляем
                    ushort two_bytes = (ushort)((bytesToModify[2 * i] << 8) | bytesToModify[2 * i + 1]);
                    resultBytes[i] = (byte)fastExp((int)(two_bytes), key.d, key.r);
                }
            }
        }

        // определяем, является ли число простым
        public bool is_prime(int a)
        {
            if (a < 2)
                return false;
            for (int i = 2; i < (int)(Math.Sqrt(a)) + 1; i++)
            {
                if (a % i == 0)
                    return false;
            }
            return true;
        }
        
        // алгоритм Евклида для нахождения просто НОД
        public int gcd(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a = a % b;
                else
                    b = b % a;
            }
            return a + b;
        }

        // p, q должны быть простыми + Кс нормальный
        public bool check_fields()
        {
            if (tabControl1.SelectedTab == tbpgEncipher)
            {
                if (txtbxP.Text == "" || txtbxQ.Text == "" || txtbxKc.Text == "")
                {
                    empty = "Не все поля заполнены! ";
                    return false;
                }

                // P и Q точно числа 
                bool p_res = int.TryParse(txtbxP.Text, out p);
                bool q_res = int.TryParse(txtbxQ.Text, out q);
                // P и Q должны быть простыми
                if (!is_prime(p) || !is_prime(q)) // не простые 
                {
                    prostye = "P и/или Q не простые! ";
                    return false;
                }
                // все нормально с p и q - находим r и функцию Эйлера
                r = p * q;
                if (255 >= r || r >= 65536)  // модуль >= 2 байт или == 1 байт
                {
                    menshe1bolshe2 = "Модуль r (p*q) должен быть \nбольше 255 (1 байт) и меньше 65536 (2 байта). ";
                    return false;
                }

                fi_x = (p - 1) * (q - 1);

                // Закрытый ключ тоже число - парсим из строки в переменную числовую
                int.TryParse(txtbxKc.Text, out d);
                string res_d = "";
                // первое условие - 1<d<fi_x
                if (d <= 1 || d >= fi_x)
                {
                    res_d += $"Значение закрытого ключа \nне попадает в диапазон 1 < Kc < fi = {fi_x}. ";
                    KclosedProstoye = res_d;
                    return false;
                }
                // второе условие - взаимно простое с функцией Эйлера
                if (gcd(d, fi_x) != 1)
                    res_d += $"Закрытый ключ \nне взаимно простой с функцией Эйлера (fi = {fi_x}). ";
                KclosedProstoye = res_d;
                if (KclosedProstoye != "")
                    return false;
                // Закрытый ключ прошел все проверки - все нормально

                KClosed = new Key(d, r, false); // не знаю пока, нужна мне эта структура или не
            }
            else
            {
                if (txtbxR.Text == "" || txtbxKcClosed.Text == "")
                {
                    empty = "Не все поля заполнены! ";
                    return false;
                }

                // модуль ввели
                int.TryParse(txtbxR.Text, out r);
                if (255 >= r || r >= 65536)  // модуль >= 2 байт или == 1 байт
                {
                    menshe1bolshe2 = "Модуль r должен быть больше \n255 (1 байт) и меньше 65536 (2 байта). ";
                    return false;
                }

                // Закрытый ключ тоже число - парсим из строки в переменную числовую
                int.TryParse(txtbxKcClosed.Text, out d);
                string res_d = "";
                // первое условие - 1<d<fi_x
                if (d <= 1)
                    res_d += "Значение закрытого ключа \nне попадает в диапазон 1 < Kc < fi. ";
                KclosedProstoye = res_d;
                if (KclosedProstoye != "")
                    return false;
                KClosed = new Key(d, r, false); // не знаю пока, нужна мне эта структура или не
            }

            // Выбран файл для модификаций?
            if (OpenedFileName == "")
            {
                file_not_chosen = "Вы не выбрали файл! ";
                return false;
            }

            return true;
        }

        // вычисление открытого ключа
        public Key kOpen_calculate(int d, int r)
        {
            int e;
            e = euclideX(fi_x, d);
            if (e < 0)
                e += fi_x;
            return new Key(e, r, true);
        }

        // расширенный алгоритм Евклида для нахождения
        // инверсного мультипликативного e
        public int euclideX(int a, int b)
        {
            // x1*a + y1*b = d1, d1 = gcd(a, b)
            int d0 = a, d1 = b,
                x0 = 1, x1 = 0,
                y0 = 0, y1 = 1;
            int d2, x2, y2;
            int quotient;

            while (d1 > 1)
            {
                quotient = d0 / d1;
                d2 = d0 % d1;
                x2 = x0 - quotient * x1;
                y2 = y0 - quotient * y1;
                d0 = d1; d1 = d2;
                x0 = x1; x1 = x2;
                y0 = y1; y1 = y2;
            }

            // в d1 - НОД = 1, y1 - е
            return y1;  // мультипликативное инверсное e
        }

        public void show_result_file(byte[] data, RichTextBox textBox)
        {
            int count = 0;
            if (tabControl1.SelectedTab == tbpgEncipher)
            {
                int columns = 5;
                if (data.Length > 200)
                {
                    for (int i = 0; i < 40; i = i + 2)
                    {
                        ushort chislo = (ushort)(data[i] << 8 | data[i + 1]);
                        textBox.Text += $"{chislo,7}"; // 8 позиций на число, выравнивание вправо

                        if ((count + 1) % columns == 0)
                            textBox.Text += "\n";
                        count++;
                    }
                    count = 0;
                    textBox.Text += "..................................\n";
                    for (int i = data.Length - 40; i < data.Length; i = i + 2)
                    {
                        ushort chislo = (ushort)(data[i] << 8 | data[i + 1]);
                        textBox.Text += $"{chislo,7}"; // 8 позиций на число, выравнивание вправо

                        if ((count + 1) % columns == 0)
                            textBox.Text += "\n";
                        count++;
                    }
                }
                else
                {
                    for (int i = 0; i < data.Length / 2; i++)
                    {
                        ushort chislo = (ushort)(data[2 * i] << 8 | data[2 * i + 1]);
                        textBox.Text += $"{chislo,7}"; // 8 позиций на число, выравнивание вправо

                        if ((i + 1) % columns == 0)
                            textBox.Text += "\n";
                    }
                }
            }
            else
            {
                int columns = 5;
                if (data.Length > 100)
                {
                    count = 0;
                    for (int i = 0; i < 20; i++)
                    {
                        textBox.Text += $"{data[i],7}"; // 8 позиций на число, выравнивание вправо

                        if ((count + 1) % columns == 0)
                            textBox.Text += "\n";
                        count++;
                    }
                    textBox.Text += "..................................\n";
                    count = 0;
                    for (int i = data.Length - 20; i < data.Length; i++)
                    {
                        textBox.Text += $"{data[i],7}"; // 8 позиций на число, выравнивание вправо

                        if ((count + 1) % columns == 0)
                            textBox.Text += "\n";
                        count++;
                    }
                }
                else
                {
                    for (int i = 0; i < data.Length; i++)
                    {
                        textBox.Text += $"{data[i],7}"; // 8 позиций на число, выравнивание вправо

                        if ((i + 1) % columns == 0)
                            textBox.Text += "\n";
                    }
                }
            }
        }

        private void btnEbcipher_Click(object sender, EventArgs e)
        {
            prostye = "";
            empty = "";
            file_not_chosen = "";
            KclosedProstoye = "";
            menshe1bolshe2 = "";
            rtxtbxEnciphered.Text = "";
            if (check_fields())
            {
                //resultBytes = new byte[bytesToModify.Length];
                KOpen = kOpen_calculate(KClosed.d, KClosed.r);
                cipher_modify(KOpen);
                show_result_file(resultBytes, rtxtbxEnciphered);
                File.WriteAllBytes(encipheredFileName, resultBytes);  // записали зашифрованное в файл
                MessageBox.Show("Файл зашифрован! См. enciphered.bin");
            }
            else
            {
                MessageBox.Show($"Некорректные данные! {empty}{prostye}{menshe1bolshe2}" +
                    $"{KclosedProstoye}{file_not_chosen}", "Ошибка");
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                OpenedFileName = openFileDialog1.FileName;
                bytesToModify = File.ReadAllBytes(OpenedFileName);
                if (tabControl1.SelectedTab == tbpgEncipher)
                    richTextBox1.Text = $"Выбран файл:\n{OpenedFileName}";
                else
                    richTextBox2.Text = $"Выбран файл:\n{OpenedFileName}";
            }
        }

        private void btnOpenFileDecipher_Click(object sender, EventArgs e)
        {
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    OpenedFileName = openFileDialog1.FileName;
            //    bytesToModify = File.ReadAllBytes(OpenedFileName);
            //}
        }

        private void btnEbcipher_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEbcipher_Click(sender, e);
                e.SuppressKeyPress = true; // Чтобы не было "пиканья"
                return;
            }
        }

        private void btnDecipher_Click(object sender, EventArgs e)
        {
            prostye = "";
            empty = "";
            file_not_chosen = "";
            KclosedProstoye = "";
            menshe1bolshe2 = "";
            rtxtbxDeciphered.Text = "";
            if (check_fields())
            {
                //resultBytes = new byte[bytesToModify.Length];
                //KOpen = kOpen_calculate(KClosed.d, KClosed.r);  // тут нет открытого ключа в дешифровании
                cipher_modify(KClosed);
                show_result_file(resultBytes, rtxtbxDeciphered);
                File.WriteAllBytes(decipheredFileName, resultBytes);  // записали зашифрованное в файл
                MessageBox.Show("Файл расшифрован! См. deciphered.bin");
            }
            else
            {
                MessageBox.Show($"Некорректные данные! {empty}{prostye}{menshe1bolshe2}" +
                    $"{KclosedProstoye}{file_not_chosen}", "Ошибка");
            }
        }

        public bool check_key_codes(KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || char.IsControl(e.KeyChar))
            {
                return true;
            }
            MessageBox.Show("В это поле можно вводить только цифры!", "Ошибка ввода");
            return false;
        }

        private void txtbxP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!check_key_codes(e))
                e.Handled = true; // This prevents the character from being entered
        }

        private void btnDecipher_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDecipher_Click(sender, e);
                e.SuppressKeyPress = true; // Чтобы не было "пиканья"
                return;
            }
        }
    }
}
