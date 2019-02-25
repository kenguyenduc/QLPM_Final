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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        #region PHẦN CHIA NGƯỜI DÙNG
        private void frmMain_Load(object sender, EventArgs e)
        {
            OnOff(this);
            lbTrangThai.Text = "";
        }

        public void OnOff(Form frm)
        {
            frmMain f = (frmMain)frm;
            switch (PhanQuyenNguoiDung.ChucVu)
            {
                case "Admin":
                    {
                        f.btnDangNhap.Enabled = false;
                        f.btnDangXuat.Enabled = true;
                        f.btnDoiMatKhau.Enabled = true;
                        f.btnThayDoiThongTinCaNhan.Enabled = true;
                        f.btnQuanLyNguoiDung.Enabled = true;
                        f.btnBaoCaoSuDungThuoc.Enabled = true;
                        f.btnBaoCaoDoanhThu.Enabled = true;
                        f.btnBenhNhan.Enabled = true;
                        f.btnPhieuKham.Enabled = true;
                        f.btnTraCuuBenhNhan.Enabled = true;
                        f.btnThuoc.Enabled = true;
                        f.btnDong.Enabled = true;
                        f.btnDongTatCa.Enabled = true;
                        f.btnDangNhap.Caption =PhanQuyenNguoiDung.ChucVu;
                        f.btnDangXuat.Caption = "Đăng xuất " + "'" + PhanQuyenNguoiDung.TenDangNhap + "'";
                        f.lbTrangThai.Text = "Đăng nhập thành công";
                        f.stt();
                    }
                    break;
                case "Nhân Viên":
                    {
                        f.btnDangNhap.Enabled = false;
                        f.btnDangXuat.Enabled = true;
                        f.btnDoiMatKhau.Enabled = true;
                        f.btnThayDoiThongTinCaNhan.Enabled = true;
                        f.btnQuanLyNguoiDung.Enabled = false;
                        f.btnBaoCaoSuDungThuoc.Enabled = false;
                        f.btnBaoCaoDoanhThu.Enabled = false;
                        f.btnBenhNhan.Enabled = true;
                        f.btnPhieuKham.Enabled = true;
                        f.btnTraCuuBenhNhan.Enabled = true;
                        f.btnThuoc.Enabled = true;
                        f.btnDong.Enabled = true;
                        f.btnDongTatCa.Enabled = true;
                        f.btnDangNhap.Caption = PhanQuyenNguoiDung.ChucVu;
                        f.btnDangXuat.Caption = "Đăng xuất " +"'"+ PhanQuyenNguoiDung.TenDangNhap + "'";
                        f.lbTrangThai.Text = "Đăng nhập thành công";
                        f.stt();
                    }
                    break;
                default:
                    {
                        f.btnDangNhap.Enabled = true;
                        f.btnDangXuat.Enabled = false;
                        f.btnDoiMatKhau.Enabled = false;
                        f.btnThayDoiThongTinCaNhan.Enabled = false;
                        f.btnQuanLyNguoiDung.Enabled = false;
                        f.btnBaoCaoSuDungThuoc.Enabled = false;
                        f.btnBaoCaoDoanhThu.Enabled = false;
                        f.btnBenhNhan.Enabled = false;
                        f.btnPhieuKham.Enabled = false;
                        f.btnTraCuuBenhNhan.Enabled = false;
                        f.btnThuoc.Enabled = false;
                        f.btnDong.Enabled = false;
                        f.btnDongTatCa.Enabled = false;
                        f.btnDangNhap.Caption = "Đăng nhập";
                        f.btnDangXuat.Caption = "Đăng xuất ";
                    }
                    break;
            }
        }
        #endregion

        #region ẨN STATUSSTRIP sau 1.3s
        public void stt()
        {
            var t = new Timer();
            t.Interval = 1300;
            t.Tick += (s, e) =>
            {
                lbTrangThai.Text = "";
                t.Stop();
            };
            t.Start();
        }
        #endregion

        #region HỆ THỐNG
        private void btnDangNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool _IsActive = false;
            foreach (Form form in Application.OpenForms.OfType<Form>().ToList())
            {
                if (form.GetType() == typeof(frmDangNhap))
                {
                    form.Activate();
                    _IsActive = true;
                }
            }
            if (!_IsActive)
            {
                frmDangNhap frm = new frmDangNhap();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất hay không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                foreach (Form frm in this.MdiChildren)
                    frm.Close();
                PhanQuyenNguoiDung.ChucVu = "";
                PhanQuyenNguoiDung.TenDangNhap = "";
                lbTrangThai.Text = "Đăng xuất thành công";
                stt();
                OnOff(this);
            }
        }

        private void btnDoiMatKhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau();
            frm.ShowDialog();
        }

        private void btnThayDoiThongTinCaNhan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCapNhatThongTinND frm = new frmCapNhatThongTinND();
            frm.ShowDialog();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
        }

        private void btnDongTatCa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
                frm.Close();
        }
        #endregion

        #region QUẢN LÝ NGƯỜI DÙNG
        private void btnQuanLyNguoiDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool _IsActive = false;
            foreach (Form form in Application.OpenForms.OfType<Form>().ToList())
            {
                if (form.GetType() == typeof(frmQuanLyNguoiDung))
                {
                    form.Activate();
                    _IsActive = true;
                }
            }
            if (!_IsActive)
            {
                frmQuanLyNguoiDung frm = new frmQuanLyNguoiDung();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        #endregion

        #region QUẢN LÝ BỆNH NHÂN

        private void btnBenhNhan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool _IsActive = false;
            foreach (Form form in Application.OpenForms.OfType<Form>().ToList())
            {
                if (form.GetType() == typeof(frmDanhSachKhamBenh))
                {
                    form.Activate();
                    _IsActive = true;
                }
            }
            if (!_IsActive)
            {
                frmDanhSachKhamBenh frm = new frmDanhSachKhamBenh();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnPhieuKham_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool _IsActive = false;
            foreach (Form form in Application.OpenForms.OfType<Form>().ToList())
            {
                if (form.GetType() == typeof(frmPhieuKhamBenh))
                {
                    form.Activate();
                    _IsActive = true;
                }
            }
            if (!_IsActive)
            {
                frmPhieuKhamBenh frm = new frmPhieuKhamBenh();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnHoaDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool _IsActive = false;
            foreach (Form form in Application.OpenForms.OfType<Form>().ToList())
            {
                if (form.GetType() == typeof(frmHoaDonThanhToan))
                {
                    form.Activate();
                    _IsActive = true;
                }
            }
            if (!_IsActive)
            {
                frmHoaDonThanhToan frm = new frmHoaDonThanhToan();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnTraCuuBenhNhan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool _IsActive = false;
            foreach (Form form in Application.OpenForms.OfType<Form>().ToList())
            {
                if (form.GetType() == typeof(frmDanhSachBenhNhan))
                {
                    form.Activate();
                    _IsActive = true;
                }
            }
            if (!_IsActive)
            {
                frmDanhSachBenhNhan frm = new frmDanhSachBenhNhan();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        #endregion

        #region QUẢN LÝ THUỐC

        private void btnThuoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool _IsActive = false;
            foreach (Form form in Application.OpenForms.OfType<Form>().ToList())
            {
                if (form.GetType() == typeof(frmQuanLyThuoc))
                {
                    form.Activate();
                    _IsActive = true;
                }
            }
            if (!_IsActive)
            {
                frmQuanLyThuoc frm = new frmQuanLyThuoc();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnToaThuoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool _IsActive = false;
            foreach (Form form in Application.OpenForms.OfType<Form>().ToList())
            {
                if (form.GetType() == typeof(frmThemToaThuoc))
                {
                    form.Activate();
                    _IsActive = true;
                }
            }
            if (!_IsActive)
            {
                frmThemToaThuoc frm = new frmThemToaThuoc();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        #endregion

        #region THỐNG KÊ

        private void btnBaoCaoSuDungThuoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool _IsActive = false;
            foreach (Form form in Application.OpenForms.OfType<Form>().ToList())
            {
                if (form.GetType() == typeof(frmBaoCaoSuDungThuoc))
                {
                    form.Activate();
                    _IsActive = true;
                }
            }
            if (!_IsActive)
            {
                frmBaoCaoSuDungThuoc frm = new frmBaoCaoSuDungThuoc();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnBaoCaoDoanhThu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool _IsActive = false;
            foreach (Form form in Application.OpenForms.OfType<Form>().ToList())
            {
                if (form.GetType() == typeof(frmBaoCaoDoanhThuTheoThang))
                {
                    form.Activate();
                    _IsActive = true;
                }
            }
            if (!_IsActive)
            {
                frmBaoCaoDoanhThuTheoThang frm = new frmBaoCaoDoanhThuTheoThang();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        #endregion

        #region TRỢ GIÚP

        private void btnThongTinPhanMem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThongTinPhanMem frm = new frmThongTinPhanMem();
            frm.ShowDialog();
        }

        private void btnHuongDanSuDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmHuongDanSuDung frm = new frmHuongDanSuDung();
            frm.ShowDialog();
        }

        #endregion
    }
}
