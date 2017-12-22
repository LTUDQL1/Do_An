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
    public partial class dsKhachHang : Form
    {
        public static string MaKH = string.Empty;
        DataTable dt;
        public dsKhachHang()
        {
            InitializeComponent();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            KhachHang KH = new KhachHang();
            KH.ShowDialog();
            Form_Load();
        }

        private void dsKhachHang_Load(object sender, EventArgs e)
        {
            Form_Load();
        }

        void Form_Load()
        {
            dt = XuLyDuLieu.docDuLieu("Select * From KHACH_HANG");
            dgvKhachHang.DataSource = dt;
            dgvKhachHang.Columns[0].Visible = false;
        }

        private void dgvKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                DataRow cn = ((DataRowView)dgvKhachHang.SelectedRows[0].DataBoundItem).Row;
                MaKH = cn[0].ToString();
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                DataRow cn = ((DataRowView)dgvKhachHang.SelectedRows[0].DataBoundItem).Row;
                SqlConnection conn = new SqlConnection(XuLyDuLieu.connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("proc_DKHACH_HANG", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaKH", SqlDbType.Int));
                cmd.Parameters["@MaKH"].Value = int.Parse(cn[0].ToString());
                cmd.ExecuteNonQuery();
                conn.Close();
                Form_Load();
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                DataRow cn = ((DataRowView)dgvKhachHang.SelectedRows[0].DataBoundItem).Row;
                XuLyDuLieu.ghiDuLieu("KHACH_HANG", dt);
            }
            Form_Load();
        }
    }
}
