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
    public partial class GhiChu : Form
    {
        DataTable dt;

        public GhiChu()
        {
            InitializeComponent();
        }

        private void btXacNhan_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(XuLyDuLieu.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("proc_DATHANG", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@MaDH", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@MaKH", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@GhiChu", SqlDbType.NVarChar));

            cmd.Parameters["@MaDH"].Value = UDQL.Ma;
            cmd.Parameters["@MaKH"].Value = DBNull.Value;
            cmd.Parameters["@GhiChu"].Value = txtGhiChu.Text;

            cmd.ExecuteNonQuery();
            conn.Close();

            this.Hide();
        }

        private void GhiChu_Load(object sender, EventArgs e)
        {
            dt = XuLyDuLieu.docDuLieu("Select GhiChu From DAT_HANG Where MaDH = " + UDQL.Ma + "and MaBan = " + UDQL.MaBan);
            foreach(DataRow dr in dt.Rows)
            {
                txtGhiChu.Text = dr[0].ToString();
            }
        }
    }
}
