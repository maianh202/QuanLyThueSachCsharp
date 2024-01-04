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
    public partial class FrmKhachHang : Form
    {
        public FrmKhachHang()
        {
            InitializeComponent();
        }
        DataTable tblkh;
        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            txtmakhach.Enabled = false;
            btnluu.Enabled = false;
            btnboqua.Enabled = false;
            chkgioitinh.Checked = false;
            load_datagrid();
        }
        private void load_datagrid()
        {
            string sql;
            sql = "SELECT Makhach, Tenkhach, Gioitinh, Diachi, Ngaysinh FROM tblKhach";
            tblkh = Classes.Funtions.GetDataToTable(sql);
            dgridkhachhang.DataSource = tblkh;
            dgridkhachhang.Columns[0].HeaderText = "Mã khách";
            dgridkhachhang.Columns[1].HeaderText = "Tên khách";
            dgridkhachhang.Columns[2].HeaderText = "Giới tính";
            dgridkhachhang.Columns[3].HeaderText = "Địa chỉ";
            dgridkhachhang.Columns[4].HeaderText = "Ngày sinh";
            dgridkhachhang.Columns[0].Width = 70;
            dgridkhachhang.Columns[1].Width = 120;
            dgridkhachhang.Columns[2].Width = 60;
            dgridkhachhang.Columns[3].Width = 120;
            dgridkhachhang.Columns[4].Width = 90;
            dgridkhachhang.AllowUserToAddRows = false;
            dgridkhachhang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValues()
        {
            txtmakhach.Text = "";
            txttenkhach.Text = "";
            chkgioitinh.Checked = false;
            txtdiachi.Text = "";
            txtngaysinh.Text = "  /  /    ";
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnthem.Enabled = false;
            btnluu.Enabled = true;
            btnxoa.Enabled = false;
            btnboqua.Enabled = true;
            btnsua.Enabled = false;
            txtmakhach.Enabled = true;
            txtmakhach.Focus();
            ResetValues();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblkh.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtmakhach.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "delete tblKhach where Makhach=N'" + txtmakhach.Text + "'";
                Classes.Funtions.RunSQL(sql);
                load_datagrid();
                ResetValues();
            }

        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (txtmakhach.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmakhach.Focus();
                return;
            }
            if (txttenkhach.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttenkhach.Focus();
                return;
            }
            if (txtdiachi.Text == "")
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdiachi.Focus();
                return;
            }
            if (txtngaysinh.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtngaysinh.Focus();
                return;
            }
            if (!Classes.Funtions.isDate(txtngaysinh.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtngaysinh.Text = "";
                txtngaysinh.Focus();
                return;
            }
            if (chkgioitinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            sql = "SELECT Makhach FROM tblKhach WHERE Makhach=N'" + txtmakhach.Text.Trim() + "'";
            if (Classes.Funtions.Checkkey(sql))
            {
                MessageBox.Show("Mã khách này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmakhach.Focus();
                txtmakhach.Text = "";
                return;
            }
            sql = "INSERT INTO tblkhach(Makhach,Tenkhach,Gioitinh, Diachi, Ngaysinh) VALUES(N'" + txtmakhach.Text.Trim() + "', N'" + txttenkhach.Text.Trim() + "', N'" + gt.Trim() + "', N'" + txtdiachi.Text.Trim() + "', '" + Classes.Funtions.ConvertDateTime(txtngaysinh.Text) + "')";

            Classes.Funtions.RunSQL(sql);
            load_datagrid();
            ResetValues();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnboqua.Enabled = false;
            btnluu.Enabled = false;
            txtmakhach.Enabled = false;
        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            btnboqua.Enabled = false;
            btnluu.Enabled = false;
            btnthem.Enabled = true;
            btnxoa.Enabled=true;
            btnsua.Enabled=true;
            btndong.Enabled = true;
            txtmakhach.Enabled=false;
            ResetValues();
        }

        private void dgridkhachhang_Click(object sender, EventArgs e)
        {
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Bạn đang ở chế độ thêm mới!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            txtmakhach.Text = dgridkhachhang.CurrentRow.Cells["Makhach"].Value.ToString();
            txttenkhach.Text = dgridkhachhang.CurrentRow.Cells["Tenkhach"].Value.ToString();
            string gt = dgridkhachhang.CurrentRow.Cells["Gioitinh"].Value.ToString();
            if (gt.Trim() == "Nam")
            {
                chkgioitinh.Checked = true;
            }
            else
            {
                chkgioitinh.Checked = false;
            }
            txtdiachi.Text = dgridkhachhang.CurrentRow.Cells["Diachi"].Value.ToString();
            txtngaysinh.Text = dgridkhachhang.CurrentRow.Cells["Ngaysinh"].Value.ToString();
            btnsua.Enabled = true;
            btnboqua.Enabled = true;    
            btnxoa.Enabled = true;
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblkh.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmakhach.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }    
            if(txttenkhach.Text.Trim().Length==0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }    
            if(txtngaysinh.Text=="  /  /    ")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return ;
            }
            string gt;
            if (chkgioitinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            sql = "update tblKhach set TenKhach=N'"+txttenkhach.Text.Trim().ToString()+"', Gioitinh=N'"+gt+"',Diachi=N'"+txtdiachi.Text.Trim().ToString()+"',Ngaysinh='"+Classes.Funtions.ConvertDateTime(txtngaysinh.Text)+"' where Makhach=N'"+txtmakhach.Text+"'";
            Classes.Funtions.RunSQL(sql);
            load_datagrid();
            ResetValues();
            btnboqua.Enabled = false;   
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
