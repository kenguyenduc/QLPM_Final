using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyPhongMach2;

namespace QuanLyPhongMachTest
{
    [TestClass]
    public class Test_frmCapNhatThongTinND
    {
        [TestMethod]
        public void TestUpdateNguoiDung()
        {
            frmCapNhatThongTinND frm = new frmCapNhatThongTinND();

            //Cập nhập người dùng thành công
            Assert.AreEqual("successed", frm.Update("Lê Dương Khang", new DateTime(1997, 12, 8), true, "HCM", "0935134402", "khangld", "khangld", "Admin"));

            //Tên người dùng để trống
            Assert.AreEqual("failed", frm.Update("", new DateTime(1997, 12, 8), true, "HCM", "0935134402", "khang123", "khangld", "Admin"));
            //Ngày sinh lớn hơn thời gian hiện tại
            Assert.AreEqual("failed", frm.Update("Lê Dương Khang", new DateTime(2997, 12, 8), true, "HCM", "0935134402", "khang123", "khangld", "Admin"));
        }
    }
}
