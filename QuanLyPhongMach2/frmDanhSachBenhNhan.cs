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
    public partial class frmDanhSachBenhNhan : Form
    {
        public frmDanhSachBenhNhan()
        {
            InitializeComponent();

        }

        private void frmDanhSachBenhNhan_Load(object sender, EventArgs e)
        {
            lblThongBao.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var tb = new HideNotifications();
            if (txtHoTen.Text != "")
            {
                try
                {
                    dgvDSBenhNhan.DataSource = PhieuKham.DSKhamBenh(txtHoTen.Text);
                    if (dgvDSBenhNhan.RowCount != 0)
                    {
                        dgvDSBenhNhan.Columns["STT"].HeaderText = "STT";
                        dgvDSBenhNhan.Columns["HoTen"].HeaderText = "Họ & Tên";
                        dgvDSBenhNhan.Columns["NgayKham"].HeaderText = "Ngày khám";
                        dgvDSBenhNhan.Columns["LoaiBenh"].HeaderText = "Loại bệnh";
                        dgvDSBenhNhan.Columns["TrieuChung"].HeaderText = "Triệu chứng";

                        dgvDSBenhNhan.Columns["STT"].Width = 50;
                        dgvDSBenhNhan.Columns["HoTen"].Width = 150;
                        dgvDSBenhNhan.Columns["NgayKham"].Width = 150;
                        dgvDSBenhNhan.Columns["LoaiBenh"].Width = 200;
                        dgvDSBenhNhan.Columns["TrieuChung"].Width = 350;
                    }
                    else
                    {
                        lblThongBao.ForeColor = Color.Red;
                        lblThongBao.Text = "Không tìm thấy kết quả nào!";
                        tb.stt(lblThongBao);
                    }
                }
                catch
                {
                    MessageBox.Show("Tìm kiếm dữ liệu bị lỗi");
                }
            }
            else
            {
                lblThongBao.ForeColor = Color.Red;
                lblThongBao.Text = "Điền tên bệnh nhân";
                txtHoTen.Focus();
                tb.stt(lblThongBao);
            }
        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {
            dgvDSBenhNhan.DataSource = PhieuKham.DSKhamBenh(txtHoTen.Text);

            dgvDSBenhNhan.Columns["STT"].HeaderText = "STT";
            dgvDSBenhNhan.Columns["HoTen"].HeaderText = "Họ & Tên";
            dgvDSBenhNhan.Columns["NgayKham"].HeaderText = "Ngày khám";
            dgvDSBenhNhan.Columns["LoaiBenh"].HeaderText = "Loại bệnh";
            dgvDSBenhNhan.Columns["TrieuChung"].HeaderText = "Triệu chứng";

            dgvDSBenhNhan.Columns["STT"].Width = 50;
            dgvDSBenhNhan.Columns["HoTen"].Width = 150;
            dgvDSBenhNhan.Columns["NgayKham"].Width = 150;
            dgvDSBenhNhan.Columns["LoaiBenh"].Width = 200;
            dgvDSBenhNhan.Columns["TrieuChung"].Width = 350;
        }
        public string Search(string name)
        {
            if (name != "")
            {
                if (PhieuKham.DSKhamBenh(name).Count() != 0)
                    return "successed";
                else
                    return "failed";
            }
            else
                return "failed";
        }
    }
}
