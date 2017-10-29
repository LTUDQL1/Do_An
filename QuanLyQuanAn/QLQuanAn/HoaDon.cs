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
        public HoaDon()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=ERK\SQLEXPRESS;Initial Catalog=QLQA;Integrated Security=True");
        private void ketNoiCSDL()
        {
            con.Open();
            string sql = "select * from DAT_HANG";
            SqlCommand com = new SqlCommand(sql, con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dgvHoaDon.DataSource = dt;
        }
        DataTable DSHD = new DataTable();
        private void HoaDon_Load(object sender, EventArgs e)
        {
            DSHD.Columns.Add("STT");
            DSHD.Columns.Add("Ten Mon An");
            DSHD.Columns.Add("So luong");
            DSHD.Columns.Add("Don Gia");
            dgvHoaDon.DataSource = DSHD;
            ketNoiCSDL();
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
