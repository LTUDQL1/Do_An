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
        SqlConnection con = new SqlConnection(@"Data Source=LYATUN\SQLEXPRESS;Initial Catalog=QLQA;Integrated Security=True");
        private void ketNoiCSDL()
        {
            con.Open();
            string sql = "select * from CHI_NHANH";
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
            DataTable TK = new DataTable();
            TK.Columns.Add("ID");
            TK.Columns.Add("Mã NV");
            TK.Columns.Add("Số Lượng ĐH");
            TK.Columns.Add("Tổng DThu");
            TK.Columns.Add("Chi Phí Phát Sinh Thêm");
            DSTK.DataSource = TK;
            DSTK.ReadOnly = true;
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
    }
}
