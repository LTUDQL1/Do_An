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
    public partial class MonChay : Form
    {
        DataTable dsMC;

        public MonChay()
        {
            InitializeComponent();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void MonChay_Load(object sender, EventArgs e)
        {
            dsMC = XuLyDuLieu.docDuLieu("Select * from MON_AN where Loai = 'MonChay'");
            DSMM.DataSource = dsMC;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Them M = new Them();
            M.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sua S = new Sua();
            S.Show();
        }
    }
}
