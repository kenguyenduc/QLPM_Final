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
    public partial class frmQuanLyNguoiDung : Form
    {
        public frmQuanLyNguoiDung()
        {
            InitializeComponent();
        }

        #region RÀNG BUỘC CÁC KÍ TỰ TRONG CÁC Ô TEXTBOX

        private void txtTenDangNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar) || char.IsNumber(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar) || char.IsNumber(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsNumber(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }

        private void txtTenNguoiDung_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }
        #endregion


        //Hàm bật tắt các textbox không cho người dùng chỉnh sửa. chỉ mở khi xóa trắng dữ liệu để thêm người dùng mới
        void OnOff(bool en)
        {
            txtDiaChi.ReadOnly = !en;
            txtMatKhau.ReadOnly = !en;
            txtSoDienThoai.ReadOnly = !en;
            txtTenDangNhap.ReadOnly = !en;
            txtTenNguoiDung.ReadOnly = !en;
            cbxChucVu.Enabled = en;
            rdoNu.Enabled = en;
            rdoNam.Enabled = en;
        }

        //Load lại dữ liệu khi có sự thay đổi về người dùng
        void LoadData()
        {
            OnOff(true);
            dgvDSNguoiDung.DataSource = NguoiDung.LayDSNguoiDung();

            dgvDSNguoiDung.Columns["STT"].HeaderText = "STT";
            dgvDSNguoiDung.Columns["TenDangNhap"].HeaderText = "Tên đăng nhập";
            dgvDSNguoiDung.Columns["ChucVu"].HeaderText = "Chức vụ";
            dgvDSNguoiDung.Columns["TenND"].HeaderText = "Tên người dùng";
            dgvDSNguoiDung.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvDSNguoiDung.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvDSNguoiDung.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvDSNguoiDung.Columns["SDT"].HeaderText = "Số điện thoại";

            dgvDSNguoiDung.Columns[0].Width = 50;
            dgvDSNguoiDung.Columns[1].Width = 120;
            dgvDSNguoiDung.Columns[2].Width = 100;
            dgvDSNguoiDung.Columns[3].Width = 200;
            dgvDSNguoiDung.Columns[4].Width = 150;
            dgvDSNguoiDung.Columns[5].Width = 80;
            dgvDSNguoiDung.Columns[6].Width = 350;

            //không xoá đc khi số tài khoản <=2
            if (dgvDSNguoiDung.RowCount <= 2)
                btnXoa.Enabled = false;
            else
                btnXoa.Enabled = true;
            lblThongBao.Text = "";
        }
        void XoaTrang()
        {
            OnOff(true);
            txtTenNguoiDung.Focus();
            txtTenNguoiDung.Text = "";
            txtMatKhau.Text = "";
            rdoNam.Checked = true;
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
            txtTenDangNhap.Text = "";
            btnThem.Enabled = true;
            lblThongBao.Text = "";
            dtpNgaySinh.Value = new DateTime(1990, 1, 1);
        }

        private void QuanLyNguoiDung_Load(object sender, EventArgs e)
        {
            lblThongBao.Text = "";
            LoadData();

        }

        #region SỰ KIỆN CÁC BUTTON
        private void btnThem_Click(object sender, EventArgs e)
        {
            var str = new StandardWord();
            var tb = new HideNotifications();

            //Lầy các giá trị của các textbox 
            string TenND = str.Standard_Word(txtTenNguoiDung.Text);
            DateTime NgaySinh = dtpNgaySinh.Value;
            string DiaChi = txtDiaChi.Text;
            string SDT = txtSoDienThoai.Text;
            string TenDangNhap = txtTenDangNhap.Text;
            string MK = txtMatKhau.Text;
            string ChucVu = cbxChucVu.Text;
            int GioiTinh;
            if (rdoNam.Checked == true)
                GioiTinh = 1;
            else
                GioiTinh = 0;

            try
            {
                if (TenND.Trim() != "")
                {
                    if (TenDangNhap.Trim() != "")
                    {
                        if (MK.Trim() != "")
                        {
                            if (DateTime.Compare(NgaySinh, DateTime.Now) <= 0)
                            {
                                try
                                {
                                    NguoiDung.ThemNguoiDung(TenND, NgaySinh, GioiTinh, DiaChi, SDT, TenDangNhap, MK, ChucVu);
                                    LoadData();

                                    lblThongBao.ForeColor = Color.Green;
                                    lblThongBao.Text = "Thêm người dùng thành công!";
                                    tb.stt(lblThongBao);
                                }
                                catch
                                {
                                    lblThongBao.ForeColor = Color.Red;
                                    lblThongBao.Text = "Tên đăng nhập đã có người sử dụng";
                                    tb.stt(lblThongBao);
                                    txtTenDangNhap.Clear();
                                    txtTenDangNhap.Focus();
                                }
                            }
                            else
                            {
                                lblThongBao.ForeColor = Color.Red;
                                lblThongBao.Text = "Lỗi ngày sinh";
                                tb.stt(lblThongBao);
                                dtpNgaySinh.Focus();
                            }
                        }
                        else
                        {
                            lblThongBao.ForeColor = Color.Red;
                            lblThongBao.Text = "Bạn chưa nhập mật khẩu";
                            tb.stt(lblThongBao);
                            txtMatKhau.Focus();
                        }
                    }
                    else
                    {
                        lblThongBao.ForeColor = Color.Red;
                        lblThongBao.Text = "Bạn chưa nhập tên đăng nhập";
                        tb.stt(lblThongBao);
                        txtTenDangNhap.Focus();
                    }
                }
                else
                {
                    lblThongBao.ForeColor = Color.Red;
                    lblThongBao.Text = "Bạn chưa nhập tên";
                    tb.stt(lblThongBao);
                    txtTenNguoiDung.Focus();
                }
            }
            catch
            {
                lblThongBao.ForeColor = Color.Red;
                lblThongBao.Text = "Thêm bị lỗi";
                tb.stt(lblThongBao);
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var tb = new HideNotifications();

            int a = dgvDSNguoiDung.CurrentCell.RowIndex;
            string TenDangNhap = dgvDSNguoiDung[1, a].Value.ToString();
            string ChucVu = dgvDSNguoiDung[2, a].Value.ToString();

            //Không được xóa admin và tài khoản đang đăng nhập
            if (ChucVu != "Admin")
            {

                NguoiDung.XoaNguoiDung(TenDangNhap);
                LoadData();
                lblThongBao.ForeColor = Color.Green;
                lblThongBao.Text = "Xoá người dùng thành công!";
                tb.stt(lblThongBao);
            }
            else
            {
                lblThongBao.ForeColor = Color.Red;
                lblThongBao.Text = "Bạn không thể xóa người dùng này";
                tb.stt(lblThongBao);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var str = new StandardWord();
            var tb = new HideNotifications();

            if (dgvDSNguoiDung.CurrentCell != null)
            {
                try
                {
                    string TenDangNhap = (string)dgvDSNguoiDung["TenDangNhap", dgvDSNguoiDung.CurrentCell.RowIndex].Value;
                    string TenND = str.Standard_Word(txtTenNguoiDung.Text);
                    DateTime NgaySinh = dtpNgaySinh.Value;
                    string DiaChi = txtDiaChi.Text;
                    string SDT = txtSoDienThoai.Text;
                    string MK = txtMatKhau.Text;
                    string ChucVu = cbxChucVu.Text;
                    int GioiTinh;
                    if (rdoNam.Checked == true)
                        GioiTinh = 1;
                    else
                        GioiTinh = 0;

                    if (TenND.Trim() != "")
                    {
                        if (TenDangNhap.Trim() != "")
                        {
                            if (DateTime.Compare(NgaySinh, DateTime.Now) <= 0)
                            {
                                try
                                {
                                    // DateTime ns = DateTime.Parse(NgaySinh);
                                    NguoiDung.CapNhatThongTin(TenDangNhap, TenND, NgaySinh, GioiTinh, DiaChi, SDT);
                                    LoadData();
                                    lblThongBao.ForeColor = Color.Green;
                                    lblThongBao.Text = "Cập nhập người dùng thành công!";
                                    tb.stt(lblThongBao);
                                }
                                catch
                                {
                                    lblThongBao.ForeColor = Color.Red;
                                    lblThongBao.Text = "Ngày sinh không hợp lệ";
                                    tb.stt(lblThongBao);
                                    dtpNgaySinh.Focus();
                                }
                            }
                            else
                            {
                                lblThongBao.ForeColor = Color.Red;
                                lblThongBao.Text = "Lỗi ngày sinh";
                                tb.stt(lblThongBao);
                                dtpNgaySinh.Focus();
                            }
                        }
                        else
                        {
                            lblThongBao.ForeColor = Color.Red;
                            lblThongBao.Text = "Bạn chưa nhập tên đăng nhập";
                            txtTenDangNhap.Focus();
                            tb.stt(lblThongBao);
                        }
                    }
                    else
                    {
                        lblThongBao.ForeColor = Color.Red;
                        lblThongBao.Text = "Bạn chưa nhập tên";
                        txtTenNguoiDung.Focus();
                        tb.stt(lblThongBao);
                    }
                }
                catch
                {
                    lblThongBao.ForeColor = Color.Red;
                    lblThongBao.Text = "Dữ liệu không hợp lệ";
                    txtTenNguoiDung.Focus();
                    tb.stt(lblThongBao);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            XoaTrang();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        //Lấy dự liệu lên cho các textbox
        private void dgvDSNguoiDung_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                int a = dgvDSNguoiDung.CurrentCell.RowIndex;
                txtTenDangNhap.Text = dgvDSNguoiDung["TenDangNhap", a].Value.ToString();
                txtDiaChi.Text = dgvDSNguoiDung["DiaChi", a].Value.ToString();
                dtpNgaySinh.Text = dgvDSNguoiDung["NgaySinh", a].Value.ToString();
                txtSoDienThoai.Text = dgvDSNguoiDung["SDT", a].Value.ToString();
                txtTenNguoiDung.Text = dgvDSNguoiDung["TenND", a].Value.ToString();
                cbxChucVu.Text = dgvDSNguoiDung["ChucVu", a].Value.ToString();

                if ((bool)dgvDSNguoiDung["GioiTinh", a].Value == true)
                {
                    rdoNam.Checked = true;
                }
                else
                    rdoNu.Checked = true;

                lblThongBao.Text = "";
            }
            catch
            {
                XoaTrang();
            }
        }

        #region
        public string Add(string TenND, DateTime NgaySinh, bool GioiTinh, string DiaChi, string SDT, string TenDangNhap, string MatKhau, string ChucVu)
        {
            if (TenND.Trim() != "")
            {
                if (TenDangNhap.Trim() != "")
                {
                    if (MatKhau.Trim() != "")
                    {
                        if (DateTime.Compare(NgaySinh, DateTime.Now) <= 0)
                        {
                            try
                            {
                                NguoiDung.ThemNguoiDung(TenND, NgaySinh, (GioiTinh) ? 1 : 0, DiaChi, SDT, TenDangNhap, MatKhau, ChucVu);
                                return "successed";
                            }
                            catch
                            {
                                return "failed";
                            }
                        }
                        else
                        {
                            return "failed";
                        }
                    }
                    else
                    {
                        return "failed";
                    }
                }
                else
                {
                    return "failed";
                }
            }
            else
            {
                return "failed";
            }
        }

        public string Edit(string TenND, DateTime NgaySinh, bool GioiTinh, string DiaChi, string SDT, string TenDangNhap, string MatKhau, string ChucVu)
        {
            if (TenND.Trim() != "")
            {
                if (TenDangNhap.Trim() != "")
                {
                    if (DateTime.Compare(NgaySinh, DateTime.Now) <= 0)
                    {
                        try
                        {
                            NguoiDung.CapNhatThongTin(TenDangNhap, TenND, NgaySinh, (GioiTinh) ? 1 : 0, DiaChi, SDT);
                            if (NguoiDung.LayThongTin(TenDangNhap).TenND == TenND && NguoiDung.LayThongTin(TenDangNhap).NgaySinh == NgaySinh && NguoiDung.LayThongTin(TenDangNhap).GioiTinh == GioiTinh && NguoiDung.LayThongTin(TenDangNhap).DiaChi == DiaChi && NguoiDung.LayThongTin(TenDangNhap).SDT == SDT)
                            {
                                return "successed";
                            }
                            else return "failed";
                        }
                        catch
                        {
                            return "failed";
                        }
                    }
                    else
                    {
                        return "failed";
                    }
                }
                else
                {
                    return "failed";
                }
            }
            else
            {
                return "failed";
            }
        }

        public string Delete(string TenDangNhap, string ChucVu)
        {
            if (ChucVu != "Admin")
            {
                try
                {
                    NguoiDung.XoaNguoiDung(TenDangNhap);
                    if (NguoiDung.DSNguoiDungTheoTen(TenDangNhap).Count() == 0)
                        return "successed";
                    else
                        return "failed";
                }
                catch
                {
                    return "failed";
                }
            }
            else
                return "failed";
        }


        #endregion


    }
}
