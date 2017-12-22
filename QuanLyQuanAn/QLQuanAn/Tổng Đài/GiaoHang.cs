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
    public partial class GiaoHang : Form
    {
        public GiaoHang()
        {
            InitializeComponent();
        }

        private void GiaoHang_Load(object sender, EventArgs e)
        {
            DataTable dt = XuLyDuLieu.docDuLieu("Select G.MaGH, K.HoTen, G.NgayGH, D.NgayDH, M.TenMA, DH.SoLuong From GIAO_HANG G, DAT_HANG D, DON_HANG DH, MON_AN M, KHACH_HANG K Where K.MaKH = D.MaKH and M.MaMA = DH.MaMA and G.MaDH = D.MaDH and D.MaDH = DH.MaDH");
            dgvGiaoHang.DataSource = dt;
        }
    }
}
