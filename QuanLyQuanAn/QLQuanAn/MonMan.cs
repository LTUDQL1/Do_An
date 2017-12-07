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
        DataTable dsCN;
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
            loadDSChiNhanh();
            loadDSMA();
            
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
        private void loadDSMA()
        {
            dsMM = XuLyDuLieu.docDuLieu("Select * from MON_AN ma,DANH_MUC_MON_AN dm where dm.MaDMMA = ma.MaDMMA and dm.TenDMMA = N'Món Mặn' and ma.MaCN like N'" + cbDSCN.SelectedValue + "'");
            DSMM.DataSource = dsMM;
        }
        private void loadDSChiNhanh()
        {
            
            string str = "select * from CHI_NHANH";
            dsCN = XuLyDuLieu.docDuLieu(str);
            cbDSCN.DataSource = dsCN;
            cbDSCN.ValueMember = "MaCN";
            cbDSCN.DisplayMember = "TenCN";
        }
        private void cbDSCN_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDSMA();
        }
    }
}
