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
    public partial class TongDai : Form
    {
        public static string MaKH = string.Empty;
        string tenDanhMuc;
        string Ma;
        string MaDH;
        int Tong = 0;

        public TongDai()
        {
            InitializeComponent();
            LoadChiNhanh();
        }
        void LoadChiNhanh()
        {
            DataTable listChiNhanh = XuLyDuLieu.docDuLieu("SELECT TenCN FROM dbo.CHI_NHANH");
            cbChiNhanh.DataSource = listChiNhanh;
            cbChiNhanh.DisplayMember = "TenCN";
        }
        void LoadMonAnTheoDanhMuc(string tenDanhMuc)
        {
            DataTable listFood = XuLyDuLieu.docDuLieu(string.Format("SELECT M.TenMA FROM dbo.MON_AN M, dbo.CHI_NHANH C WHERE M.MaCN = C.MaCN and M.Loai = '{0}' AND C.TenCN like N'{1}'", tenDanhMuc, cbChiNhanh.Text));
            cbMonAn.DataSource = listFood;
            cbMonAn.DisplayMember = "TenMA";
            //cbMonAn.ValueMember = "Tên Món";
        }
        private void cbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            tenDanhMuc = string.Empty;
            if (cbDanhMuc.Text == "Món Mặn")
            {
                tenDanhMuc = "MonMan";
            }
            if (cbDanhMuc.Text == "Món Chay")
            {
                tenDanhMuc = "MonChay";
            }
            if (cbDanhMuc.Text == "Nước")
            {
                tenDanhMuc = "Nuoc";
            }
            if (cbDanhMuc.Text == "Tráng Miệng")
            {
                tenDanhMuc = "Dessert";
            }
            if (cbDanhMuc.Text == "Thêm")
            {
                tenDanhMuc = "Them";
            }
            LoadMonAnTheoDanhMuc(tenDanhMuc);
        }
        private void btnThemMon_Click(object sender, EventArgs e)
        {
            DataTable db = XuLyDuLieu.docDuLieu("Select * From DAT_HANG Where MaKH = '" + dsKhachHang.MaKH + "'");
            foreach (DataRow r in db.Rows)
            {
                MaDH = r[0].ToString();
            }
            DataTable dm = XuLyDuLieu.docDuLieu("Select * From MON_AN Where TenMA like N'" + cbMonAn.Text + "'");
            foreach(DataRow d in dm.Rows)
            {
                Ma = d[0].ToString();
            }
            DataTable dt = XuLyDuLieu.docDuLieu("Select * From DON_HANG");
            DataRow dr = dt.NewRow();
            dr[1] = MaDH;
            dr[2] = Ma;
            dr[3] = nbudSoLuong.Value;
            dt.Rows.Add(dr);
            XuLyDuLieu.ghiDuLieu("DON_HANG", dt);
            Form_Load();
        }
        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btChiNhanh_Click(object sender, EventArgs e)
        {
            ChiNhanh frmChiNhanh = new ChiNhanh();
            frmChiNhanh.Show();
        }
        private void TongDai_Load(object sender, EventArgs e)
        {
            btnThemMon.Enabled = false;
            btTaoMoi.Enabled = false;
            DataTable db = XuLyDuLieu.docDuLieu("Select * From DAT_HANG");
            foreach (DataRow r in db.Rows)
            {
                MaDH = r[0].ToString();
            }
            DataTable dT = XuLyDuLieu.docDuLieu("Select * From KHACH_HANG");
            foreach (DataRow r in dT.Rows)
            {
                MaKH = r[0].ToString();
            }
            Form_Load();
        }
        void Form_Load()
        {
            DataTable db = XuLyDuLieu.docDuLieu("Select * From DAT_HANG Where MaKH = '" + dsKhachHang.MaKH + "'");
            foreach (DataRow r in db.Rows)
            {
                MaDH = r[0].ToString();
            }
            Tong = 0;
            DataTable dt = XuLyDuLieu.docDuLieu("Select D.MaDonHang, D.MaDH, M.TenMA, M.DonGia, D.SoLuong, M.DonGia * D.SoLuong as ThanhTien From DON_HANG D, MON_AN M, DAT_HANG DH Where D.MaDH = DH.MaDH and D.MaMA = M.MaMA and DH.MaDH = '" + MaDH + "'");
            foreach (DataRow dr in dt.Rows)
            {
                Tong += int.Parse(dr[5].ToString());
            }
            txtTongTien.Text = Tong.ToString();
            DataTable dtDonHang = XuLyDuLieu.docDuLieu("Select D.MaDonHang, D.MaDH, M.TenMA, M.DonGia, D.SoLuong, M.DonGia * D.SoLuong as ThanhTien From DON_HANG D, MON_AN M, DAT_HANG DH Where D.MaDH = DH.MaDH and D.MaMA = M.MaMA and DH.MaDH = '" + MaDH + "'");
            dgvGioHang.DataSource = dtDonHang;
            dgvGioHang.Columns[0].Visible = false;
            dgvGioHang.Columns[1].Visible = false;
        }

        private void cbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = XuLyDuLieu.docDuLieu("Select M.TenMA From MON_AN M, CHI_NHANH C Where M.MaCN = C.MaCN and C.TenCN like N'" + cbChiNhanh.Text + "' and M.Loai = '" + tenDanhMuc + "'");
            cbMonAn.DataSource = dt;
        }

        private void btMoi_Click(object sender, EventArgs e)
        {
            dsKhachHang KH = new dsKhachHang();
            KH.ShowDialog();

            SqlConnection conn = new SqlConnection(XuLyDuLieu.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("proc_IDAT_HANG", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MaNV", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@MaKH", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@MaCN", SqlDbType.Char));
            cmd.Parameters.Add(new SqlParameter("@MaBan", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@NgayDH", SqlDbType.DateTime));
            cmd.Parameters.Add(new SqlParameter("@GhiChu", SqlDbType.NVarChar));

            cmd.Parameters["@MaNV"].Value = UDQL.MaNV;
            cmd.Parameters["@MaKH"].Value = dsKhachHang.MaKH;
            cmd.Parameters["@MaCN"].Value = DBNull.Value;
            cmd.Parameters["@MaBan"].Value = DBNull.Value;
            cmd.Parameters["@NgayDH"].Value = DateTime.Now;
            cmd.Parameters["@GhiChu"].Value = DBNull.Value;
            cmd.ExecuteNonQuery();
            conn.Close();
            MaKH = dsKhachHang.MaKH;
            Form_Load();
            btnThemMon.Enabled = true;
            btTaoMoi.Enabled = true;
        }

        private void btGuiDonHang_Click(object sender, EventArgs e)
        {
            DataTable dt = XuLyDuLieu.docDuLieu("Select * From GIAO_HANG");
            DataRow dr = dt.NewRow();
            dr[1] = DateTime.Now;
            dr[2] = MaDH;
            dt.Rows.Add(dr);
            XuLyDuLieu.ghiDuLieu("GIAO_HANG", dt);
            MaKH = string.Empty;
            Form_Load();
            btnThemMon.Enabled = false;
            btTaoMoi.Enabled = false;
        }

        private void btTaoMoi_Click(object sender, EventArgs e)
        {
            DataTable dt = XuLyDuLieu.docDuLieu("Select * From DAT_HANG");
            DataRow dr = dt.NewRow();
            dr[1] = UDQL.MaNV;
            dr[2] = dsKhachHang.MaKH;
            dr[3] = DBNull.Value;
            dr[4] = DBNull.Value;
            dr[5] = DateTime.Now;
            dr[6] = DBNull.Value;
            dt.Rows.Add(dr);
            XuLyDuLieu.ghiDuLieu("DAT_HANG", dt);

            DataTable db = XuLyDuLieu.docDuLieu("Select * From DAT_HANG Where MaKH = '" + dsKhachHang.MaKH + "'");
            foreach (DataRow r in db.Rows)
            {
                MaDH = r[0].ToString();
            }
            Form_Load();
        }

        private void btGiaoHang_Click(object sender, EventArgs e)
        {
            GiaoHang GH = new GiaoHang();
            GH.ShowDialog();
        }
    }
}
