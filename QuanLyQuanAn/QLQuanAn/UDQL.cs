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
    public partial class UDQL : Form
    {
        DataTable DT;
        public static string username = string.Empty;
        public UDQL()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LYATUN\SQLEXPRESS;Initial Catalog=QLQA;Integrated Security=True");
        private void ketNoiCSDL()
        {
            con.Open();
            string sql = "select * from DON_HANG";
            SqlCommand com = new SqlCommand(sql, con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            Store.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DangNhap A = new DangNhap();
            A.Show();
        }

        private void UDQL_Load(object sender, EventArgs e)
        {
            toolStrip2.Hide();
            DT = new DataTable();
            DT.Columns.Add("Stt");
            DT.Columns.Add("Tên món ăn");
            DT.Columns.Add("Số lượng");
            DT.Columns.Add("Đơn Giá");
            DT.Columns.Add("Thành Tiền");

            Store.DataSource = DT;
            Store.ReadOnly = false;
            ketNoiCSDL();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DangNhap D = new DangNhap();
            D.ShowDialog();
            if (!string.IsNullOrEmpty(username))
            {
                this.User.Text = username;
            }
            toolStrip1.Hide();
            toolStrip2.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            toolStrip2.Hide();
            toolStrip1.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ProFile A = new ProFile();
            A.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Them A = new Them();
            A.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sua A = new Sua();
            A.Show();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DangKy D = new DangKy();
            D.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MonMan M = new MonMan();
            M.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Bo B = new Bo();
            B.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Heo B = new Heo();
            B.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            MaTD A = new MaTD();
            A.Show();
            this.Hide();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            GhiChu A = new GhiChu();
            A.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MonThem A = new MonThem();
            A.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Ga B = new Ga();
            B.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            HaiSan B = new HaiSan();
            B.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Chay B = new Chay();
            B.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            TrangMieng B = new TrangMieng();
            B.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ThucUong B = new ThucUong();
            B.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ThongKe K = new ThongKe();
            K.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MonChay M = new MonChay();
            M.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TrangMiengDS D = new TrangMiengDS();
            D.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Salad S = new Salad();
            S.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Nuoc N = new Nuoc();
            N.Show();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            HoaDon hd = new HoaDon();
            hd.ShowDialog();
        }

        private void Store_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Store.CurrentRow.Selected = true;
            }
            catch { }
        }
    }
}
