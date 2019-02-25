using QuanLyPhongMach2.DAO;
using QuanLyPhongMach2.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyPhongMach2
{
    public partial class frmPhieuKhamBenh : Form
    {
        public frmPhieuKhamBenh()
        {
            InitializeComponent();
        }

        public static int MaPK;
        int MaBN;

        // ràng buộc kí tư
        private void cbxHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }

        //Load dữ liệu
        private void LoadData()
        {
            MaBN = 0;
            try
            {
                cbxHoTen.DisplayMember = "TenBN";
                cbxHoTen.ValueMember = "MaBN";
                cbxHoTen.DataSource = BenhNhan.LayDSBenhNhan(dtpNgayKham.Text);//Lầy dữ liệu cho cbxHoTen theo ngày khám                
                cbxHoTen.SelectedIndex = 0;
                MaBN = (int)cbxHoTen.SelectedValue;

                dgvToaThuoc.DataSource = ToaThuoc.LayChiTietDonThuoc(MaPK);

                dgvToaThuoc.Columns["STT"].HeaderText = "STT";
                dgvToaThuoc.Columns["MaThuoc"].HeaderText = "Mã Thuốc";
                dgvToaThuoc.Columns["TenThuoc"].HeaderText = "Tên thuốc";
                dgvToaThuoc.Columns["SoLuong"].HeaderText = "Số lượng";
                dgvToaThuoc.Columns["DonVi"].HeaderText = "Đơn vị";
                dgvToaThuoc.Columns["CachDung"].HeaderText = "Cách dùng";

                dgvToaThuoc.Columns["STT"].Width = 50;
                dgvToaThuoc.Columns["MaThuoc"].Width = 100;
                dgvToaThuoc.Columns["TenThuoc"].Width = 120;
                dgvToaThuoc.Columns["SoLuong"].Width = 80;
                dgvToaThuoc.Columns["DonVi"].Width = 100;
                dgvToaThuoc.Columns["CachDung"].Width = 250;

                MaPK = PhieuKham.TimPhieuKham(dtpNgayKham.Text, MaBN);//Lầy ra MaPk dựa vào Ngày khám và MABN
                List<ChiTietToaThuoc> toaThuoc = ToaThuoc.LayChiTietDonThuoc(MaPK);

                if (toaThuoc.Count > 0)
                {
                    dgvToaThuoc.DataSource = toaThuoc;//Lầy chi tiết toa thuốc của phiếu khám
                }
                else
                {
                    dgvToaThuoc.DataSource = null;
                }

                string TrieuChung;
                string LoaiBenh;
                PhieuKham.LayDuLieu(MaPK, out LoaiBenh, out TrieuChung);//Lấy ra triệu chứng và loại bệnh của bệnh nhân. nếu có
                txtTrieuChung.Text = TrieuChung;
                txtLoaiBenh.Text = LoaiBenh;

                if (DateTime.Now.Day == dtpNgayKham.Value.Day && DateTime.Now.Month == dtpNgayKham.Value.Month && DateTime.Now.Year == dtpNgayKham.Value.Year)
                {
                    btnXemHD.Enabled = true;
                    btnThemThuoc.Enabled = true;
                    btnCapNhapTT.Enabled = true;
                    if (ToaThuoc.LayChiTietDonThuoc(MaPK).Count > 0)
                    {
                        btnXoaThuoc.Enabled = true;
                    }
                    else
                    {
                        btnXoaThuoc.Enabled = false;
                    }
                }
                else
                {
                    btnXemHD.Enabled = false;
                    btnThemThuoc.Enabled = false;
                    btnCapNhapTT.Enabled = false;
                    btnXoaThuoc.Enabled = false;
                }
            }
            catch//Không có bệnh nhân nào
            {
                cbxHoTen.Text = "";
                btnXemHD.Enabled = false;
                btnThemThuoc.Enabled = false;
                btnCapNhapTT.Enabled = false;
                btnXoaThuoc.Enabled = false;

                txtLoaiBenh.Text = "";
                txtTrieuChung.Text = "";
            }
        }

        private void PhieuKhamBenh_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // Lấy danh sách bệnh nhân vào comboboxHoTen
        private void cbxHoTen_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MaBN = (int)cbxHoTen.SelectedValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dtpNgayKham_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }


        #region SỰ KIỆN CỦA CÁC BUTTON
        private void btnThemLoaiThuoc_Click(object sender, EventArgs e)
        {
            frmThemToaThuoc frm = new frmThemToaThuoc();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.FormClosing += new FormClosingEventHandler(ChildFormClosing);
            frm.ShowDialog();
        }
        private void ChildFormClosing(object sender, FormClosingEventArgs e)
        {
            LoadData();
        }

        private void btnXoaThuoc_Click(object sender, EventArgs e)
        {
            try
            {
                int rowindex = dgvToaThuoc.CurrentCell.RowIndex;
                int MaThuoc = (int)dgvToaThuoc["MaThuoc", rowindex].Value;
                ToaThuoc.XoaDuLieu(MaPK, MaThuoc);
                LoadData();
            }
            catch
            {
                MessageBox.Show("Xóa bị lỗi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhapTT_Click(object sender, EventArgs e)
        {
            if (txtLoaiBenh.Text != "" && txtTrieuChung.Text != "")
            {
                try
                {
                    PhieuKham.CapNhapPhieuKham(MaPK, txtTrieuChung.Text, txtLoaiBenh.Text);
                }
                catch
                {
                    MessageBox.Show("Thêm dữ liệu bị lỗi");
                }
                LoadData();
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin trong khung phiếu khám");
            }

        }

        private void btnXemHD_Click(object sender, EventArgs e)
        {
            frmHoaDonThanhToan frm = new frmHoaDonThanhToan();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
