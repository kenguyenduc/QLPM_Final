using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongMach2.DTO
{
    public class ChiTietBaoCaoDoanhThu
    {
        #region(Các thuộc tính và phương thức khởi tạo)
        public ChiTietBaoCaoDoanhThu(int STT, string NgayKham, int SoBN, int DoanhThu)
        {
            sTT = STT;
            ngayKham = NgayKham;
            soBN = SoBN;
            doanhThu = DoanhThu;
        }
        int sTT;

        public int STT
        {
            get { return sTT; }
            set { sTT = value; }
        }
        string ngayKham;

        public string NgayKham
        {
            get { return ngayKham; }
            set { ngayKham = value; }
        }


        int soBN;

        public int SoBN
        {
            get { return soBN; }
            set { soBN = value; }
        }
        int doanhThu;

        public int DoanhThu
        {
            get { return doanhThu; }
            set { doanhThu = value; }
        }
        #endregion
    }
}
