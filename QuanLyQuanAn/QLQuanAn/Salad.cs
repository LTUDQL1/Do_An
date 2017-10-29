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
    public partial class Salad : Form
    {
        public Salad()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=ERK\SQLEXPRESS;Initial Catalog=QLQA;Integrated Security=True");
        private void ketNoiCSDL()
        {
            con.Open();
            string sql = "select MaMA as 'Mã Món Ăn', TenMA as 'Tên Món Ăn', DonGia as 'Đơn Giá', ThongTin as 'Thông tin', MaCN as 'Mã Chi Nhánh', MaDMMA as 'Mã DMMA' from MON_AN where Loai = 'Salad'";
            SqlCommand com = new SqlCommand(sql, con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            DSMM.DataSource = dt;
        }
        private void Salad_Load(object sender, EventArgs e)
        {
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
    }
}
