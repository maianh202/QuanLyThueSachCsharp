using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Quan_ly_thue_sach.Classes;

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
            btnTimlai.Enabled = false;
            txtTennv.Focus();
            Classes.Funtions.FillCombo("SELECT Maca, Tenca FROM tblCalam", cboCalam, "Maca", "Tenca");
            cboCalam.SelectedIndex = -1;
            Load_DataGridView();

        }
        private void ResetValues()
        {
            txtTennv.Text = "";
            txtTennv.Focus();
            cboCalam.Text = "";
            cboGioitinh.Text = "";
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtTennv.Text == "") && (cboCalam.Text == "") && (cboGioitinh.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            sql = "SELECT * FROM tblNV WHERE 1=1 ";
            if (txtTennv.Text != "") 
            {
                sql = sql +  " AND TenNV LIKE N'%"+txtTennv.Text+"%'";
            } 
                
            if (cboCalam.Text != "")
            {
                string sql1, ma;
                sql1 = "SELECT Maca FROM tblCalam WHERE Tenca = N'" + cboCalam.Text + "'";
                ma = Funtions.GetFieldValues(sql1);
                sql = sql + " AND Maca = N'" + ma + "'";
            }    

            if (cboGioitinh.Text != "")
            {
                sql = "select * from tblNV where Gioitinh = N'" + cboGioitinh.Text + "'";
            }

            tblNV = Funtions.GetDataToTable(sql);
            dataGridTKNV.DataSource = tblNV;

            if (tblNV.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có" + tblNV.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            ResetValues();
            btnTimlai.Enabled = true;
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "select * from tblNV";
            tblNV = Classes.Funtions.GetDataToTable(sql);
            dataGridTKNV.DataSource = tblNV;
            dataGridTKNV.Columns[0].HeaderText = "Mã Nhân Viên";
            dataGridTKNV.Columns[1].HeaderText = "Tên Nhân Viên";
            dataGridTKNV.Columns[2].HeaderText = "Mã ca";
            dataGridTKNV.Columns[3].HeaderText = "Năm sinh";
            dataGridTKNV.Columns[4].HeaderText = "Giới tính";
            dataGridTKNV.Columns[5].HeaderText = "Địa chỉ";
            dataGridTKNV.Columns[6].HeaderText = "Điện Thoại";
            dataGridTKNV.Columns[7].HeaderText = "Lương";
     
            ResetValues();
        }

        private void btnTimlai_Click(object sender, EventArgs e)
        {
            /*ResetValues();
            dataGridTKNV.DataSource = null;*/
            Load_DataGridView();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridTKNV_Click(object sender, EventArgs e)
        {
            dataGridTKNV.AllowUserToAddRows = false;   //ko cho phép thêm mới dữ liệu ở datagrid
            dataGridTKNV.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void cboCalam_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
