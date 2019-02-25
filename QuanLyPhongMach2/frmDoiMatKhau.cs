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
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtMKCu.Focus();
            lblThongBao.Text = "";
        }

        #region TẠO RÀNG BUỘC KÍ TỰ CHO CÁC Ô TEXTBOX
        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar) || char.IsNumber(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }
        #endregion

        #region SỰ KIỆN CÁC BUTTON
        private void btnLuu_Click(object sender, EventArgs e)
        {

            var tb = new HideNotifications();

            //Lầy dữ liệu từ các textbox
            string MKCu = txtMKCu.Text.Trim();
            string MKMoi = txtMKMoi.Text.Trim();
            string NhapLaiMK = txtNhapLaiMK.Text.Trim();

            //Kiểm tra dữ liệu trước khi đổi mật khẩu
            if (MKCu != "" && MKMoi != "" && NhapLaiMK != "")
            {
                if (MKMoi != NhapLaiMK)
                {
                    lblThongBao.Text = "Mật khẩu xác nhận không đúng";
                    tb.stt(lblThongBao);
                }
                else
                {
                    if (NguoiDung.DoiMatKhau(PhanQuyenNguoiDung.TenDangNhap, MKMoi, MKCu) > 0)
                    {

                        MessageBox.Show("Đổi mật khẩu thành công");

                        this.Close();
                    }
                    else
                    {
                        lblThongBao.Text = "Đổi mật khẩu bị lỗi";
                        tb.stt(lblThongBao);
                    }
                }
            }
            else
            {
                lblThongBao.Text = "Vui lòng nhập đầy đủ thông tin!";
                tb.stt(lblThongBao);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        public string ChangePassword(string TenDangNhap, string MatKhauCu, string MatKhauMoi, string NhapLaiMatKhauMoi)
        {
            if (MatKhauCu != "" && MatKhauMoi != "" && NhapLaiMatKhauMoi != "")
            {
                if (MatKhauMoi == NhapLaiMatKhauMoi)
                {
                    if (NguoiDung.DoiMatKhau(TenDangNhap, MatKhauMoi, MatKhauCu) > 0)
                    {
                        return "successed";
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
    }
}
