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
    public partial class ThongKe : Form
    {
        DataTable dsThongKe;
        public ThongKe()
        {
            InitializeComponent();
        }
        private void ThongKe_Load(object sender, EventArgs e)
        {
            dsThongKe = XuLyDuLieu.docDuLieu("select B.MaBC as 'Mã Báo Cáo', B.MaNV as 'Mã Nhân Viên', B.SoLuongDH as 'Số Lượng ĐH', B.TongDT as 'Tổng Doanh Thu', B.Ngay as 'Ngày', C.SoDienT as 'DT' from BAO_CAO B, CHI_NHANH C Where B.MaCN = C.MaCN");
            DSTK.DataSource = dsThongKe;
            DataTable dt = XuLyDuLieu.docDuLieu("select * from CHI_NHANH");
            foreach (DataRow dr in dt.Rows)
            {
                comboBox2.Items.Add(dr["TenCN"].ToString());
            }
        }

        private void DSTK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DSTK.CurrentRow.Selected = true;
            }
            catch { }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = XuLyDuLieu.docDuLieu("select B.MaBC as 'Mã Báo Cáo', B.MaNV as 'Mã Nhân Viên', B.SoLuongDH as 'Số Lượng ĐH', B.TongDT as 'Tổng Doanh Thu', B.Ngay as 'Ngày', C.SoDienT as 'DT' from BAO_CAO B, CHI_NHANH C Where B.MaCN = C.MaCN and C.TenCN = '" + comboBox2.SelectedItem.ToString() + "'");
            foreach (DataRow dr in dt.Rows)
            {
                label5.Text = dr["DT"].ToString();
                DSTK.DataSource = dt;
                DSTK.Columns[5].Visible = false;
            }
        }
    }
}
