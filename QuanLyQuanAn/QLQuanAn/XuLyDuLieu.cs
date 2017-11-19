using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QLQuanAn
{
    class XuLyDuLieu
    {
        public static String NameServerSQL = @"DESKTOP-SINDORL\SQLEXPRESS";
        public static String connectionString = "Data Source= " + NameServerSQL + ";Initial Catalog=QLQA;Integrated Security=True";

        public static DataTable docDuLieu(String sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connectionString);
            adapter.Fill(dt);
            return dt;
        }
        public static void ghiDuLieu(String nameTB, DataTable dt)
        {
            string sql = "Select * From " + nameTB;
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connectionString);
            SqlCommandBuilder sqlcb = new SqlCommandBuilder(adapter);
            adapter.Update(dt);
            adapter.Dispose();
        }
    }
}
