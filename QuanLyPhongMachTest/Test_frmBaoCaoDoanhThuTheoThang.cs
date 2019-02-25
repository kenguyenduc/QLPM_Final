using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyPhongMach2;

namespace QuanLyPhongMachTest
{
    [TestClass]
    public class Test_frmBaoCaoDoanhThuTheoThang
    {
        [TestMethod]
        public void TestViewReport()
        {
            frmBaoCaoDoanhThuTheoThang frm = new frmBaoCaoDoanhThuTheoThang();

            Assert.AreEqual("successed", frm.Report(1, 2019));
            Assert.AreEqual("failed", frm.Report(2, 2019));
            Assert.AreEqual("failed", frm.Report(1, 2020));
        }
    }
}
