using System.Windows.Forms;

namespace Boundless.ReNamer
{
    public partial class FrmError : Form
    {
        public string ErrorMessage
        {
            set
            {
                tbxError.Text = value;
                tbxError.Refresh();
            }
        }

        public bool TestMode
        {
            set
            {
                lblInstruction.Text = 
                    value 
                    ? "The following source files do not exist, and the remainder were not copied:" 
                    : "The following source files do not exist:";
                lblInstruction.Refresh();
                tbxError.SelectionStart = 0;
                tbxError.SelectionLength = 0;
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
