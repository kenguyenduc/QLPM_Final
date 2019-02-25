using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyPhongMach2;

namespace QuanLyPhongMachTest
{
    [TestClass]
    public class Test_frmDangNhap
    {
        [TestMethod]
        public void TestLogin()
        {
            frmDangNhap frm = new frmDangNhap();
            Assert.AreEqual("successed", frm.Login("khangld", "khangld"));
            Assert.AreEqual("failed", frm.Login("", "khangld"));
            Assert.AreEqual("failed", frm.Login("khangld", ""));
            Assert.AreEqual("failed", frm.Login("12345", "12445"));
        }
    }
}
