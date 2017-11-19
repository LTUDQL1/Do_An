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
    public partial class HoaDon : Form
    {
        DataTable dsHD;

        public HoaDon()
        {
            InitializeComponent();
        }
        private void HoaDon_Load(object sender, EventArgs e)
        {
            dsHD = XuLyDuLieu.docDuLieu("select * from DAT_HANG");
            dgvHoaDon.DataSource = dsHD;
        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvHoaDon.CurrentRow.Selected = true;
            }
            catch { }
        }
        
    }
}
