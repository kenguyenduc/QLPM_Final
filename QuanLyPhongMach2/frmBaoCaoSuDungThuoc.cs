using DevExpress.XtraReports.UI;
using QuanLyPhongMach2.DAO;
using QuanLyPhongMach2.DTO;
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
    public partial class frmBaoCaoSuDungThuoc : Form
    {
        public frmBaoCaoSuDungThuoc()
        {
            InitializeComponent();
            lblThongBao.Text = "";
        }

        //Thang, nam mặc định khi load lên form là tháng, năm hiện tại
        int thang = DateTime.Now.Month;
        int nam = DateTime.Now.Year;

        //Hàm LoadData để load lại dữ liệu khi có sự thay đổi
        public void LoatData()
        {
            cbxThang.Text = thang.ToString();
            numNam.Value = nam;
            dgvDSThuoc.DataSource = BaoCaoThuoc.LayDuLieu(thang, nam);

            dgvDSThuoc.Columns["TenThuoc"].HeaderText = "Thuốc";
            dgvDSThuoc.Columns["DonVi"].HeaderText = "Đơn vị tính";
            dgvDSThuoc.Columns["TongSoLuong"].HeaderText = "Số lượng";
            dgvDSThuoc.Columns["SoLanDung"].HeaderText = "Số lần dùng";

            dgvDSThuoc.Columns["TenThuoc"].Width = 200;
            dgvDSThuoc.Columns["DonVi"].Width = 80;
            dgvDSThuoc.Columns["TongSoLuong"].Width = 200;
            dgvDSThuoc.Columns["SoLanDung"].Width = 200;
        }

        private void frmBaoCaoThuoc_Load(object sender, EventArgs e)
        {
            LoatData();
        }

        private void cbxThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            thang = int.Parse(cbxThang.Text);
            LoatData();
        }

        private void numNam_ValueChanged(object sender, EventArgs e)
        {
            nam = (int)numNam.Value;
            LoatData();
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            var tb = new HideNotifications();
            cbxThang.Text = thang.ToString();
            numNam.Value = nam;
 

            if (nam <= DateTime.Now.Year)
            {
                if (thang <= DateTime.Now.Month)
                {
                    rptBaoCaoSuDungThuoc report = new rptBaoCaoSuDungThuoc();
                    report.DataSource = BaoCaoThuoc.LayDuLieu(thang, nam);
                    report.BinData();
                    ReportPrintTool tool = new ReportPrintTool(report);
                    report.ShowPreviewDialog();
                }
                else
                {
                    lblThongBao.ForeColor = Color.Red;
                    lblThongBao.Text = "Tháng không tồn tại";
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
        public string Report(int month, int year)
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
