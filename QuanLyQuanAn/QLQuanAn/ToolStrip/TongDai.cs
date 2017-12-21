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
    public partial class TongDai : Form
    {
        public TongDai()
        {
            InitializeComponent();
            LoadDanhMucMonAn();
            LoadChiNhanh();
        }



        void LoadDanhMucMonAn()
        {
            DataTable listDanhMuc = XuLyDuLieu.docDuLieu("SELECT DISTINCT Loai FROM dbo.MON_AN");
            cbDanhMuc.DataSource = listDanhMuc  ;
            cbDanhMuc.DisplayMember = "Loai";
            //cbDanhMuc.ValueMember = "Danh Mục";
        }

        void LoadChiNhanh()
        {
            DataTable listChiNhanh = XuLyDuLieu.docDuLieu("SELECT TenCN FROM dbo.CHI_NHANH");
            cbChiNhanh.DataSource = listChiNhanh;
            cbChiNhanh.DisplayMember = "TenCN";
        }

        void LoadMonAnTheoDanhMuc(string tenDanhMuc)
        {
            DataTable listFood = XuLyDuLieu.docDuLieu(string.Format("SELECT TenMA FROM dbo.MON_AN WHERE Loai = '{0}'", tenDanhMuc));
            cbMonAn.DataSource = listFood;
            cbMonAn.DisplayMember = "TenMA";
            //cbMonAn.ValueMember = "Tên Món";
        }

        private void cbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tenDanhMuc = cbDanhMuc.Text;
            LoadMonAnTheoDanhMuc(tenDanhMuc);
        }
        

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btChiNhanh_Click(object sender, EventArgs e)
        {
            ChiNhanh frmChiNhanh = new ChiNhanh();
            frmChiNhanh.Show();
        }
    }
}
