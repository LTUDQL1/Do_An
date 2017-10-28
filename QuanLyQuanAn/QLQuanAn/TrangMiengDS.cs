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
    public partial class TrangMiengDS : Form
    {
        DataTable MM;
        public TrangMiengDS()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LYATUN\SQLEXPRESS;Initial Catalog=QLQA;Integrated Security=True");

        private void ketNoiCSDL()
        {
            con.Open();
            string sql = "select * from MON_AN where Loai = 'Dessert'";
            SqlCommand com = new SqlCommand(sql, con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            DSMM.DataSource = dt;
        }
        private void TrangMiengDS_Load(object sender, EventArgs e)
        {
            MM = new DataTable();
            MM.Columns.Add("Stt");
            MM.Columns.Add("Tên Món Ăn");
            MM.Columns.Add("Đơn Giá");
            MM.Columns.Add("Thông Tin");

            DSMM.DataSource = MM;
            DSMM.ReadOnly = false;
            ketNoiCSDL();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Them T = new Them();
            T.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sua S = new Sua();
            S.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void DSMM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DSMM.CurrentRow.Selected = true;
            }
            catch { }
        }
    }
}
