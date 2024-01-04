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
using COMExcel = Microsoft.Office.Interop.Excel; 
namespace Quan_ly_thue_sach.Forms

{
    public partial class FrmTraSach : Form
    {
        public FrmTraSach()
        {
            InitializeComponent();
        }
        DataTable tbltrasach;
        private void FrmTraSach_Load(object sender, EventArgs e)
        {

            txtmasach.Enabled = false ;
            txttenkhach.Enabled = false;
            txtmathue.Enabled = true;
            txtmatinhtrang.Enabled = false;
            txtngaythue.Enabled = false;
             txtmatra.Enabled = false;
            txtdongiathue.Enabled = false;
            txttiencoc.Enabled = false;
            cbomakhach.Enabled= false;  
            
            txttongtien.Enabled = false;
            txttienphat.Enabled = false;
            txtthanhtien.Enabled = false;
            txttienphat.Text = "0";
            txttongtien.Text = "0";
            Classes.Funtions.FillCombo("select Makhach,Tenkhach from tblKhach ", cbomakhach, "Makhach", "Tenkhach");
            cbomakhach.SelectedIndex = -1;
            Classes.Funtions.FillCombo("select MaNV from tblNV", cbomanhanvien, "MaNV", "MaNV");
            cbomanhanvien.SelectedIndex = -1;
            Classes.Funtions.FillCombo("select MaVP,TenVP from tblVipham", cbomavipham, "MaVP", "TenVP");
            cbomavipham.SelectedIndex = -1;
            Classes.Funtions.FillCombo("select Mathue from tblHDThue", cbomatthue, "Mathue", "Mathue");
            cbomatthue.SelectedIndex = -1;
       
            if (txtmathue.Text != "")
            {
                Load_ttHD();
                btnin.Enabled = true;
            }
            Load_Datagridview();
        }
        private void Load_Datagridview()
        {
            string sql;
            sql = "select b.Mathue, a.Masach, b.Ngaythue, a.Dongiathue, c.Datra from tblSach a, tblHDThue b,tblCTHDThue c where a.Masach=c.Masach and b.Mathue=c.Mathue and c.Datra=N'Chưa' and b.Mathue='" + txtmathue.Text + "' ";
            tbltrasach = Classes.Funtions.GetDataToTable(sql);
            dgirdtrasach.DataSource = tbltrasach;
            dgirdtrasach.Columns[0].HeaderText = "Mã thuê";
            dgirdtrasach.Columns[1].HeaderText = "Mã sách";
            dgirdtrasach.Columns[2].HeaderText = "Ngày thuê";
            dgirdtrasach.Columns[3].HeaderText = "Đơn giá thuê";
            dgirdtrasach.Columns[4].HeaderText = "Đã trả";
            dgirdtrasach.AllowUserToAddRows = false;
            dgirdtrasach.EditMode = DataGridViewEditMode.EditProgrammatically;

        }
        private void Load_ttHD()
        {
            string str;
            str = "select Ngaythue from tblHDThue where Mathue=N'" + txtmathue.Text + "'";
            txtngaythue.Text = Classes.Funtions.ConvertDateTime(Classes.Funtions.GetFieldValues(str));
            str = "select Makhach from tblHDThue where Mathue=N'" + txtmathue.Text + "'";
            cbomakhach.Text = Classes.Funtions.GetFieldValues(str);
            str = "select Tenkhach from tblKhach where Makhach=N'" + cbomakhach.Text + "'";
            txttenkhach.Text = Classes.Funtions.GetFieldValues(str);
            str = "select Tiendatcoc from tblHDThue where Mathue=N'" + txtmathue.Text + "'";
            txttiencoc.Text = Classes.Funtions.GetFieldValues(str);
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            if (cbomatthue.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomatthue.Focus();
                return;
            }
            txtmathue.Text = cbomatthue.SelectedValue.ToString();
            Load_ttHD();
            Load_Datagridview();
            btnluu.Enabled = true;
            btnin.Enabled = true;
            cbomatthue.SelectedIndex = -1;

        }

        private void cbomatthue_DropDown(object sender, EventArgs e)
        {
            Classes.Funtions.FillCombo("SELECT Mathue FROM tblHDThue", cbomatthue, "Mathue", "Mathue");
            cbomatthue.SelectedIndex = -1;
        }

        private void btntra_Click(object sender, EventArgs e)
        {

            btnluu.Enabled = true;
            btnin.Enabled = false;
            btntra.Enabled = false;
            ResetValues();            
            txtmatra.Text = Classes.Funtions.CreateKey("HDT");
            txtngaytra.Text = DateTime.Now.ToShortDateString();
            dgirdtrasach.DataSource = null;
        }
        private void ResetValues()
        {
            txtmathue.Text = "";
            txtmasach.Text = "";
            cbomakhach.Text = "";
            txtmatinhtrang.Text = "";
            txttienphat.Text = "0";
            txtdongiathue.Text = "0";
           txtthanhtien.Text = "0";
            txttiencoc.Text = "0";
            txtngaythue.Text = "";
            txttenkhach.Text = "";
            txtdongiathue.Text = "";
            cbomanhanvien.Text = "";
            cbomavipham.Text = "";

        }

