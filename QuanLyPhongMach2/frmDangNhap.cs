using QuanLyPhongMach2.DAO;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyPhongMach2
{
    public partial class frmDangNhap : Form
    {
        static DuLieu dl = new DuLieu();
        public frmDangNhap()
        {
            InitializeComponent();
            //TaoChuChim();
        }

        //#region TẠO CHỮ CHÌM
        //private void TaoChuChim()
        //{
        //    txtTenDangNhap.ForeColor = Color.LightGray;
        //    txtTenDangNhap.Text = "Không quá 35 kí tự";
        //    this.txtTenDangNhap.Enter += new System.EventHandler(this.txtTenDangNhap_Enter);
        //    this.txtTenDangNhap.Leave += new System.EventHandler(this.txtTenDangNhap_Leave);

        //    txtMatKhau.ForeColor = Color.LightGray;
        //    txtMatKhau.Text = "password";
        //    this.txtMatKhau.Enter += new System.EventHandler(this.txtMatKhau_Enter);
        //    this.txtMatKhau.Leave += new System.EventHandler(this.txtMatKhau_Leave);
        //}

        //private void txtTenDangNhap_Leave(object sender, EventArgs e)
        //{
        //    if (txtTenDangNhap.Text == "")
        //    {
        //        txtTenDangNhap.Text = "Không quá 35 kí tự";
        //        txtTenDangNhap.ForeColor = Color.Gray;
        //    }
        //}

        //private void txtTenDangNhap_Enter(object sender, EventArgs e)
        //{
        //    if (txtTenDangNhap.Text == "Không quá 35 kí tự")
        //    {
        //        txtTenDangNhap.Text = "";
        //        txtTenDangNhap.ForeColor = Color.Black;
        //    }
        //}

        //private void txtMatKhau_Enter(object sender, EventArgs e)
        //{
        //    if (txtMatKhau.Text == "password")
        //    {
        //        txtMatKhau.Text = "";
        //        txtMatKhau.ForeColor = Color.Black;
        //    }
        //}

        //private void txtMatKhau_Leave(object sender, EventArgs e)
        //{
        //    if (txtMatKhau.Text == "")
        //    {
        //        txtMatKhau.Text = "password";
        //        txtMatKhau.ForeColor = Color.Gray;
        //    }
        //}
        //#endregion

        #region BỎ KÍ TỰ THỪA
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
        #endregion

        #region SỰ KIỆN CÁC BUTTON
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            var tb = new HideNotifications();
            SqlConnection conn = dl.Connect();
            string sql = "select MaND, TenDangNhap,ChucVu from NguoiDung where TenDangNhap = '" + txtTenDangNhap.Text + "' and MatKhau = '" + txtMatKhau.Text + "'";
            DataTable dt = NguoiDung.GetDataTable(conn, sql);
            if (txtMatKhau.Text!="" && txtTenDangNhap.Text !="")
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        PhanQuyenNguoiDung.TenDangNhap = dr["TenDangNhap"].ToString();
                        PhanQuyenNguoiDung.ChucVu = dr["ChucVu"].ToString();
                        frmMain f = new frmMain();
                        f.OnOff(this.ParentForm);
                        this.Close();
                    }
                }
                else
                {
                    txtMatKhau.Clear();
                    txtTenDangNhap.Clear();
                    //TaoChuChim();
                    txtTenDangNhap.Focus();
                    lblThongBao.Text = "Tên tài khoản hoặc mật khẩu không chính xác";

                    tb.stt(lblThongBao);
                }
            }
            else
            {
                txtMatKhau.Clear();
                txtTenDangNhap.Clear();
                //TaoChuChim();
                txtTenDangNhap.Focus();
                lblThongBao.Text = "Vui lòng nhập đầy đủ thông tin!";
                
                tb.stt(lblThongBao);
            }
        
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        #endregion

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            lblThongBao.Text = "";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmServerName obj = new frmServerName();
            obj.ShowDialog();
        }

        #region UNIT TEST
        public string Login(string name, string pass)
        {
            if (name != "" && pass != "")
            {
                SqlConnection conn = dl.Connect();
                string sql = "select MaND, TenDangNhap,ChucVu from NguoiDung where TenDangNhap = '" + name + "' and MatKhau = '" + pass + "'";
                DataTable dt = NguoiDung.GetDataTable(conn, sql);
                if (dt.Rows.Count > 0)
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
        #endregion
    }

}
