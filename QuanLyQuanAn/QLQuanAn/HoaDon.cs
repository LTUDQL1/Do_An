using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoaDon
{
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
        }
        DataTable DSHD = new DataTable();
        private void Form1_Load(object sender, EventArgs e)
        {
          
            DSHD.Columns.Add("STT");
            DSHD.Columns.Add("Ten Mon An");
            DSHD.Columns.Add("So luong");
            DSHD.Columns.Add("Don Gia");
            DSHD.Columns.Add("Thanh Tien");
            dgvHD.DataSource = DSHD;
            
            //dgvHD.Columns["STT"].Visible = false
        }

       
       
    }
}
