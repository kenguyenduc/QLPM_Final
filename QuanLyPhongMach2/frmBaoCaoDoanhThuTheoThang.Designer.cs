namespace QuanLyPhongMach2
{
    partial class frmBaoCaoDoanhThuTheoThang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCaoDoanhThuTheoThang));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxThang = new System.Windows.Forms.ComboBox();
            this.numNam = new System.Windows.Forms.NumericUpDown();
            this.bttXemBaoCao = new System.Windows.Forms.Button();
            this.label_lastday = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_firstday = new System.Windows.Forms.Label();
            this.grbDoanhThu = new System.Windows.Forms.GroupBox();
            this.dgvDoanhThu = new System.Windows.Forms.DataGridView();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).BeginInit();
            this.grbDoanhThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblThongBao);
            this.panel1.Controls.Add(this.cbxThang);
            this.panel1.Controls.Add(this.numNam);
            this.panel1.Controls.Add(this.bttXemBaoCao);
            this.panel1.Controls.Add(this.label_lastday);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label_firstday);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 165);
            this.panel1.TabIndex = 1;
            // 
            // cbxThang
            // 
            this.cbxThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxThang.FormattingEnabled = true;
            this.cbxThang.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbxThang.Location = new System.Drawing.Point(190, 68);
            this.cbxThang.Name = "cbxThang";
            this.cbxThang.Size = new System.Drawing.Size(54, 28);
            this.cbxThang.TabIndex = 1;
            this.cbxThang.SelectedIndexChanged += new System.EventHandler(this.cbxThang_SelectedIndexChanged);
            // 
            // numNam
            // 
            this.numNam.Location = new System.Drawing.Point(337, 70);
            this.numNam.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numNam.Minimum = new decimal(new int[] {
            2017,
            0,
            0,
            0});
            this.numNam.Name = "numNam";
            this.numNam.Size = new System.Drawing.Size(78, 26);
            this.numNam.TabIndex = 2;
            this.numNam.Value = new decimal(new int[] {
            2019,
            0,
            0,
            0});
            this.numNam.ValueChanged += new System.EventHandler(this.numNam_ValueChanged);
            this.numNam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numNam_KeyPress);
            // 
            // bttXemBaoCao
            // 
            this.bttXemBaoCao.Location = new System.Drawing.Point(460, 70);
            this.bttXemBaoCao.Name = "bttXemBaoCao";
            this.bttXemBaoCao.Size = new System.Drawing.Size(130, 28);
            this.bttXemBaoCao.TabIndex = 3;
            this.bttXemBaoCao.Text = "Xem báo cáo";
            this.bttXemBaoCao.UseVisualStyleBackColor = true;
            this.bttXemBaoCao.Click += new System.EventHandler(this.bttXemBaoCao_Click);
            // 
            // label_lastday
            // 
            this.label_lastday.AutoSize = true;
            this.label_lastday.Location = new System.Drawing.Point(283, 73);
            this.label_lastday.Name = "label_lastday";
            this.label_lastday.Size = new System.Drawing.Size(42, 20);
            this.label_lastday.TabIndex = 2;
            this.label_lastday.Text = "Năm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(152, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(324, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "BÁO CÁO DOANH THU";
            // 
            // label_firstday
            // 
            this.label_firstday.AutoSize = true;
            this.label_firstday.Location = new System.Drawing.Point(130, 72);
            this.label_firstday.Name = "label_firstday";
            this.label_firstday.Size = new System.Drawing.Size(54, 20);
            this.label_firstday.TabIndex = 0;
            this.label_firstday.Text = "Tháng";
            // 
            // grbDoanhThu
            // 
            this.grbDoanhThu.Controls.Add(this.dgvDoanhThu);
            this.grbDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDoanhThu.Location = new System.Drawing.Point(0, 165);
            this.grbDoanhThu.Name = "grbDoanhThu";
            this.grbDoanhThu.Size = new System.Drawing.Size(744, 296);
            this.grbDoanhThu.TabIndex = 2;
            this.grbDoanhThu.TabStop = false;
            this.grbDoanhThu.Text = "Doanh thu  ";
            // 
            // dgvDoanhThu
            // 
            this.dgvDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDoanhThu.Location = new System.Drawing.Point(3, 22);
            this.dgvDoanhThu.Name = "dgvDoanhThu";
            this.dgvDoanhThu.ReadOnly = true;
            this.dgvDoanhThu.Size = new System.Drawing.Size(738, 271);
            this.dgvDoanhThu.TabIndex = 0;
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.ForeColor = System.Drawing.Color.Red;
            this.lblThongBao.Location = new System.Drawing.Point(297, 122);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(14, 20);
            this.lblThongBao.TabIndex = 11;
            this.lblThongBao.Text = "|";
            // 
            // frmBaoCaoDoanhThuTheoThang
            // 
            this.AcceptButton = this.bttXemBaoCao;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(744, 461);
            this.Controls.Add(this.grbDoanhThu);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBaoCaoDoanhThuTheoThang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Báo cáo doanh thu";
            this.Load += new System.EventHandler(this.frmBCDoanhThuTheoNgay_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).EndInit();
            this.grbDoanhThu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bttXemBaoCao;
        private System.Windows.Forms.Label label_lastday;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_firstday;
        private System.Windows.Forms.NumericUpDown numNam;
        private System.Windows.Forms.GroupBox grbDoanhThu;
        private System.Windows.Forms.DataGridView dgvDoanhThu;
        private System.Windows.Forms.ComboBox cbxThang;
        private System.Windows.Forms.Label lblThongBao;
    }
}