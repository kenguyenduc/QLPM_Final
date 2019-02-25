using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyPhongMach2.DTO
{
    class ChiTietHoaDon
    {
        #region(Các thuộc tính và phương thức khởi tạo)
        public ChiTietHoaDon()
        { }
        public ChiTietHoaDon(string TenBN, DateTime NgayKham, int TienKham, int TienThuoc)
        {
            tienKham = TienKham;
            tenBN = TenBN;
            ngayKham = NgayKham;
            tienThuoc = TienThuoc;
        }

        string tenBN;

        public string TenBN
        {
            get { return tenBN; }
            set { tenBN = value; }
        }
        DateTime ngayKham;

        public DateTime NgayKham
        {
            get { return ngayKham; }
            set { ngayKham = value; }
        }

        int tienKham;

        public int TienKham
        {
            get { return tienKham; }
            set { tienKham = value; }
        }
        int tienThuoc;

        public int TienThuoc
        {
            get { return tienThuoc; }
            set { tienThuoc = value; }
        }
        #endregion
    }
}
