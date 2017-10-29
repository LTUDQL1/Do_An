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
        public ThongKe()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=ERK\SQLEXPRESS;Initial Catalog=QLQA;Integrated Security=True");
        private void ketNoiCSDL()
        {
            con.Open();
            string sql = "select MaBC as 'Mã Báo Cáo', MaNV as 'Mã Nhân Viên', SoLuongDH as 'Số Lượng ĐH', TongDT as 'Tổng Doanh Thu', Ngay as 'Ngày' from BAO_CAO";
            SqlCommand com = new SqlCommand(sql, con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            DSTK.DataSource = dt;
        }
        private void ThongKe_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from CHI_NHANH";
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox2.Items.Add(dr["TenCN"].ToString());
            }
            con.Close();
            ketNoiCSDL();
        }

        private void DSTK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DSTK.CurrentRow.Selected = true;
            }
            catch { }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select B.MaBC as 'Mã Báo Cáo', B.MaNV as 'Mã Nhân Viên', B.SoLuongDH as 'Số Lượng ĐH', B.TongDT as 'Tổng Doanh Thu', B.Ngay as 'Ngày', C.SoDienT as 'DT' from BAO_CAO B, CHI_NHANH C Where B.MaCN = C.MaCN and C.TenCN = '" + comboBox2.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                label5.Text = dr["DT"].ToString();
                DSTK.DataSource = dt;
                DSTK.Columns[5].Visible = false;
            }
            con.Close();
        }
    }
}
