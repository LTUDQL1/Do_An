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
    public partial class DangKy : Form
    {
        DataTable dt;
        string Ma = string.Empty;

        public DangKy()
        {
            InitializeComponent();
        }

        private void DangKy_Load(object sender, EventArgs e)
        {
            dt = XuLyDuLieu.docDuLieu("Select TenCN From CHI_NHANH");
            foreach(DataRow dr in dt.Rows)
            {
                txtChiNhanh.Items.Add(dr[0].ToString());
            }
        }

        private void btXacNhan_Click(object sender, EventArgs e)
        {
            MaQL M = new MaQL();
            M.ShowDialog();
            if (M.DialogResult == DialogResult.OK)
            {
                dt = XuLyDuLieu.docDuLieu("Select MaCN From CHI_NHANH Where TenCN like N'" + txtChiNhanh.Text + "'");
                foreach (DataRow dr in dt.Rows)
                {
                    Ma = dr[0].ToString();
                }

                // Store
                SqlConnection con = new SqlConnection(XuLyDuLieu.connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("DangKy", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaCN", SqlDbType.Char));
                cmd.Parameters.Add(new SqlParameter("@HoTen", SqlDbType.NVarChar));
                cmd.Parameters.Add(new SqlParameter("@GioiTinh", SqlDbType.Char));
                cmd.Parameters.Add(new SqlParameter("@DienThoai", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@DiaChi", SqlDbType.NVarChar));
                cmd.Parameters.Add(new SqlParameter("@NgaySinh", SqlDbType.DateTime));
                cmd.Parameters.Add(new SqlParameter("@TaiKhoan", SqlDbType.Char));
                cmd.Parameters.Add(new SqlParameter("@MatKhau", SqlDbType.Char));

                cmd.Parameters["@MaCN"].Value = Ma;
                cmd.Parameters["@HoTen"].Value = txtHoTen.Text;
                if (cbNam.CheckState == CheckState.Checked)
                {
                    cmd.Parameters["@GioiTinh"].Value = cbNam.Text;
                }
                else
                {
                    cmd.Parameters["@GioiTinh"].Value = cbNu.Text;
                }
                cmd.Parameters["@DienThoai"].Value = txtSDT.Text;
                cmd.Parameters["@DiaChi"].Value = txtDiaChi.Text;
                cmd.Parameters["@NgaySinh"].Value = txtNgaySinh.Text;
                cmd.Parameters["@TaiKhoan"].Value = txtTaiKhoan.Text;
                cmd.Parameters["@MatKhau"].Value = txtMatKhau.Text;

                cmd.Parameters.Add("RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                con.Close();

                int ReturnValueInt = Convert.ToInt32(cmd.Parameters["RETURN_VALUE"].Value);
                if (ReturnValueInt == 1)
                {
                    MessageBox.Show("Đăng ký thành công");
                    this.Hide();
                }
                else
                    MessageBox.Show("Tài khoản đã tồn tại");    
            }     
        }
    }
}
