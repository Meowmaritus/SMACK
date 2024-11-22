using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMetroidPaletteTool
{
    public partial class FormAskToClose : Form
    {
        public FormAskToClose()
        {
            InitializeComponent();

            var dpi = DeviceDpi / 96f;
            Size = new Size((int)Math.Round(Width * dpi), (int)Math.Round(Height * dpi));

            checkBoxDoNotAsk.Checked = Properties.Settings.Default.NeverAskToConfirmQuit;
        }

        private void checkBoxDoNotAsk_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.NeverAskToConfirmQuit = checkBoxDoNotAsk.Checked;
            Properties.Settings.Default.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void FormAskToClose_Load(object sender, EventArgs e)
        {
            
        }
    }
}
