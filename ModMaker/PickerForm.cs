using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModMaker
{
    public partial class PickerForm : Form
    {
        public PickerForm()
        {
            InitializeComponent();
        }

        private void PackButton_Click(object sender, EventArgs e)
        {
            Hide();
            new PackForm().ShowDialog();
            Show();
        }

        private void PatchButton_Click(object sender, EventArgs e)
        {
            Hide();
            new PatchForm().ShowDialog();
            Show();
        }
    }
}
