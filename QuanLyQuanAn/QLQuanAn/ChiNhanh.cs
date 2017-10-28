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
        public ChiNhanh()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LYATUN\SQLEXPRESS;Initial Catalog=QLQA;Integrated Security=True");
        private void ketNoiCSDL()
        {
            con.Open();
            string sql = "select * from CHI_NHANH";
            SqlCommand com = new SqlCommand(sql, con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }
        
        private void ChiNhanh_Load(object sender, EventArgs e)
        {
            ketNoiCSDL();
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
