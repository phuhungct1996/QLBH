using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Form1
{
    public partial class fm_inDex_Main : Form
    {
        public fm_inDex_Main()
        {
            InitializeComponent();
        }
        public string tennv = "";
        public string namsinh = "";
        public string gioitinh = "";
        public string soDT = "";
        public string soCMND = "";
        public string diachi = "";
        public string maNV = "";
       // public string chucvu = "";
        public string ngay = "";
        public Image anhNV = null;
        public fm_inDex_Main(string ten,string NS,string phai,string ĐT,string CMND,string DC,string manhanvien,string Date,byte[] anh) :this()
        {
             tennv = ten;
             namsinh = NS;
             gioitinh = phai;
             soDT = ĐT;
             soCMND = CMND;
             diachi = DC;
             maNV = manhanvien;
             //chucvu = chuc;
            ngay = Date;
            anhNV = byteArrayToImage((byte[])anh);
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        } 
        private void inDex_Main_Load(object sender, EventArgs e)
        {
            
            this.lb_hoten.Text = this.tennv.ToString();
            this.lb_namsinh.Text = this.namsinh.ToString();
            this.lb_gioitinh.Text = this.gioitinh.ToString();
            this.lb_sodt.Text = this.soDT.ToString();
            this.lb_socmnd.Text = this.soCMND.ToString();
            this.lb_diachi.Text = this.diachi.ToString();
            this.lb_manv.Text = this.maNV.ToString();
           // this.lb_chucvu.Text = this.chucvu.ToString();
            this.lb_vaolam.Text = this.ngay.ToString();
            this.ptb_anhnv.Image = this.anhNV;
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void btnHangHoa_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnNguonHang_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }


        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btn_nhanvien_Click(object sender, EventArgs e)
        {
            fm_nhanvien nhanvien = new fm_nhanvien();
            nhanvien.ShowDialog();
        }
    }
}
