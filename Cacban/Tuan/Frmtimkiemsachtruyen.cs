using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quan_ly_thue_sach.Classes;

namespace Quan_ly_thue_sach.Forms.Tuan
{
    public partial class frmtimkiemsachtruyen : Form
    {
        public frmtimkiemsachtruyen()
        {
            InitializeComponent();
        }
        DataTable dtTuan;
        private void frmtimkiemsachtruyen_Load(object sender, EventArgs e)
        {
            dgr.DataSource = null;
            resetvalues();
            Funtions.FillCombo("SELECT Malinhvuc,Tenlinhvuc FROM tblLinhvuc", cbo, "Malinhvuc", "Tenlinhvuc");
            cbo.SelectedIndex = -1;
            Funtions.FillCombo("SELECT Matacgia,Tentacgia FROM tblTacgia", cbotacgia, "Matacgia", "Tentacgia");
            cbotacgia.SelectedIndex = -1;
            Funtions.FillCombo("SELECT MaNXB,TenNXB FROM tblNXB", cbonxb, "MaNXB", "TenNXB");
            cbonxb.SelectedIndex = -1;
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btntimlai_Click(object sender, EventArgs e)
        {
            resetvalues();
            dgr.DataSource = null;
        }
        private void resetvalues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            cbotacgia.Focus();
            cbo.Text = "";
            cbonxb.Text = "";
            cbotacgia.Text = "";
            cbotacgia.Enabled = true;
            cbonxb.Enabled = true;
            txttensach.Enabled = true;
            btntimkiem.Enabled = true;
           cbo.Enabled = true;
        }

        private void Load_DataGridView()
        {
            dgr.Columns[0].HeaderText = "Mã sách";
            dgr.Columns[1].HeaderText = "Tên sách";
            dgr.Columns[2].HeaderText = "Mã loại";
            dgr.Columns[3].HeaderText = "Mã lĩnh vực";
            dgr.Columns[4].HeaderText = "Mã tác giả";
            dgr.Columns[5].HeaderText = "Mã NXB";
            dgr.Columns[6].HeaderText = "Mã ngôn ngữ";
            dgr.Columns[7].HeaderText = "Số trang";
            dgr.Columns[8].HeaderText = "Giá sách";
            dgr.Columns[9].HeaderText = "Đơn giá thuê";
            dgr.Columns[10].HeaderText = "Số lượng";
            dgr.Columns[11].HeaderText = "Ảnh";
            dgr.Columns[12].HeaderText = "Ghi chú";

            dgr.Columns[0].Width = 50;
            dgr.Columns[1].Width = 100;
            dgr.Columns[2].Width = 50;
            dgr.Columns[3].Width = 50;
            dgr.Columns[4].Width = 50;
            dgr.Columns[5].Width = 100;
            dgr.Columns[6].Width = 100;
            dgr.Columns[7].Width = 50;
            dgr.Columns[8].Width = 50;
            dgr.Columns[9].Width = 50;
            dgr.Columns[10].Width = 50;
            dgr.Columns[11].Width = 50;
            dgr.Columns[12].Width = 50;

            dgr.AllowUserToAddRows = false;
            dgr.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((cbonxb.Text == "") && (cbotacgia.Text == "") && (cbo.Text == "") && (txttensach.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblSach WHERE 1=1";
            if (txttensach.Text != "")
                sql = sql + " AND Tensach Like N'%" + txttensach.Text + "%'";
            if (cbo.Text != "")
                sql = sql + " AND Malinhvuc Like N'%" + cbo.SelectedValue + "%'";
            if (cbotacgia.Text != "")
                sql = sql + " AND Matacgia Like N'%" + cbotacgia.SelectedValue + "%'";
            if (cbonxb.Text != "")
                sql = sql + " AND MaNXB Like N'%" + cbonxb.SelectedValue + "%'";
            dtTuan = Funtions.GetDataToTable(sql);
            if (dtTuan.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + dtTuan.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            dgr.DataSource = dtTuan;
            Load_DataGridView();
            btntimkiem.Enabled = false;
            cbonxb.Enabled = false;
            cbotacgia.Enabled = false;
           txttensach.Enabled = false;
           cbo.Enabled = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
