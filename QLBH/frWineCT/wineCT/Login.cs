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
using System.IO;

namespace Form1
{
    public partial class fm_Login : Form
    {
        public fm_Login()
        {
            InitializeComponent();
        }

        public string tentruyensang = "";
        public string namsinhtruyensang = "";
        public string phaitruyensang = "";
        public string sodttruyensang = "";
        public string socmndtruyensang = "";
        public string diachitruyensang = "";
        public string manvtruyensang = "";
       // public string chucvutruyensang = "";
        public string ngaytruyensang = "";
        public byte[] anhtruyensang = null;
        string sqlconn = @"Data Source=PC2017082619BMY\SQLEXPRESS;Initial Catalog=database2;Integrated Security=True";
        SqlConnection conn = null;
        SqlDataAdapter DBA = null;
        DataTable DTB = null;
        public DataTable checlog(String tk,string mk)
        {
            string sql = "select * from nhanvien where maNV = '" + tk + "' and matKHAU='" + mk + "'";
            conn = new SqlConnection(sqlconn);
            DBA = new SqlDataAdapter(sql, conn);
            DTB = new DataTable();
            DBA.Fill(DTB);
            return DTB;
           
        }
        private void nutDangNhap_Click(object sender, EventArgs e)
        {
            DTB = checlog(txt_taikhoan.Text,txt_matkhau.Text);
            if (DTB.Rows.Count > 0)
            {
                tentruyensang = DTB.Rows[0]["tenNV"].ToString();
                namsinhtruyensang = DTB.Rows[0]["namSINH"].ToString();
                phaitruyensang = DTB.Rows[0]["gioiTINH"].ToString();
                sodttruyensang = DTB.Rows[0]["soDT"].ToString();
                socmndtruyensang = DTB.Rows[0]["soCMND"].ToString();
                diachitruyensang = DTB.Rows[0]["diaCHI"].ToString();
                manvtruyensang = DTB.Rows[0]["maNV"].ToString();
                //chucvutruyensang = DTB.Rows[0]["chucVU"].ToString();
                ngaytruyensang = DTB.Rows[0]["ngayVAOLAM"].ToString();
                anhtruyensang = (byte[])DTB.Rows[0]["anh_NV"];
                
               // ngaytruyensang = DTB.Rows[0]["ngayVAOLAM"].ToString();
                fm_inDex_Main chuyen = new fm_inDex_Main(tentruyensang.ToString(),namsinhtruyensang.ToString(),phaitruyensang.ToString(),sodttruyensang.ToString(),socmndtruyensang.ToString(),diachitruyensang.ToString(),manvtruyensang.ToString(),ngaytruyensang.ToString(),anhtruyensang);
               // this.Hide();Convert.ToDateTime(txtNgayDK.Text)
                chuyen.ShowDialog();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void nutThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
