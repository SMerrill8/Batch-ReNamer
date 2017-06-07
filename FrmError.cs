using System.Windows.Forms;

namespace Ideal.ReNamer
{
    public partial class FrmError : Form
    {
        public string ErrorMessage
        {
            set
            {
                tbxError.Text = value;
                tbxError.SelectedText = "";
                tbxError.SelectionLength = 0;
                tbxError.SelectionStart = 0;
                tbxError.Refresh();
            }
        }

        public FrmError()
        {
            InitializeComponent();
        }

        private void cmdOK_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void mnuCopy_Click(object sender, System.EventArgs e)
        {
            tbxError.Copy();
        }
    }
}
