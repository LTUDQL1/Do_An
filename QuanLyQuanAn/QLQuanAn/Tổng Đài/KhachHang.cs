using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanAn
{
    public partial class KhachHang : Form
    {
        DataTable dt;

        public KhachHang()
        {
            InitializeComponent();
        }

        private void btXacNhan_Click(object sender, EventArgs e)
        {
            dt = XuLyDuLieu.docDuLieu("Select * From KHACH_HANG");
            DataRow dr = dt.NewRow();
            dr[2] = txtTenKH.Text;
            dr[1] = txtSDTKH.Text;
            dr[3] = txtDiaChiKH.Text;
            dt.Rows.Add(dr);
            XuLyDuLieu.ghiDuLieu("KHACH_HANG", dt);
            this.Hide();
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {

        }
    }
}
