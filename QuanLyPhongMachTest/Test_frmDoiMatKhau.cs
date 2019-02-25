using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyPhongMach2;

namespace QuanLyPhongMachTest
{
    [TestClass]
    public class Test_frmDoiMatKhau
    {
        [TestMethod]
        public void TestChangePassWord()
        {
            frmDoiMatKhau frm = new frmDoiMatKhau();
            Assert.AreEqual("successed", frm.ChangePassword("khangld", "khangld", "khangld", "khangld"));
        }
    }
}
