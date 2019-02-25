using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QuanLyPhongMach2
{
    public partial class rptHoaDonThanhToan : DevExpress.XtraReports.UI.XtraReport
    {
        public rptHoaDonThanhToan()
        {
            InitializeComponent();
        }

        public void BinData()
        {
            lblNgayKham.DataBindings.Add("Text", DataSource, "ngayKham");
            lblHoTenBenhNhan.DataBindings.Add("Text", DataSource, "tenBN");
            lblTienKham.DataBindings.Add("Text", DataSource, "tienKham");
            lblTienThuoc.DataBindings.Add("Text", DataSource, "tienThuoc");

            lblLoaiBenh.DataBindings.Add("Text", DataSource, "loaiBenh");
            lblTrieuChung.DataBindings.Add("Text", DataSource, "trieuChung");

            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            lblNgayHienTai.Text = "" + day + "/" + month + "/" + year;
        }

    }
}
