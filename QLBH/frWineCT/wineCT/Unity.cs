using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Form1
{
    class Unity
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataAdapter data;

        public SqlConnection Opendata()
        {
            con = new SqlConnection(@"Data Source=PC2017082619BMY\SQLEXPRESS;Initial Catalog=database2;Integrated Security=True");
            return con;
        }

        // tao ket noi toi database 
        public static void Openconnec()
        {
            // tạo ra chuỗi kết nối
            string sql = @"Data Source=PC2017082619BMY\SQLEXPRESS;Initial Catalog=database2;Integrated Security=True";
            try
            {
                con = new SqlConnection(sql);
                con.Open();
            }catch (Exception ex)
            {
                
            }
        }

        // tạo hàm ngắt kết nối với database
        public static void Close()
        {
            // đóng kết nối với database
            con.Close();
            // ngắt kết nối với database
            con.Dispose();
            con = null;
        }
        public static DataTable getDatatable(string sql)
        {
            cmd = new SqlCommand(sql, con);
            data = new SqlDataAdapter();
            data.SelectCommand = cmd;
            DataTable table = new DataTable();
            data.Fill(table);
            return table;
        }

        // TẠO HÀM THỰC THI ĐỂ THAO TAO TRUY VẤN TRÊN DATABASE
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        public static int Excute(string sql)
        {
            try
            {
                Openconnec();
                cmd.CommandText = sql;

                return cmd.ExecuteNonQuery();
            }
            catch { return -1;  }
            finally { Close(); }
            //Close();
        }

        internal static SqlConnection Opentata()
        {
            throw new NotImplementedException();
        }
    }
}
