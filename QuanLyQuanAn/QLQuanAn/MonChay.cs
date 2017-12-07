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
    public partial class MonChay : Form
    {
        DataTable dsMC;
        DataTable dsCN;
        public MonChay()
        {
            InitializeComponent();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void MonChay_Load(object sender, EventArgs e)
        {
            loadDSChiNhanh();
            loadDSMA();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Them M = new Them();
            M.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sua S = new Sua();
            S.Show();
        }
        private void loadDSMA()
        {
            dsMC = XuLyDuLieu.docDuLieu("Select * from MON_AN ma,DANH_MUC_MON_AN dm where dm.MaDMMA = ma.MaDMMA and dm.TenDMMA = N'Món Chay' and ma.MaCN like N'" + cbDSCN.SelectedValue + "'");
            DSMM.DataSource = dsMC;
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
