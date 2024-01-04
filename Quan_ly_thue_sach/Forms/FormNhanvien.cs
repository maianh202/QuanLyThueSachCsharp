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
    public partial class frmNhanvien : Form
    {
        public frmNhanvien()
        {
            InitializeComponent();
        }

        DataTable tblNV;
        private void frmNhanvien_Load(object sender, EventArgs e)
        {
            txtMaNV.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            string sql;
            sql = "SELECT Maca, Tenca FROM tblCalam";
            Funtions.FillCombo(sql, cboMaca, "Maca", "Tenca");
            cboMaca.SelectedIndex = -1;
            Load_DG();
        }

        private void Load_DG()
        {
            string sql;
            sql = "SELECT * FROM tblNV";
            tblNV = Funtions.GetDataToTable(sql);
            data_GridDSNV.DataSource = tblNV;
            string[] Header = new string[8] { "Ma NV", "Ten NV", "Ma ca", "Nam sinh", "Gioi tinh" ,"Dia chi", "SDT", "Luong thang" };
            for (int i = 0; i < Header.Length; i++)
            {
                data_GridDSNV.Columns[i].HeaderText = Header[i];
            }
            data_GridDSNV.AllowUserToAddRows = false;
            data_GridDSNV.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void data_GridDSNV_Click(object sender, EventArgs e)
        {
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Khong co du lieu");
                return;
            }

            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Dang o che do them");
                return;
            }

            txtMaNV.Text = data_GridDSNV.CurrentRow.Cells["MaNV"].Value.ToString();
            txtTen.Text = data_GridDSNV.CurrentRow.Cells["TenNV"].Value.ToString();
            string sql, ma;
            ma = data_GridDSNV.CurrentRow.Cells["Maca"].Value.ToString();
            sql = "SELECT Tenca FROM tblCalam WHERE Maca = N'"+ma+"'";
            cboMaca.Text = Funtions.GetFieldValues(sql);
            mskNamsinh.Text = Funtions.ConvertDateTime(data_GridDSNV.CurrentRow.Cells["Namsinh"].Value.ToString());
            txtDiachi.Text = data_GridDSNV.CurrentRow.Cells["Diachi"].Value.ToString();
            mskSDT.Text = data_GridDSNV.CurrentRow.Cells["Dienthoai"].Value.ToString();
            txtLuong.Text = data_GridDSNV.CurrentRow.Cells["Luong"].Value.ToString();
            if (data_GridDSNV.CurrentRow.Cells["Gioitinh"].Value.ToString() == "Nam")
            {
                chkGT.Checked = true;
            }
            else
            {
                chkGT.Checked = false;
            }
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnBoqua.Enabled = true;
            Reset_Values();
            txtMaNV.Enabled = true;
            txtMaNV.Focus();
        }

        private void Reset_Values()
        {
            txtMaNV.Clear();
            txtTen.Clear();
            cboMaca.SelectedIndex = -1;
            chkGT.Checked = false;
            mskNamsinh.Clear();
            txtDiachi.Clear();
            mskSDT.Clear();
            txtLuong.Clear();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Chua nhap ma nhan vien");
                txtMaNV.Focus();
                return;
            }

            if (txtTen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Chua nhap ho va ten");
                txtTen.Focus();
                return;
            }

            if (cboMaca.SelectedIndex == -1)
            {
                MessageBox.Show("Chua chon ma ca");
                cboMaca.Focus();
                return;
            }

            if (!mskNamsinh.MaskFull)
            {
                MessageBox.Show("Chua nhap nam sinh");
                mskNamsinh.Focus();
                return;
            }

            if (!Funtions.isDate(mskNamsinh.Text))
            {
                MessageBox.Show("Ngay thang sai!");
                mskNamsinh.Clear();
                return;
            }
            
            if (txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Chua nhap dia chi");
                txtDiachi.Focus();
                return;
            }

            if (!mskSDT.MaskFull)
            {
                MessageBox.Show("Chua nhap SDT");
                mskSDT.Focus();
                return;
            }

            if (txtLuong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Chua nhap luong");
                txtLuong.Focus();
                return;
            }

            string sql, gt, ma;
            sql = "SELECT MaNV FROM tblNV WHERE MaNV = N'"+txtMaNV.Text+"'";
            if (Funtions.Checkkey(sql))
            {
                MessageBox.Show("Ma nay da ton tai, vui long nhap ma khac");
                txtMaNV.Clear();
                txtMaNV.Focus();
                return;
            }
            
            if (chkGT.Checked)
            {
                gt = "Nam";
            }
            else
            {
                gt = "Nữ";
            }

            sql = "SELECT Maca FROM tblCalam WHERE Tenca = N'" + cboMaca.Text + "'";
            ma = Funtions.GetFieldValues(sql);
            sql = "INSERT INTO tblNV(MaNV, TenNV, Maca, Namsinh, Gioitinh, Diachi, Dienthoai, Luong) " +
                "VALUES(N'"+txtMaNV.Text+ "', N'"+txtTen.Text+ "', N'"+ma+"', '"+Funtions.ConvertDateTime(mskNamsinh.Text)+ "', N'"+gt+ "', N'"+txtDiachi.Text+"' ,'" + mskSDT.Text+"', "+txtLuong.Text+")";
            Funtions.RunSQL(sql);
            Load_DG();
            Reset_Values();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaNV.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Khong co du lieu");
                return;
            }

            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Chua chon ban ghi nao");
                return;
            }

            DialogResult dlg = new DialogResult();
            dlg = MessageBox.Show("Ban co muon xoa ?", "Thong bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dlg == DialogResult.OK)
            {
                string sql;
                sql = "DELETE tblNV WHERE MaNV = N'"+txtMaNV.Text+"'";
                Funtions.RunDelSQL(sql);
                Load_DG();
                Reset_Values();
            }
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            Reset_Values();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaNV.Enabled = false;
        }
    }
}
