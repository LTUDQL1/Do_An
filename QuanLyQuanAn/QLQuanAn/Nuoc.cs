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
    public partial class Nuoc : Form
    {
        DataTable dsNuoc;

        public Nuoc()
        {
            InitializeComponent();
        }
        private void Nuoc_Load(object sender, EventArgs e)
        {
            dsNuoc = XuLyDuLieu.docDuLieu("select * from MON_AN where Loai = 'Nuoc'");
            DSMM.DataSource = dsNuoc;
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
