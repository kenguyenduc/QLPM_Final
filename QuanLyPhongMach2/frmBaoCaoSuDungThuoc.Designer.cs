namespace QuanLyPhongMach2
{
    partial class frmBaoCaoSuDungThuoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCaoSuDungThuoc));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxThang = new System.Windows.Forms.ComboBox();
            this.numNam = new System.Windows.Forms.NumericUpDown();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.label_lastday = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_firstday = new System.Windows.Forms.Label();
            this.grbBaoCaoSuDungThuoc = new System.Windows.Forms.GroupBox();
            this.dgvDSThuoc = new System.Windows.Forms.DataGridView();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).BeginInit();
            this.grbBaoCaoSuDungThuoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSThuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblThongBao);
            this.panel1.Controls.Add(this.cbxThang);
            this.panel1.Controls.Add(this.numNam);
            this.panel1.Controls.Add(this.btnXemBaoCao);
            this.panel1.Controls.Add(this.label_lastday);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label_firstday);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 165);
            this.panel1.TabIndex = 3;
            // 
            // cbxThang
            // 
            this.cbxThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.numNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemBaoCao.Location = new System.Drawing.Point(460, 70);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(130, 28);
            this.btnXemBaoCao.TabIndex = 3;
            this.btnXemBaoCao.Text = "Xem báo cáo";
            this.btnXemBaoCao.UseVisualStyleBackColor = true;
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            // 
            // label_lastday
            // 
            this.label_lastday.AutoSize = true;
            this.label_lastday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.label2.Location = new System.Drawing.Point(168, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(396, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "BÁO CÁO SỬ DỤNG THUỐC";
            // 
            // label_firstday
            // 
            this.label_firstday.AutoSize = true;
            this.label_firstday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_firstday.Location = new System.Drawing.Point(130, 72);
            this.label_firstday.Name = "label_firstday";
            this.label_firstday.Size = new System.Drawing.Size(54, 20);
            this.label_firstday.TabIndex = 0;
            this.label_firstday.Text = "Tháng";
            // 
            // grbBaoCaoSuDungThuoc
            // 
            this.grbBaoCaoSuDungThuoc.Controls.Add(this.dgvDSThuoc);
            this.grbBaoCaoSuDungThuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbBaoCaoSuDungThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBaoCaoSuDungThuoc.Location = new System.Drawing.Point(0, 165);
            this.grbBaoCaoSuDungThuoc.Name = "grbBaoCaoSuDungThuoc";
            this.grbBaoCaoSuDungThuoc.Size = new System.Drawing.Size(744, 296);
            this.grbBaoCaoSuDungThuoc.TabIndex = 4;
            this.grbBaoCaoSuDungThuoc.TabStop = false;
            this.grbBaoCaoSuDungThuoc.Text = "Danh sách thuốc sử dụng";
            // 
            // dgvDSThuoc
            // 
            this.dgvDSThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSThuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDSThuoc.Location = new System.Drawing.Point(3, 22);
            this.dgvDSThuoc.Name = "dgvDSThuoc";
            this.dgvDSThuoc.ReadOnly = true;
            this.dgvDSThuoc.Size = new System.Drawing.Size(738, 271);
            this.dgvDSThuoc.TabIndex = 1;
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongBao.ForeColor = System.Drawing.Color.Red;
            this.lblThongBao.Location = new System.Drawing.Point(297, 122);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(14, 20);
            this.lblThongBao.TabIndex = 12;
            this.lblThongBao.Text = "|";
            // 
            // frmBaoCaoSuDungThuoc
            // 
            this.AcceptButton = this.btnXemBaoCao;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(744, 461);
            this.Controls.Add(this.grbBaoCaoSuDungThuoc);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBaoCaoSuDungThuoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Báo cáo sử dụng thuốc";
            this.Load += new System.EventHandler(this.frmBaoCaoThuoc_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).EndInit();
            this.grbBaoCaoSuDungThuoc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSThuoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numNam;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.Label label_lastday;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_firstday;
        private System.Windows.Forms.GroupBox grbBaoCaoSuDungThuoc;
        private System.Windows.Forms.DataGridView dgvDSThuoc;
        private System.Windows.Forms.ComboBox cbxThang;
        private System.Windows.Forms.Label lblThongBao;
    }
}