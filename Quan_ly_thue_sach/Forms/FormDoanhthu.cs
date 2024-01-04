using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;
using Quan_ly_thue_sach.Classes;

namespace Quan_ly_thue_sach.Forms
{
    public partial class FormDoanhthu : Form
    {
        public FormDoanhthu()
        {
            InitializeComponent();
        }

        DataTable tblTimkiem;

        private void FormDoanhthu_Load(object sender, EventArgs e)
        {
            ResetValues();
            data_GV.DataSource = null;
            UpdateYear();
        }

        private void ResetValues()
        {
            foreach(RadioButton rdo in groupBox1.Controls)
            {
                rdo.Checked = false;
            }

            foreach(Control cbo in groupBox2.Controls)
            {
                if (cbo is ComboBox)
                {
                    ComboBox cbo1 = (ComboBox)cbo;
                    cbo1.SelectedIndex = -1;
                    cbo1.Enabled = false;
                }
            }
            data_GV.DataSource = null;
            txtDT.Text = "";
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if (!rdoNam.Checked && !rdoQuy.Checked && !rdoThang.Checked)
            {
                MessageBox.Show("Hay chon mot tuy chon di!");
                return;
            }

            string sql;
            sql =  "SELECT * FROM tblHDTra WHERE 1=1 ";
            if (rdoThang.Checked)
            {
                if (cboThang.SelectedIndex == -1 || cboNam.SelectedIndex == -1)
                {
                    MessageBox.Show("Hay chon day du Thang va Nam!"); 
                    return;
                }

                sql = sql + " AND MONTH(Ngaytra) = " + cboThang.Text + " AND YEAR(Ngaytra) = " +cboNam.Text+ "";
            }
            
            if (rdoQuy.Checked)
            {
                if (cboQuy.SelectedIndex == -1 || cboNam.SelectedIndex == -1)
                {
                    MessageBox.Show("Hay chon day du Quy va Nam!");
                    return;
                }

                switch(cboQuy.SelectedIndex)
                {
                    case 0:
                        {
                            sql = sql + " AND MONTH(Ngaytra) BETWEEN 1 AND 3";
                            break;
                        }
                    case 1:
                        {
                            sql = sql + " AND MONTH(Ngaytra) BETWEEN 4 AND 6";
                            break;
                        }
                    case 2:
                        {
                            sql = sql + " AND MONTH(Ngaytra) BETWEEN 7 AND 9"; 
                            break;
                        }
                    case 3:
                        {
                            sql = sql + " AND MONTH(Ngaytra) BETWEEN 10 AND 12";
                            break;
                        }
                }
            }

            if (rdoNam.Checked)
            {
                if (cboNam.SelectedIndex == -1)
                {
                    MessageBox.Show("Ban chua chon nam");
                    return;
                }

                sql = sql + " AND YEAR(Ngaytra) = " + cboNam.Text + "";
            }


            sql = sql + " AND YEAR(Ngaytra) = " + cboNam.Text + "";
            tblTimkiem = Funtions.GetDataToTable(sql);

            if (tblTimkiem.Rows.Count == 0)
            {
                MessageBox.Show("Khong co ban ghi thoa man dieu kien");
                ResetValues();
            }
            else
            {
                MessageBox.Show("Co " + tblTimkiem.Rows.Count + " ban ghi thoa man");
                data_GV.DataSource = tblTimkiem;
                Load_DGV();
                UpdateReverage();
            }
        }


