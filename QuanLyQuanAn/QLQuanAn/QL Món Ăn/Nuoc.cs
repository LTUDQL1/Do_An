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
    public partial class Nuoc : Form
    {
        DataTable dsMM;
        DataTable dsCN;
        DataView dvdsMM;
        static int dem = 1;
        public Nuoc()
        {
            InitializeComponent();
            cbbChiNhanh.SelectedIndexChanged += new EventHandler(cbbChiNhanh_SelectedIndexChanged);
            txtTimKiem.TextChanged += new EventHandler(txtTimKiem_TextChanged);
            dgvNuoc.SelectionChanged += new EventHandler(dgvMonMan_SelectionChanged);
            txtDonGia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtDonGia_keypress);
        }
        public void txtDonGia_keypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        public void loadDSMM()
        {
            string str = "Select * from MON_AN where Loai = 'Nuoc' and MaCN like N'%"+cbbChiNhanh.SelectedValue+"'";
            dsMM = XuLyDuLieu.docDuLieu(str);
            dgvNuoc.DataSource = dsMM;
            dgvNuoc.Columns[0].Visible = false;
            dgvNuoc.Columns[5].Visible = false;
            
        }

        public void Nuoc_Load(object sender, EventArgs e)
        {
            loadDSMM();
            loadDSChiNhanh();
        }
        private void loadDSChiNhanh()
        {
            
            string str = "select * from CHI_NHANH";
            dsCN = XuLyDuLieu.docDuLieu(str);
            cbbChiNhanh.DataSource = dsCN;
            cbbChiNhanh.ValueMember = "MaCN";
            cbbChiNhanh.DisplayMember = "TenCN";
        }
        private void dgvMonMan_SelectionChanged(object sender,EventArgs e)
        {
            if (dgvNuoc.SelectedRows.Count > 0)
            {
                DataRow cn = ((DataRowView)dgvNuoc.SelectedRows[0].DataBoundItem).Row;
                txtTen.Text = cn[1].ToString();
                txtDonGia.Text = cn[2].ToString();
                txtThongTin.Text = cn[3].ToString();
                
            }
        }
        private void cbbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDSMM();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dvdsMM = new DataView(dsMM);
            if (txtTimKiem.Text == "")
            {
                dvdsMM.RowFilter = "";
            }
            else
            {
                dvdsMM.RowFilter = "TenMA like'%" + txtTimKiem.Text + "%'";
            }
            dgvNuoc.DataSource = dvdsMM;

        }
        
        private void btThem_Click(object sender, EventArgs e)
        {
            string MaMA = "MA0001";
            while (XuLyDuLieu.kiemtratontai(MaMA))
            {
                if (dem < 10)
                    MaMA = "MA000" + dem.ToString();
                else if (dem < 100)
                    MaMA = "MA00" + dem.ToString();
                else if (dem < 1000)
                    MaMA = "MA0" + dem.ToString();
                else
                    MaMA = "MA" + dem.ToString();
                dem++;
            }

            DataRow cn = dsMM.NewRow();
            cn[0] = MaMA;
            cn[1] = txtTen.Text;
            cn[2] = txtDonGia.Text;
            cn[3] = txtThongTin.Text;
            cn[4] = "Nuoc";
            cn[5] = cbbChiNhanh.SelectedValue;
            dsMM.Rows.Add(cn);
            XuLyDuLieu.ghiDuLieu("MON_AN", dsMM);
            loadDSMM();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
           
            if ( dgvNuoc.SelectedRows.Count > 0)
            {
                DataRow cn = ((DataRowView)dgvNuoc.SelectedRows[0].DataBoundItem).Row;
                String noidung = String.Format("Anh/chi co muon xoa món '{0}' khong?", cn[1]);
                DialogResult dr = MessageBox.Show(noidung, "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    cn.Delete();
                    XuLyDuLieu.ghiDuLieu("MON_AN", dsMM);
                }
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
           if(dgvNuoc.SelectedRows.Count >0)
           {
               DataRow cn = ((DataRowView)dgvNuoc.SelectedRows[0].DataBoundItem).Row;
               cn[1] = txtTen.Text;
               cn[2] = txtDonGia.Text;
               cn[3] = txtThongTin.Text;

               XuLyDuLieu.ghiDuLieu("MON_AN", dsMM);
           }
        }

    }
}