namespace Quan_ly_thue_sach.Forms
{
    partial class FrmBaocaotop5doanhthu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBaocaotop5doanhthu));
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnhienthi = new System.Windows.Forms.Button();
            this.btndong = new System.Windows.Forms.Button();
            this.btnin = new System.Windows.Forms.Button();
            this.btntimlai = new System.Windows.Forms.Button();
            this.dgridbaocao = new System.Windows.Forms.DataGridView();
            this.txtnam = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgridbaocao)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Moccasin;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(69, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(873, 52);
            this.label4.TabIndex = 3;
            this.label4.Text = "TOP 5 SÁCH CÓ DOANH THU CAO NHẤT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.NavajoWhite;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Location = new System.Drawing.Point(323, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 32);
            this.label5.TabIndex = 4;
            this.label5.Text = "Năm";
            // 
            // btnhienthi
            // 
            this.btnhienthi.BackColor = System.Drawing.Color.LightCyan;
            this.btnhienthi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnhienthi.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnhienthi.Location = new System.Drawing.Point(177, 469);
            this.btnhienthi.Name = "btnhienthi";
            this.btnhienthi.Size = new System.Drawing.Size(115, 38);
            this.btnhienthi.TabIndex = 5;
            this.btnhienthi.Text = "Hiển thị";
            this.btnhienthi.UseVisualStyleBackColor = false;
            this.btnhienthi.Click += new System.EventHandler(this.btnhienthi_Click);
            // 
            // btndong
            // 
            this.btndong.BackColor = System.Drawing.Color.LightCyan;
            this.btndong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndong.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btndong.Location = new System.Drawing.Point(697, 469);
            this.btndong.Name = "btndong";
            this.btndong.Size = new System.Drawing.Size(89, 38);
            this.btndong.TabIndex = 6;
            this.btndong.Text = "Đóng";
            this.btndong.UseVisualStyleBackColor = false;
            this.btndong.Click += new System.EventHandler(this.btndong_Click);
            // 
            // btnin
            // 
            this.btnin.BackColor = System.Drawing.Color.LightCyan;
            this.btnin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnin.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnin.Location = new System.Drawing.Point(513, 469);
            this.btnin.Name = "btnin";
            this.btnin.Size = new System.Drawing.Size(135, 38);
            this.btnin.TabIndex = 7;
            this.btnin.Text = "In báo cáo";
            this.btnin.UseVisualStyleBackColor = false;
            this.btnin.Click += new System.EventHandler(this.btnin_Click);
            // 
            // btntimlai
            // 
            this.btntimlai.BackColor = System.Drawing.Color.LightCyan;
            this.btntimlai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntimlai.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btntimlai.Location = new System.Drawing.Point(347, 469);
            this.btntimlai.Name = "btntimlai";
            this.btntimlai.Size = new System.Drawing.Size(114, 38);
            this.btntimlai.TabIndex = 8;
            this.btntimlai.Text = "Tìm lại";
            this.btntimlai.UseVisualStyleBackColor = false;
            this.btntimlai.Click += new System.EventHandler(this.btntimlai_Click);
            // 
            // dgridbaocao
            // 
            this.dgridbaocao.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgridbaocao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridbaocao.Location = new System.Drawing.Point(102, 218);
            this.dgridbaocao.Name = "dgridbaocao";
            this.dgridbaocao.RowHeadersWidth = 51;
            this.dgridbaocao.RowTemplate.Height = 24;
            this.dgridbaocao.Size = new System.Drawing.Size(786, 222);
            this.dgridbaocao.TabIndex = 11;
            // 
            // txtnam
            // 
            this.txtnam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnam.Location = new System.Drawing.Point(422, 157);
            this.txtnam.Name = "txtnam";
            this.txtnam.Size = new System.Drawing.Size(177, 30);
            this.txtnam.TabIndex = 13;
            // 
            // FrmBaocaotop5doanhthu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(989, 558);
            this.Controls.Add(this.txtnam);
            this.Controls.Add(this.dgridbaocao);
            this.Controls.Add(this.btntimlai);
            this.Controls.Add(this.btnin);
            this.Controls.Add(this.btndong);
            this.Controls.Add(this.btnhienthi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Name = "FrmBaocaotop5doanhthu";
            this.Text = "FRmBaocaotop5doanhthu";
            this.Load += new System.EventHandler(this.FrmBaocaotop5doanhthu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgridbaocao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnhienthi;
        private System.Windows.Forms.Button btndong;
        private System.Windows.Forms.Button btnin;
        private System.Windows.Forms.Button btntimlai;
        private System.Windows.Forms.DataGridView dgridbaocao;
        private System.Windows.Forms.TextBox txtnam;
    }
}