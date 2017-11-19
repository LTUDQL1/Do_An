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
        DataTable TM;
        DataView dvTM;

        public TrangMiengDS()
        {
            InitializeComponent();
        }
        private void TrangMiengDS_Load(object sender, EventArgs e)
        {
            TM = XuLyDuLieu.docDuLieu("Select * From MON_AN where Loai = 'Dessert'");
            dvTM = new DataView(TM);
            DSMM.DataSource = dvTM;
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
