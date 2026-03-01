using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba1IT
{
    public partial class frmVizhener : Form
    {
        private string alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private char[,] TableVizhener = new char[33, 33];
        private char[] StartText = new char[1024];
        private char[] ResultText = new char[1024];
        private char[] Key = new char[1024];
        private int KeyCount = 0, textLength = 0;
        private string FileName, FileText, KeyStr;
        private string saveEncipher = ".\\Encipher.txt";
        private string saveDecipher = ".\\Decipher.txt";
        private int i, j;
        public frmVizhener()
        {
            InitializeComponent();
            int index = 0;
            for (i = 0; i< 33; i++)
            {
                for (j = 0; j<33; j++)
                {
                    TableVizhener[i, j] = alphabet[index%33];
                    index++;
                }
                index = i + 1;
            }
        }
        // метод для проверки заполенных полей корректными (почти) символами
        private bool proverkaAndFilling()
        {
            // если ничего еще не было записано в переменную для шифрования/дешифрования
            if (textLength == 0 && StartText[0] == '\0')
            {
                j = 0;
                for (int i = 0; i < txtStart.Text.Length; i++)
                {
                    if (alphabet.IndexOf(txtStart.Text.ToUpper()[i])!=-1 )
                    {
                        StartText[j] = txtStart.Text.ToUpper()[i];
                        j++;
                    }
                }
                StartText[j] = '\0';
                textLength = j;
            }
            // текст ключа
            KeyStr = (txtKey.Text).ToUpper();
            j = 0;
            // заполняем переменную ключа
            for (i = 0; i < KeyStr.Length; i++)
            {
                if (alphabet.IndexOf(KeyStr.ToUpper()[i]) != -1)
                {
                    Key[j] = KeyStr[i];
                    j++;
                }
            }
            Key[j] = '\0';
            KeyCount = j;
            // 
            return (KeyCount != 0 && textLength != 0);
        }
        private void keyLarger()
        {
            // j остался на конце Key  - нужно дополнять
            j = KeyCount;
            while (j < textLength)
            {
                // сдвиг букв ключа на 1 после полного ключевого слова в ключе
                // было MODE, становится MODENPEF ...
                Key[j] = alphabet[(alphabet.IndexOf(Key[j - KeyCount]) + 1) % 33];
                j++;
            }
            Key[j] = '\0';
        }

        private void frmVizhener_Load(object sender, EventArgs e)
        {

        }

        private void btnDecipher_Click(object sender, EventArgs e)
        {
            // все поля заполнены корректными (почти) символами
            if (proverkaAndFilling())
            {
                keyLarger();
                for (i=0; i < textLength; i++)
                {
                    ResultText[i] = alphabet[(alphabet.IndexOf(StartText[i]) - alphabet.IndexOf(Key[i]) + 33) % 33];
                }
                ResultText[textLength] = '\0';
                txtResult.Text = new string(ResultText);
                File.WriteAllText(saveDecipher, txtResult.Text);
                StartText[0] = '\0';
                textLength = 0;
                ResultText[0] = '\0';
                KeyCount = 0;
                Key[0] = '\0';
            }
            else
                MessageBox.Show("Вы не заполнили поля ключа/исходного текста!");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStart.Text = "";
            txtResult.Text = "";
            txtKey.Text = "";
        }

        private void btnReadFromFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // taking the file name
                FileName = openFileDialog1.FileName;
                // reading the plain or the cipher text into FileText
                FileText = (File.ReadAllText(FileName)).ToUpper();
                txtStart.Text = FileText;
            }
        }

        private void btnEncipher_Click(object sender, EventArgs e)
        {
            if (proverkaAndFilling())
            {
                keyLarger();
                // шифрование
                int indexKey = 0;
                int indexStartText = 0;
                for (i = 0; i < textLength; i++)
                {
                    indexKey = alphabet.IndexOf(Key[i]);
                    indexStartText = alphabet.IndexOf(StartText[i]);
                    ResultText[i] = TableVizhener[indexKey, indexStartText];
                }
                ResultText[textLength] = '\0';
                txtResult.Text = new string(ResultText);
                File.WriteAllText(saveEncipher, txtResult.Text);
                StartText[0] = '\0';
                textLength = 0;
                ResultText[0] = '\0';
                KeyCount = 0;
                Key[0] = '\0';
            }
            else
                MessageBox.Show("Вы не заполнили поля ключа/исходного текста!");
        }
    }
}
