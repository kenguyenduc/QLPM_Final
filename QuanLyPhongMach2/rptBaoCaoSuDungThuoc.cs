using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QuanLyPhongMach2
{
    public partial class rptBaoCaoSuDungThuoc : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBaoCaoSuDungThuoc()
        {
            InitializeComponent();
        }
        public void BinData()
        {
            //lblMaNhanVien.DataBindings.Add("Text", DataSource, "manv")
            //lblTenNhanVien.DataBindings.Add("Text", DataSource, "tennv")
            //lblNoiSinh.DataBindings.Add("Text", DataSource, "tinhthanh")
            //lblNgaySinh.DataBindings.Add("Text", DataSource, "ngaysinh").FormatString = "{0:dd/MM/yyyy}"
            //lblDiaChi.DataBindings.Add("Text", DataSource, "diachi1")
            lblStt.DataBindings.Add("Text", DataSource, "STT");
            lblTenThuoc.DataBindings.Add("Text", DataSource, "TenThuoc");
            lblDonViTinh.DataBindings.Add("Text", DataSource, "DonVi");
            lblSoLuong.DataBindings.Add("Text", DataSource, "TongSoLuong");
            lblSoLanDung.DataBindings.Add("Text", DataSource, "SoLanDung");
        }

    }
}
