using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyPhongMach2;

namespace QuanLyPhongMachTest
{
    [TestClass]
    public class Test_frmDanhSachBenhNhan
    {
        [TestMethod]
        public void TestSearchBenhBanh()
        {
            frmDanhSachBenhNhan frm = new frmDanhSachBenhNhan();

            Assert.AreEqual("successed", frm.Search("khang"));
            //không có trong dữ liệu
            Assert.AreEqual("failed", frm.Search("kkkkkkkkkkkkk"));
            //để trống
            Assert.AreEqual("failed", frm.Search(""));

        }
    }
}
