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
    public partial class FrmTacgia : Form
    {
        public FrmTacgia()
        {
            InitializeComponent();
        }

        private void FrmTacgia_Load(object sender, EventArgs e)
        {
            txttentg.Enabled = false;
            txtmatg.Enabled = false;
            picLuu.Enabled = false;
            picBoqua.Enabled = false;
            Load_DataGridView();
           
            ResetValues();
        }
        DataTable tbltg;
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT * FROM tblTacgia";
            tbltg = Funtions.GetDataToTable(sql);
            data_GridDSNV.DataSource = tbltg;
            data_GridDSNV.Columns[0].HeaderText = "Mã tác giả";
            data_GridDSNV.Columns[1].HeaderText = "Tên tác giả";
            data_GridDSNV.Columns[2].HeaderText = "Ngày sinh ";
            data_GridDSNV.Columns[3].HeaderText = "Giới tính";
            data_GridDSNV.Columns[4].HeaderText = "Địa chỉ";

            data_GridDSNV.Columns[0].Width = 80;
            data_GridDSNV.Columns[1].Width = 140;
            data_GridDSNV.Columns[2].Width = 80;
            data_GridDSNV.Columns[3].Width = 80;
            data_GridDSNV.Columns[4].Width = 100;

            data_GridDSNV.AllowUserToAddRows = false;
            data_GridDSNV.EditMode = DataGridViewEditMode.EditProgrammatically;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void picDong_Click(object sender, EventArgs e)
        {
           
        }

        private void picBoqua_Click(object sender, EventArgs e)
        {
           
        }
        private void ResetValues()
        {
            cboGT.Checked = false;
            mskngaysinh.Text= "";
            txtmatg.Text = "";
            txttentg.Text = "";
            txtdiachi.Text = "";
        }

        private void picThem_Click(object sender, EventArgs e)
        {
           
        }

        private void data_GridDSNV_Click(object sender, EventArgs e)
        {
            string ma;
            if (picThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttentg.Focus();
                return;
            }
            if (tbltg.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtdiachi.Text = data_GridDSNV.CurrentRow.Cells["Diachi"].Value.ToString();
            txttentg.Text = data_GridDSNV.CurrentRow.Cells["Tentacgia"].Value.ToString();
            ma = data_GridDSNV.CurrentRow.Cells["Gioitinh"].Value.ToString();
            if (ma.Trim() == "Nam")
            {
                cboGT.Checked = true;
            }
            else
            {
                cboGT.Checked = false;
            }

            txtmatg.Text = data_GridDSNV.CurrentRow.Cells["Matacgia"].Value.ToString();
            mskngaysinh.Text = data_GridDSNV.CurrentRow.Cells["Ngaysinh"].Value.ToString();

            picSua.Enabled = true;
            picXoa.Enabled = true;
            picBoqua.Enabled = true;
        }

        private void picXoa_Click(object sender, EventArgs e)
        {
         
        }

        private void picDong_Click_1(object sender, EventArgs e)
        {
            DialogResult dlg = new DialogResult();
            dlg = MessageBox.Show("Ban co muon thoat that khong?", "Thong bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlg == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void picBoqua_Click_1(object sender, EventArgs e)
        {
            ResetValues();
            picBoqua.Enabled = false;
            picThem.Enabled = true;
            picXoa.Enabled = true;
            picSua.Enabled = true;
            picLuu.Enabled = false;
        }

        private void picThem_Click_1(object sender, EventArgs e)
        {
            picSua.Enabled = false;
            picXoa.Enabled = false;
            picBoqua.Enabled = true;
            picLuu.Enabled = true;
            picThem.Enabled = false;
            ResetValues();
            txttentg.Enabled = true;
            txtmatg.Enabled = true;
            txttentg.Focus();
            if (mskngaysinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskngaysinh.Focus();
                return;
            }
        }

        private void picXoa_Click_1(object sender, EventArgs e)
        {
            string sql;
            if (tbltg.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Information);
                return;
            }
            if (txtmatg.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo",
MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblTacgia WHERE Matacgia=N'" + txtmatg.Text + "'";
                Funtions.RunDelSQL(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void picSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tbltg.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Information);
                return;
            }
            if (txtmatg.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttentg.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên tác giả", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Warning);
                txttentg.Focus();
                return;
            }
            if (txtdiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdiachi.Focus();
                return;
            }
            if (mskngaysinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskngaysinh.Focus();
                return;
            }
            if (!Funtions.isDate(mskngaysinh.Text))
            {
                MessageBox.Show("Vui lòng nhập lại ngày sinh");
                mskngaysinh.Text = "";
                mskngaysinh.Focus();
                return; 
            }
            string gt;
            if (cboGT.Checked)
            {
                gt = "Nam";
            }
            else
            {
                gt = "Nữ";
            }

            sql = "UPDATE tblTacgia SET Tentacgia=N'" + txttentg.Text.Trim().ToString() +
                "',Gioitinh=N'" + gt +
                "',Diachi=N'" + txtdiachi.Text +
                "',Ngaysinh=N'" + Funtions.ConvertDateTime(mskngaysinh.Text) + 
                "' WHERE Matacgia=N'" + txtmatg.Text + "'";
            Funtions.RunSQL(sql);
            Load_DataGridView();
            ResetValues();
            picBoqua.Enabled = false;

        }

        private void picLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtdiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Warning);
               txtdiachi.Focus();
                return;
            }
            if (txttentg.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên tác giả", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttentg.Focus();
                return;
            }
            if (mskngaysinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
               mskngaysinh.Focus();
                return;
            }
            if (!Funtions.isDate(mskngaysinh.Text))
            {
                MessageBox.Show("Vui lòng nhập lại ngày sinh");
                mskngaysinh.Text = "";
                mskngaysinh.Focus();
                return;
            }
            if(mskngaysinh.Text.Trim().Length==0 )
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskngaysinh.Focus();
                return;
            }    
            sql = "SELECT Matacgia FROM tblTacgia WHERE Matacgia=N'" + txtmatg.Text.Trim() + "'";
            if (Funtions.Checkkey(sql))
            {
                MessageBox.Show("Mã tác giả này đã có, bạn phải nhập mã khác", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmatg.Focus();
                txtmatg.Text = "";
                return;
            }
            string gt;
            if (cboGT.Checked)
            {
                gt = "Nam";
            }
            else
            {
                gt = "Nữ";
            }
            sql = "INSERT INTO tblTacgia(Matacgia,Tentacgia,Ngaysinh,Gioitinh,Diachi) VALUES(N'" + txtmatg.Text.Trim() +
                    "',N'" + txttentg.Text.Trim() + "','" + Funtions.ConvertDateTime(mskngaysinh.Text) + "',N'" + gt + "',N'" + txtdiachi.Text + "')";
            Funtions.RunSQL(sql);
            Load_DataGridView();
            ResetValues();
            picXoa.Enabled = true;
            picThem.Enabled = true;
            picSua.Enabled = true;
           picBoqua.Enabled = false;
           picLuu.Enabled = false;
            txtmatg.Enabled = false;
       

    }

    private void cbogt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
            

           