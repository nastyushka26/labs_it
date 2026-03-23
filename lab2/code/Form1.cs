using System.CodeDom.Compiler;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace code                  // полином x^26 + x^8 + x^7 + x + 1
                                // масочка 1 00000 00000 00000 00110 00001 1
                                // используются в обратной связи 26-ой, 8-ой, 7-ой и 1-ый
{
    public partial class frmMain : Form
    {
        // файл для чтения (FileNameOpen) и для сохранения (FilePathForSave)
        public string FileNameOpen, FilePathForSave = "..\\saved_data.bin";  

        public byte[] plainTextBytes, generatedKey, cipherText;
        public byte[] initKey;
        public int keyStart = 0, registerState = 0;

        public const int MAX_KEY_ENTER = 26;
        public const int MASK = 0b1_00000_00000_00000_00110_00001;
        public const int MASK_STATE = 0b1_11111_11111_11111_11111_11111; //26 единиц для получения только 26 при сдвигах влево
       
        
        public frmMain()
        {
            InitializeComponent();
            rtxtboxKey.Enabled = false;
            btnKeyEnter.Enabled = false;
            initKey = new byte[MAX_KEY_ENTER]; // создали массив для инициализации ключа
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
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

                // получили в массиве байты - надо отобразить на интерфейсе
                string binaryDataPlain = "";
                string binaryByte = "";
                for (int i = 0; i < plainTextBytes.Length; i++)
                {
                    binaryByte = Convert.ToString(plainTextBytes[i], 2).PadLeft(8, '0');  // не добавляет лидирующие нули
                    // конвертируем байты массива в эквивалентное строковое двоичное представление
                    binaryDataPlain += binaryByte + " ";
                }
                rtxtboxPlainText.Text = binaryDataPlain;

                rtxtboxKey.MaxLength = MAX_KEY_ENTER; // plainTextBytes.Length * 8; // ставим ограничение на ввод количества бит ключа
                
                rtxtboxKey.Enabled = true;
                btnKeyEnter.Enabled = true;
                generatedKey = new byte[plainTextBytes.Length]; // сгенерированный будет такой же по длине, что и текст
                cipherText = new byte[plainTextBytes.Length]; // массив для зашифрованного
            }
            else
            {
                MessageBox.Show("Вы не выбрали файл!");
            }
            
        }

        private void btnEncipher_Click(object sender, EventArgs e)
        {
            // нужно сгенерировать ключ, занести его в массив, потом проксорить, получить шифрованный и его отобразить
            registerState = keyStart;


            // ПОКА ЧТО РАБОТАЕТ ПРАВИЛЬНО

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

            // выводим полученный ключ на экран
            // получили в массиве байты - надо отобразить на интерфейсе
            string binaryDataKey = "";
            string binaryByte = "";
            for (int i = 0; i < generatedKey.Length; i++)
            {
                binaryByte = Convert.ToString(generatedKey[i], 2).PadLeft(8, '0');  // не добавляет лидирующие нули
                                                                                      // конвертируем байты массива в эквивалентное строковое двоичное представление
                binaryDataKey += binaryByte + " ";
            }
            rtxtboxGenerKey.Text = binaryDataKey;


            // ШИФРУЕМ XOROM!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            for (int i = 0; i<generatedKey.Length; i++)
            {
                cipherText[i] = (byte)(generatedKey[i] ^ plainTextBytes[i]);
            }


            // выводим полученный шифр
            // получили в массиве байты - надо отобразить на интерфейсе
            string binaryDataCipher = "";
            string binaryCipher = "";
            for (int i = 0; i < cipherText.Length; i++)
            {
                binaryCipher = Convert.ToString(cipherText[i], 2).PadLeft(8, '0');  // не добавляет лидирующие нули
                                                                                  // конвертируем байты массива в эквивалентное строковое двоичное представление
                binaryDataCipher += binaryCipher + " ";
            }
            rtxtboxCipherText.Text = binaryDataCipher;
        }

        private void btnDecipher_Click(object sender, EventArgs e)
        {

        }

        private void btnKeyEnter_Click(object sender, EventArgs e)
        {
            if (rtxtboxKey.Text.Length > 0)
            {
                rtxtboxKey.Text = (rtxtboxKey.Text).Replace("\r\n", "");
                if (rtxtboxKey.Text.Length < MAX_KEY_ENTER)
                {
                    // лучше дозаполнить нулями
                }


      // ДЛЯ ЗАПОЛНЕНИЯ МАССИВА И ПОТОМ КОНВЕРТАЦИЮ
               // // идет заполнение байтов массива инициализатора ключа
               // for (int i = 0; i < rtxtboxKey.TextLength; i++)//i = i + 8)
               // {
               //     // получаем текущий байт (его биты)
               //     string currByte = "";
               //     //for (int j = 0; j < 8 && j+i<rtxtboxKey.TextLength; j++)
               //     //{
               //     //    currByte += rtxtboxKey.Text[i + j];
               //     //}
               //     currByte += rtxtboxKey.Text[i]; // берем просто бит 

               //     // занесли байт ключа в массив
               //     initKey[i] = Convert.ToByte(currByte, 2); // initKey[i / 8] = Convert.ToByte(currByte, 2);
               // }

               //// массив заполнен -формируем начальное состояние регистра
               // for (int i = 0; i < MAX_KEY_ENTER; i++)
               // {
               //     keyStart = keyStart << 1 | initKey[i];
               // }

                keyStart = Convert.ToInt32(rtxtboxKey.Text, 2);
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
            }
            else if (e.KeyCode == Keys.Space)
            {
                rtxtboxKey.MaxLength += 1;
            }
            else if ((e.KeyCode < Keys.D0 || e.KeyCode > Keys.D1) && e.KeyCode != Keys.Escape)
            {
                MessageBox.Show("В поле ключа можно вводить только нули и единицы!");
            }
        }
    }
}
