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
    public partial class FrmBaocaotop5doanhthu : Form
    {
        public FrmBaocaotop5doanhthu()
        {
            InitializeComponent();
        }
        DataTable tblbcdt;
        private void FrmBaocaotop5doanhthu_Load(object sender, EventArgs e)
        {
            ResetValues();
            dgridbaocao.DataSource = null;
            btnin.Enabled = false;
            btntimlai.Enabled = false;
        }
        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txtnam.Focus();
        }

        private void btnhienthi_Click(object sender, EventArgs e)
        {

            if (txtnam.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập năm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtnam.Focus();
                return;
            }
            string sql;
            sql = "select top 5 a.Masach,c.Tensach, sum(a.Thanhtien) as DoanhThu FROM tblCTHDTra as a, tblHDTra as b,tblSach as c WHERE  a.Matra = b.Matra and a.Masach=c.Masach and YEAR(b.Ngaytra) = '" + txtnam.Text.Trim() +"'  group by a.Masach,c.Tensach order by DoanhThu desc";
            tblbcdt = Classes.Funtions.GetDataToTable(sql);
            if (tblbcdt.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
                MessageBox.Show("Có " + tblbcdt.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Load_DatagridView();
        }
        private void Load_DatagridView()
        {
            dgridbaocao.DataSource = tblbcdt;
            dgridbaocao.Columns[0].HeaderText = "Mã sách";
            dgridbaocao.Columns[1].HeaderText = "Tên sách";
            dgridbaocao.Columns[2].HeaderText = "Doanh Thu";
            dgridbaocao.Columns[0].Width = 100;
            dgridbaocao.Columns[1].Width = 100;
            dgridbaocao.Columns[2].Width = 100;
            dgridbaocao.AllowUserToAddRows = false;
            dgridbaocao.EditMode = DataGridViewEditMode.EditProgrammatically;
            btntimlai.Enabled = true;
            btnin.Enabled = true;
        }

        private void btntimlai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgridbaocao.DataSource = null;
            btntimlai.Enabled = false;
            btnin.Enabled = false;

        }

        private void btnin_Click(object sender, EventArgs e)
        {
            if (txtnam.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập năm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtnam.Focus();
                return;
            }
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook;
            COMExcel.Worksheet exSheet;
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable danhsach;

            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5;
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Cửa hàng cho thuê sách_MỌT NHÓM";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "12 Chùa Bộc, Đống Đa, Hà Nội";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: 0378588031";
            exRange.Range["D2:H2"].Font.Size = 15;
            exRange.Range["D2:H2"].Font.Bold = true;
            exRange.Range["D2:H2"].Font.ColorIndex = 3;
            exRange.Range["D2:H2"].MergeCells = true;
            exRange.Range["D2:H2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["D2:H2"].Value = "BÁO CÁO TOP 5 SẢN PHẨM ĐẠT DOANH THU CAO NHẤT";
            sql = "select top 5 a.Masach,c.Tensach, sum(a.Thanhtien) as DoanhThu FROM tblCTHDTra as a, tblHDTra as b,tblSach as c WHERE  a.Matra = b.Matra and a.Masach=c.Masach and (YEAR(b.Ngaytra) = '" + txtnam.Text.Trim() + "') group by a.Masach,c.Tensach order by DoanhThu desc";
            danhsach = Classes.Funtions.GetDataToTable(sql);
            exRange.Range["D5:G5"].Font.Bold = true;
            exRange.Range["D5:G5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["D5:D5"].ColumnWidth = 12;
            exRange.Range["E5:E5"].ColumnWidth = 11;
            exRange.Range["F5:F5"].ColumnWidth = 23;
            exRange.Range["G5:G5"].ColumnWidth = 23;    
            exRange.Range["D5:D5"].Value = "STT";
            exRange.Range["E5:E5"].Value = "Mã sách";
            exRange.Range["F5:F5"].Value = "Tên sách";
            exRange.Range["G5:G5"].Value = "Doanh Thu";
          
            for (hang = 0; hang < danhsach.Rows.Count; hang++)
            {
                exSheet.Cells[4][hang + 6] = hang + 1;
                for (cot = 0; cot < tblbcdt.Columns.Count; cot++)
                {

                    exSheet.Cells[cot + 5][hang + 6] = tblbcdt.Rows[hang][cot].ToString();
                    if (cot == 3) exSheet.Cells[cot + 5][hang + 6] = tblbcdt.Rows[hang][cot].ToString();
                }
            }

            exRange = exSheet.Cells[4][hang + 8];
            exRange.Range["D1:F1"].MergeCells = true;
            exRange.Range["D1:F1"].Font.Italic = true;
            exRange.Range["D1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["D1:F1"].Value = "Hà Nội, Ngày " + DateTime.Now.ToShortDateString();
            exRange = exSheet.Cells[4][hang + 8];
            exRange.Range["D1:F1"].MergeCells = true;
        //    exRange.Range["D1:F1"].Font.Bold = true;
            exRange.Range["D1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["D1:F1"].Value = "Hà Nội, Ngày " + DateTime.Now.ToShortDateString();
            exSheet.Name = "Báo cáo";
            exApp.Visible = true;

        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
