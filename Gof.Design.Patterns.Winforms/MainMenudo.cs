using Gof.Design.Patterns.Winforms.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gof.Design.Patterns.Winforms
{
    public partial class MainMenudo : Form
    {
        public MainMenudo()
        {
            InitializeComponent();
        }

        private void handleMenus(object sender, EventArgs e)
        {            
            switch (((ToolStripMenuItem)sender).Name)
            {
                case "mnuEmployee":
                    this.ShowAsChild(FrmEmployee.Instance);
                    break;
                default:
                    break;
            }
        }

        private void ShowAsChild(Form frm)
        {
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

    }
}
