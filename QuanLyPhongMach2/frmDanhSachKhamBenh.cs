using QuanLyPhongMach2.DAO;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyPhongMach2
{
    public partial class frmDanhSachKhamBenh : Form
    {
        public frmDanhSachKhamBenh()
        {
            InitializeComponent();
        }

        #region SỰ KIỆN CÁC BUTTON
        private void btnThem_Click(object sender, EventArgs e)
        {
            var str = new StandardWord();
            var tb = new HideNotifications();

            if (txtHoTen.Text.Trim() != "" && txtDiaChi.Text.Trim() != "")// kiểm tra có đầy đủ thông tin hay không
            {
                if (DateTime.Compare(dtpNgayKham.Value, dtpNgaySinh.Value) >= 0)//Kiểm tra ngày sinh có lớn hơn ngày hiện tại hay không
                {
                    string HoTen = str.Standard_Word(txtHoTen.Text);
                    DateTime NgaySinh = dtpNgaySinh.Value;
                    string DiaChi = txtDiaChi.Text;
                    int GioiTinh;
                    string ngayKham = dtpNgayKham.Text;
                    int MaBN;

                    //Kiểm tra giới tính
                    if (rdoNam.Checked == true)
                        GioiTinh = 1;
                    else
                        GioiTinh = 0;

                    //Nếu chưa có bệnh nhân này trong danh sách thì sẽ thêm vào
                    if (BenhNhan.KTBenhNhan(HoTen, NgaySinh, out MaBN) == true)
                    {
                        BenhNhan.ThemBenhNhan(HoTen, GioiTinh, NgaySinh, DiaChi);
                        BenhNhan.KTBenhNhan(HoTen, NgaySinh, out MaBN);

                        if (PhieuKham.TimPhieuKham(dtpNgayKham.Text, MaBN) == 0)//không tìm thấy phiếu khám
                        {
                            PhieuKham.TaoPhieuKham(ngayKham, MaBN);
                            LoadData();
                        }
                        else
                        {
                            XoaTrang();
                        }

                        lblThongBao.ForeColor = Color.Green;
                        lblThongBao.Text = "Thêm mới bệnh nhân thành công!";
                        tb.stt(lblThongBao);
                    }
                    else
                    {
                        lblThongBao.ForeColor = Color.Red;
                        lblThongBao.Text = "Bệnh nhân bị trùng";
                        tb.stt(lblThongBao);
                        txtHoTen.Focus();
                    }
                }
                else
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
                lblThongBao.Text = "Vui lòng nhập đầy đủ dữ liệu!";
                tb.stt(lblThongBao);
                txtHoTen.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var tb = new HideNotifications();
            if (dgvDSBenhNhan.CurrentCell != null)
            {
                //Cảnh báo người dùng nến chọn xóa một người
                if (MessageBox.Show("Bạn có chắc muốn xóa phiếu khám bệnh của bệnh nhân này không", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    int a = dgvDSBenhNhan.CurrentCell.RowIndex;
                    int IDBenhNhan = (int)dgvDSBenhNhan["MaBN", a].Value;
                    int IDPhieuKham = PhieuKham.TimPhieuKham(dtpNgayKham.Text, IDBenhNhan);
                    PhieuKham.XoaPhieuKham(IDPhieuKham);

                    if (PhieuKham.TimBenhNhan(IDBenhNhan) == false)//Xoá hết tất cả các phiếu khám liên quan đến bệnh nhân đó thì xoá luôn bênh nhân đó
                    {
                        BenhNhan.XoaBN(IDBenhNhan);
                    }
                    LoadData();

                    lblThongBao.ForeColor = Color.Green;
                    lblThongBao.Text = "Xoá bệnh nhân thành công!";
                    tb.stt(lblThongBao);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var str = new StandardWord();
            var tb = new HideNotifications();

            if (dgvDSBenhNhan.CurrentCell != null)
            {
                if (txtDiaChi.Text != "" && txtHoTen.Text != "")
                {
                    if (DateTime.Compare(dtpNgayKham.Value, dtpNgaySinh.Value) >= 0)
                    {
                        int gioiTinh;
                        if (rdoNam.Checked == true)
                            gioiTinh = 1;
                        else
                            gioiTinh = 0;
                        int a = dgvDSBenhNhan.CurrentCell.RowIndex;//Lấy ra chỉ số dòng hiện hành cua dgvDSBenhNhan để chỉnh sửa thông tin cho bệnh nhân đó
                        int MaBN = (int)dgvDSBenhNhan["MaBN", a].Value;
                        BenhNhan.SuaTTBenhNhan(MaBN, str.Standard_Word(txtHoTen.Text), gioiTinh, dtpNgaySinh.Value, txtDiaChi.Text);
                        LoadData();
                        lblThongBao.ForeColor = Color.Green;
                        lblThongBao.Text = "Cập nhập bệnh nhân thành công!";
                        tb.stt(lblThongBao);
                    }
                    else
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
                    lblThongBao.Text = "Vui lòng nhập đầy đủ thông tin!";
                    tb.stt(lblThongBao);
                    txtHoTen.Focus();
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

        // bỏ ký tự thừa
        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
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
            dgvDSBenhNhan.DataSource = BenhNhan.LayDSBenhNhan(dtpNgayKham.Text);
            dgvDSBenhNhan.Columns["STT"].HeaderText = "STT";
            dgvDSBenhNhan.Columns["TenBN"].HeaderText = "Họ & Tên";
            dgvDSBenhNhan.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvDSBenhNhan.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvDSBenhNhan.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvDSBenhNhan.Columns["MaBN"].HeaderText = "Mã bệnh nhân";

            dgvDSBenhNhan.Columns["STT"].Width = 50;
            dgvDSBenhNhan.Columns["MaBN"].Width = 100;
            dgvDSBenhNhan.Columns["TenBN"].Width = 200;
            dgvDSBenhNhan.Columns["GioiTinh"].Width = 100;
            dgvDSBenhNhan.Columns["Ngaysinh"].Width = 100;
            dgvDSBenhNhan.Columns["DiaChi"].Width = 400;

            if (/*DateTime.Compare(DateTime.Now, dtpNgayKham.Value) == 0*/DateTime.Now.Day == dtpNgayKham.Value.Day && DateTime.Now.Month == dtpNgayKham.Value.Month && DateTime.Now.Year == dtpNgayKham.Value.Year)
            {
                btnThem.Enabled = true;

                if (dgvDSBenhNhan.RowCount < 1)// nếu không có bệnh nhân nào thì không cho click nút xoá,sửa
                {
                    btnXoa.Enabled = false;
                    btnSua.Enabled = false;
                    btnHuy.Enabled = false;
                }
                else
                {
                    btnXoa.Enabled = true;
                    btnSua.Enabled = true;
                    btnHuy.Enabled = true;
                }
            }
            else
            {
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                btnHuy.Enabled = false;
                btnThem.Enabled = false;
            }
            lblThongBao.Text = "";

        }

        // reset các các giá trị các textbox, datetime
        private void XoaTrang()
        {
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            dtpNgaySinh.Value = new DateTime(1990, 1, 1);
            rdoNam.Checked = true;
            txtHoTen.Focus();
            lblThongBao.Text = "";
        }

        private void DanhSachKhamBenh_Load(object sender, EventArgs e)
        {
            LoadData();
            lblThongBao.Text = "";
        }


        //kiểm tra số lượng bệnh nhân với số lượng bệnh nhân tối đa trong ngày
        private void numSLBN_ValueChanged(object sender, EventArgs e)
        {
            if (dgvDSBenhNhan.RowCount < numSLBN.Value)
            {
                btnThem.Enabled = true;
            }
            else
            {
                btnThem.Enabled = false;
            }
        }

        //Lấy lại thông tin cho các textbox khi ô hiện hành trong dgvDSBenhNhan bị thay doi
        private void dgvDSBenhNhan_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                int a = dgvDSBenhNhan.CurrentCell.RowIndex;
                txtHoTen.Text = dgvDSBenhNhan["TenBN", a].Value.ToString();
                txtDiaChi.Text = dgvDSBenhNhan["DiaChi", a].Value.ToString();
                dtpNgaySinh.Text = dgvDSBenhNhan["NgaySinh", a].Value.ToString();

                if ((bool)dgvDSBenhNhan["GioiTinh", a].Value == true)
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

        //Giá trị ngày khám thay đổi sẽ load dữ liệu lai như cũ
        private void dtpNgayKham_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        public string AddBN(string TenBN, DateTime NgaySinh, string DiaChi, bool GioiTinh)
        {
            int MaBN;
            if (TenBN!="")
            {
                if (DiaChi != "")
                {
                    if (DateTime.Compare(NgaySinh, DateTime.Now) <= 0)
                    {
                        if (BenhNhan.KTBenhNhan(TenBN, NgaySinh, out MaBN) == true)
                        {
                            BenhNhan.ThemBenhNhan(TenBN, GioiTinh ? 1 : 0, NgaySinh, DiaChi);
                            return "successed";
                        }
                        else
                            return "failed";
                    }
                    else return "failed";
                }
                else
                    return "failed";
            }
            else
                return "failed";
        }
        public string DeleteBN(int MaBN)
        {
            if (MaBN > 0)
            {
                BenhNhan.XoaBN(MaBN);
                return "successed";
            }
            else
                return "failed";
        }
        public string EditBN(int MaBN, string TenBN, DateTime NgaySinh, string DiaChi, bool GioiTinh)
        {

            if (MaBN > 0)
            {
                if (DateTime.Compare(NgaySinh, DateTime.Now) <= 0)
                { 
                    BenhNhan.SuaTTBenhNhan(MaBN, TenBN, GioiTinh ? 1 : 0, NgaySinh, DiaChi);
                    return "successed";
                }
                else
                    return "failed";
            }
            else
                return "failed";
        }

    }
}
