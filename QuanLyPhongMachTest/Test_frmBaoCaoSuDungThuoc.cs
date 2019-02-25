using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyPhongMach2;

namespace QuanLyPhongMachTest
{
    [TestClass]
    public class Test_frmBaoCaoSuDungThuoc
    {
        [TestMethod]
        public void TestViewReport()
        {
            frmBaoCaoSuDungThuoc frm = new frmBaoCaoSuDungThuoc();

            Assert.AreEqual("successed", frm.Report(1, 2019));
            Assert.AreEqual("failed", frm.Report(2,2019));
            Assert.AreEqual("failed", frm.Report(1,2020));
        }
    }
}
