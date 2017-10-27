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

namespace Nhaphangv2
{
    public partial class Form1 : Form
    {
        //tao ham showData de hien thi du lieu

        public void ShowData(string sql)
        {
            Utility.OpenConnection();
            //truy xuat toi DB trong bang hang
            dGV_1.DataSource = Utility.getDatatable("Select* from hang");
            Utility.Close();
        }
        //tao ham chuan hoa chuoi khi nhap chuoi vao
        public string Chuan_hoa_chuoi(string a)
        {
            string s = "";
            if (a == "")
            {
          
            }
            else
            {
                //bo cac khoang trang thua o dau va cuoi
                a = a.Trim().ToLower();
                while (a.IndexOf("\t") >= 0)
                {
                    a = a.Replace("\t", " ");

                }
                while (a.IndexOf(" ") >= 0)
                {
                    a = a.Replace(" ", " ");

                }
                string[] arr = a.Split(' ');
                foreach (string item in arr)
                {
                    s += item.Substring(0, 1).ToLower() + item.Substring(1).ToLower() + " ";
                }
            }
            return s;
        }
        public Form1()
        {
            InitializeComponent();
            this.ShowData("select * from hang");
        }


        private void grp_tthanghoa_Enter(object sender, EventArgs e)
        {

        }

        private void grp_thanhtoan_Enter(object sender, EventArgs e)
        {

        }

        private void lbl_giam_Click(object sender, EventArgs e)
        {

        }
        private static int id1;
        private static string giatridau = "0";
        private void but_tang_Click(object sender, EventArgs e)
        {
            DataGridViewRow a = (DataGridViewRow)dGV_1.Rows[id1].Clone();
            a.Cells[0].Value = dGV_1.Rows[id1].Cells[0].Value;
            a.Cells[1].Value = dGV_1.Rows[id1].Cells[1].Value;
            a.Cells[3].Value = dGV_1.Rows[id1].Cells[3].Value;
            this.dGV_2.Rows.Add(a);
           

            //them o so luong
            dGV_2.Rows[dGV_2.Rows.Count - 2].Cells[2].Value = 1;

            //them tong

            foreach (DataGridViewRow item in dGV_2.Rows)
            {
                dGV_2.Rows[dGV_2.Rows.Count - 2].Cells[4].Value =
                    (Double.Parse(dGV_2.Rows[dGV_2.Rows.Count - 2].Cells[2].Value.ToString()) *
                    Double.Parse(dGV_2.Rows[dGV_2.Rows.Count - 2].Cells[3].Value.ToString())).ToString();
            }

            //tinh tong so tien cua hoa don
            giatridau = "0";
            for (int i = 0; i <= dGV_2.Rows.Count - 2; i++)
            {
                giatridau = (Double.Parse(giatridau) +
                    Double.Parse(dGV_2.Rows[i].Cells[4].Value.ToString())).ToString();
            }
            txt_tongtien.Text = giatridau;
        }

        private void but_giam_Click(object sender, EventArgs e)
        {
            int n = dGV_2.CurrentCell.RowIndex;
            dGV_2.Rows.RemoveAt(n);
            giatridau = "0";
            for (int i = 0; i <= dGV_2.Rows.Count - 2; i++)
            {
                giatridau = (Double.Parse(giatridau) +
                    Double.Parse(dGV_2.Rows[i].Cells[4].Value.ToString())).ToString();
            }
            txt_tongtien.Text = giatridau;
        }



       private string tientra = null;
       private string conno = "0";
        private void txt_datra_TextChanged(object sender, EventArgs e)
        { 
            tientra = txt_datra.Text;
           // conno = 
            conno = (Double.Parse(txt_tongcong.Text) - Double.Parse(tientra)).ToString();
            txt_conno.Text = conno;

        }

        private void txt_giamgia1_TextChanged(object sender, EventArgs e)
        {
           txt_giamgia2.Text = (Double.Parse(giatridau) * (Double.Parse(txt_giamgia1.Text)/100)).ToString();
        }

        private void txt_giamgia2_TextChanged(object sender, EventArgs e)
        {
            txt_tongcong.Text = (Double.Parse(txt_tongtien.Text) - Double.Parse(txt_giamgia2.Text)).ToString();
        }

        

        private void dGV_1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id1 = e.RowIndex;
        }
       
        private void txt_timkiem_TextChanged(object sender, EventArgs e)
        {
           
             
        }

        private void txt_timkiem_MouseLeave(object sender, EventArgs e)
        {
            
        }
        Utility conn = new Utility();
        SqlConnection sql ;
        SqlCommand cmd;
        SqlDataAdapter table;
        DataSet DA;
        public void load_nhacungcap()
        {
            sql = conn.openDB();
            sql.Open();
            cmd = new SqlCommand("select tennhacc,diachi from cungcap", sql);
            table = new SqlDataAdapter(cmd);
            DA = new DataSet();
            table.Fill(DA,"cungcap");
            cbo_nhacc.DataSource = DA.Tables[0];
            cbo_nhacc.DisplayMember = "tennhacc";
            cbo_nhacc.ValueMember = "diachi";
            sql.Close();
        }
        public void load_nhanvien()
        {
            sql = conn.openDB();
            sql.Open();
            cmd = new SqlCommand("select tennv from nv", sql);
            table = new SqlDataAdapter(cmd);
            DA = new DataSet();
            table.Fill(DA, "nv");
            cbo_nhanvien.DataSource = DA.Tables[0];
            cbo_nhanvien.DisplayMember = "tennv";
            sql.Close();
        }
        private void cbo_nhacc_SelectedIndexChanged(object sender, EventArgs e)
        {
            sql = conn.openDB();
            sql.Open();
            
            cmd = new SqlCommand("select * from cungcap where diachi = '" + cbo_nhacc.SelectedValue.ToString() + "'",sql);
            SqlDataReader read = cmd.ExecuteReader();
            if (read.HasRows)
            {
                read.Read();
               txt_dienthoai.Text = read.GetInt32(2).ToString();
              // MessageBox.Show(read.GetString(2).ToString());
               txt_diachi.Text = read.GetString(3).ToString();
                txt_nocu.Text = read.GetInt32(4).ToString();
            }
            //sql.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.load_nhacungcap();
            this.load_nhanvien();
        }

        private void txt_nocu_TextChanged(object sender, EventArgs e)
        {
            txt_noluyke.Text = (Double.Parse(conno) + Double.Parse(txt_nocu.Text)).ToString();
        }

        private void txt_tongcong_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
