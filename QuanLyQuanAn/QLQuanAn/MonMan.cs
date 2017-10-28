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
        DataTable MM;
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
            MM = new DataTable();
            MM.Columns.Add("Stt");
            MM.Columns.Add("Tên Món Ăn");
            MM.Columns.Add("Đơn Giá");
            MM.Columns.Add("Thông Tin");

            DSMM.DataSource = MM;
            DSMM.ReadOnly = false;
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
