using DevExpress.XtraReports.UI;
using QuanLyPhongMach2.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongMach2
{
    public partial class frmBaoCaoDoanhThuTheoThang : Form
    {
        public frmBaoCaoDoanhThuTheoThang()
        {
            InitializeComponent();
            lblThongBao.Text = "";
        }

        int thang = DateTime.Now.Month;
        int nam = DateTime.Now.Year;

        //Hàm LoadData để load lại dữ liệu khi có sự thay đổi
        public void LoadData()
        {

            cbxThang.Text = thang.ToString();
            numNam.Value = nam;
            dgvDoanhThu.DataSource = BaoCaoDoanhThu.LayDuLieu(thang, nam);

            dgvDoanhThu.Columns["NgayKham"].HeaderText = "Ngày";
            dgvDoanhThu.Columns["SoBN"].HeaderText = "Số bệnh nhân";
            dgvDoanhThu.Columns["DoanhThu"].HeaderText = "Doanh thu";

            dgvDoanhThu.Columns["NgayKham"].Width = 200;
            dgvDoanhThu.Columns["SoBN"].Width = 150;
            dgvDoanhThu.Columns["DoanhThu"].Width = 200;
        }
        //Load form
        private void frmBCDoanhThuTheoNgay_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cbxThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            thang = int.Parse(cbxThang.Text);
            LoadData();
        }

        private void numNam_ValueChanged(object sender, EventArgs e)
        {
            nam = (int)numNam.Value;
            LoadData();
        }

        private void bttXemBaoCao_Click(object sender, EventArgs e)
        {
            var tb = new HideNotifications();
            cbxThang.Text = thang.ToString();
            numNam.Value = nam;
            if (nam <= DateTime.Now.Year) {
                if (thang <= DateTime.Now.Month)
                {
                    rptBaoCaoDoanhThuTheoNgay report = new rptBaoCaoDoanhThuTheoNgay();
                    report.DataSource = BaoCaoDoanhThu.LayDuLieu(thang, nam);
                    report.BinData();
                    ReportPrintTool tool = new ReportPrintTool(report);
                    report.ShowPreviewDialog();
                }
                else
                {
                    lblThongBao.ForeColor = Color.Red;
                    lblThongBao.Text ="Tháng không tồn tại";
                    tb.stt(lblThongBao);
                }
            }
            else
            {

                lblThongBao.ForeColor = Color.Red;
                lblThongBao.Text = "Năm không tồn tại";
                tb.stt(lblThongBao);
                numNam.Focus();
            }
        }


        #region UNIT TEST
        public string Report(int month , int year)
        {
            if (year <= DateTime.Now.Year)
            {
                if (month <= DateTime.Now.Month)
                {
                    return "successed";
                }
                else
                    return "failed";
            }
            else
                return "failed";
        }
        #endregion

        private void numNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsNumber(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }
    }
}
