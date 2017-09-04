using System.Windows.Forms;

namespace Ideal.ReNamer
{
    public partial class FrmResult : Form
    {
        public string Message
        {
            set
            {
                tbxResult.Text = value;
                tbxResult.SelectedText = "";
                tbxResult.SelectionLength = 0;
                tbxResult.SelectionStart = 0;
                tbxResult.Refresh();
            }
        }

        public FrmResult()
        {
            InitializeComponent();
        }

        private void cmdOK_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void mnuCopy_Click(object sender, System.EventArgs e)
        {
            if (tbxResult.SelectionLength == 0)
            {
                tbxResult.SelectAll();
            }
            tbxResult.Copy();
        }

        private void mnuSelectAll_Click(object sender, System.EventArgs e)
        {
            tbxResult.SelectAll();
            tbxResult.Focus();
        }
    }
}