        private void Load_DGV()
        {
            string[] Header = new string[5] { "Ma tra", "Ma thue", "Ma NV", "Ngay tra", "Tong tien" };
            for (int i = 0; i < Header.Length; i++)
            {
                data_GV.Columns[i].HeaderText = Header[i];
            }
            data_GV.AllowUserToAddRows = false;
            data_GV.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnLamlai_Click(object sender, EventArgs e)
        {
            ResetValues();
            data_GV.DataSource = null;
        }

        private void rdoThang_CheckedChanged(object sender, EventArgs e)
        {
            cboThang.Enabled = true;
            cboNam.Enabled = true;
            cboQuy.Enabled = false;
        }

        private void rdoQuy_CheckedChanged(object sender, EventArgs e)
        {
            cboThang.Enabled = false;
            cboNam.Enabled = true;
            cboQuy.Enabled = true;
        }

        private void rdoNam_CheckedChanged(object sender, EventArgs e)
        {
            cboThang.Enabled = false;
            cboNam.Enabled = true;
            cboQuy.Enabled = false;
        }

        private void UpdateYear()
        {
            DataTable tblYEAR;
            string sql;
            sql = "SELECT YEAR(Ngaytra) FROM tblHDTra";
            tblYEAR = Funtions.GetDataToTable(sql);
            for (int i = 0; i < tblYEAR.Rows.Count; i++)
            {
                if (i == 0)
                {
                    cboNam.Items.Add(tblYEAR.Rows[i][0].ToString());
                }
                else
                {
                    for (int j = 0; j < cboNam.Items.Count; j++)
                    {
                        if (cboNam.Items[j].ToString() == tblYEAR.Rows[i][0].ToString())
                        {
                            return;
                        }
                        cboNam.Items.Add(tblYEAR.Rows[i][0].ToString());
                    }
                }
            }
            cboNam.Sorted = true;
        }

        private void UpdateReverage()
        {
            double tien = 0;
            for (int i = 0; i < tblTimkiem.Rows.Count; i++)
            {
                tien += Convert.ToDouble(tblTimkiem.Rows[i][4].ToString());
            }
            txtDT.Text = tien.ToString();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; // Excel 1 - n Workbook
            COMExcel.Worksheet exSheet; // Workbook 1 - n Worksheet
            COMExcel.Range exRange;

            string sql;
            int hang = 0, cot = 0;
            DataTable tblDT;
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
            string header;
            header = "Báo cáo Doanh thu ";
            if (rdoThang.Checked)
            {
                header += "tháng " + cboThang.Text + " năm " +cboNam.Text+ "";
            }
            if (rdoQuy.Checked)
            {
                header += "quý " + cboQuy.Text + " năm " + cboNam.Text + "";
            }
            if (rdoNam.Checked)
            {
                header += "năm  " + cboNam.Text + "";
            }
            exRange.Range["D2:I2"].Value = header;

            sql = "SELECT * FROM tblHDTra WHERE 1=1 ";
            if (rdoThang.Checked)
            {
                sql = sql + " AND MONTH(Ngaytra) = " + cboThang.Text + " AND YEAR(Ngaytra) = " + cboNam.Text + "";
            }

            if (rdoQuy.Checked)
            {
                switch (cboQuy.SelectedIndex)
                {
                    case 0:
                        {
                            sql = sql + " AND MONTH(Ngaytra) BETWEEN 1 AND 3";
                            break;
                        }
                    case 1:
                        {
                            sql = sql + " AND MONTH(Ngaytra) BETWEEN 4 AND 6";
                            break;
                        }
                    case 2:
                        {
                            sql = sql + " AND MONTH(Ngaytra) BETWEEN 7 AND 9";
                            break;
                        }
                    case 3:
                        {
                            sql = sql + " AND MONTH(Ngaytra) BETWEEN 10 AND 12";
                            break;
                        }
                }
            }

            if (rdoNam.Checked)
            {
                sql = sql + " AND YEAR(Ngaytra) = " + cboNam.Text + "";
            }
            tblDT = Funtions.GetDataToTable(sql);
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Mã trả";
            exRange.Range["C11:C11"].Value = "Mã thuê";
            exRange.Range["D11:D11"].Value = "Mã NV";
            exRange.Range["E11:E11"].Value = "Ngày trả";
            exRange.Range["E11:E11"].ColumnWidth = 20;
            exRange.Range["F11:F11"].Value = "Tổng tiền";
            for (hang = 0; hang < tblDT.Rows.Count; hang++)
            {
                // Điền số thứ tự vào cột
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < tblDT.Columns.Count; cot++)
                {
                    // Điền thông tin hàng từ cột 2, dòng 12
                    exSheet.Cells[cot + 2][hang + 12] = tblDT.Rows[hang][cot].ToString();
                }
            }
            int tmp;
            tmp = hang;

            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = txtDT.Text;

            exRange = exSheet.Cells[4][hang + 15];
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            string tien = txtDT.Text;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + Funtions.ChuyenSoSangChu(tien);

            exRange = exSheet.Cells[4][hang + 17];
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblDT.Rows[0][3]);
            exRange.Range["A1:C1"].Value = "Chùa Bộc, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;

            exSheet.Name = "1";
            exApp.Visible = true;
        }

    }
}
