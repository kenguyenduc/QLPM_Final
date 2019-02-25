using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyPhongMach2.DAO;
using QuanLyPhongMach2.DTO;
using QuanLyPhongMach2;

namespace QuanLyPhongMachTest
{
    [TestClass]
    public class Test_frmQuanLyNguoiDung
    {

        [TestInitialize]

        //[TestMethod]
        //public void TestThemNguoiDung()
        //{
        //    frmQuanLyNguoiDung frm = new frmQuanLyNguoiDung();
        //    // TenND, NgaySinh, GioiTinh, DiaChi, SDT, TenDangNhap, MatKhau, ChucVu

        //    Assert.AreEqual("successed", frm.Add("Lê Dương Khang", new DateTime(1997,12,8), true, "HCM", "0935134402", "khang1234", "khangld", "Nhân Viên"));
        //    //Tên người dùng để trống
        //    Assert.AreEqual("failed", frm.Add("", new DateTime(1997, 12, 8), true, "HCM", "0935134402", "khang123", "khangld", "Admin"));
        //    //Ngày sinh lớn hơn thời gian hiện tại
        //    Assert.AreEqual("failed", frm.Add("Lê Dương Khang", new DateTime(2997, 12, 8), true, "HCM", "0935134402", "khang123", "khangld", "Admin"));
        //    //Tên đăng nhập để trống
        //    Assert.AreEqual("failed", frm.Add("Lê Dương Khang", new DateTime(1997, 12, 8), true, "HCM", "0935134402", "", "khangld", "Admin"));
        //    //Mật khẩu để trống
        //    Assert.AreEqual("failed", frm.Add("Lê Dương Khang", new DateTime(1997, 12, 8), true, "HCM", "0935134402", "khang123", "", "Admin"));

        //}

        [TestMethod]
        public void TestXoaNguoiDung()
        {
            frmQuanLyNguoiDung frm = new frmQuanLyNguoiDung();
            
            //Xoá người dùng thành công
            Assert.AreEqual("successed", frm.Delete("123", "Nhân Viên"));

            //Không xoá được người dùng là admin
            Assert.AreEqual("failed", frm.Delete("khang123", "Admin"));

        }

        [TestMethod]
        public void TestSuaNguoiDung()
        {
            frmQuanLyNguoiDung frm = new frmQuanLyNguoiDung();

            //Cập nhập người dùng thành công
            Assert.AreEqual("successed", frm.Edit("Lê Dương Khang", new DateTime(1997, 12, 8), true, "HCM", "0935134402", "khangld", "khangld", "Admin"));

            //Tên người dùng để trống
            Assert.AreEqual("failed", frm.Add("", new DateTime(1997, 12, 8), true, "HCM", "0935134402", "khang123", "khangld", "Admin"));
            //Ngày sinh lớn hơn thời gian hiện tại
            Assert.AreEqual("failed", frm.Add("Lê Dương Khang", new DateTime(2997, 12, 8), true, "HCM", "0935134402", "khang123", "khangld", "Admin"));
            //Tên đăng nhập để trống
            Assert.AreEqual("failed", frm.Add("Lê Dương Khang", new DateTime(1997, 12, 8), true, "HCM", "0935134402", "", "khangld", "Admin"));
        }
    }
}