        private void ResetValuesSach()
        {
            txtmasach.Text = "";
            txtdongiathue.Text = "0";
            txtthanhtien.Text = "0";
            txtsongaythue.Text = "0";
            txttienphat.Text = "0";

        }

        private void dgirdtrasach_Click(object sender, EventArgs e)
        {
            if(tbltrasach.Rows.Count==0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                cbomakhach.Text = Classes.Funtions.GetFieldValues("select Makhach from tblHDThue where Mathue=N'" + txtmathue.Text + "'");
                txttenkhach.Text = Classes.Funtions.GetFieldValues("select Tenkhach from tblKhach where Makhach=N'"+cbomakhach.Text+"'");
                txtmasach.Text = dgirdtrasach.CurrentRow.Cells["Masach"].Value.ToString();
               txtmatinhtrang.Text = Classes.Funtions.GetFieldValues("select MaTT from tblCTHDThue where Masach=N'" + txtmasach.Text + "' and Mathue=N'"+txtmathue.Text+"'" );
                txtngaythue.Text = dgirdtrasach.CurrentRow.Cells["Ngaythue"].Value.ToString();
                txtdongiathue.Text = Classes.Funtions.GetFieldValues("select Dongiathue from tblSach where Masach=N'" + txtmasach.Text + "'");
                if(btntra.Enabled==false)
                {
                    tinhngay();
                    double dgt, tp, thanhtien, songay;
                    dgt = Convert.ToDouble(txtdongiathue.Text);
                    tp = Convert.ToDouble(txttienphat.Text);
                    songay = Convert.ToDouble(txtsongaythue.Text);
                    thanhtien = dgt * songay + tp;
                    txtthanhtien.Text = thanhtien.ToString();
                }                       
            }                
        }
       
