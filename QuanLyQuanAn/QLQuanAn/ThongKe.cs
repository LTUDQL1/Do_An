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
    public partial class ThongKe : Form
    {
        public ThongKe()
        {
            InitializeComponent();
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            DataTable TK = new DataTable();
            TK.Columns.Add("ID");
            TK.Columns.Add("Mã NV");
            TK.Columns.Add("Số Lượng ĐH");
            TK.Columns.Add("Tổng DThu");
            TK.Columns.Add("Chi Phí Phát Sinh Thêm");
            DSTK.DataSource = TK;
            DSTK.ReadOnly = true;
        }
    }
}
