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

        private void btXacNhan_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(XuLyDuLieu.connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("DoiMatKhau", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@TaiKhoan", SqlDbType.Char));
            cmd.Parameters.Add(new SqlParameter("@MatKhau", SqlDbType.Char));
            cmd.Parameters.Add(new SqlParameter("@MatKhauMoi", SqlDbType.Char));

            cmd.Parameters["@TaiKhoan"].Value = txtTaiKhoan.Text;
            cmd.Parameters["@MatKhau"].Value = txtMKCu.Text;
            cmd.Parameters["@MatKhauMoi"].Value = txtMKMoi.Text;

            cmd.Parameters.Add("RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            if (txtMKMoi.Text == txtXacNhanMK.Text)
            {
                cmd.ExecuteNonQuery();

                int ReturnValueInt = Convert.ToInt32(cmd.Parameters["RETURN_VALUE"].Value);
                if (ReturnValueInt == 1)
                {
                    MessageBox.Show("Đổi mật khẩu thành công");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ không đúng");
                }
            }
            else
            {
                MessageBox.Show("Mật Khẩu Xác Nhận Không Đúng");
            }
            con.Close();
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(XuLyDuLieu.connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Info", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@DiaChi", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@DienThoai", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@TaiKhoan", SqlDbType.Char));

            cmd.Parameters["@DiaChi"].Value = txtDiaChi.Text;
            cmd.Parameters["@DienThoai"].Value = txtSDT.Text;
            cmd.Parameters["@TaiKhoan"].Value = txtTaiKhoan.Text;

            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
