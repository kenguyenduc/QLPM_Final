using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanLyPhongMach2
{
    class HideNotifications
    {
        public void stt(Label lblThongBao)
        {
            var t = new Timer();
            t.Interval = 1000;
            t.Tick += (s, e) =>
            {
                lblThongBao.Text = "";
                t.Stop();
            };
            t.Start();
        }
    }
}
