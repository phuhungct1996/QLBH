namespace Form1
{
    partial class fm_Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fm_Login));
            this.nutDangNhap = new System.Windows.Forms.Button();
            this.nutThoat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_matkhau = new System.Windows.Forms.TextBox();
            this.txt_taikhoan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.logo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // nutDangNhap
            // 
            this.nutDangNhap.Location = new System.Drawing.Point(143, 233);
            this.nutDangNhap.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.nutDangNhap.Name = "nutDangNhap";
            this.nutDangNhap.Size = new System.Drawing.Size(85, 29);
            this.nutDangNhap.TabIndex = 0;
            this.nutDangNhap.Text = "Đăng Nhập";
            this.nutDangNhap.UseVisualStyleBackColor = true;
            this.nutDangNhap.Click += new System.EventHandler(this.nutDangNhap_Click);
            // 
            // nutThoat
            // 
            this.nutThoat.Location = new System.Drawing.Point(238, 233);
            this.nutThoat.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.nutThoat.Name = "nutThoat";
            this.nutThoat.Size = new System.Drawing.Size(85, 29);
            this.nutThoat.TabIndex = 1;
            this.nutThoat.Text = "Thoát";
            this.nutThoat.UseVisualStyleBackColor = true;
            this.nutThoat.Click += new System.EventHandler(this.nutThoat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 162);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tài khoản";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 202);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mật khẩu:";
            // 
            // txt_matkhau
            // 
            this.txt_matkhau.Location = new System.Drawing.Point(143, 195);
            this.txt_matkhau.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_matkhau.Name = "txt_matkhau";
            this.txt_matkhau.Size = new System.Drawing.Size(182, 20);
            this.txt_matkhau.TabIndex = 4;
            this.txt_matkhau.UseSystemPasswordChar = true;
            this.txt_matkhau.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txt_taikhoan
            // 
            this.txt_taikhoan.Location = new System.Drawing.Point(143, 162);
            this.txt_taikhoan.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_taikhoan.Name = "txt_taikhoan";
            this.txt_taikhoan.Size = new System.Drawing.Size(182, 20);
            this.txt_taikhoan.TabIndex = 5;
            this.txt_taikhoan.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(194, 129);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Đăng nhập";
            // 
            // logo
            // 
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.InitialImage = ((System.Drawing.Image)(resources.GetObject("logo.InitialImage")));
            this.logo.Location = new System.Drawing.Point(174, 12);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(121, 114);
            this.logo.TabIndex = 8;
            this.logo.TabStop = false;
            // 
            // fm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 309);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_taikhoan);
            this.Controls.Add(this.txt_matkhau);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nutThoat);
            this.Controls.Add(this.nutDangNhap);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "fm_Login";
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button nutDangNhap;
        private System.Windows.Forms.Button nutThoat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_matkhau;
        private System.Windows.Forms.TextBox txt_taikhoan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox logo;
    }
}

