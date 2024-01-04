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

namespace Quan_ly_thue_sach.Forms
{
    public partial class frmNXB : Form
    {
        DataTable tblNXB;
        public frmNXB()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormNXB_Load(object sender, EventArgs e)
        {
            txtManxb.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            //gọi hàm hiển thị dữ liệu lên datagridview
            load_datagrid();
        }
        private void load_datagrid()
        {
            string sql;
            sql = "select manxb,tennxb,diachi,dienthoai from tblNXB";
            
            tblNXB = Classes.Funtions.GetDataToTable(sql);
            dataGridNXB.DataSource = tblNXB;
            dataGridNXB.Columns[0].HeaderText = "Mã NXB";
            dataGridNXB.Columns[1].HeaderText = "Tên NXB";
            dataGridNXB.Columns[2].HeaderText = "Địa chỉ";
            dataGridNXB.Columns[3].HeaderText = "Điện thoại";
            dataGridNXB.Columns[0].Width = 100;
            dataGridNXB.Columns[1].Width = 150;
            dataGridNXB.Columns[2].Width = 150;
            dataGridNXB.Columns[3].Width = 150;
            dataGridNXB.AllowUserToAddRows=false;
            dataGridNXB.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
    protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnSua.Enabled = false;
            resetvalue();
            txtManxb.Enabled = true;
            txtManxb.Focus();
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtManxb.Enabled = false;
            resetvalue();
        }
        private void resetvalue()
        {
            txtManxb.Text = "";
            txtTennxb.Text = "";
            txtDiachi.Text = "";
            mskDienthoai.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtManxb.Text == "")
            {
                MessageBox.Show("Ban phai nhap ma nha xuat ban", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtManxb.Focus();
                return;
            }
            if (txtTennxb.Text == "")
            {
                MessageBox.Show("Ban phai nhap ten nha xuat ban", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTennxb.Focus();
                return;
            }
            if (txtDiachi.Text == "")
            {
                MessageBox.Show("Ban phai nhap dia chi", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiachi.Focus();
                return;
            }
            if (mskDienthoai.Text == "(  )            ")
            {
                MessageBox.Show("Ban phai nhap so dien thoai", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mskDienthoai.Focus();
                return;
            }
            string sql;
            sql = "select Manxb from tblNXB where Manxb=N'" + txtManxb.Text.Trim() + "'";
            if (Classes.Funtions.Checkkey(sql))
            {
                MessageBox.Show("Bi trung ma nha xuat ban", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtManxb.Text = "";
                txtManxb.Focus();
                return;
            }
            //insert vao csdl
            sql = "insert into tblNXB(Manxb,Tennxb,Diachi,Dienthoai) values(N'" + txtManxb.Text.Trim() + "',N'" + txtTennxb.Text.Trim() + "',N'" + txtDiachi.Text.Trim() + "',N'" + mskDienthoai.Text.Trim() + "')";
            Classes.Funtions.RunSQL(sql);
            load_datagrid();
            resetvalue();
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtManxb.Enabled = false;
        }

        private void dataGridNXB_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Ban dang o che do them moi", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dataGridNXB.Rows.Count == 0)
            {
                MessageBox.Show("Khong co du lieu!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtManxb.Text = dataGridNXB.CurrentRow.Cells["Manxb"].Value.ToString();
            txtTennxb.Text = dataGridNXB.CurrentRow.Cells["Tennxb"].Value.ToString();
            txtDiachi.Text = dataGridNXB.CurrentRow.Cells["Diachi"].Value.ToString();
            mskDienthoai.Text = dataGridNXB.CurrentRow.Cells["Dienthoai"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtManxb.Text == "")
            {
                MessageBox.Show("Chua chon ban ghi nao", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dataGridNXB.Rows.Count == 0)
            {

                MessageBox.Show("Khong co du lieu", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTennxb.Text == "")
            {

                MessageBox.Show("Ban phai nhap ten nha xuat ban", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTennxb.Focus();
                return;
            }
            if (txtDiachi.Text == "")
            {

                MessageBox.Show("Ban phai nhap Dia chi", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiachi.Focus();
                return;
            }
            if (mskDienthoai.Text == "(  )            ")
            {
                MessageBox.Show("Ban phai nhap so dien thoai", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mskDienthoai.Focus();
                return;
            }
            string sql;
            sql = "update tblNXB set Tennxb=N'" + txtTennxb.Text.Trim().ToString() + "',Diachi=N'" + txtDiachi.Text.Trim().ToString() + "',Dienthoai=N'" + mskDienthoai.Text.Trim().ToString() + "'where Manxb=N'" + txtManxb.Text.Trim() + "'";
            Classes.Funtions.RunSQL(sql);
            load_datagrid();
            resetvalue();
            btnBoqua.Enabled = false;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtManxb.Text == "")
            {
                MessageBox.Show("Chua chon ban ghi nao", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dataGridNXB.Rows.Count == 0)
            {

                MessageBox.Show("Khong co du lieu!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Ban co muon xoa khong?", "Thong Bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string sql;
                sql = "delete tblNXB Where Manxb=N'" + txtManxb.Text.Trim() + "'";
                Classes.Funtions.RunDelSQL(sql);
                load_datagrid();
                resetvalue();
            }

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
