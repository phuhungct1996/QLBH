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
using System.Globalization;
//using Doanbanhang;

namespace Form1
{
    public partial class fm_nhanvien : Form
    {
        public fm_nhanvien()
        {
            InitializeComponent();
            this.Showdata("select* from nhanvien");
        }
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter DA;
        public void Showdata(string sql)
        {
            Unity.Openconnec();
            // TRUY XUẤT database của datagidview
            dgv_nhanvien.DataSource = Unity.getDatatable("select* from nhanvien");
        }
          public void clean()
        {
            txt_manv.Clear();
            txt_hoten.Clear();
            txt_socmnd.Clear();
            txt_namsinh.Clear();
            rbt_nam.DataBindings.Clear();
            rbt_nu.DataBindings.Clear();
            txt_sodt.Clear();
            dtp_ngayvaolam = null;
            txt_machucvu.Clear();
            cb_chucvu = null;
            
            // đưa con trỏ về vị trí texbox id
            txt_manv.Focus();
        }

        // tạo hàm chuẩn hóa chuỗi nhập vào các ô textbox 
        public string chuanhoa(string s)
        {
            string s1 = "";
            if (s == "")
            {

            }
            else {
                // bỏ các khoảng trắng thừa, chuyển về dang chữ thường
                s = s.Trim().ToLower();
                while (s.IndexOf("\t")>= 0)
                {
                    s = s.Replace("\t"," ");
                }
                while (s.IndexOf(" ")>= 0)
                {
                    s = s.Replace(" "," ");
                }
                string[] arr = s.Split(' ');
               
                foreach (string item in arr)
                {
                    // lây từ phần tử thứ 0 1 đơn vị túc là chữ cái đầu tiên của mỗi từ sau đó đổi thành chữ in hoa
                    // từ phần tử di chuyển về chuỗi thường
                    s1 += item.Substring(0, 1).ToLower() + item.Substring(1).ToLower() + " ";
                }
               
            }
            return s1;
        }
        // tạo hàm kiểm tra chuỗi rỗng
      /*  public bool KT_CHUOI(string id, string ma, string ten, string email, string gioi)
        {
            if (id == null && ma == "" && ten == "" && email == "" && gioi == "")
            {
                MessageBox.Show("Chưa nhập thông tin");
                idTextBox.Focus();
                return true;
            }
            else if (id == null)
            {
                MessageBox.Show("Chưa nhập id");
                idTextBox.Focus();
                return true;
            }
            else if (ma == "")
            {
                MessageBox.Show("Chưa nhập mã sinh viên");
                masvTextBox.Focus();
                return true;
            }
            else if (ten == "")
            {
                MessageBox.Show("Chưa nhập ten");
                hotenTextBox.Focus();
                return true;
            }
            else if (email == "")
            {
                MessageBox.Show("Chưa nhập email");
                emailTextBox.Focus();
                return true;
            }
            else if (gioi == "")
            {
                MessageBox.Show("Chưa nhập gioi tính");
                gioitinhTextBox.Focus();
                return true;
            }
            return true;
        }
        */
        // hàm kiểm tra trùng nhau
        public bool KT_trungnhau(string s)
        {
            // lấy ra ma sinh vien của từng ô
            int chiso = dgv_nhanvien.CurrentRow.Index; 
            for (int i = 0; i < dgv_nhanvien.Rows.Count;i++)
            {
                if (s == dgv_nhanvien[0, chiso].Value.ToString())
                {
                    MessageBox.Show("Trùng Mã sinh viên");
                    return false;
                }
            }
            return true;
        }
        Unity UT = new Unity();
        DataSet Table;
        public void showComboBox()
        {
            conn = UT.Opendata();
            conn.Open();
            cmd = new SqlCommand("select chucVU,maNV from nhanvien");
            DA = new SqlDataAdapter();
            DA.SelectCommand = cmd;
            Table = new DataSet();
            DA.Fill(Table,"nhanvien");
            cb_chucvu.DataSource = Table.Tables[0];
            cb_chucvu.DisplayMember = "chucVU";
            cb_chucvu.ValueMember = "maNV";
            
        }

       /* private void cb_chucvu_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn = UT.Opendata();
            conn.Open();
            cmd = new SqlCommand("select * from nhanvien where maNV = '"+ cb_chucvu.SelectedValue.ToString() +"'",conn);
            SqlDataAdapter BT = cmd.ExecuteReader();
            this.showComboBox();
        }
        */
        private void dgv_nhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int chiso = dgv_nhanvien.CurrentRow.Index;
            txt_manv.Text = dgv_nhanvien[0, chiso].Value.ToString();
            txt_hoten.Text = dgv_nhanvien[1, chiso].Value.ToString();
            txt_socmnd.Text = dgv_nhanvien[2, chiso].Value.ToString();
            txt_namsinh.Text = dgv_nhanvien[3, chiso].Value.ToString();
           // từ datagripview đưa lên radiobutton
            if (dgv_nhanvien[5, chiso].Value.ToString() == "Nam")
            {
                rbt_nam.Checked = true;
                //MessageBox.Show(dgv_nhanvien[4, chiso].Value.ToString());
            }
            else
                
