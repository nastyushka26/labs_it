using System.CodeDom.Compiler;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace code                  // полином x^26 + x^8 + x^7 + x + 1
                                // масочка 1 00000 00000 00000 00110 00001 1
                                // используются в обратной связи 26-ой, 8-ой, 7-ой и 1-ый
{
    public partial class frmMain : Form
    {
        // файл для чтения (FileNameOpen) и для сохранения (FilePathForSave)
        public string FileNameOpen, FilePathSaveEncipher = "enciphered.bin", FilePathSaveDecipher = "deciphered.bin";

        public byte[] plainTextBytes, generatedKey, cipherText;
        //public byte[] initKey;
        public int keyStart = 0, registerState = 0;

        public const int MAX_KEY_ENTER = 26;
        //public const int MASK = 0b1_00000_00000_00000_00110_00001;
        public const int MASK_STATE = 0b1_11111_11111_11111_11111_11111; //26 единиц для получения только 26 при сдвигах влево


        public frmMain()
        {
            InitializeComponent();
            rtxtboxKey.Enabled = false;
            btnKeyEnter.Enabled = false;
            //initKey = new byte[MAX_KEY_ENTER]; // создали массив для инициализации ключа
            btnEncipher.Enabled = false;
            btnDecipher.Enabled = false;
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            rtxtboxGenerKey.Text = "";
            rtxtboxCipherText.Text = "";
            lblFile.Text = "Текущий файл: ";
            lblCipher.Text = "Полученное содержание файла";
            lblResKey.Text = "Сгенерированный ключ";
            lblPlain.Text = "Исходное содержимое файла";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // получаем имя файла
                FileNameOpen = openFileDialog1.FileName;
                using (FileStream fs = new FileStream(FileNameOpen, FileMode.Open, FileAccess.Read))
                {
                    // получаем данные файла в массив байтов
                    plainTextBytes = new byte[fs.Length];
                    fs.Read(plainTextBytes, 0, plainTextBytes.Length);
                }

                // тут тоже заменено на вызов метода для отображения данных в двоичном виде
                //// получили в массиве байты - надо отобразить на интерфейсе
                rtxtboxPlainText.Text = output_in_binary(plainTextBytes);
                lblPlain.Text += $" ({plainTextBytes.Length} байт)";

                rtxtboxKey.MaxLength = MAX_KEY_ENTER; // plainTextBytes.Length * 8; // ставим ограничение на ввод количества бит ключа

                rtxtboxKey.Enabled = true;
                btnKeyEnter.Enabled = true;
                generatedKey = new byte[plainTextBytes.Length]; // сгенерированный будет такой же по длине, что и текст
                cipherText = new byte[plainTextBytes.Length]; // массив для зашифрованного
                lblFile.Text += $"\n{FileNameOpen}";
            }
            else
            {
                MessageBox.Show("Вы не выбрали файл!");
            }

        }

        // метод для отображения данных в двоичном виде на интерфейсе
        public string output_in_binary(byte[] data_for_output)
        {
            string binaryData = "";
            string binaryByte = "";
            // если больше 20 байтов - выводим первые и последние 10 байтов
            if (data_for_output.Length > 20)
            {
                for (int i = 0; i < 10; i++)
                {
                    // не добавляет лидирующие нули
                    // конвертируем байты массива в эквивалентное строковое двоичное представление
                    binaryByte = Convert.ToString(data_for_output[i], 2).PadLeft(8, '0');  
                    binaryData += binaryByte + " ";
                }

                binaryData += "\n...\n";
                for (int i = 10; i > 0; i--)
                {
                    binaryByte = Convert.ToString(data_for_output[data_for_output.Length - i - 1], 2).PadLeft(8, '0'); 
                    binaryData += binaryByte + " ";
                }
            }
            else
            {
                for (int i = 0; i < data_for_output.Length; i++)
                {
                    binaryByte = Convert.ToString(data_for_output[i], 2).PadLeft(8, '0'); 
                    binaryData += binaryByte + " ";
                }
            }
            return binaryData;
        }

        // метод для генерации ключа
        public void generate_key()
        {
            // нужно сгенерировать ключ, занести его в массив, потом проксорить, получить шифрованный и его отобразить
            registerState = keyStart;

            // идем по битам - колво байт*8
            for (int i = 0; i < plainTextBytes.Length * 8; i++)
            {
                // нужно проксорить 26, 8, 7 и 1 бит - (1-ый - он же нулевой, поэтому -1)
                int xor = 0;
                xor ^= registerState >> (26 - 1) & 1; // ксор с 26-ым
                xor ^= registerState >> (8 - 1) & 1;
                xor ^= registerState >> (7 - 1) & 1;
                xor ^= registerState >> (1 - 1) & 1;  // ксор с 1-ым
                registerState = registerState << 1; // сдвинули на 1 влево
                byte bit = (byte)(registerState >> 26 & 1); // получаем старший 27 вытолкнувшийся бит для ключа
                registerState = (registerState & MASK_STATE) | xor; // получаем те же 26 бит + справа бит из ксора
                int celoe = i / 8;  // определяем, какой байт идет
                generatedKey[celoe] = (byte)(generatedKey[celoe] << 1 | bit);
            }
        }

        private void btnEncipher_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            // ПОКА ЧТО РАБОТАЕТ ПРАВИЛЬНО
            generate_key(); // генерируем ключ
            // в generatedKey - полученный сгенерированный ключ

            // выводим полученный ключ на экран
            // получили в массиве байты - надо отобразить на интерфейсе
            rtxtboxGenerKey.Text = output_in_binary(generatedKey);

            // ШИФРУЕМ XOROM!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            for (int i = 0; i < generatedKey.Length; i++)
            {
                cipherText[i] = (byte)(generatedKey[i] ^ plainTextBytes[i]);
            }

            // выводим полученный шифр
            // получили в массиве байты - надо отобразить на интерфейсе
            rtxtboxCipherText.Text = output_in_binary(cipherText);
            lblResKey.Text += $" ({generatedKey.Length} байт)";
            lblCipher.Text += $" ({cipherText.Length} байт)";

            File.WriteAllBytes(FilePathSaveEncipher, cipherText);
            MessageBox.Show("Файл зашифрован! См. enciphered.bin");
        }

        private void btnDecipher_Click(object sender, EventArgs e)
        {
            // ПОКА ЧТО РАБОТАЕТ ПРАВИЛЬНО
            generate_key(); // генерируем ключ
            // в generatedKey - полученный сгенерированный ключ

            // выводим полученный ключ на экран
            // получили в массиве байты - надо отобразить на интерфейсе
            rtxtboxGenerKey.Text = output_in_binary(generatedKey);


            // ДЕШИФРУЕМ XOROM!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            for (int i = 0; i < generatedKey.Length; i++)
            {
                cipherText[i] = (byte)(generatedKey[i] ^ plainTextBytes[i]);
            }

            // выводим полученный шифр
            // получили в массиве байты - надо отобразить на интерфейсе
            rtxtboxCipherText.Text = output_in_binary(cipherText);
            lblResKey.Text += $" ({generatedKey.Length} байт)";
            lblCipher.Text += $" ({cipherText.Length} байт)";

            File.WriteAllBytes(FilePathSaveDecipher, cipherText);
            MessageBox.Show("Файл расшифрован! См. deciphered.bin");
        }

        private void btnKeyEnter_Click(object sender, EventArgs e)
        {
            
            //lblPlain.Text = "Исходное содержимое файла";
            if (rtxtboxKey.Text.Length > 0)
            {
                label5.Text = "";
                lblEnterLeft.Text = "Ключ введен";
                rtxtboxKey.Text = (rtxtboxKey.Text).Replace("\r\n", "");
                if (rtxtboxKey.Text.Length < MAX_KEY_ENTER)
                {
                    // лучше дозаполнить нулями - заполняется справа нулями
                    while (rtxtboxKey.Text.Length < MAX_KEY_ENTER)
                    {
                        rtxtboxKey.Text += '0';
                    }
                }

                // получаем просто число - инициализатор ключа
                keyStart = Convert.ToInt32(rtxtboxKey.Text, 2);
                btnEncipher.Enabled = true;
                btnDecipher.Enabled = true;
            }
            else
            {
                MessageBox.Show("Вы не ввели значение ключа!");
            }
        }

        private void rtxtboxKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnKeyEnter_Click(sender, e);
                e.SuppressKeyPress = true; // Чтобы не было "пиканья"
                return;
            }

            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete ||
                e.KeyCode == Keys.Left || e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Home || e.KeyCode == Keys.End ||
                e.KeyCode == Keys.Tab)
            {
                if ((e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete) && rtxtboxKey.TextLength <= 26)
                {
                    if (26 - rtxtboxKey.TextLength + 1<=26)
                    lblEnterLeft.Text = $"Осталось ввести: {26 - rtxtboxKey.TextLength+1} бит";
                }
                // Разрешаем навигационные и редактирующие клавиши
                return;
            }

            // введены 1 и 0
            if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D1) || 
                (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad1))
            {
                if (rtxtboxKey.TextLength <= 25)
                {
                    lblEnterLeft.Text = $"Осталось ввести: {25 - rtxtboxKey.TextLength} бит";
                }
                return;
            }

            // Все остальные клавиши блокируем
            e.SuppressKeyPress = true;
            label5.Text = "В поле ключа можно вводить только 0 и 1!";

            // устанавливаем курсор на конец текста
            rtxtboxKey.SelectionStart = rtxtboxKey.TextLength;
            rtxtboxKey.SelectionLength = 0;
            rtxtboxKey.Focus();
            rtxtboxKey.ScrollToCaret();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblEnterLeft.Text = "Осталось ввести: 26 бит";
            rtxtboxKey.Clear();
            rtxtboxCipherText.Clear();
            rtxtboxGenerKey.Clear();
            rtxtboxPlainText.Clear();
            btnKeyEnter.Enabled = false;
            rtxtboxKey.Enabled = false;
            btnEncipher.Enabled = false;
            btnDecipher.Enabled = false;
            lblCipher.Text = "Полученное содержание файла";
            lblResKey.Text = "Сгенерированный ключ";
            lblPlain.Text = "Исходное содержимое файла";
        }
    }
}
