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
    public partial class KhachHang : Form
    {
        DataTable dsKH;

        public KhachHang()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dsKH = XuLyDuLieu.docDuLieu("Select * From KHACH_HANG");
            DataRow cn = dsKH.NewRow();
            cn[0] = textBox2.Text;
            cn[1] = textBox1.Text;
            cn[2] = textBox3.Text;
            dsKH.Rows.Add(cn);
            XuLyDuLieu.ghiDuLieu("KHACH_HANG", dsKH);
            MessageBox.Show("Thành Công");
            this.Hide();
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {

        }
    }
}