                {
                    rbt_nu.Checked = true;
                }
          /*  string Gender = "";
            if (dgv_nhanvien.SelectedRows.Count > 0)
            {
                Gender = dgv_nhanvien.SelectedRows[0].Cells["phai"].Value.ToString();
                if (Gender == "Nam")
                {
                    rbt_nam.Checked = true;
                }
                else
                {
                    rbt_nu.Checked = true;
                }
            }*/
           // txt_sodt.Text = dgv_nhanvien[4, chiso].Value.ToString();
           // txt_diachi.Text = dgv_nhanvien[5, chiso].Value.ToString();
            //dtp_ngayvaolam.Format = DateTimePickerFormat.Custom;
            //dtp_ngayvaolam.CustomFormat = "dd/MM/yyyy";
           dtp_ngayvaolam.Value = Convert.ToDateTime(dgv_nhanvien[4, chiso].Value);
          //  DateTime dt = DateTime.ParseExact(dgv_nhanvien.CurrentCell.Value.ToString(), "dd/MM/yyyy",CultureInfo.InvariantCulture);

         //  dtp_ngayvaolam.Value = Convert.ToDateTime(dgv_nhanvien.Rows[e.RowIndex].Cells[7].Value.ToString("dd/MM/yyyy"));
            txt_machucvu.Text = dgv_nhanvien[6, chiso].Value.ToString();
        //   cb_chucvu.Text = dgv_nhanvien[0, chiso].EditedFormattedValue.ToString();
        }
        string phai = null;
        string image ="";
        private void btn_themnhanvien_Click(object sender, EventArgs e)
        {
            string id = txt_manv.Text;
            string ten = txt_hoten.Text;
            //string macv = masvTextBox.Text;
            string sodt = txt_sodt.Text;
            string socmnd = txt_socmnd.Text;
            string macv = txt_machucvu.Text;
            string namsinh = txt_namsinh.Text;
            string diachi = txt_diachi.Text;
           // string matkhau = txt_matkhau;
            // them vao database
           /*string sql = "Insert into sinhvien values('" + id + "',N'" + ma + "',N'" + ten + "',N'" + email + "',N'" + gioi + "')";
            Unity.Excute(sql);
            this.Showdata("select* from sinhvien");*/
            byte[] image_file = null;
            FileStream read_file = new FileStream(image, FileMode.Open, FileAccess.Read);

            BinaryReader bina = new BinaryReader(read_file);
            image_file = bina.ReadBytes((int)read_file.Length);

            conn = UT.Opendata();
            conn.Open();
            //string sqlSAVE = "insert into nhanvien(maNV,tenNV,maCV,namSINH,gioiTINH,ngayVAOLAM,soDT,soCMND,diaCHI,matKHAU,anh_NV) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "',@image_file)";
            string sqlSAVE = "insert into nhanvien(maNV,tenNV,maCV,namSINH,ngayVAOLAM,gioiTINH,soDT,soCMND,diaCHI,anh_NV) values('" + id + "','" + ten + "','" + macv + "','" + namsinh + "','" + dtp_ngayvaolam.Value.ToString("MM/dd/yyyy") + "','" + phai + "','" + sodt + "','" + socmnd + "','" + diachi + "',@image_file)";
            MessageBox.Show(sqlSAVE);
            cmd = new SqlCommand(sqlSAVE, conn);
            cmd.Parameters.Add(new SqlParameter("@image_file", image_file));
            cmd.ExecuteNonQuery();
           // conn.Close();
            //  MessageBox.Show(N.ToString(), "anh da them thanh công");
            conn.Close();

           
        }

        private void rbt_nam_CheckedChanged(object sender, EventArgs e)
        {
            phai = "Nam";
        }

        private void rbt_nu_CheckedChanged(object sender, EventArgs e)
        {
            phai = "Nữ";
        }

        private void btn_suanhanvien_Click(object sender, EventArgs e)
        {
            string sql = "update nhanvien set tenTEN = '" + txt_hoten.Text + "',maCV = '" + txt_machucvu.Text + "',namSINH ='" +  txt_namsinh.Text + "',ngayVAOLAM = '" + dtp_ngayvaolam.Value.ToString("dd/MM/yyyy") + "',gioiTINH = '" + phai + "',soĐT = '" + txt_sodt.Text + "',soCMND = '" + txt_socmnd + "',diaCHI = '" + txt_diachi + "', matKHAU = '" + txt_machucvu + "',@image_file where id = '" + txt_manv.Text + "'";
            Unity.Excute(sql);
            this.Showdata("select * from nhanvien");
        }

        private void btn_chonhinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog browser = new OpenFileDialog();
            browser.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";

            if (browser.ShowDialog() == DialogResult.OK)
            {
                image = browser.FileName;

                // MessageBox.Show(image);
                pictureBox_hinhanh.ImageLocation = image;
            }
        }

        private void btn_xoanhanvien_Click(object sender, EventArgs e)
        {
            int chiso = dgv_nhanvien.CurrentRow.Index;
            //sau khi xác định được chỉ số cần xóa ta viết câu lệnh xóa
            string sql = "delete from nhanvien where maNV = '" + dgv_nhanvien[0, chiso].Value.ToString() + "'";

            Unity.Excute(sql);
            this.Showdata("select * from nhanvien");
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        //lọc 
       /* private void txt_manv_TextChanged(object sender, EventArgs e)
        {
            conn = UT.Opendata();
            DA = new SqlDataAdapter("select * from nhanvien where maNV like '" + txt_manv.Text + "%'", conn);
            DataTable table = new DataTable();
            DA.Fill(table);
            dgv_nhanvien.DataSource = table;
            int chiso = dgv_nhanvien.CurrentRow.Index;
           // txt_manv.Text = dgv_nhanvien[0, chiso].Value.ToString();
            txt_hoten.Text = dgv_nhanvien[1, chiso].Value.ToString();
        }*/
    }
}
