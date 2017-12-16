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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(XuLyDuLieu.connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("DangNhap", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@TaiKhoan", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@MatKhau", SqlDbType.VarChar));
            cmd.Parameters["@TaiKhoan"].Value = txtTaiKhoan.Text;
            cmd.Parameters["@MatKhau"].Value = txtMatKhau.Text;

            cmd.Parameters.Add("RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            cmd.ExecuteNonQuery();
            con.Close();

            int ReturnValueInt = Convert.ToInt32(cmd.Parameters["RETURN_VALUE"].Value);
            if (ReturnValueInt == 1)
            {
                UDQL.TaiKhoan = txtTaiKhoan.Text;
                MessageBox.Show("Đăng nhập thành công");
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");
                this.DialogResult = DialogResult.No;
            }
        }
    }
}
