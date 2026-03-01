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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnReshetka_Click(object sender, EventArgs e)
        {
            frmReshetka reshetkaForm = new frmReshetka();
            reshetkaForm.Show();
        }

        private void btnVizhener_Click(object sender, EventArgs e)
        {
            frmVizhener vizhenerForm = new frmVizhener();
            vizhenerForm.Show();
        }
    }
}
