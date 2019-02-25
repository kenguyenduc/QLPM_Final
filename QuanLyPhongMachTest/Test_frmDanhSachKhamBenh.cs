using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyPhongMach2;

namespace QuanLyPhongMachTest
{
    [TestClass]
    public class Test_frmDanhSachKhamBenh
    {
        [TestMethod]
        public void TestAddBN()
        {
            frmDanhSachKhamBenh frm = new frmDanhSachKhamBenh();
            Assert.AreEqual("successed", frm.AddBN("duongkhang", new DateTime(1997,12,8),"HCM", true));
            //tên bn trống
            Assert.AreEqual("failed", frm.AddBN("", new DateTime(1997, 12, 8), "HCM", true));
            //địa chỉ trống
            Assert.AreEqual("failed", frm.AddBN("duongkhang", new DateTime(1997, 12, 8), "", true));
            //ngày sinh sai
            Assert.AreEqual("failed", frm.AddBN("duongkhang", new DateTime(2222, 12, 8), "HCM", true));
        }
        [TestMethod]
        public void TestDeleteBN()
        {
            frmDanhSachKhamBenh frm = new frmDanhSachKhamBenh();
            
            Assert.AreEqual("successed", frm.DeleteBN(52));
            //sai mã
            Assert.AreEqual("failed", frm.DeleteBN(-1));
        }
        [TestMethod]
        public void TestUpdateBN()
        {
            frmDanhSachKhamBenh frm = new frmDanhSachKhamBenh();

            Assert.AreEqual("successed", frm.EditBN(48,"hihi", new DateTime(1997, 12, 8), "HCM", true));

            //sai mã
            Assert.AreEqual("failed", frm.EditBN(-2,"duongkhang", new DateTime(1997, 12, 8), "HCM", true));
            //sai ngày sinh
            Assert.AreEqual("failed", frm.EditBN(-2, "duongkhang", new DateTime(2222, 12, 8), "HCM", true));
        }
    }
}
