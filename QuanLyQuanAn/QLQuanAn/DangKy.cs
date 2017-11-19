using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanAn
{
    public partial class DangKy : Form
    {
        DataTable dsNV;
        DataTable dsCN;

        public DangKy()
        {
            InitializeComponent();
        }

        private void DangKy_Load(object sender, EventArgs e)
        {
            dsCN = XuLyDuLieu.docDuLieu("select * from CHI_NHANH");
            foreach (DataRow dr in dsCN.Rows)
            {
                tbcn.Items.Add(dr["MaCN"].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MaQL M = new MaQL();
            M.ShowDialog();
            if (M.DialogResult == DialogResult.OK)
            {
                dsNV = XuLyDuLieu.docDuLieu("Select * From NHAN_VIEN");
                DataRow cn = dsNV.NewRow();
                cn[0] = tbmanv.Text;
                cn[1] = tbcn.Text;
                cn[2] = tbtennv.Text;
                if (cbnam.Checked == true)
                {
                    cn[3] = "Nam";
                }
                if (cbnu.Checked == true)
                {
                    cn[3] = "Nữ";
                }
                cn[4] = tbsdt.Text;
                cn[5] = tbdc.Text;
                cn[6] = tbnamsinh.Text;
                cn[7] = tbtk.Text;
                cn[8] = tbmk.Text;
                dsNV.Rows.Add(cn);
                XuLyDuLieu.ghiDuLieu("NHAN_VIEN", dsNV);
            }
            this.Hide();
        }
    }
}
