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
    public partial class frmSachTruyen : Form
    {
        DataTable tblsachtruyen;
        public frmSachTruyen()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void frmSachTruyen_Load(object sender, EventArgs e)
        {
            string sql;
            txtMasach.Enabled = false;
            btnLuu_sach.Enabled = false;
            btnBoqua_sach.Enabled = false;
            load_datagrid();

            sql = "SELECT Maloai, Tenloai FROM tblLoaisach";
            Funtions.FillCombo(sql, cboMaloaisach, "Maloai", "Tenloai");
            cboMaloaisach.SelectedIndex = -1;

            sql = "SELECT Malinhvuc, Tenlinhvuc FROM tblLinhvuc";
            Funtions.FillCombo(sql, cboMalinhvuc, "Malinhvuc", "Tenlinhvuc");
            cboMalinhvuc.SelectedIndex = -1;
            
            sql = "SELECT Matacgia, Tentacgia FROM tblTacgia";
            Funtions.FillCombo(sql, cboMatacgia, "Matacgia", "Tentacgia");
            cboMatacgia.SelectedIndex = -1;
            
            sql = "SELECT MaNXB, TenNXB FROM tblNXB";
            Funtions.FillCombo(sql, cboMaNXB, "MaNXB", "TenNXB");
            cboMaNXB.SelectedIndex = -1;

            sql = "SELECT Mangonngu, Tenngonngu FROM tblNgonngu";
            Funtions.FillCombo(sql, cboMangonngu, "Mangonngu", "Tenngonngu");
            cboMangonngu.SelectedIndex = -1;
        }

        private void resetvalues()
        {
            txtMasach.Text = "";
            txtTensach.Text = "";
            cboMaloaisach.Text = "";
            cboMalinhvuc.Text = "";
            cboMatacgia.Text = "";
            cboMaNXB.Text = "";
            cboMangonngu.Text = "";
            txtSotrang.Text = "";
            txtGiasach.Text = "";
            txtDongiathue.Text = "";
            txtSoluong.Text = "0";
            picAnh.Image = null;
            txtGhichu.Text = "";
            txtPath.Text = "";
        }

        private void load_datagrid()
        {
            string sql;
            sql = "select * from tblSach";
            tblsachtruyen = Classes.Funtions.GetDataToTable(sql);
            dgrid_sachtruyen.DataSource = tblsachtruyen;

            dgrid_sachtruyen.Columns[0].HeaderText = "Mã sách";
            dgrid_sachtruyen.Columns[1].HeaderText = "Tên sách";
            dgrid_sachtruyen.Columns[2].HeaderText = "Mã loại";
            dgrid_sachtruyen.Columns[3].HeaderText = "Mã lĩnh vực";
            dgrid_sachtruyen.Columns[4].HeaderText = "Mã tác giả";
            dgrid_sachtruyen.Columns[5].HeaderText = "Mã NXB";
            dgrid_sachtruyen.Columns[6].HeaderText = "Mã ngôn ngữ";
            dgrid_sachtruyen.Columns[7].HeaderText = "Số trang";
            dgrid_sachtruyen.Columns[8].HeaderText = "Giá sách";
            dgrid_sachtruyen.Columns[9].HeaderText = "Đơn giá thuê";
            dgrid_sachtruyen.Columns[10].HeaderText = "Số lượng";
            dgrid_sachtruyen.Columns[11].HeaderText = "Ảnh";
            dgrid_sachtruyen.Columns[12].HeaderText = "Ghi chú";

            dgrid_sachtruyen.AllowUserToAddRows = false;
            dgrid_sachtruyen.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void dgrid_sachtruyen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgrid_sachtruyen_Click(object sender, EventArgs e)
        {
            string mals, malv, matg, manxb, mann, sql;

            if (tblsachtruyen.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (btnThem_sach.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMasach.Focus();
                return;
            }
            txtMasach.Text = dgrid_sachtruyen.CurrentRow.Cells["Masach"].Value.ToString();
            txtTensach.Text = dgrid_sachtruyen.CurrentRow.Cells["Tensach"].Value.ToString();
            
            mals= dgrid_sachtruyen.CurrentRow.Cells["Maloai"].Value.ToString();
            cboMaloaisach.Text=Classes.Funtions.GetFieldValues("select Tenloai from tblLoaisach where Maloai=N'" + mals + "'");
            
            malv = dgrid_sachtruyen.CurrentRow.Cells["Malinhvuc"].Value.ToString();
            cboMalinhvuc.Text = Classes.Funtions.GetFieldValues("select Tenlinhvuc from tblLinhvuc where Malinhvuc=N'" + malv + "'");
            
            matg = dgrid_sachtruyen.CurrentRow.Cells["Matacgia"].Value.ToString();
            cboMatacgia.Text = Classes.Funtions.GetFieldValues("select Tentacgia from tblTacgia where Matacgia=N'" + matg + "'");
            
            manxb= dgrid_sachtruyen.CurrentRow.Cells["MaNXB"].Value.ToString();
            cboMaNXB.Text = Classes.Funtions.GetFieldValues("select TenNXB from tblNXB where MaNXB=N'" + manxb + "'");
            
            mann= dgrid_sachtruyen.CurrentRow.Cells["Mangonngu"].Value.ToString();
            cboMangonngu.Text = Classes.Funtions.GetFieldValues("select Tenngonngu from tblNgonngu where Mangonngu=N'" + mann + "'");
            
            txtSotrang.Text = dgrid_sachtruyen.CurrentRow.Cells["Sotrang"].Value.ToString();
            txtGiasach.Text = dgrid_sachtruyen.CurrentRow.Cells["Giasach"].Value.ToString();
            txtDongiathue.Text = dgrid_sachtruyen.CurrentRow.Cells["Dongiathue"].Value.ToString();
            txtSoluong.Text = dgrid_sachtruyen.CurrentRow.Cells["Soluong"].Value.ToString();
            txtGhichu.Text = dgrid_sachtruyen.CurrentRow.Cells["Ghichu"].Value.ToString();
            txtPath.Text = dgrid_sachtruyen.CurrentRow.Cells["Anh"].Value.ToString();
            picAnh.Image = Image.FromFile(txtPath.Text);

            btnXoa_sach.Enabled = true;
            btnBoqua_sach.Enabled = true;
        }

        private void btnThem_sach_Click(object sender, EventArgs e)
        {
            btnSua_sach.Enabled = false;
            btnXoa_sach.Enabled = false;
            btnBoqua_sach.Enabled = true;
            btnLuu_sach.Enabled = true;
            btnThem_sach.Enabled = false;
            resetvalues();
            txtMasach.Enabled = true;
            txtMasach.Focus();
        }

        private void btnXoa_sach_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblsachtruyen.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMasach.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblSach WHERE Masach=N'" + txtMasach.Text + "'";
                Classes.Funtions.RunDelSQL(sql);
                load_datagrid();
                resetvalues();
            }
        }

        private void btnSua_sach_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblsachtruyen.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMasach.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTensach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTensach.Focus();
                return;
            }
            if (txtSotrang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số trang", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSotrang.Focus();
                return;
            }
            if (txtGiasach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giá sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiasach.Focus();
                return;
            }
            if (txtDongiathue.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá thuê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDongiathue.Focus();
                return;
            }
            if (txtSoluong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluong.Focus();
                return;
            }
            if (cboMaloaisach.Text == "")
            {
                MessageBox.Show("Chua chon loai sach");
                cboMaloaisach.Focus();
                return;
            }
            if (cboMalinhvuc.Text == "")
            {
                MessageBox.Show("Chua chon linh vuc");
                cboMalinhvuc.Focus();
                return;
            }
            if (cboMatacgia.Text == "")
            {
                MessageBox.Show("Chua chon tac gia");
                cboMatacgia.Focus();
                return;
            }
            if (cboMaNXB.Text == "")
            {
                MessageBox.Show("Chua chon NXB");
                cboMaNXB.Focus();
                return;
            }
            if (cboMangonngu.Text == "")
            {
                MessageBox.Show("Chua chon ngon ngu");
                cboMangonngu.Focus();
                return;
            }

            string ml, mlv, mtg, mnxb, mnn;
            sql = "SELECT Maloai FROM tblLoaisach WHERE Tenloai = N'" + cboMaloaisach.Text + "'";
            ml = Funtions.GetFieldValues(sql);

            sql = "SELECT Malinhvuc FROM tblLinhvuc WHERE Tenlinhvuc = N'" + cboMalinhvuc.Text + "'";
            mlv = Funtions.GetFieldValues(sql);

            sql = "SELECT Matacgia FROM tblTacgia WHERE Tentacgia = N'" + cboMatacgia.Text + "'";
            mtg = Funtions.GetFieldValues(sql);

            sql = "SELECT MaNXB FROM tblNXB WHERE TenNXB = N'" + cboMaNXB.Text + "'";
            mnxb = Funtions.GetFieldValues(sql);

            sql = "SELECT Mangonngu FROM tblNgonngu WHERE Tenngonngu = N'" + cboMangonngu.Text + "'";
            mnn = Funtions.GetFieldValues(sql);

            sql = "UPDATE tblSach SET " +
                "Tensach = N'"+txtTensach.Text+ "', Maloai = N'"+ml+ "', Malinhvuc = N'"+mlv+ "', Matacgia = N'"+mtg+"', MaNXB = N'"+mnxb+ "', Mangonngu = N'"+mnn+"', Sotrang = "+txtSotrang.Text+", Giasach = "+txtGiasach.Text+", Dongiathue = "+txtDongiathue.Text+", Soluong = "+txtSoluong.Text+", Anh = N'"+txtPath.Text+"', Ghichu = N'"+txtGhichu.Text+"' WHERE Masach = N'"+txtMasach.Text+"'";
            Classes.Funtions.RunSQL(sql);
            load_datagrid();
            resetvalues();
        }

        private void btnLuu_sach_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMasach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMasach.Focus();
                return;
            }
            if (txtTensach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTensach.Focus();
                return;
            }
            if (txtSotrang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số trang", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSotrang.Focus();
                return;
            }
            if (txtGiasach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giá sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiasach.Focus();
                return;
            }
            if (txtDongiathue.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá thuê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDongiathue.Focus();
                return;
            }
            if (txtSoluong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluong.Focus();
                return;
            }
            if (cboMaloaisach.Text == "")
            {
                MessageBox.Show("Chua chon loai sach");
                cboMaloaisach.Focus();
                return;
            }
            if (cboMalinhvuc.Text == "")
            {
                MessageBox.Show("Chua chon linh vuc");
                cboMalinhvuc.Focus();
                return;
            }
            if (cboMatacgia.Text == "")
            {
                MessageBox.Show("Chua chon tac gia");
                cboMatacgia.Focus();
                return;
            }
            if (cboMaNXB.Text == "")
            {
                MessageBox.Show("Chua chon NXB");
                cboMaNXB.Focus();
                return;
            }
            if (cboMangonngu.Text == "")
            {
                MessageBox.Show("Chua chon ngon ngu");
                cboMangonngu.Focus();
                return;
            }
            sql = "SELECT Masach FROM tblSach WHERE Masach=N'" + txtMasach.Text.Trim() + "'";
            if (Classes.Funtions.Checkkey(sql))
            {
                MessageBox.Show("Mã sách này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMasach.Focus();
                txtMasach.Text = "";
                return;
            }

            string ml, mlv, mtg, mnxb, mnn;
            sql = "SELECT Maloai FROM tblLoaisach WHERE Tenloai = N'" + cboMaloaisach.Text + "'";
            ml = Funtions.GetFieldValues(sql);

            sql = "SELECT Malinhvuc FROM tblLinhvuc WHERE Tenlinhvuc = N'" + cboMalinhvuc.Text + "'";
            mlv = Funtions.GetFieldValues(sql);

            sql = "SELECT Matacgia FROM tblTacgia WHERE Tentacgia = N'"+cboMatacgia.Text+"'";
            mtg = Funtions.GetFieldValues(sql);

            sql = "SELECT MaNXB FROM tblNXB WHERE TenNXB = N'" + cboMaNXB.Text + "'";
            mnxb = Funtions.GetFieldValues(sql);

            sql = "SELECT Mangonngu FROM tblNgonngu WHERE Tenngonngu = N'"+cboMangonngu.Text+"'";
            mnn = Funtions.GetFieldValues(sql);

            sql = "INSERT INTO tblSach(Masach, Tensach, Maloai, Malinhvuc, Matacgia, MaNXB, Mangonngu, Sotrang, Giasach, Dongiathue, Soluong, Anh, Ghichu) VALUES(N'"+txtMasach.Text+ "', N'"+txtTensach.Text+ "', N'"+ml+ "', N'"+mlv+ "', N'"+mtg+ "', N'"+mnxb+ "', N'"+mnn+"', "+txtSotrang.Text+", "+txtGiasach.Text+", "+txtDongiathue.Text+", "+txtSoluong.Text+", N'"+txtPath.Text+"', N'"+txtGhichu.Text+"')";

            Classes.Funtions.RunSQL(sql);
            load_datagrid();
            resetvalues();
            btnXoa_sach.Enabled = true;
            btnThem_sach.Enabled = true;
            btnSua_sach.Enabled = true;
            btnBoqua_sach.Enabled = false;
            btnLuu_sach.Enabled = false;
            txtMasach.Enabled = false;
        }

        private void btnBoqua_sach_Click(object sender, EventArgs e)
        {
            resetvalues();
            btnBoqua_sach.Enabled = false;
            btnThem_sach.Enabled = true;
            btnXoa_sach.Enabled = true;
            btnSua_sach.Enabled = true;
            btnLuu_sach.Enabled = false;
            txtMasach.Enabled = false;
        }

        private void btnDong_sach_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMo_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "J pê gờ|*.jpg|Pờ nờ gờ|*.png|Gíph|*.gif";
            dlg.InitialDirectory = @"D:\Downloads\Photos";
            dlg.Title = "Chọn ảnh đi bạn";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = dlg.FileName;
                picAnh.Image = Image.FromFile(txtPath.Text);
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }
    }
}
