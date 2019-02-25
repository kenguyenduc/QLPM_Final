using QuanLyPhongMach2.DAO;
using System;
using System.Windows.Forms;

namespace QuanLyPhongMach2
{
    public partial class frmServerName : Form
    {
        public frmServerName()
        {
            InitializeComponent();
            btnSet.Enabled = false;
            btnTest.Focus();
            txtServer.Text = Environment.MachineName;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string servername = txtServer.Text;
            string connString = @"Data Source="+servername+@";Initial Catalog=QLPM;Integrated Security=True";
            DuLieu duLieu = new DuLieu();
            if(!duLieu.MoKetNoi(connString))
            {
                MessageBox.Show("Không thành công");
            }
            else
            {
                MessageBox.Show("Thành công");
                btnSet.Enabled = true;
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            string servername = txtServer.Text;
            string connString = @"Data Source=" + servername + @";Initial Catalog=QLPM;Integrated Security=True";
            DuLieu.SetConn(connString);
            this.Close();
        }

        #region UINT TEST
        public string ConnectionString(string severName)
        {
            string connString = @"Data Source=" + severName + @";Initial Catalog=QLPM;Integrated Security=True";
            DuLieu duLieu = new DuLieu();
            if (!duLieu.MoKetNoi(connString))
            {
                return "failed";
            }
            else
            {
                return "successed";
            }
        }
        #endregion
    }
}
