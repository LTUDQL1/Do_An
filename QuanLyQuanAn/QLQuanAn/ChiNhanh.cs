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
    public partial class ChiNhanh : Form
    {
        DataTable dsCN;
        public ChiNhanh()
        {
            InitializeComponent();
        }
        private void ChiNhanh_Load(object sender, EventArgs e)
        {
            dsCN = XuLyDuLieu.docDuLieu("select * from CHI_NHANH");
            dataGridView1.DataSource = dsCN;
            dataGridView1.Columns[0].Visible = false;
        }

        private void btnChiNhanhExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView1.CurrentRow.Selected = true;
            }
            catch { }
        }
    }
}
