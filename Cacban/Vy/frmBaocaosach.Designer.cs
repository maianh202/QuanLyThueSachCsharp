namespace Quan_ly_thue_sach.Forms.Tuan
{
    partial class frmBaocaosach
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaocaosach));
            this.label1 = new System.Windows.Forms.Label();
            this.dgr = new System.Windows.Forms.DataGridView();
            this.btnbaocao = new System.Windows.Forms.Button();
            this.btnboqua = new System.Windows.Forms.Button();
            this.btnin = new System.Windows.Forms.Button();
            this.btndong = new System.Windows.Forms.Button();
            this.txtthang = new System.Windows.Forms.TextBox();
            this.txtnam = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgr)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(238, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(728, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh sách sách được mượn chưa trả";
            // 
            // dgr
            // 
            this.dgr.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgr.Location = new System.Drawing.Point(127, 163);
            this.dgr.Name = "dgr";
            this.dgr.RowHeadersWidth = 51;
            this.dgr.RowTemplate.Height = 24;
            this.dgr.Size = new System.Drawing.Size(952, 305);
            this.dgr.TabIndex = 1;
            this.dgr.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgr_CellContentClick);
            // 
            // btnbaocao
            // 
            this.btnbaocao.BackColor = System.Drawing.Color.LightSalmon;
            this.btnbaocao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbaocao.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnbaocao.Location = new System.Drawing.Point(255, 476);
            this.btnbaocao.Name = "btnbaocao";
            this.btnbaocao.Size = new System.Drawing.Size(124, 42);
            this.btnbaocao.TabIndex = 2;
            this.btnbaocao.Text = "Báo cáo";
            this.btnbaocao.UseVisualStyleBackColor = false;
            this.btnbaocao.Click += new System.EventHandler(this.btnbaocao_Click);
            // 
            // btnboqua
            // 
            this.btnboqua.BackColor = System.Drawing.Color.LightSalmon;
            this.btnboqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnboqua.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnboqua.Location = new System.Drawing.Point(446, 477);
            this.btnboqua.Name = "btnboqua";
            this.btnboqua.Size = new System.Drawing.Size(124, 42);
            this.btnboqua.TabIndex = 3;
            this.btnboqua.Text = "Bỏ qua";
            this.btnboqua.UseVisualStyleBackColor = false;
            this.btnboqua.Click += new System.EventHandler(this.btnboqua_Click);
            // 
            // btnin
            // 
            this.btnin.BackColor = System.Drawing.Color.LightSalmon;
            this.btnin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnin.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnin.Location = new System.Drawing.Point(624, 477);
            this.btnin.Name = "btnin";
            this.btnin.Size = new System.Drawing.Size(124, 42);
            this.btnin.TabIndex = 4;
            this.btnin.Text = "In báo cáo";
            this.btnin.UseVisualStyleBackColor = false;
            this.btnin.Click += new System.EventHandler(this.btnin_Click);
            // 
            // btndong
            // 
            this.btndong.BackColor = System.Drawing.Color.LightSalmon;
            this.btndong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndong.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btndong.Location = new System.Drawing.Point(814, 477);
            this.btndong.Name = "btndong";
            this.btndong.Size = new System.Drawing.Size(124, 42);
            this.btndong.TabIndex = 5;
            this.btndong.Text = "Đóng";
            this.btndong.UseVisualStyleBackColor = false;
            this.btndong.Click += new System.EventHandler(this.btndong_Click);
            // 
            // txtthang
            // 
            this.txtthang.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtthang.Location = new System.Drawing.Point(287, 118);
            this.txtthang.Multiline = true;
            this.txtthang.Name = "txtthang";
            this.txtthang.Size = new System.Drawing.Size(206, 31);
            this.txtthang.TabIndex = 6;
            this.txtthang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtnam
            // 
            this.txtnam.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnam.Location = new System.Drawing.Point(781, 119);
            this.txtnam.Multiline = true;
            this.txtnam.Name = "txtnam";
            this.txtnam.Size = new System.Drawing.Size(206, 31);
            this.txtnam.TabIndex = 7;
            this.txtnam.Text = "\r\n";
            this.txtnam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Brown;
            this.label2.Location = new System.Drawing.Point(191, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 29);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tháng";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Brown;
            this.label3.Location = new System.Drawing.Point(706, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 29);
            this.label3.TabIndex = 9;
            this.label3.Text = "Năm";
            // 
            // frmBaocaosach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1173, 529);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtnam);
            this.Controls.Add(this.txtthang);
            this.Controls.Add(this.btndong);
            this.Controls.Add(this.btnin);
            this.Controls.Add(this.btnboqua);
            this.Controls.Add(this.btnbaocao);
            this.Controls.Add(this.dgr);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "frmBaocaosach";
            this.Text = "frmBaocaosach";
            this.Load += new System.EventHandler(this.frmBaocaosach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgr;
        private System.Windows.Forms.Button btnbaocao;
        private System.Windows.Forms.Button btnboqua;
        private System.Windows.Forms.Button btnin;
        private System.Windows.Forms.Button btndong;
        private System.Windows.Forms.TextBox txtthang;
        private System.Windows.Forms.TextBox txtnam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}