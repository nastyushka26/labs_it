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
using System.Drawing.Drawing2D;
using System.Security.Cryptography;

namespace laba1IT
{
    public partial class frmReshetka : Form
    {
        private bool isTemplateFromVisual = false;
        private char[] StartText = new char[1024];
        private char[] ResultText = new char[1024];
        private char[] Key = new char[1024];
        private int KeyCount = 0, textLength = 0;
        private string FileName, FileText;
        private List<List<int>> BaseMatrix = new List<List<int>>();
        private List<List<int>> KeyTemplate = new List<List<int>>();
        private List<List<char>> ResMatrix = new List<List<char>>();
        private string saveEncipher = ".\\EncipherResh.txt";
        private string saveDecipher = ".\\DecipherResh.txt";
        private int i, j, countN, temp, alpha, countDyrka;
        private Label lblMatrixInfo; // добавьте эту строку

        private void btnDecipher_Click(object sender, EventArgs e)
        {
            if (proverkaAndFilling())
            {
                int index = 0;
                bool centerGet = false;
                for (int i = 0; i<countN; i++)
                {
                    for (int j = 0; j<countN; j++)
                    {
                        ResMatrix[i][j] = StartText[index];
                        index++;
                    }
                }
                index = 0;
                // 4 раза заполняем
                for (int k = 0; k < 4; k++)
                {
                    // идем по шаблону
                    for (i = 0; i < countN; i++)
                    {
                        for (j = 0; j < countN; j++)
                        {
                            // дырка в шаблоне
                            if (KeyTemplate[i][j] == 1)
                            {
                                // если центр при нечетном еще не читался или не он сейчас или четная - просто читаем
                                if ((odd && !centerGet && i==j && i==(countN/2)) || (odd && !(i==countN/2 && j==countN/2)) || !odd)
                                {
                                    ResultText[index] = ResMatrix[i][j];
                                    index++;
                                    if (odd && i == j && i == (countN / 2))
                                        centerGet = true;
                                }
                                   
                            }
                        }
                    }
                    // повернули решетку
                    rotateResh();
                }
                ResultText[index] = '\0';
                txtResult.Text = new string(ResultText);
                File.WriteAllText(saveDecipher, txtResult.Text);
                StartText[0] = '\0';
                textLength = 0;
                ResultText[0] = '\0';
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStartResh.Text = "";
            txtResult.Text = "";
            btnCreateTemplate.Enabled = false;
        }

        private void btnCreateTemplate_Click(object sender, EventArgs e)
        {
            if (countN == 0)
            {
                MessageBox.Show("Сначала постройте матрицу!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Создаем и показываем редактор шаблона
            frmTemplateEditor editor = new frmTemplateEditor(countN, countDyrka, BaseMatrix);
            if (editor.ShowDialog() == DialogResult.OK)
            {
                // Конвертируем визуальный шаблон в формат KeyTemplate
                for (int i = 0; i < countN; i++)
                {
                    for (int j = 0; j < countN; j++)
                    {
                        KeyTemplate[i][j] = editor.Template[i, j] ? 1 : 0;
                    }
                }

                isTemplateFromVisual = true;
                btnCreateTemplate.BackColor = Color.LightGreen;
                MessageBox.Show("Шаблон успешно создан!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private bool odd;

        private void btnEncipher_Click(object sender, EventArgs e)
        {
            if (proverkaAndFilling())
            {
                int index = 0;
                alpha = 0;
                // 4 раза заполняем
                for (int k = 0; k < 4; k++)
                {
                    // идем по шаблону
                    for (int i = 0; i < countN; i++)
                    {
                        for (int j = 0; j < countN; j++)
                        {
                            // дырка в шаблоне
                            if (KeyTemplate[i][j] == 1)
                            {
                                // закончились буквы исходного текста

                                // если попалась середина матрицы и она нечетная
                                if (odd && i == j && i == countN / 2)
                                {

                                    if (ResMatrix[i][j] == ' ')
                                        if (index == textLength)
                                        {
                                            ResMatrix[i][j] = (char)(alpha + 'A');
                                            alpha++;
                                        }
                                        else
                                        {
                                            ResMatrix[i][j] = StartText[index];
                                            index++;
                                        }
                                }
                                else
                                {
                                    if (index == textLength)
                                    {
                                        ResMatrix[i][j] = (char)(alpha + 'A');
                                        alpha++;
                                    }
                                    else
                                    {
                                        ResMatrix[i][j] = StartText[index];
                                        index++;
                                    }
                                }
                            }
                        }
                    }
                    // повернули решетку
                    rotateResh();
                } 
                int indexRes = 0;
                for (i = 0; i < countN; i++)
                {
                    for (j = 0; j < countN; j++)
                    {
                        ResultText[indexRes] = ResMatrix[i][j];
                        indexRes++;
                    }
                }
                ResultText[indexRes] = '\0';
                txtResult.Text = new string(ResultText);
                File.WriteAllText(saveEncipher, txtResult.Text);
                StartText[0] = '\0';
                textLength = 0;
                ResultText[0] = '\0';
            }
        }
        private void btnInitMatrix_Click(object sender, EventArgs e)
        {
            proverkaAndFilling();
            countN = (int)Math.Ceiling(Math.Sqrt(textLength));
            countDyrka = (int)Math.Ceiling((double)countN * countN / 4);
            odd = countN % 2 != 0;
            // Инициализируем матрицы
            BaseMatrix.Clear();
            KeyTemplate.Clear();
            ResMatrix.Clear();

            for (i = 0; i < countN; i++)
            {
                BaseMatrix.Add(new List<int>());
                KeyTemplate.Add(new List<int>());
                ResMatrix.Add(new List<char>());

                for (j = 0; j < countN; j++)
                {
                    BaseMatrix[i].Add(0);
                    KeyTemplate[i].Add(0);
                    ResMatrix[i].Add(' ');
                }
            }

            i = 0;
            j = 0;
            int number = 1;
            while (countDyrka>=number)
            {
                if (BaseMatrix[i][j] == 0)
                {
                    BaseMatrix[i][j] = number;
                    BaseMatrix[j][countN-i-1] = number;
                    BaseMatrix[countN - i - 1][countN - j - 1] = number;
                    BaseMatrix[countN - j - 1][i] = number;
                    number++;
                    // прошли в строке дальше
                    j++;
                }
                else
                {
                    // переход на следующую строку
                    i++;
                    j = i;
                }
            }
            if (countN == 0)
                MessageBox.Show("В исходном тексте нет корректных символов / поле не заполнено!");
            else
                MessageBox.Show($"Матрица построена. Размер: {countN}x{countN}, отверстий: {countDyrka}",
                                   "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (countDyrka !=0)
                btnCreateTemplate.Enabled = true;
        }

        // поворот решетки на 90 градусов
        private void rotateResh()
        {
            // транспонировали
            for (int i = 0; i<countN; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    temp = KeyTemplate[i][j];
                    KeyTemplate[i][j] = KeyTemplate[j][i];
                    KeyTemplate[j][i] = temp;
                }
            }
            // вертикально зеркалировали
            for (int i = 0; i<countN; i++)
            {
                for (int j = 0; j<countN / 2;  j++)
                {
                    temp = KeyTemplate[i][j];
                    KeyTemplate[i][j] = KeyTemplate[i][countN - j - 1];
                    KeyTemplate[i][countN-j-1] = temp;
                }
            }
        }

        public frmReshetka()
        {
            InitializeComponent();
        }

        private bool proverkaAndFilling()
        {
            // если ничего еще не было записано в переменную для шифрования/дешифрования
            if (textLength == 0 && StartText[0] == '\0')
            {
                j = 0;
                for (int i = 0; i < txtStartResh.Text.Length; i++)
                {
                    if ((txtStartResh.Text.ToUpper()[i]) <= 'Z' && txtStartResh.Text.ToUpper()[i] >= 'A')
                    {
                        StartText[j] = txtStartResh.Text.ToUpper()[i];
                        j++;
                    }
                }
                StartText[j] = '\0';
                textLength = j;
            }
            return textLength != 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // taking the file name
                FileName = openFileDialog1.FileName;
                // reading the plain or the cipher text into FileText
                FileText = (File.ReadAllText(FileName)).ToUpper();
                txtStartResh.Text = FileText;
            }
        }
    }
}
