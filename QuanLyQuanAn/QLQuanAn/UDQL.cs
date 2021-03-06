﻿using System;
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
    public partial class UDQL : Form
    {
        public static string TaiKhoan = string.Empty;
        public static string MaCN = string.Empty;
        public static int Ma;
        public static int MaBan;
        public static string MaNV = string.Empty;
        DataTable dtDonHang;
        DataView dv;
        DataTable dt;
        DataTable dsChiNhanh;
        DataTable dsBan;
        DataView ds;

        public UDQL()
        {
            InitializeComponent();
        }

        private void btTongDai_Click(object sender, EventArgs e)
        {
            this.Hide();
            TongDai TD = new TongDai();
            TD.Show();
        }

        private void btThongKe_Click(object sender, EventArgs e)
        {
            ThongKe TK = new ThongKe();
            TK.ShowDialog();
        }

        private void btExit2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btProfile_Click(object sender, EventArgs e)
        {
            ProFile PF = new ProFile();
            PF.ShowDialog();
        }

        private void btDangXuat_Click(object sender, EventArgs e)
        {
            dgvDSBan.Controls.Clear();
            dgvDSBan.Hide();
            dgvDSBan.Enabled = false;
            tsMenu1.Show();
            tsMenu2.Hide();
            tp2.Enabled = false;
            tp3.Enabled = false;
        }

        private void UDQL_Load(object sender, EventArgs e)
        {
            dgvDSBan.Enabled = false;
            dgvDSBan.Hide();
            btGhiChu.Enabled = false;
            btMoi.Enabled = false;
            pnMonAn.Enabled = false;
            Form_Load();
            tp2.Enabled = false;
            tp3.Enabled = false;
        }

        void Load_Ban()
        {
            dgvDSBan.Controls.Clear();
            int i = 1;
            int j = 1;
            int z = 1;
            int y = 1;
            dt = XuLyDuLieu.docDuLieu("Select * From BAN Where MaCN = '" + MaCN + "'");
            foreach (DataRow dr in dt.Rows)
            {
                Button N = new Button();
                N.Width = 60;
                N.Height = 60;
                N.Top = 10 * z;
                N.Left = 10 * i;
                N.BackColor = Color.Aqua;
                //N.Name = "BT" + i;
                N.Tag = string.Format("{0}", dr[0].ToString());
                N.Text = dr[1].ToString();
                this.dgvDSBan.Controls.Add(N);
                N.Click += new EventHandler(Ban_Click);
                N.DialogResult = DialogResult.OK;
                i += 6;
                j++;
                if (j == 7 * y)
                {
                    y++;
                    i = 1;
                    j = 1;
                    z = 7;
                }
            }
        }

        private void Ban_Click(object sender, EventArgs e)
        {
            MaBan = int.Parse(((Button)sender).Tag.ToString());
            Form_Load();
            btMoi.Enabled = true;
            btGhiChu.Enabled = true;
            pnMonAn.Enabled = false;
        }

        void Form_Load()
        {
            dt = XuLyDuLieu.docDuLieu("Select N.HoTen, C.TenCN, C.MaCN, N.MaNV From NHAN_VIEN N,CHI_NHANH C Where N.MaCN = C.MaCN and TaiKhoan = '" + TaiKhoan + "'");
            foreach (DataRow dr in dt.Rows)
            {
                txtTen.Text = dr[0].ToString();
                HoaDon.HoTenNV = dr[0].ToString();
                lbChiNhanh.Text = dr[1].ToString();
                MaCN = dr[2].ToString();
                MaNV = dr[3].ToString();
            }
            int M = 0;
            dt = XuLyDuLieu.docDuLieu("Select * From DAT_HANG Where MaBan = " + MaBan);
            foreach (DataRow dr in dt.Rows)
            {
                M = int.Parse(dr[0].ToString());
            }
            Ma = M;
            Load_Ban();
            dtDonHang = XuLyDuLieu.docDuLieu("Select D.MaDonHang, D.MaDH, M.TenMA, M.DonGia, D.SoLuong, M.DonGia * D.SoLuong as ThanhTien From DON_HANG D, MON_AN M, DAT_HANG DH Where D.MaDH = DH.MaDH and D.MaMA = M.MaMA and MaBan = " + MaBan);
            dv = new DataView(dtDonHang);
            dgvGioHang.DataSource = dv;
            dgvGioHang.Columns[0].Visible = false;
            dgvGioHang.Columns[1].Visible = false;

            dsChiNhanh = XuLyDuLieu.docDuLieu("Select * From Chi_Nhanh");
            ds = new DataView(dsChiNhanh);
            dgvChiNhanh.DataSource = ds;
        }

        private void btMoi_Click(object sender, EventArgs e)
        {
            dt = XuLyDuLieu.docDuLieu("Select * From DAT_HANG");
            DataRow dr = dt.NewRow();
            dr[1] = MaNV;
            dr[2] = DBNull.Value;
            dr[3] = MaCN;
            dr[4] = MaBan;
            dr[5] = DateTime.Now;
            dr[6] = DBNull.Value;
            dt.Rows.Add(dr);
            XuLyDuLieu.ghiDuLieu("DAT_HANG", dt);
            Form_Load();
            pnMonAn.Enabled = true;
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap DN = new DangNhap();
            DN.ShowDialog();
            if (DN.DialogResult == DialogResult.OK)
            {
                tsMenu1.Hide();
                tsMenu2.Show();
                tp2.Enabled = true;
                tp3.Enabled = true;
                dgvDSBan.Enabled = true;
                dgvDSBan.Show();
                Form_Load();
            }
        }

        private void btDangKy_Click(object sender, EventArgs e)
        {
            DangKy DK = new DangKy();
            DK.ShowDialog();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btMonMan_Click(object sender, EventArgs e)
        {
            pnMonAn.Controls.Clear();
            int i = 1;
            int j = 1;
            int z = 1;
            int y = 1;
            DataTable dt = XuLyDuLieu.docDuLieu("Select M.* From MON_AN M,CHI_NHANH C Where M.MaCN = C.MaCN and M.Loai like N'MonMan' and C.TenCN like N'" + lbChiNhanh.Text + "'");
            foreach(DataRow dr in dt.Rows)
            {
                Button N = new Button();
                N.Width = 60;
                N.Height = 60;
                N.Top = 10 * z;
                N.Left = 10 * i;
                N.BackColor = Color.SkyBlue;
                //N.Name = "BT" + i;
                N.Tag = string.Format("{0}", dr[0].ToString());
                N.Text = dr[1].ToString();
                this.pnMonAn.Controls.Add(N);
                N.Click += new EventHandler(N_Click);
                i += 6;
                j++;
                if (j == 8 * y)
                {
                    y++;
                    i = 1;
                    j = 1;
                    z = 7;
                }
            }
        }

        private void btMonChay_Click(object sender, EventArgs e)
        {
            pnMonAn.Controls.Clear();
            int i = 1;
            int j = 1;
            int z = 1;
            int y = 1;
            DataTable dt = XuLyDuLieu.docDuLieu("Select M.* From MON_AN M,CHI_NHANH C Where M.MaCN = C.MaCN and M.Loai like N'MonChay' and C.TenCN like N'" + lbChiNhanh.Text + "'");
            foreach (DataRow dr in dt.Rows)
            {
                Button N = new Button();
                N.Width = 60;
                N.Height = 60;
                N.Top = 10 * z;
                N.Left = 10 * i;
                N.BackColor = Color.SkyBlue;
                //N.Name = "BT" + i;
                N.Tag = string.Format("{0}", dr[0].ToString());
                N.Text = dr[1].ToString();
                this.pnMonAn.Controls.Add(N);
                N.Click += new EventHandler(N_Click);
                i += 6;
                j++;
                if (j == 8 * y)
                {
                    y++;
                    i = 1;
                    j = 1;
                    z = 7;
                }
            }
        }

        private void btTrangMieng_Click(object sender, EventArgs e)
        {
            pnMonAn.Controls.Clear();
            int i = 1;
            int j = 1;
            int z = 1;
            int y = 1;
            DataTable dt = XuLyDuLieu.docDuLieu("Select M.* From MON_AN M,CHI_NHANH C Where M.MaCN = C.MaCN and M.Loai like N'TrangMieng' and C.TenCN like N'" + lbChiNhanh.Text + "'");
            foreach (DataRow dr in dt.Rows)
            {
                Button N = new Button();
                N.Width = 60;
                N.Height = 60;
                N.Top = 10 * z;
                N.Left = 10 * i;
                N.BackColor = Color.SkyBlue;
                //N.Name = "BT" + i;
                N.Tag = string.Format("{0}", dr[0].ToString());
                N.Text = dr[1].ToString();
                this.pnMonAn.Controls.Add(N);
                N.Click += new EventHandler(N_Click);
                i += 6;
                j++;
                if (j == 8 * y)
                {
                    y++;
                    i = 1;
                    j = 1;
                    z = 7;
                }
            }
        }

        private void btNuoc_Click(object sender, EventArgs e)
        {
            pnMonAn.Controls.Clear();
            int i = 1;
            int j = 1;
            int z = 1;
            int y = 1;
            DataTable dt = XuLyDuLieu.docDuLieu("Select M.* From MON_AN M,CHI_NHANH C Where M.MaCN = C.MaCN and M.Loai like N'Nuoc' and C.TenCN like N'" + lbChiNhanh.Text + "'");
            foreach (DataRow dr in dt.Rows)
            {
                Button N = new Button();
                N.Width = 60;
                N.Height = 60;
                N.Top = 10 * z;
                N.Left = 10 * i;
                N.BackColor = Color.SkyBlue;
                //N.Name = "BT" + i;
                N.Tag = string.Format("{0}", dr[0].ToString());
                N.Text = dr[1].ToString();
                this.pnMonAn.Controls.Add(N);
                N.Click += new EventHandler(N_Click);
                i += 6;
                j++;
                if (j == 8 * y)
                {
                    y++;
                    i = 1;
                    j = 1;
                    z = 7;
                }
            }
        }

        private void btSalad_Click(object sender, EventArgs e)
        {
            pnMonAn.Controls.Clear();
            int i = 1;
            int j = 1;
            int z = 1;
            int y = 1;
            DataTable dt = XuLyDuLieu.docDuLieu("Select M.* From MON_AN M,CHI_NHANH C Where M.MaCN = C.MaCN and M.Loai like N'Salad' and C.TenCN like N'" + lbChiNhanh.Text + "'");
            foreach (DataRow dr in dt.Rows)
            {
                Button N = new Button();
                N.Width = 60;
                N.Height = 60;
                N.Top = 10 * z;
                N.Left = 10 * i;
                N.BackColor = Color.SkyBlue;
                //N.Name = "BT" + i;
                N.Tag = string.Format("{0}", dr[0].ToString());
                N.Text = dr[1].ToString();
                this.pnMonAn.Controls.Add(N);
                N.Click += new EventHandler(N_Click);
                i += 6;
                j++;
                if (j == 8 * y)
                {
                    y++;
                    i = 1;
                    j = 1;
                    z = 7;
                }
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            pnMonAn.Controls.Clear();
            int i = 1;
            int j = 1;
            int z = 1;
            int y = 1;
            DataTable dt = XuLyDuLieu.docDuLieu("Select M.* From MON_AN M,CHI_NHANH C Where M.MaCN = C.MaCN and M.Loai like N'Them' and C.TenCN like N'" + lbChiNhanh.Text + "'");
            foreach (DataRow dr in dt.Rows)
            {
                Button N = new Button();
                N.Width = 60;
                N.Height = 60;
                N.Top = 10 * z;
                N.Left = 10 * i;
                N.BackColor = Color.SkyBlue;
                //N.Name = "BT" + i;
                N.Tag = string.Format("{0}", dr[0].ToString());
                N.Text = dr[1].ToString();
                this.pnMonAn.Controls.Add(N);
                N.Click += new EventHandler(N_Click);
                i += 6;
                j++;
                if (j == 8 * y)
                {
                    y++;
                    i = 1;
                    j = 1;
                    z = 7;
                }
            }
        }
        private void N_Click(object sender, EventArgs e)
        {
            dtDonHang = XuLyDuLieu.docDuLieu("Select * From DON_HANG");
            DataRow dr = dtDonHang.NewRow();
            dr[1] = Ma;
            dr[2] = ((Button)sender).Tag;
            dr[3] = 1;
            dtDonHang.Rows.Add(dr);
            XuLyDuLieu.ghiDuLieu("DON_HANG", dtDonHang);
            Form_Load();
        }
        private void btGhiChu_Click(object sender, EventArgs e)
        {
            GhiChu GC = new GhiChu();
            GC.ShowDialog();
        }

        private void btXacNhan_Click(object sender, EventArgs e)
        {
            pnMonAn.Enabled = false;
            HoaDon HD = new HoaDon();
            HD.ShowDialog();
            if (HD.DialogResult == DialogResult.OK)
            {
                SqlConnection conn = new SqlConnection(XuLyDuLieu.connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("proc_DATHANGBAN", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@MaBanC", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@MaBan", SqlDbType.Int));

                cmd.Parameters["@MaBanC"].Value = UDQL.MaBan;
                cmd.Parameters["@MaBan"].Value = DBNull.Value;

                cmd.ExecuteNonQuery();
                conn.Close();

                Form_Load();
                btGhiChu.Enabled = false;
                btMoi.Enabled = false;
            }
        }

        private void MonMan_Click(object sender, EventArgs e)
        {
            MonMan frmMonMan = new MonMan();
            frmMonMan.Show();
        }

        private void MonChay_Click(object sender, EventArgs e)
        {
            MonChay frmMonChay = new MonChay();
            frmMonChay.Show();
        }

        private void Dessert_Click(object sender, EventArgs e)
        {
            TrangMiengDS frm = new TrangMiengDS();
            frm.Show();
        }

        private void Nuoc_Click(object sender, EventArgs e)
        {
            Nuoc frm = new Nuoc();
            frm.Show();
        }

        private void Salad_Click(object sender, EventArgs e)
        {
            Salad frm = new Salad();
            frm.Show();
        }
        private void btSuaBan_Click_1(object sender, EventArgs e)
        {
            if (dgvBan.SelectedRows.Count > 0)
            {
                DataRow dr = ((DataRowView)dgvBan.SelectedRows[0].DataBoundItem).Row;
                dr[1] = this.txtTenBan.Text;
                dr[3] = this.cbTrangThai.Text;
                XuLyDuLieu.ghiDuLieu("BAN", dsBan);
            }
            Form_Load();
        }
        private void btThemBan_Click(object sender, EventArgs e)
        {
            DataRow cn = ((DataRowView)dgvChiNhanh.SelectedRows[0].DataBoundItem).Row;
            DataRow dr = dsBan.NewRow();
            dr[1] = this.txtTenBan.Text;
            dr[2] = cn[0].ToString();
            dr[3] = this.cbTrangThai.Text;
            dsBan.Rows.Add(dr);
            XuLyDuLieu.ghiDuLieu("BAN", dsBan);
            Form_Load();
        }


        private void btXoaBan_Click(object sender, EventArgs e)
        {
            MaQL M = new MaQL();
            M.ShowDialog();
            if (M.DialogResult == DialogResult.OK)
            {
                if (dgvBan.SelectedRows.Count > 0)
                {
                    DataRow dr = ((DataRowView)dgvBan.SelectedRows[0].DataBoundItem).Row;
                    SqlConnection conn = new SqlConnection(XuLyDuLieu.connectionString);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("proc_XoaBan", conn);
                    cmd.Parameters.Add(new SqlParameter("@Ma", SqlDbType.Char));
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters["@Ma"].Value = dr[0];
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            Form_Load();
            LoadDSBan(txtMaCN.Text);
        }
       
        private void dgvChiNhanh_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dgvChiNhanh.SelectedRows.Count > 0)
            {
                DataRow dr = ((DataRowView)dgvChiNhanh.SelectedRows[0].DataBoundItem).Row;
                this.txtMaCN.Text = dr[0].ToString();
                this.txtTenCN.Text = dr[1].ToString();
                this.txtSoLuongBanCN.Text = dr[2].ToString();
                this.txtDiaChiCN.Text = dr[3].ToString();
                this.txtSDTCN.Text = dr[4].ToString();
                this.txtQuanLyCN.Text = dr[5].ToString();
                LoadDSBan(dr[0].ToString());
                MaCN = dr[0].ToString();
                //XuLyDuLieu.ghiDuLieu("CHI_NHANH", dsChiNhanh);

            }
        }

        private void btLamMoiCN_Click_1(object sender, EventArgs e)
        {
            this.txtMaCN.Text = "";
            this.txtTenCN.Text = "";
            this.txtSoLuongBanCN.Text = "";
            this.txtDiaChiCN.Text = "";
            this.txtSDTCN.Text = "";
            this.txtQuanLyCN.Text = "";
            
        }

        private void btSuaCN_Click(object sender, EventArgs e)
        {
            if (dgvChiNhanh.SelectedRows.Count > 0)
            {
                DataRow dr = ((DataRowView)dgvChiNhanh.SelectedRows[0].DataBoundItem).Row;
                dr[0] = this.txtMaCN.Text;
                dr[1] = this.txtTenCN.Text;
                dr[2] = this.txtSoLuongBanCN.Text;
                dr[3] = this.txtDiaChiCN.Text;
                dr[4] = this.txtSDTCN.Text;
                dr[5] = this.txtQuanLyCN.Text;
                XuLyDuLieu.ghiDuLieu("CHI_NHANH", dsChiNhanh);
            }
            Load_Ban();
        }

        private void btThemCN_Click(object sender, EventArgs e)
        {
            DataRow dr = dsChiNhanh.NewRow();
            dr[0] = this.txtMaCN.Text;
            dr[1] = this.txtTenCN.Text;
            dr[2] = this.txtSoLuongBanCN.Text;
            dr[3] = this.txtDiaChiCN.Text;
            dr[4] = this.txtSDTCN.Text;
            dr[5] = this.txtQuanLyCN.Text;
            dsChiNhanh.Rows.Add(dr);
            XuLyDuLieu.ghiDuLieu("CHI_NHANH", dsChiNhanh);
            Form_Load();
        }

        private void btXoaCN_Click_1(object sender, EventArgs e)
        {
            MaQL A = new MaQL();
            A.ShowDialog();
            if (A.DialogResult == DialogResult.OK)
            {
                if (dgvChiNhanh.SelectedRows.Count > 0)
                {
                    DataRow dr = ((DataRowView)dgvChiNhanh.SelectedRows[0].DataBoundItem).Row;
                    SqlConnection conn = new SqlConnection(XuLyDuLieu.connectionString);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("proc_XoaCN", conn);
                    cmd.Parameters.Add(new SqlParameter("@maCN", SqlDbType.Char));
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters["@maCN"].Value = dr[0];
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            Form_Load();

        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.SelectedRows.Count > 0)
            {
                DataRow cn = ((DataRowView)dgvGioHang.SelectedRows[0].DataBoundItem).Row;

                SqlConnection conn = new SqlConnection(XuLyDuLieu.connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("proc_XoaDonHang", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaDH", SqlDbType.Int));
                cmd.Parameters["@MaDH"].Value = cn["MaDonHang"];
                cmd.ExecuteNonQuery();
                conn.Close();
 
                cn.Delete();
            }
        }
        private void LoadDSBan(string MaCN)
        {

            string str = "Select * From BAN Where MaCN like N'%"+MaCN.ToString()+"'" ;
            dsBan = XuLyDuLieu.docDuLieu(str);
            dgvBan.DataSource = dsBan;
            dgvBan.Columns[0].Visible = false;
            dgvBan.Columns[2].Visible = false;
        }
        private void THEM_Click(object sender, EventArgs e)
        {
            Them frm = new Them();
            frm.Show();
        }

        private void btLamMoiBan_Click_1(object sender, EventArgs e)
        {
            this.txtTenBan.Text = "";
            this.cbTrangThai.Text = "False";
        }

        private void dgvBan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBan.SelectedRows.Count > 0)
            {
                DataRow dr = ((DataRowView)dgvBan.SelectedRows[0].DataBoundItem).Row;
                this.txtTenBan.Text = dr[1].ToString();
                this.cbTrangThai.Text = dr[3].ToString();
                XuLyDuLieu.ghiDuLieu("CHI_NHANH", dsBan);

            }
        }
    }
}
