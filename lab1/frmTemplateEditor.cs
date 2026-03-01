using System;
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
    public partial class frmTemplateEditor : Form
    {
        private int gridSize;
        private bool[,] template;
        private Button[,] gridButtons;
        private int holesCount;
        private int requiredHoles;
        private List<List<int>> BaseMatrix = new List<List<int>>();

        public bool[,] Template
        {
            get { return template; }
            private set { template = value; }
        }
        public frmTemplateEditor(int size, int requiredHolesCount, List<List<int>> baseMatrix)
        {
            InitializeComponent();
            gridSize = size;
            requiredHoles = requiredHolesCount;
            template = new bool[size, size];
            gridButtons = new Button[size, size];
            holesCount = 0;
            this.BaseMatrix = baseMatrix;

            CreateGrid();
            UpdateHolesCountLabel();
            BaseMatrix = baseMatrix;
        }

        private void CreateGrid()
        {
            tableLayoutPanel.Controls.Clear();
            tableLayoutPanel.RowCount = gridSize;
            tableLayoutPanel.ColumnCount = gridSize;
            tableLayoutPanel.RowStyles.Clear();
            tableLayoutPanel.ColumnStyles.Clear();

            for (int i = 0; i < gridSize; i++)
            {
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / gridSize));
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / gridSize));
            }

            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    int groupNumber = BaseMatrix[row][col];
                    Button btn = new Button
                    {
                        Dock = DockStyle.Fill,
                        BackColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        Tag = new Point(row, col),
                        Text = groupNumber.ToString()
                    };

                    btn.Click += GridButton_Click;
                    gridButtons[row, col] = btn;
                    tableLayoutPanel.Controls.Add(btn, col, row);
                }
            }
        }

        private void GridButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Point pos = (Point)btn.Tag;

            if (template[pos.X, pos.Y])
            {
                template[pos.X, pos.Y] = false;
                btn.BackColor = Color.White;
                holesCount--;
            }
            else
            {
                if (holesCount < requiredHoles)
                {
                    template[pos.X, pos.Y] = true;
                    btn.BackColor = Color.Green;
                    holesCount++;
                }
                else
                {
                    MessageBox.Show($"Максимальное количество отверстий: {requiredHoles}", "Предупреждение",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                }
            }

            UpdateHolesCountLabel();
        }

        private void UpdateHolesCountLabel()
        {
            lblHolesCount.Text = $"Отверстий: {holesCount} из {requiredHoles}";
            btnSave.Enabled = holesCount == requiredHoles;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    template[row, col] = false;
                    gridButtons[row, col].BackColor = Color.White;
                }
            }
            holesCount = 0;
            UpdateHolesCountLabel();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSave_Click_2(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
