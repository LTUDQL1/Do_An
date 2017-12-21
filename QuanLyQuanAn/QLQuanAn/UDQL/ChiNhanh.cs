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
            LoadChiNhanh();
        }

        void LoadChiNhanh()
        {
            DataTable listChiNhanh = XuLyDuLieu.docDuLieu("SELECT TenCN AS N'Tên Chi Nhánh', SoLuongBan AS N'Số Lượng Bàn', DiaChi AS N'Địa Chỉ', SoDienT AS N'Điện Thoại', QuanLy AS N'Quản Lý' FROM dbo.CHI_NHANH");
            dgvChiNhanh.DataSource = listChiNhanh;
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
