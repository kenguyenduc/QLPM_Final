using QuanLyPhongMach2.DAO;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;

namespace QuanLyPhongMach2
{
    public partial class frmThemToaThuoc : Form
    {
        public frmThemToaThuoc()
        {
            InitializeComponent();
        }

        private void ThemToaThuoc_Load(object sender, EventArgs e)
        {
            cbxThuoc.DataSource = Thuoc.LayThuoc();
            cbxThuoc.ValueMember = "MaThuoc";
            cbxThuoc.DisplayMember = "TenThuoc";
            cbxDonVi.Text = Thuoc.LayDonViThuoc((int)cbxThuoc.SelectedValue);
            lblThongBao.Text = "";
        }

        // Lấy đúng đơn vị cho thuốc
        private void cbxThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbxDonVi.Text = Thuoc.LayDonViThuoc((int)cbxThuoc.SelectedValue);
            }
            catch
            { }
        }


        #region SỰ KIỆN CÁC BUTTON
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var tb = new HideNotifications();
            if (txtCachDung.Text.Trim() != "" && txtSoLuong.Text.Trim() != "")
            {
                int SoLuong = int.Parse(txtSoLuong.Text);//Kiểm tra tính đúng đắn của số lượng nhập vào
                try
                {
                    int MaPK = frmPhieuKhamBenh.MaPK;
                    int MaThuoc = (int)cbxThuoc.SelectedValue;
                    string CachDung = txtCachDung.Text;
                    ToaThuoc.ThemDuLieu(MaPK, MaThuoc, SoLuong, CachDung);

                    lblThongBao.ForeColor = Color.Green;
                    lblThongBao.Text = "Thêm thuốc thành công";
                    tb.stt(lblThongBao);

                    txtSoLuong.Text = "";
                    txtCachDung.Text = "";

                }
                catch
                {
                    lblThongBao.ForeColor = Color.Red;
                    lblThongBao.Text = "Thuốc đã tồn tại trong hoá đơn";
                    tb.stt(lblThongBao);
                }
            }
            else
            {
                lblThongBao.ForeColor = Color.Red;
                lblThongBao.Text = "Chưa nhập đủ dữ liệu";
                tb.stt(lblThongBao);
                txtCachDung.Focus();
            }
        }
        #endregion

        // Ràng buộc kí tự
        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }
    }
}
