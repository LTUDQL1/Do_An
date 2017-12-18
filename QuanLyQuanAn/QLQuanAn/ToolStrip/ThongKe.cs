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
    public partial class ThongKe : Form
    {
        DataTable dt;

        public ThongKe()
        {
            InitializeComponent();
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            dt = XuLyDuLieu.docDuLieu("Select TenCN From CHI_NHANH");
            foreach(DataRow dr in dt.Rows)
            {
                cbbChiNhanh.Items.Add(dr[0].ToString());
            }

            dt = XuLyDuLieu.docDuLieu("Select N.HoTen, C.TenCN, B.SoLuongDH, B.TongDT, B.Ngay From BAO_CAO B, NHAN_VIEN N, CHI_NHANH C Where B.MaNV = N.MaNV and B.MaCN = C.MaCN");
            dgvThongKe.DataSource = dt;
        }

        private void cbbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = XuLyDuLieu.docDuLieu("Select C.SoDienT, N.HoTen, B.SoLuongDH, B.TongDT, B.Ngay From BAO_CAO B, NHAN_VIEN N, CHI_NHANH C Where B.MaNV = N.MaNV and B.MaCN = C.MaCN and C.TenCN like N'" + cbbChiNhanh.Text + "'");
            dgvThongKe.DataSource = dt;
            dgvThongKe.Columns[0].Visible = false;
            foreach(DataRow dr in dt.Rows)
            {
                lbSDT.Text = dr[0].ToString();
            }
        }

        private void cbbThongKe_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = XuLyDuLieu.docDuLieu("Select N.HoTen, B.SoLuongDH, B.TongDT From BAO_CAO B, NHAN_VIEN N, CHI_NHANH C Where B.MaNV = N.MaNV and B.MaCN = C.MaCN and C.TenCN like N'" + cbbChiNhanh.Text + "' and B.Ngay like N'%" + cbbThongKe.Text + "%'");
            dgvThongKe.DataSource = dt;
        }
    }
}
