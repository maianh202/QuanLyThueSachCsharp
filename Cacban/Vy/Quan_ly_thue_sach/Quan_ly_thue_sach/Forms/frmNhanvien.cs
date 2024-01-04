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
    public partial class frmNhanvien : Form
    {
        DataTable tblnhanvien;
        public frmNhanvien()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void frmNhanvien_Load(object sender, EventArgs e)
        {
            Classes.Funtions.KetNoi();

             txtManv.Enabled = false;
             btnLuu_nv.Enabled = false;
             btnBoqua_nv.Enabled = false;
            
        }

         private void resetvalues()
         {
             txtManv.Text = "";
             txtTennv.Text = "";
             txtNamsinh.Text = "";
             txtDiachi.Text = "";
             mskDienthoai.Text = "";
             txtLuong.Text = "";
         }
         private void load_datagrid()
         {
             string sql;
             sql = "select * from tblNV";
             tblnhanvien = Classes.Funtions.GetDataToTable(sql);
             dgrid_DSNV.DataSource = tblnhanvien;

             dgrid_DSNV.Columns[0].HeaderText = "Mã nhân viên";
             dgrid_DSNV.Columns[1].HeaderText = "Tên nhân viên";
             dgrid_DSNV.Columns[2].HeaderText = "Mã ca";
             dgrid_DSNV.Columns[3].HeaderText = "Năm sinh";
             dgrid_DSNV.Columns[4].HeaderText = "Giới tính";
             dgrid_DSNV.Columns[5].HeaderText = "Địa chỉ";
             dgrid_DSNV.Columns[6].HeaderText = "Điện thoại";
             dgrid_DSNV.Columns[7].HeaderText = "Lương";

             dgrid_DSNV.AllowUserToAddRows = false;
             dgrid_DSNV.EditMode = DataGridViewEditMode.EditProgrammatically;
         }

         private void dgrid_DSNV_Click(object sender, EventArgs e)
         {
             string ma;
             if (btnThem_nv.Enabled == false)
             {
                 MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 txtManv.Focus();
                 return;
             }
             if (tblnhanvien.Rows.Count == 0)
             {
                 MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 return;
             }
             txtManv.Text = dgrid_DSNV.CurrentRow.Cells["Manv"].Value.ToString();
             txtTennv.Text = dgrid_DSNV.CurrentRow.Cells["Tennv"].Value.ToString();
             ma = dgrid_DSNV.CurrentRow.Cells["Maca"].Value.ToString();
             cboMaca.Text = Classes.Funtions.GetFieldValues("select Tenca from tblCalam where Maca=N'" + ma + "'");
             txtNamsinh.Text = dgrid_DSNV.CurrentRow.Cells["Namsinh"].Value.ToString();
             if (dgrid_DSNV.CurrentRow.Cells["Gioitinh"].Value.ToString() == "Nam")
                 chkGioitinh.Checked = true;
             else
                 chkGioitinh.Checked = false;
             txtDiachi.Text = dgrid_DSNV.CurrentRow.Cells["Diachi"].Value.ToString();
             mskDienthoai.Text = dgrid_DSNV.CurrentRow.Cells["Dienthoai"].Value.ToString();
             txtLuong.Text = dgrid_DSNV.CurrentRow.Cells["Luong"].Value.ToString();

             btnSua_nv.Enabled = true;
             btnXoa_nv.Enabled = true;
             btnBoqua_nv.Enabled = true;
         }

         private void btnThem_nv_Click(object sender, EventArgs e)
         {
             txtManv.Enabled = true;
             txtManv.Focus();
             btnLuu_nv.Enabled = true;
             btnXoa_nv.Enabled = false;
             btnSua_nv.Enabled = false;
             btnThem_nv.Enabled = false;
             btnBoqua_nv.Enabled = true;
             resetvalues();
         }

         private void btnXoa_nv_Click(object sender, EventArgs e)
         {
             string sql;
             if (tblnhanvien.Rows.Count == 0)
             {
                 MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 return;
             }
             if (txtManv.Text == "")
             {
                 MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 return;
             }
             if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
             {
                 sql = "DELETE tblNV WHERE MaNV=N'" + txtManv.Text + "'";
                 Classes.Funtions.RunSQL(sql);
                 load_datagrid();
                 resetvalues();
             }
         }

         private void btnSua_nv_Click(object sender, EventArgs e)
         {
             string sql, gt;
             if (tblnhanvien.Rows.Count == 0)
             {
                 MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 return;
             }
             if (txtManv.Text == "")
             {
                 MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 return;
             }
             if (txtTennv.Text.Trim().Length == 0)
             {
                 MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 txtTennv.Focus();
                 return;
             }
             if (txtDiachi.Text.Trim().Length == 0)
             {
                 MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 txtDiachi.Focus();
                 return;
             }
             if (mskDienthoai.Text == "(   )     -")
             {
                 MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 mskDienthoai.Focus();
                 return;
             }
             if (txtNamsinh.Text.Trim().Length == 0)
             {
                 MessageBox.Show("Bạn phải nhập năm sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 txtNamsinh.Focus();
                 return;
             }
             if (chkGioitinh.Checked == true)
                 gt = "Nam";
             else
                 gt = "Nữ";
             sql = "UPDATE tblNV SET  TenNV=N'" + txtTennv.Text.Trim().ToString() + "',Diachi=N'" + txtDiachi.Text.Trim().ToString() + "',Dienthoai='" + mskDienthoai.Text.ToString() + "',Gioitinh=N'" + gt + "',Namsinh='" + txtNamsinh.Text.ToString()+"' WHERE MaNV=N'" + txtManv.Text + "'";
             Classes.Funtions.RunSQL(sql);
             load_datagrid();
             resetvalues();
             btnBoqua_nv.Enabled = false;
         }

         private void btnLuu_nv_Click(object sender, EventArgs e)
         {
             string sql, gt;
             if (txtManv.Text.Trim().Length == 0)
             {
                 MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 txtManv.Focus();
                 return;
             }
             if (txtTennv.Text.Trim().Length == 0)
             {
                 MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 txtTennv.Focus();
                 return;
             }
             if (txtNamsinh.Text.Trim().Length == 0)
             {
                 MessageBox.Show("Bạn phải nhập năm sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 txtNamsinh.Focus();
                 return;
             }
             if (txtDiachi.Text.Trim().Length == 0)
             {
                 MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 txtDiachi.Focus();
                 return;
             }
             if (mskDienthoai.Text.Trim().Length == 0)
             {
                 MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 mskDienthoai.Focus();
                 return;
             }
             if (txtLuong.Text.Trim().Length == 0)
             {
                 MessageBox.Show("Bạn phải nhập lương", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 txtLuong.Focus();
                 return;
             }
             if (chkGioitinh.Checked == true)
                 gt = "Nam";
             else
                 gt = "Nữ";
             sql = "SELECT MaNV FROM tblNV WHERE MaNV=N'" + txtManv.Text.Trim() + "'";
             if (Classes.Funtions.Checkkey(sql))
             {
                 MessageBox.Show("Mã nhân viên này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 txtManv.Focus();
                 txtManv.Text = "";
                 return;
             }
             sql = "INSERT INTO tblNV(MaNV,TenNV, Namsinh, Gioitinh, Diachi, Dienthoai, Luong) VALUES(N'" + txtManv.Text.Trim() + "', N'" + txtTennv.Text.Trim() + "', N'" + gt + "', N'" + txtDiachi.Text.Trim() + "', '" + mskDienthoai.Text + "', '" + Classes.Funtions.ConvertDateTime(txtNamsinh.Text) + "')";
             Classes.Funtions.RunSQL(sql);
             load_datagrid();
             resetvalues();
             btnXoa_nv.Enabled = true;
             btnThem_nv.Enabled = true;
             btnSua_nv.Enabled = true;
             btnBoqua_nv.Enabled = false;
             btnLuu_nv.Enabled = false;
             txtManv.Enabled = false;
         }

         private void btnBoqua_nv_Click(object sender, EventArgs e)
         {
             resetvalues();
             btnBoqua_nv.Enabled = false;
             btnThem_nv.Enabled = true;
             btnXoa_nv.Enabled = true;
             btnSua_nv.Enabled = true;
             btnLuu_nv.Enabled = false;
             txtManv.Enabled = false;

         }

         private void btnDong_nv_Click(object sender, EventArgs e)
         {
             this.Close();
         } 
     
    }  
}
