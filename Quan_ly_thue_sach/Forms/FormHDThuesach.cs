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
using System.Data.SqlClient;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace Quan_ly_thue_sach.Forms
{
    public partial class frmHDThuesach : Form
    {
        public frmHDThuesach()
        {
            InitializeComponent();
        }

        DataTable tblHDThue;
        private void frmHDThuesach_Load(object sender, EventArgs e)
        {
            btnBoqua.Enabled = false;
            btnCN.Enabled = false;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnIn.Enabled = false;
            txtMathue.ReadOnly = true;
            txtTenkhach.ReadOnly = true;
            txtTenNV.ReadOnly = true;
            txtDiachi.ReadOnly = true;
            txtTensach.ReadOnly = true;
            txtTongtiencoc.ReadOnly = true;
            txtSoluong.ReadOnly = true;
            txtGiathuc.ReadOnly = true;
            txtDongia.ReadOnly = true;
            txtGhichu.ReadOnly = true;
            Funtions.FillCombo("SELECT MaNV FROM tblNV", cboMaNV, "MaNV", "MaNV");
            cboMaNV.SelectedIndex = -1;
            Funtions.FillCombo("SELECT Makhach FROM tblKhach", cboMakhach, "Makhach", "Makhach");
            cboMakhach.SelectedIndex = -1;
            Funtions.FillCombo("SELECT Masach FROM tblSach", cboMasach, "Masach", "Masach");
            cboMasach.SelectedIndex = -1;
            Funtions.FillCombo("SELECT MaTT, TenTT FROM tblTinhtrang", cboMaTT, "MaTT", "TenTT");
            cboMaTT.SelectedIndex = -1;
            Funtions.FillCombo("SELECT Mathue FROM tblHDThue", cboMathue, "Mathue", "Mathue");
            cboMathue.SelectedIndex = -1;

            if (txtMathue.Text != "")
            {
                Load_ThongtinHD();
                btnXoa.Enabled = true;
                btnIn.Enabled = true;
            }
            Load_DVChitiet();
        }
        private void Load_DVChitiet()
        {
            string sql;
            sql = "SELECT a.Makhach, d.Masach, b.Mathue, a.Tenkhach, a.Diachi, b.Ngaythue, d.Tensach, d.Dongiathue, c.MaTT, c.Datra, d.Giasach FROM tblKhach a, tblHDThue b, tblCTHDThue c, tblSach d WHERE a.Makhach = b.Makhach AND b.Mathue = c.Mathue AND c.Masach = d.Masach AND b.Mathue = N'" + txtMathue.Text + "'";
            tblHDThue = Funtions.GetDataToTable(sql);
            data_GV.DataSource = tblHDThue;

            string[] Header = new string[11] { "Ma khach", "Ma sach", "Ma thue", "Ten khach", "Dia chi", "Ngay thue", "Ten sach", "Don gia thue", "Ma tinh trang", "Da tra", "Gia sach" };
            for (int i = 0; i < Header.Length; i++)
            {
                data_GV.Columns[i].HeaderText = Header[i];
            }

            data_GV.AllowUserToAddRows = false;
            data_GV.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void Load_ThongtinHD()
        {
            string sql;
            sql = "SELECT Ngaythue FROM tblHDThue WHERE Mathue = N'" + txtMathue.Text + "'";
            DateTime time = Convert.ToDateTime(Funtions.GetFieldValues(sql));
            txtNgaythue.Text = Funtions.ConvertDateTime(time.ToShortDateString());

            sql = "SELECT MaNV FROM tblHDThue WHERE Mathue = N'" + txtMathue.Text + "'";
            cboMaNV.Text = Funtions.GetFieldValues(sql);

            sql = "SELECT Makhach FROM tblHDThue WHERE Mathue = N'" + txtMathue.Text + "'";
            cboMakhach.Text = Funtions.GetFieldValues(sql);

            sql = "SELECT Tiendatcoc FROM tblHDThue WHERE Mathue = N'" + txtMathue.Text + "'";
            txtTongtiencoc.Text = Funtions.GetFieldValues(sql);

            lblTien.Text = "Bằng chữ: " + Funtions.ChuyenSoSangChu(txtTongtiencoc.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnIn.Enabled = false;
            btnThem.Enabled = false;
            Reset_Values();
            txtMathue.Text = Funtions.CreateKey("MT");
            Load_DVChitiet();
        }

        private void Reset_Values()
        {
            txtMathue.Clear();
            cboMaNV.SelectedIndex = -1;
            cboMakhach.SelectedIndex = -1;
            cboMasach.SelectedIndex = -1;
            cboMaTT.SelectedIndex = -1;
            txtSoluong.Text = "";
            txtDongia.Text = "";
            txtTongtiencoc.Text = "0";
            lblTien.Text = "Bằng chữ:";
            txtNgaythue.Text = Funtions.ConvertDateTime(DateTime.Now.ToShortDateString());
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            double slKho, slCon, tong, tongMoi;

            // Chỗ này để check mã thuê đã xuất hiện ngay từ lần lưu đầu tiên chưa
            // nếu có rồi thì nhảy sang bước lưu chi tiết sản phẩm để không bị trùng
            // mã thuê
            sql = "SELECT Mathue FROM tblHDThue WHERE Mathue = N'"+ txtMathue.Text + "'";
            if (!Funtions.Checkkey(sql))
            {
                if (txtNgaythue.Text.Length == 0)
                {
                    MessageBox.Show("Ban phai nhap ngay thue");
                    txtNgaythue.Focus();
                    return;
                }


                if (cboMaNV.SelectedIndex == -1)
                {
                    MessageBox.Show("Chua chon nhan vien");
                    cboMaNV.Focus();
                    return;
                }

                if (cboMakhach.SelectedIndex == -1)
                {
                    MessageBox.Show("Chua chon khach hang");
                    cboMakhach.Focus();
                    return;
                }

                sql = "INSERT INTO tblHDThue(Mathue, Makhach, MaNV, Ngaythue, Tiendatcoc) VALUES (N'" + txtMathue.Text + "', N'" + cboMakhach.Text + "', N'" + cboMaNV.Text + "', '" + Funtions.ConvertDateTime(txtNgaythue.Text) + "', " + txtTongtiencoc.Text + ")";
                Funtions.RunSQL(sql);
            }

            // Tiến hành lưu thông tin chi tiết sản phẩm
            if (cboMasach.SelectedIndex == -1)
            {
                MessageBox.Show("Chua chon ma sach");
                cboMasach.Focus();
                return;
            }

            if (cboMaTT.SelectedIndex == -1)
            {
                MessageBox.Show("Chua chon tinh trang sach");
                cboMasach.Focus();
                return;
            }

            sql = "SELECT Masach FROM tblCTHDThue WHERE Masach = N'" + cboMasach.Text + "' AND Mathue = N'" + txtMathue.Text + "'";
            if (Funtions.Checkkey(sql))
            {
                MessageBox.Show("Chi duoc chon moi cuon sach 1 sach! Vui long cho nguoi khac muon");
                cboMasach.SelectedIndex = -1;
                Reset_Values_Sach();
                cboMasach.Focus();
                return;
            }

            string matt;

            matt = Funtions.GetFieldValues("SELECT MaTT FROM tblTinhtrang WHERE TenTT = N'" + cboMaTT.Text + "'");
            sql = "INSERT INTO tblCTHDThue(Mathue, Masach, MaTT, Datra) VALUES(N'" + txtMathue.Text + "', N'" + cboMasach.Text + "', N'" + matt + "', N'"+"Chưa"+"' )";
            Funtions.RunSQL(sql);
            Load_DVChitiet();

            //Cap nhat so luong
            sql = "SELECT Soluong FROM tblSach WHERE Masach = N'" + cboMasach.Text + "'";
            slKho = Convert.ToDouble(Funtions.GetFieldValues(sql));
            slCon = slKho - 1;
            sql = "UPDATE tblSach SET Soluong = " + slCon + " WHERE Masach = N'" + cboMasach.Text + "'";
            Funtions.RunSQL(sql);

            //Cap nhat tong coc
            sql = "SELECT Tiendatcoc FROM tblHDThue WHERE Mathue = N'" + txtMathue.Text + "'";
            tong = Convert.ToDouble(Funtions.GetFieldValues(sql));
            tongMoi = tong + Convert.ToDouble(txtGiathuc.Text);
            sql = "UPDATE tblHDThue SET Tiendatcoc = " + tongMoi + " WHERE Mathue = N'" + txtMathue.Text + "'";
            Funtions.RunSQL(sql);
            txtTongtiencoc.Text = tongMoi.ToString();
            lblTien.Text = "Bằng chữ: " + Funtions.ChuyenSoSangChu(tongMoi.ToString());
            Reset_Values_Sach();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnIn.Enabled = true;
        }

        private void Reset_Values_Sach()
        {
            cboMasach.SelectedIndex = -1;
            txtTensach.Clear();
            txtSoluong.Clear();
            txtDongia.Clear();
            txtGhichu.Clear();
            txtGiathuc.Clear();
            cboMaTT.SelectedIndex = -1;
        }

        private void data_GV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tblHDThue.Rows.Count == 0)
            {
                MessageBox.Show("Khong co du lieu");
                return;
            }

            DialogResult dlg = new DialogResult();
            dlg = MessageBox.Show("Ban co muon xoa khong?", "Thong bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dlg == DialogResult.OK)
            {
                string masach;
                masach = data_GV.CurrentRow.Cells["Masach"].Value.ToString();
                DelSach(txtMathue.Text, masach);

                // Update tong coc
                Double Giathuc;
                Giathuc = Convert.ToDouble(data_GV.CurrentRow.Cells["Giasach"].Value.ToString());
                DelUpdateTongcoc(txtMathue.Text, Giathuc);
                Load_DVChitiet();
            }
        }

        private void DelSach(string Mathue, string Masach)
        {
            Double slKho, slMoi;
            string sql;
            sql = "SELECT Soluong FROM tblSach WHERE Masach = N'" + Masach + "'";
            slKho = Convert.ToDouble(Funtions.GetFieldValues(sql));

            sql = "DELETE tblCTHDThue WHERE Mathue = N'" + Mathue + "' AND Masach = N'" + Masach + "'";
            Funtions.RunDelSQL(sql);
            slMoi = slKho + 1;
            sql = "UPDATE tblSach SET Soluong = " + slMoi + " WHERE Masach = N'" + Masach + "'";
            Funtions.RunSQL(sql);
        }

        private void DelUpdateTongcoc(string Mathue, double Gia)
        {
            string sql;
            double tong, tongmoi;
            sql = "SELECT Tiendatcoc FROM tblHDThue WHERE Mathue = N'" + Mathue + "'";
            tong = Convert.ToDouble(Funtions.GetFieldValues(sql));
            tongmoi = tong - Gia;
            sql = "UPDATE tblHDThue SET Tiendatcoc = " + tongmoi + " WHERE Mathue = N'" + Mathue + "'";
            Funtions.RunSQL(sql);
            txtTongtiencoc.Text = tongmoi.ToString();
            lblTien.Text = "Bằng chữ: " + Funtions.ChuyenSoSangChu(tongmoi.ToString());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMathue.Text == "")
            {
                MessageBox.Show("Chua chon Hoa don nao");
                cboMathue.Focus();
                return;
            }
            DialogResult dlg = new DialogResult();
            dlg = MessageBox.Show("Ban muon xoa HD ?", "Thong bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dlg == DialogResult.OK)
            {
                string[] Masach = new string[20];
                string sql;
                int n = 0;
                int i;
                sql = "SELECT Masach FROM tblCTHDThue WHERE Mathue = N'" + txtMathue.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, Funtions.Conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Masach[n] = reader.GetString(0).ToString();
                    n = n + 1;
                }
                reader.Close();

                //Xoa ds cac mat hang
                for (i = 0; i <= n - 1; i++)
                {
                    DelSach(txtMathue.Text, Masach[i]);
                }

                // Xoa hoa don
                sql = "DELETE tblHDThue WHERE Mathue = N'" + txtMathue.Text + "'";
                Funtions.RunDelSQL(sql);
                Reset_Values();
                Load_DVChitiet();
                btnXoa.Enabled = false;
                btnIn.Enabled = false;
            }


        }

        private void cboMaNV_TextChanged(object sender, EventArgs e)
        {

            if (cboMaNV.Text == "")
            {
                txtTenNV.Clear();
            }

            txtTenNV.Text = Funtions.GetFieldValues("SELECT TenNV FROM tblNV WHERE MaNV = N'" + cboMaNV.SelectedValue + "'");
        }

        private void cboMakhach_TextChanged(object sender, EventArgs e)
        {
            if (cboMakhach.Text == "")
            {
                txtTenkhach.Clear();
                txtDiachi.Clear();
            }

            string sql;
            sql = "SELECT Tenkhach FROM tblKhach WHERE Makhach = N'" + cboMakhach.SelectedValue + "'";
            txtTenkhach.Text = Funtions.GetFieldValues(sql);

            sql = "SELECT Diachi FROM tblKhach WHERE Makhach = N'" + cboMakhach.SelectedValue + "'";
            txtDiachi.Text = Funtions.GetFieldValues(sql);
        }

        private void cboMasach_TextChanged(object sender, EventArgs e)
        {
            if (cboMasach.Text == "")
            {
                txtTensach.Clear();
                txtSoluong.Clear();
                txtGiathuc.Clear();
                txtDongia.Clear();
                txtGhichu.Clear();
                picAnh.Image = null;
            }

            string sql;
            sql = "SELECT Tensach FROM tblSach WHERE Masach = N'" + cboMasach.SelectedValue + "'";
            txtTensach.Text = Funtions.GetFieldValues(sql);
            sql = "SELECT Soluong FROM tblSach WHERE Masach = N'" + cboMasach.SelectedValue + "'";
            txtSoluong.Text = Funtions.GetFieldValues(sql);
            sql = "SELECT Giasach FROM tblSach WHERE Masach = N'" + cboMasach.SelectedValue + "'";
            txtGiathuc.Text = Funtions.GetFieldValues(sql);
            sql = "SELECT Dongiathue FROM tblSach WHERE Masach = N'" + cboMasach.SelectedValue + "'";
            txtDongia.Text = Funtions.GetFieldValues(sql);
            sql = "SELECT Ghichu FROM tblSach WHERE Masach = N'" + cboMasach.SelectedValue + "'";
            txtGhichu.Text = Funtions.GetFieldValues(sql);
            sql = "SELECT Anh FROM tblSach WHERE Masach = N'" + cboMasach.SelectedValue + "'";
            txtAnh.Text = Funtions.GetFieldValues(sql);
            if (txtAnh.Text != "")
                picAnh.Image = Image.FromFile(txtAnh.Text);
        }

        private void btnTimMT_Click(object sender, EventArgs e)
        {
            if (cboMathue.Text == "")
            {
                MessageBox.Show("Ban phai chon mot ma hoa don");
                cboMathue.Focus();
                return;
            }

            txtMathue.Text = cboMathue.Text;
            Load_ThongtinHD();
            Load_DVChitiet();
            btnXoa.Enabled = true;
            btnLuu.Enabled = true;
            btnIn.Enabled = true;
            cboMathue.SelectedIndex = -1;
        }

        private void cboMathue_DropDown(object sender, EventArgs e)
        {
            Funtions.FillCombo("SELECT Mathue FROM tblHDThue", cboMathue, "Mathue", "Mathue");
            cboMathue.SelectedIndex = -1;
        }

        private void frmHDThuesach_FormClosing(object sender, FormClosingEventArgs e)
        {
            Reset_Values();
        }

        private void btnCN_Click(object sender, EventArgs e)
        {
            string sql, ma;
            sql = "SELECT MaTT FROM tblTinhtrang WHERE TenTT = N'" + cboMaTT.Text + "' ";
            ma = Funtions.GetFieldValues(sql);
            sql = "UPDATE tblCTHDThue SET MaTT = N'" + ma + "'";
            Funtions.RunSQL(sql);
            Load_DVChitiet();
            Reset_Values_Sach();
            btnLuu.Enabled = true;
            cboMasach.Enabled = true;
            btnCN.Enabled = false;
            btnBoqua.Enabled = false;
        }

        private void data_GV_Click(object sender, EventArgs e)
        {
           if (tblHDThue.Rows.Count == 0)
            {
                MessageBox.Show("Khong co du lieu");
                return;
            }

            cboMasach.Text = data_GV.CurrentRow.Cells["Masach"].Value.ToString();
            string sql, ma;
            sql = "SELECT MaTT FROM tblCTHDThue WHERE Masach = N'"+cboMasach.Text+"'";
            ma = Funtions.GetFieldValues(sql);
            cboMaTT.Text = Funtions.GetFieldValues("SELECT TenTT FROM tblTinhtrang WHERE MaTT = N'"+ma+"'");

            cboMasach.Enabled = false;
            btnCN.Enabled = true;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = true;
            btnThem.Enabled = false;
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            Reset_Values_Sach();
            cboMasach.Enabled = true;
            btnLuu.Enabled = true;
            btnBoqua.Enabled = false;
            btnCN.Enabled = false;
            btnThem.Enabled = true;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; // Excel 1 - n Workbook
            COMExcel.Worksheet exSheet; // Workbook 1 - n Worksheet
            COMExcel.Range exRange;

            string sql;
            int hang = 0, cot = 0;
            DataTable tblTTHDThue, tblTTSach;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];

            //Dinh dang chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Name = "Times New Roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5;
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Thư viện Một Nhóm";

            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Chùa Bộc - Đống Đa - Hà Nội";

            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: 84 918 xxx xxx";

            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times New Roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3;
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "Phiếu thuê";

            // Thông tin chung Hóa đơn thuê
            sql = "SELECT a.Mathue, b.Tenkhach, b.Diachi, a.Ngaythue, a.Tiendatcoc, c.TenNV FROM tblHDThue a, tblKhach b, tblNV c WHERE a.Mathue = N'" + txtMathue.Text + "' AND a.Makhach = b.Makhach AND a.MaNV = c.MaNV";
            tblTTHDThue = Funtions.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times New Roman";
            
            exRange.Range["B6:B6"].Value = "Mã phiếu thuê:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblTTHDThue.Rows[0][0].ToString();
            
            exRange.Range["B7:B7"].Value = "Khách hàng:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblTTHDThue.Rows[0][1].ToString();

            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblTTHDThue.Rows[0][2].ToString();

            // Thông tin các cuốn sách
            sql = "SELECT b.Tensach, b.Giasach, b.Dongiathue, c.TenTT FROM tblCTHDThue a, tblSach b, tblTinhtrang c WHERE a.Masach = b.Masach AND a.MaTT = c.MaTT AND a.Mathue = N'" + txtMathue.Text + "'";
            tblTTSach = Funtions.GetDataToTable(sql);

            // Tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên sách";
            exRange.Range["C11:C11"].Value = "Giá của sách";
            exRange.Range["D11:D11"].Value = "Đơn giá thuê";
            exRange.Range["E11:E11"].Value = "Tình trạng";

            for (hang = 0; hang < tblTTSach.Rows.Count; hang++)
            {
                // Điền số thứ tự vào cột
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < tblTTSach.Columns.Count; cot++)
                {
                    // Điền thông tin hàng từ cột 2, dòng 12
                    exSheet.Cells[cot + 2][hang + 12] = tblTTSach.Rows[hang][cot].ToString();
                }
            }
            int tmp;
            tmp = hang;

            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblTTHDThue.Rows[0][4].ToString();

            exRange = exSheet.Cells[4][hang + 15];
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            string tien = tblTTHDThue.Rows[0][4].ToString();
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + Funtions.ChuyenSoSangChu(tien);
            
            exRange = exSheet.Cells[4][hang + 17];
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblTTHDThue.Rows[0][3]);
            exRange.Range["A1:C1"].Value = "Chùa Bộc, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;

            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";

            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblTTHDThue.Rows[0][5];
            
            exSheet.Name = "Hóa đơn thuê";
            exApp.Visible = true;

        }
    }
}
