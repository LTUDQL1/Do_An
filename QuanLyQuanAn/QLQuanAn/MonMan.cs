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
    public partial class MonMan : Form
    {
        DataTable dsMM;

        public MonMan()
        {
            InitializeComponent();
        }
        
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void MonMan_Load(object sender, EventArgs e)
        {
            dsMM = XuLyDuLieu.docDuLieu("Select * from MON_AN where Loai = 'MonMan'");
            DSMM.DataSource = dsMM;
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
