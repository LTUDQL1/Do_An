using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLQuanAn
{
    public partial class HoaDon : Form
    {
        public static string HoTenNV = string.Empty;
        public static string MaHD = string.Empty;
        int TongTien = 0;
        int Ma;
        DataTable dt;

        public HoaDon()
        {
            InitializeComponent();
        }

        private void btInHoaDon_Click(object sender, EventArgs e)
        {
            dt = XuLyDuLieu.docDuLieu("Select * From HOA_DON");
            DataRow dr = dt.NewRow();
            dr[0] = Ma + 1;
            dr[1] = UDQL.Ma;
            dr[2] = TongTien;
            dt.Rows.Add(dr);
            XuLyDuLieu.ghiDuLieu("HOA_DON", dt);
            this.Hide();
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            dt = XuLyDuLieu.docDuLieu("Select MaHD From HOA_DON");
            foreach(DataRow n in dt.Rows)
            {
                Ma = int.Parse(n[0].ToString());
            }
            dt = XuLyDuLieu.docDuLieu("Select M.DonGia * D.SoLuong as ThanhTien From DON_HANG D, MON_AN M, DAT_HANG DH Where D.MaDH = DH.MaDH and D.MaMA = M.MaMA and MaBan = " + UDQL.MaBan);
            foreach (DataRow dn in dt.Rows)
            {
                TongTien += int.Parse(dn[0].ToString());
            }
            lbToDay.Text = (DateTime.Now).ToString();
            dt = XuLyDuLieu.docDuLieu("Select M.TenMA, M.DonGia, D.SoLuong, M.DonGia * D.SoLuong as ThanhTien From DON_HANG D, MON_AN M, DAT_HANG DH Where D.MaDH = DH.MaDH and D.MaMA = M.MaMA and MaBan = " + UDQL.MaBan);
            dgvHoaDon.DataSource = dt;
            lbMaHD.Text = (Ma + 1).ToString();
            lbTenNV.Text = HoTenNV;
            dt = XuLyDuLieu.docDuLieu("Select TenBan From BAN Where MaBan =" + UDQL.MaBan);
            foreach(DataRow d in dt.Rows)
            {
                lbTenBan.Text = d[0].ToString();
            }
            lblSotien.Text = TongTien.ToString();
        }
    }
}