        private void cbomavipham_SelectedValueChanged(object sender, EventArgs e)
        {
            txttienphat.Text = Classes.Funtions.GetFieldValues("select Tienphat from tblVipham where MaVP=N'"+cbomavipham.SelectedValue+"'");
        }
        // Hàm tính số ngày thuê
        private void tinhngay()
        {
   
            DateTime thue = new DateTime();
            thue = Convert.ToDateTime(txtngaythue.Text);
            DateTime tra = new DateTime();
            tra = Convert.ToDateTime(txtngaytra.Text);
            TimeSpan songay = tra - thue;
            int sn = songay.Days;
            txtsongaythue.Text = Convert.ToString(sn);
        }
        private void txtngaytra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                tinhngay();
            }
        }
        // In hóa đơn trả sách
        private void btnin_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblthongtinsach, tbltttra;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];

            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:Z300"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 20;
            exRange.Range["C1:C1"].ColumnWidth = 25;
            exRange.Range["C1:C1"].ColumnWidth = 15;

            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Cửa hàng cho thuê sách_MỌT NHÓM";

            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "12 Chùa Bộc, Đống Đa, Hà Nội";

            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: 0378588031";


            exRange.Range["C4:E4"].Font.Size = 16;
            exRange.Range["C4:E4"].Font.Name = "Times new roman";
            exRange.Range["C4:E4"].Font.Bold = true;
            exRange.Range["C4:E4"].Font.ColorIndex = 3;

            exRange.Range["C4:E4"].MergeCells = true;
            exRange.Range["C4:E4"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C4:E4"].Value = "HÓA ĐƠN TRẢ SÁCH";
            // biểu diến thông tin chung của hóa đơn

            sql = "select b.Matra,b.MaNV,b.Ngaytra,b.Tongtien,c.TenNV  from tblCTHDTra a, tblHDTra b, tblNV c, tblCTHDThue d where a.Matra=b.Matra and c.MaNV=b.MaNV and b.Matra=N'" + txtmatra.Text + "'";
            tbltttra = Classes.Funtions.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:B6"].Value = "Mã trả sách:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tbltttra.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Mã nhân viên:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tbltttra.Rows[0][1].ToString();
            exRange.Range["B8:B8"].Value = "Tổng tiền:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tbltttra.Rows[0][3].ToString();

            //Lấy thông tin trả sách
            sql = "select  a.Masach, c.Tensach,a.MaVP, a.Thanhtien from tblCTHDTra a, tblHDTra b, tblSach c where a.Matra=b.Matra and a.Masach=c.Masach and a.Matra=N'" + txtmatra.Text + "'";
            tblthongtinsach = Classes.Funtions.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Mã sách";
            exRange.Range["C11:C11"].Value = "Tên sách";
            exRange.Range["D11:D11"].Value = "Vi phạm";
            exRange.Range["E11:E11"].Value = "Thành tiền";


            for (hang = 0; hang < tblthongtinsach.Rows.Count; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < tblthongtinsach.Columns.Count; cot++)
                {
                    exSheet.Cells[cot + 2][hang + 12] = tblthongtinsach.Rows[hang][cot].ToString();
                    if (cot == 3) exSheet.Cells[cot + 2][hang + 12] = tblthongtinsach.Rows[hang][cot].ToString();
                }
                //Điền thông tin hàng từ cột thứ 2, dòng 12
            }


            string thanhtien;
            thanhtien = Classes.Funtions.GetFieldValues("select sum(Thanhtien) from tblCTHDTra where Matra=N'" + txtmatra.Text + "'");
            double  tt, tht;
            tt = Convert.ToDouble(txttongtien.Text);
            tht = Convert.ToDouble(thanhtien);
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng thành tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tht.ToString();

            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + Classes.Funtions.ChuyenSoSangChu(tbltttra.Rows[0][3].ToString());
            exRange = exSheet.Cells[4][hang + 18];

            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            DateTime d = Convert.ToDateTime(tbltttra.Rows[0][2]);
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;

            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên thực hiện";


            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tbltttra.Rows[0][4];
            exSheet.Name = "Hóa đơn trả sách";
            exApp.Visible = true;
            ResetValues();
            btntra.Enabled = true;
            btnluu.Enabled = false;
            btnin.Enabled = false;
            txtmathue.Enabled = true;      
            txtmathue.Text = "";
            txtmatra.Text = "";
            cbomanhanvien.SelectedIndex = -1;
            txttongtien.Text = "0";
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnluu_Click(object sender, EventArgs e)
        {   
            string sql;
            double tong;
            double tongmoi;
            sql = "select Matra from tblHDTra where Matra=N'"+txtmatra.Text+"'";
            if (!Classes.Funtions.Checkkey(sql)) // nếu mã hóa đơn không trùng hóa tiến hành lưu được nhiều mã
            {
             
          
                if (cbomanhanvien.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbomanhanvien.Focus();
                    return;
                }
              
                sql = "INSERT INTO tblHDTra(Matra,Mathue, Ngaytra, MaNV, Tongtien) VALUES(N'" + txtmatra.Text.Trim() + "',N'"+txtmathue.Text.Trim()+"' ,'" + txtngaytra.Text.Trim() + "',N'" + cbomanhanvien.SelectedValue + "','" + txttongtien.Text + "')";
                Classes.Funtions.RunSQL(sql);
            }
             sql = "insert into tblCTHDTra(Matra, Masach, MaVP, Thanhtien) values(N'" + txtmatra.Text.Trim() + "', N'" + txtmasach.Text + "', N'" + cbomavipham.SelectedValue.ToString() + "', N'" + txtthanhtien.Text + "')";
             Classes.Funtions.RunSQL(sql);
            //Cập nhật lại số lượng cho bảng Sách Truyện
            sql = "update tblSach set Soluong=Soluong+1 where Masach=N'" + txtmasach.Text + "'";
            Classes.Funtions.RunSQL(sql);
            sql = "update tblCTHDThue set Datra=N'Rồi' where Masach=N'" + txtmasach.Text + "' and Mathue=N'" + txtmathue.Text + "' ";
            Classes.Funtions.RunSQL(sql);
            Load_Datagridview();
            // Cập nhật lại tổng tiền cho hóa đơn 
            tong = Convert.ToDouble(Classes.Funtions.GetFieldValues("SELECT Tongtien FROM tblHDTra WHERE Matra = N'" + txtmatra.Text + "'and Mathue= '" + txtmathue.Text + "'"));
            tongmoi = tong + Convert.ToDouble(txtthanhtien.Text); //tổng mới = tổng cũ + thành tiền
            sql = "UPDATE tblHDTra SET Tongtien =" + tongmoi + " WHERE Matra = N'" + txtmatra.Text + "'"; //update vào bảng hóa đơn trả
            Classes.Funtions.RunSQL(sql);
            txttongtien.Text = tongmoi.ToString();
          
            ResetValuesSach();       
           btnin.Enabled = true;
        }
       private void txtthanhtien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }
        private void txtsongaythue_TextChanged(object sender, EventArgs e)
        {           
            double sn, tp, dg, tt;
            if (txtsongaythue.Text == "")
                sn = 0;
            else
                sn = Convert.ToDouble(txtsongaythue.Text);
            if (txttienphat.Text == "")
                tp = 0;
            else
                tp = Convert.ToDouble(txttienphat.Text);
            if (txtdongiathue.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtdongiathue.Text);
            tt = sn * dg + tp;
            txtthanhtien.Text = tt.ToString();

        }
        private void txttienphat_TextChanged(object sender, EventArgs e)
        {
            double sn, tp, dg, tt;
            if (txtsongaythue.Text == "")
                sn = 0;
            else
                sn = Convert.ToDouble(txtsongaythue.Text);
            if (txttienphat.Text == "")
                tp = 0;
            else
                tp = Convert.ToDouble(txttienphat.Text);
            if (txtdongiathue.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtdongiathue.Text);
            tt = sn * dg + tp;
            txtthanhtien.Text = tt.ToString();
        }
    }
}
