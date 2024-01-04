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


namespace Quan_ly_thue_sach.Forms.Tuan
{
    public partial class frmBaocaosach : Form
    {
        public frmBaocaosach()
        {
            InitializeComponent();
        }

        private void frmBaocaosach_Load(object sender, EventArgs e)
        {
            btnboqua.Enabled = false;
            btnin.Enabled = false;
            Reset_Values();
            Load_DataGridView();
          
        }
        private void Reset_Values()
        {
            txtnam.Text = "";
            txtthang.Text = "";
           txtthang.Enabled = true;
            txtnam.Enabled = true;
        }
        DataTable bc;
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT a.Masach,a.Tensach, a.Maloai, a.Malinhvuc, a.Matacgia,a.MaNXB, a.Mangonngu, a.Sotrang, a.Giasach, a.Soluong, b.MaTT, b.Datra, c.Ngaythue FROM tblSach a join tblCTHDThue b on a.Masach=b.Masach JOIN tblHDThue c on c.Mathue=b.Mathue WHERE b.Datra = N'Chưa' AND 1=1";
            bc = Classes.Funtions.GetDataToTable(sql);
            dgr.DataSource = bc;
            dgr.Columns[0].HeaderText = "Mã sách";
            dgr.Columns[1].HeaderText = "Tên sách";
            dgr.Columns[2].HeaderText = "Mã loại";
            dgr.Columns[3].HeaderText = "Mã lĩnh vực";
            dgr.Columns[4].HeaderText = "Mã tác giả";
            dgr.Columns[5].HeaderText = "Mã NXB";
            dgr.Columns[6].HeaderText = "Mã ngôn ngữ";
            dgr.Columns[7].HeaderText = "Số trang";
            dgr.Columns[8].HeaderText = "Giá sách";
            dgr.Columns[9].HeaderText = "Số lượng";
            dgr.Columns[10].HeaderText = "Mã tình trạng";
            dgr.Columns[11].HeaderText = "Đã trả";
            dgr.Columns[12].HeaderText = "Ngày thuê";

            dgr.AllowUserToAddRows = false;
            dgr.EditMode =
            DataGridViewEditMode.EditProgrammatically;
        }

        private void btnbaocao_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtthang.Text == "")
            {
               
            MessageBox.Show("Nhập 1 tháng cụ thể để hiển thị.", "Thôngbáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtthang.Focus();
                return;
            }
            if (txtnam.Text == "")
            {
                MessageBox.Show("Bạn phải nhập năm.", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtnam.Focus();
                return;
            }
            sql = "SELECT a.Masach,a.Tensach, a.Maloai, a.Malinhvuc,a.Matacgia, a.MaNXB, a.Mangonngu, a.Sotrang, a.Giasach, a.Soluong, b.MaTT, b.Datra, c.Ngaythue FROM tblSach a join tblCTHDThue b on a.Masach = b.Masach JOIN tblHDThue c on c.Mathue=b.Mathue where b.Datra=N'Chưa' And Year(c.Ngaythue)='" + txtnam.Text + "' And Month(c.Ngaythue)='" + txtthang.Text + "'";
              bc= Classes.Funtions.GetDataToTable(sql);
            if (bc.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Có " + bc.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                 dgr.DataSource = bc;
                txtthang.Enabled = false;
                 txtnam.Enabled = false;
                btnbaocao.Enabled = false;
                btnboqua.Enabled = true;
                btnin.Enabled = true;
            

        }

        private void dgr_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
           Reset_Values();
            btnboqua.Enabled = false;
            btnin.Enabled = false;
            Load_DataGridView();
            btnbaocao.Enabled = true;
            txtthang.Enabled = true;
            txtnam.Enabled = true;
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnin_Click(object sender, EventArgs e)
        {
            if ((txtthang.Text == "") || (txtnam.Text == ""))
            {
                MessageBox.Show("Hãy chọn 1 tháng cụ thể để hiển thị.",
                "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; // Excel 1 - n Workbook
            COMExcel.Worksheet exSheet; // Workbook 1 - n Worksheet
            COMExcel.Range exRange;

            string sql;
            int hang = 0, cot = 0;
            DataTable tblDS;
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

            exRange.Range["D2:I2"].Font.Size = 16;
            exRange.Range["D2:I2"].Font.Name = "Times New Roman";
            exRange.Range["D2:I2"].Font.Bold = true;
            exRange.Range["D2:I2"].Font.ColorIndex = 3;
            exRange.Range["D2:I2"].MergeCells = true;
            exRange.Range["D2:I2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["D2:I2"].Value = "Danh sách các sách chưa được trả";

            sql = "SELECT b.Mathue, a.Masach, a.Tensach, c.Ngaythue, b.Datra  FROM tblSach a, tblCTHDThue b, tblHDThue c WHERE b.Masach = a.Masach AND b.Mathue = c.Mathue AND MONTH(Ngaythue) = "+txtthang.Text+" AND YEAR(Ngaythue) = "+txtnam.Text+" AND b.Datra LIKE N'Chưa'";
            tblDS = Funtions.GetDataToTable(sql);

            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Mã thuê";
            exRange.Range["C11:C11"].Value = "Mã sách";
            exRange.Range["D11:D11"].Value = "Tên sách";
            exRange.Range["E11:E11"].Value = "Ngày";
            exRange.Range["E11:E11"].ColumnWidth = 20;


            for (hang = 0; hang < tblDS.Rows.Count; hang++)
            {
                // Điền số thứ tự vào cột
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < tblDS.Columns.Count; cot++)
                {
                    // Điền thông tin hàng từ cột 2, dòng 12
                    exSheet.Cells[cot + 2][hang + 12] = tblDS.Rows[hang][cot].ToString();
                }
            }

            exRange = exSheet.Cells[4][hang + 17];
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = DateTime.Now;
            exRange.Range["A1:C1"].Value = "Chùa Bộc, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            
            exSheet.Name = "1";
            exApp.Visible = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
