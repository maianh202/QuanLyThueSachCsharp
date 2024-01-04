using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_thue_sach.Forms
{
    public partial class frmDSchuatra : Form
    {
        public frmDSchuatra()
        {
            InitializeComponent();
        }
        DataTable tblTKSACH;
        private void frmDSchuatra_Load(object sender, EventArgs e)
        {
            Classes.Funtions.KetNoi();

        }
        

    }
}
