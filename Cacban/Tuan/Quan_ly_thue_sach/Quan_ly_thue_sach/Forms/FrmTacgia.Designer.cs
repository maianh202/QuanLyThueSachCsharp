namespace Quan_ly_thue_sach.Forms
{
    partial class FrmTacgia
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTacgia));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboGT = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtdiachi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txttentg = new System.Windows.Forms.TextBox();
            this.txtmatg = new System.Windows.Forms.TextBox();
            this.data_GridDSNV = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picDong = new System.Windows.Forms.Button();
            this.picBoqua = new System.Windows.Forms.Button();
            this.picLuu = new System.Windows.Forms.Button();
            this.picSua = new System.Windows.Forms.Button();
            this.picXoa = new System.Windows.Forms.Button();
            this.picThem = new System.Windows.Forms.Button();
            this.mskngaysinh = new System.Windows.Forms.MaskedTextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_GridDSNV)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Linen;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(61, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(506, 69);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh sách tác giả";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.NavajoWhite;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(647, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 473);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.NavajoWhite;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.groupBox1.Controls.Add(this.mskngaysinh);
            this.groupBox1.Controls.Add(this.cboGT);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtdiachi);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txttentg);
            this.groupBox1.Controls.Add(this.txtmatg);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox1.Location = new System.Drawing.Point(26, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(501, 429);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chi tiết";
            // 
            // cboGT
            // 
            this.cboGT.AutoSize = true;
            this.cboGT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboGT.Location = new System.Drawing.Point(80, 269);
            this.cboGT.Name = "cboGT";
            this.cboGT.Size = new System.Drawing.Size(98, 36);
            this.cboGT.TabIndex = 13;
            this.cboGT.Text = "Nam";
            this.cboGT.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label12.Location = new System.Drawing.Point(189, 334);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 32);
            this.label12.TabIndex = 10;
            this.label12.Text = "Địa chỉ";
            // 
            // txtdiachi
            // 
            this.txtdiachi.BackColor = System.Drawing.Color.White;
            this.txtdiachi.Location = new System.Drawing.Point(95, 369);
            this.txtdiachi.Name = "txtdiachi";
            this.txtdiachi.Size = new System.Drawing.Size(305, 38);
            this.txtdiachi.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(282, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 32);
            this.label5.TabIndex = 6;
            this.label5.Text = "Ngày sinh";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(64, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 32);
            this.label4.TabIndex = 6;
            this.label4.Text = "Giới tính";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(280, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tên tác giả";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(46, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mã tác giả";
            // 
            // txttentg
            // 
            this.txttentg.BackColor = System.Drawing.Color.White;
            this.txttentg.Location = new System.Drawing.Point(286, 120);
            this.txttentg.Name = "txttentg";
            this.txttentg.Size = new System.Drawing.Size(182, 38);
            this.txttentg.TabIndex = 3;
            // 
            // txtmatg
            // 
            this.txtmatg.BackColor = System.Drawing.Color.White;
            this.txtmatg.Location = new System.Drawing.Point(51, 120);
            this.txtmatg.Name = "txtmatg";
            this.txtmatg.Size = new System.Drawing.Size(161, 38);
            this.txtmatg.TabIndex = 0;
            // 
            // data_GridDSNV
            // 
            this.data_GridDSNV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.data_GridDSNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_GridDSNV.Location = new System.Drawing.Point(12, 115);
            this.data_GridDSNV.Name = "data_GridDSNV";
            this.data_GridDSNV.RowHeadersWidth = 51;
            this.data_GridDSNV.RowTemplate.Height = 24;
            this.data_GridDSNV.Size = new System.Drawing.Size(629, 311);
            this.data_GridDSNV.TabIndex = 2;
            this.data_GridDSNV.Click += new System.EventHandler(this.data_GridDSNV_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Controls.Add(this.picDong);
            this.panel2.Controls.Add(this.picBoqua);
            this.panel2.Controls.Add(this.picLuu);
            this.panel2.Controls.Add(this.picSua);
            this.panel2.Controls.Add(this.picXoa);
            this.panel2.Controls.Add(this.picThem);
            this.panel2.Location = new System.Drawing.Point(12, 435);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(629, 100);
            this.panel2.TabIndex = 3;
            // 
            // picDong
            // 
            this.picDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.picDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.picDong.Location = new System.Drawing.Point(417, 27);
            this.picDong.Name = "picDong";
            this.picDong.Size = new System.Drawing.Size(94, 54);
            this.picDong.TabIndex = 19;
            this.picDong.Text = "Đóng";
            this.picDong.UseVisualStyleBackColor = false;
            this.picDong.Click += new System.EventHandler(this.picDong_Click_1);
            // 
            // picBoqua
            // 
            this.picBoqua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.picBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.picBoqua.Location = new System.Drawing.Point(517, 27);
            this.picBoqua.Name = "picBoqua";
            this.picBoqua.Size = new System.Drawing.Size(109, 54);
            this.picBoqua.TabIndex = 18;
            this.picBoqua.Text = "Bỏ qua";
            this.picBoqua.UseVisualStyleBackColor = false;
            this.picBoqua.Click += new System.EventHandler(this.picBoqua_Click_1);
            // 
            // picLuu
            // 
            this.picLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.picLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.picLuu.Location = new System.Drawing.Point(313, 27);
            this.picLuu.Name = "picLuu";
            this.picLuu.Size = new System.Drawing.Size(98, 54);
            this.picLuu.TabIndex = 17;
            this.picLuu.Text = "Lưu";
            this.picLuu.UseVisualStyleBackColor = false;
            this.picLuu.Click += new System.EventHandler(this.picLuu_Click);
            // 
            // picSua
            // 
            this.picSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.picSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.picSua.Location = new System.Drawing.Point(217, 27);
            this.picSua.Name = "picSua";
            this.picSua.Size = new System.Drawing.Size(90, 54);
            this.picSua.TabIndex = 16;
            this.picSua.Text = "Sửa";
            this.picSua.UseVisualStyleBackColor = false;
            this.picSua.Click += new System.EventHandler(this.picSua_Click);
            // 
            // picXoa
            // 
            this.picXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.picXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.picXoa.Location = new System.Drawing.Point(116, 27);
            this.picXoa.Name = "picXoa";
            this.picXoa.Size = new System.Drawing.Size(95, 54);
            this.picXoa.TabIndex = 15;
            this.picXoa.Text = "Xóa";
            this.picXoa.UseVisualStyleBackColor = false;
            this.picXoa.Click += new System.EventHandler(this.picXoa_Click_1);
            // 
            // picThem
            // 
            this.picThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.picThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.picThem.Location = new System.Drawing.Point(14, 27);
            this.picThem.Name = "picThem";
            this.picThem.Size = new System.Drawing.Size(96, 54);
            this.picThem.TabIndex = 14;
            this.picThem.Text = "Thêm";
            this.picThem.UseVisualStyleBackColor = false;
            this.picThem.Click += new System.EventHandler(this.picThem_Click_1);
            // 
            // mskngaysinh
            // 
            this.mskngaysinh.Location = new System.Drawing.Point(286, 265);
            this.mskngaysinh.Mask = "00/00/0000";
            this.mskngaysinh.Name = "mskngaysinh";
            this.mskngaysinh.Size = new System.Drawing.Size(184, 38);
            this.mskngaysinh.TabIndex = 15;
            this.mskngaysinh.ValidatingType = typeof(System.DateTime);
            // 
            // FrmTacgia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1204, 547);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.data_GridDSNV);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "FrmTacgia";
            this.Text = "FrmTacgia";
            this.Load += new System.EventHandler(this.FrmTacgia_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_GridDSNV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView data_GridDSNV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtmatg;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txttentg;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtdiachi;
        private System.Windows.Forms.Button picDong;
        private System.Windows.Forms.Button picBoqua;
        private System.Windows.Forms.Button picLuu;
        private System.Windows.Forms.Button picSua;
        private System.Windows.Forms.Button picXoa;
        private System.Windows.Forms.Button picThem;
        private System.Windows.Forms.CheckBox cboGT;
        private System.Windows.Forms.MaskedTextBox mskngaysinh;
    }
}