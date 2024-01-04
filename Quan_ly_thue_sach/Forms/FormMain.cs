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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            timer1.Start();
            Funtions.KetNoi();
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = DateTime.Now.ToString("T");
            label8.Text = DateTime.Now.ToString("D");
        }

        private void picThoat_Click(object sender, EventArgs e)
        {
            DialogResult dlg = new DialogResult();
            dlg = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnAn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanvien f = new frmNhanvien();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Forms.frmHDThuesach f = new frmHDThuesach();
            f.ShowDialog();
        }

        private void btnKhach_Click(object sender, EventArgs e)
        {
            Forms.FrmKhachHang f = new FrmKhachHang();
            f.ShowDialog();
        }

        private void btnSach_Click(object sender, EventArgs e)
        {
            Forms.frmSachTruyen f = new frmSachTruyen();
            f.ShowDialog();
        }

        private void btnNXB_Click(object sender, EventArgs e)
        {
            Forms.frmNXB f = new frmNXB();
            f.ShowDialog();
        }

        private void btnTacgia_Click(object sender, EventArgs e)
        {
            Forms.FrmTacgia f = new FrmTacgia();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Forms.FrmTraSach f = new FrmTraSach();
            f.ShowDialog();
        }

        private void tìmKháchHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Tuan.frmtimkiemsachtruyen f = new Tuan.frmtimkiemsachtruyen();
            f.ShowDialog();
        }

        private void tìmSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmTimKiemNhanVien f = new frmTimKiemNhanVien();
            f.ShowDialog();
        }

        private void sáchChưaĐượcTrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Tuan.frmBaocaosach f = new Tuan.frmBaocaosach();
            f.ShowDialog();
        }

        private void doanhThuTheoLựaChọnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormDoanhthu f = new FormDoanhthu();
            f.ShowDialog();
        }

        private void top5ThuêChạyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmBaocaotop5doanhthu f = new FrmBaocaotop5doanhthu();
            f.ShowDialog();
        }
    }
}
