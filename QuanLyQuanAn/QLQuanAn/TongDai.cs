using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanAn
{
    public partial class TongDai : Form
    {
        DataTable DT;
        public TongDai()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UDQL A = new UDQL();
            A.Show();
            this.Hide();
        }

        private void TongDai_Load(object sender, EventArgs e)
        {
            DT = new DataTable();
            DT.Columns.Add("Stt");
            DT.Columns.Add("Tên");
            DT.Columns.Add("Đơn GIá");
            DT.Columns.Add("Số Lượng");
            DT.Columns.Add("Thành Tiền");

            Store.DataSource = DT;
            Store.ReadOnly = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bo B = new Bo();
            B.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Heo H = new Heo();
            H.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ga G = new Ga();
            G.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            HaiSan H = new HaiSan();
            H.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Chay C = new Chay();
            C.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ThucUong T = new ThucUong();
            T.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            TrangMieng T = new TrangMieng();
            T.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MonThem M = new MonThem();
            M.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            GhiChu G = new GhiChu();
            G.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thành Công");
        }

        private void tsbChiNhanh_Click(object sender, EventArgs e)
        {
            ChiNhanh cn = new ChiNhanh();
            cn.ShowDialog();
        }
    }
}
