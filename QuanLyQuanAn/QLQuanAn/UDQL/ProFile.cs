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
    public partial class ProFile : Form
    {
        DataTable dt;

        public ProFile()
        {
            InitializeComponent();
        }

        private void ProFile_Load(object sender, EventArgs e)
        {
            dt = XuLyDuLieu.docDuLieu("Select * From NHAN_VIEN Where TaiKhoan = '" + UDQL.TaiKhoan + "'");
            foreach(DataRow dr in dt.Rows)
            {
                txtHoTen.Text = dr[2].ToString();
                txtDiaChi.Text = dr[5].ToString();
                txtSDT.Text = dr[4].ToString();
                txtTaiKhoan.Text = dr[7].ToString();
                txtMatKhau.Text = dr[8].ToString();
                if (dr[3].ToString() == "Nam")
                {
                    cbNam.CheckState = CheckState.Checked;
                }
                else
                {
                    cbNu.CheckState = CheckState.Checked;
                }
            }
        }
    }
}
