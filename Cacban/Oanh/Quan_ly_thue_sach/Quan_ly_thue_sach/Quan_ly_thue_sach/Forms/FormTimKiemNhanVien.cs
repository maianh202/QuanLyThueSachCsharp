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
    public partial class frmTimKiemNhanVien : Form
    {
        DataTable tblNV;
        public frmTimKiemNhanVien()
        {
            InitializeComponent();
        }

        private void FormTimKiemNhanVien_Load(object sender, EventArgs e)
        {
            ResetValues();
            dataGridTKNV.DataSource = null;
        }
        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txtTennv.Focus();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtTennv.Text == "") && (txtCalam.Text == "") && (txtGioitinh.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT a.tennv, a.namsinh, a.tenca, a.gioitinh, a.luong FROM tblNV AS a, tblCalam AS b WHERE 1=1 and a.maca=b.maca";

            if (txtTennv.Text != "")
                sql = sql + " AND tennv Like N'%" + txtTennv.Text + "%'";
            if (txtCalam.Text != "")
                sql = sql + " AND tenca Like N'%" + txtCalam.Text + "%'";
            if (txtGioitinh.Text != "")
                sql = sql + " AND gioitinh Like N'%" + txtGioitinh.Text + "%'";

            tblNV = Classes.Funtions.GetDataToTable(sql);
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            else
                MessageBox.Show("Có " + tblNV.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dataGridTKNV.DataSource = tblNV;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            dataGridTKNV.Columns[0].HeaderText = "Tên Nhân Viên";
            dataGridTKNV.Columns[1].HeaderText = "Năm Sinh";
            dataGridTKNV.Columns[2].HeaderText = "Ca Làm (Tên Ca)";
            dataGridTKNV.Columns[3].HeaderText = "Giới Tính ";
            dataGridTKNV.Columns[4].HeaderText = "Lương";
            dataGridTKNV.Columns[0].Width = 150;
            dataGridTKNV.Columns[1].Width = 100;
            dataGridTKNV.Columns[2].Width = 100;
            dataGridTKNV.Columns[3].Width = 100;
            dataGridTKNV.Columns[4].Width = 100;
            dataGridTKNV.AllowUserToAddRows = false;
            dataGridTKNV.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnTimlai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dataGridTKNV.DataSource = null;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridTKNV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string TenNV;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                TenNV = dataGridTKNV.CurrentRow.Cells["tennv"].Value.ToString();
                Forms.frmNhanvien frm = new frmNhanvien();
                frm.Text = TenNV;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
        }
    }
}
