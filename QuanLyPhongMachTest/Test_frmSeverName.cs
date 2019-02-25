using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyPhongMach2;

namespace QuanLyPhongMachTest
{
    [TestClass]
    public class Test_frmSeverName
    {
        [TestMethod]
        public void TestConnectionString()
        {
            frmServerName frm = new frmServerName();
            Assert.AreEqual("successed", frm.ConnectionString("DESKTOP-6PFRNM4"));
            Assert.AreEqual("failed", frm.ConnectionString("DESKTOP-abc"));
        }
    }
}
