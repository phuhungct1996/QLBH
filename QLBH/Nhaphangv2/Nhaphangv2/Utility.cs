using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Nhaphangv2
{
    class Utility
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataAdapter da;

        public SqlConnection openDB()
        {
            con = new SqlConnection(@"Data Source=PC2017082619BMY\SQLEXPRESS;Initial Catalog=dbsinhvien;Integrated Security=True");
            return con;
        }

        //tao ham mo ket noi voi DB ten la OpenConnection

        public static void OpenConnection()
        {
            //thiet lap 1 chuoi ket noi co xac thuc

            string sql = @"Data Source=PC2017082619BMY\SQLEXPRESS;Initial Catalog=dbsinhvien;Integrated Security=True";
            try
            {
                con = new SqlConnection(sql);
                con.Open();
            }catch(SqlException ex)
            { }
        }
        //tao ham dong ngat ket noi toi DB
        public static void Close()
        {
            //dong ket noi
            con.Close();
            //ngat ket noi
            con.Dispose();
            con = null;
        }

        // tao ham DB de lay du lieu tu sqlAdapter hien thi tren bang

        public static DataTable getDatatable(string sql)
        {
            cmd = new SqlCommand(sql, con);
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        //tao ham Excute de them sua xoa

        public static void Excute(string sql)
        {
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

    }
}
