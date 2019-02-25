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
    public partial class frmQuanLyThuoc : Form
    {
        public frmQuanLyThuoc()
        {
            InitializeComponent();
        }

        void LoadData()
        {

            dgvDSThuoc.DataSource = Thuoc.LayThuoc();
            dgvDSThuoc.Columns[0].Visible = false;
            dgvDSThuoc.Columns["TenThuoc"].HeaderText = "Tên thuốc";
            dgvDSThuoc.Columns["DonVi"].HeaderText = "Đơn vị";
            dgvDSThuoc.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvDSThuoc.Columns[1].Width = 350;
            dgvDSThuoc.Columns[2].Width = 100;
            dgvDSThuoc.Columns[3].Width = 100;

            if(dgvDSThuoc.RowCount<1)
            {
                //btnXoa.Enabled = false;
                btnSua.Enabled = false;
            }
            else
            {
                //btnXoa.Enabled = true;
                btnSua.Enabled = true;
            }

            lblThongBao.Text = "";
        }


        void XoaTextbox()
        {
            cbxDonVi.Text = "";
            txtTenThuoc.Text = "";
            numDonGia.Value = numDonGia.Minimum;
            txtTenThuoc.Focus();
            lblThongBao.Text = "";
        }

        private void QLThuoc_Load(object sender, EventArgs e)
        {
            lblThongBao.Text = "";
            LoadData();
        }

        #region SỰ KIỆN CỦA CÁC BUTTON
        private void btnThem_Click(object sender, EventArgs e)
        {
            var tb = new HideNotifications();
            try
            {
                if (txtTenThuoc.Text.Trim() != "")
                {

                    string TenThuoc = txtTenThuoc.Text;
                    string DonVi = cbxDonVi.Text;
                    int DonGia = (int)numDonGia.Value;
                    if (Thuoc.TimThuoc(TenThuoc, DonGia) == 0)
                    {
                        Thuoc.ThemThuoc(TenThuoc, DonVi, DonGia);
                        LoadData();

                        lblThongBao.ForeColor = Color.Green;
                        lblThongBao.Text = "Thêm mới thành công!";
                        tb.stt(lblThongBao);
                    }
                    else
                    {
                        XoaTextbox();
                    }

                }
                else
                {
                    lblThongBao.Text = "Bạn chưa nhập tên thuốc";
                    tb.stt(lblThongBao);
                    txtTenThuoc.Focus();
                }

            }
            catch
            {
                lblThongBao.Text = "Thêm bị lỗi";
                tb.stt(lblThongBao);
            }
        }

        //private void btnXoa_Click(object sender, EventArgs e)
        //{
        //    var tb = new HideNotifications();
        //    try
        //    {
        //        int MaThuoc = (int)dgvDSThuoc["MaThuoc", dgvDSThuoc.CurrentCell.RowIndex].Value;
        //        if (MessageBox.Show("Bạn có chắc muốn xóa loại thuốc này không. Nếu xóa, tất cả những đơn thuốc có liên quan đến loại thuốc này sẽ bị xóa hết", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
        //        {
        //            Thuoc.XoaThuoc(MaThuoc);
        //            LoadData();

        //            lblThongBao.ForeColor = Color.Green;
        //            lblThongBao.Text = "Xoá thành công!";
        //            tb.stt(lblThongBao);
        //        }
        //    }
        //    catch
        //    {
        //        lblThongBao.Text = "Xóa bị lỗi";
        //        tb.stt(lblThongBao);
        //    }
        //}

        private void btnSua_Click(object sender, EventArgs e)
        {
            var tb = new HideNotifications();
            try
            {
                int MaThuoc = (int)dgvDSThuoc["MaThuoc", dgvDSThuoc.CurrentCell.RowIndex].Value;
                string TenThuoc = txtTenThuoc.Text;
                string DonVi = cbxDonVi.Text;
                int DonGia = (int)numDonGia.Value;
                if (TenThuoc.Trim() != "")
                {
                    Thuoc.CapNhatThuoc(MaThuoc, TenThuoc, DonVi, DonGia);
                    LoadData();

                    lblThongBao.ForeColor = Color.Green;
                    lblThongBao.Text = "Đã cập nhập!";
                    tb.stt(lblThongBao);
                }
                else
                {
                    lblThongBao.Text = "Bạn chưa nhập tên thuốc";
                    tb.stt(lblThongBao);
                    txtTenThuoc.Focus();
                }
            }
            catch
            {
                lblThongBao.Text = "Dữ liệu không hợp lệ";
                tb.stt(lblThongBao);
                txtTenThuoc.Focus();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            XoaTextbox();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void dgvDSThuoc_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                int a = dgvDSThuoc.CurrentCell.RowIndex;
                txtTenThuoc.Text = dgvDSThuoc["TenThuoc", a].Value.ToString();
                cbxDonVi.Text = dgvDSThuoc["DonVi", a].Value.ToString();
                numDonGia.Value = decimal.Parse(dgvDSThuoc["DonGia", a].Value.ToString());
            }
            catch
            {
            }
        }
    }
}
