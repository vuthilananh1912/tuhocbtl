
namespace tuhocbtl
{
    partial class Login
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.txtTenDN = new System.Windows.Forms.TextBox();
            this.lbMatKhau = new System.Windows.Forms.Label();
            this.lbTenDN = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.btnDangNhap);
            this.panel1.Controls.Add(this.txtMatKhau);
            this.panel1.Controls.Add(this.txtTenDN);
            this.panel1.Controls.Add(this.lbMatKhau);
            this.panel1.Controls.Add(this.lbTenDN);
            this.panel1.Location = new System.Drawing.Point(257, 161);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(553, 232);
            this.panel1.TabIndex = 3;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Location = new System.Drawing.Point(256, 167);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(111, 41);
            this.btnDangNhap.TabIndex = 3;
            this.btnDangNhap.Text = "Đăng Nhập";
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.Location = new System.Drawing.Point(256, 109);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(250, 30);
            this.txtMatKhau.TabIndex = 2;
            this.txtMatKhau.UseSystemPasswordChar = true;
            // 
            // txtTenDN
            // 
            this.txtTenDN.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDN.Location = new System.Drawing.Point(256, 42);
            this.txtTenDN.Name = "txtTenDN";
            this.txtTenDN.Size = new System.Drawing.Size(250, 30);
            this.txtTenDN.TabIndex = 1;
            // 
            // lbMatKhau
            // 
            this.lbMatKhau.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lbMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbMatKhau.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMatKhau.Location = new System.Drawing.Point(51, 107);
            this.lbMatKhau.Name = "lbMatKhau";
            this.lbMatKhau.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.lbMatKhau.Size = new System.Drawing.Size(168, 32);
            this.lbMatKhau.TabIndex = 1;
            this.lbMatKhau.Text = "Mật Khẩu";
            // 
            // lbTenDN
            // 
            this.lbTenDN.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lbTenDN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbTenDN.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenDN.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbTenDN.Location = new System.Drawing.Point(51, 44);
            this.lbTenDN.Name = "lbTenDN";
            this.lbTenDN.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lbTenDN.Size = new System.Drawing.Size(168, 30);
            this.lbTenDN.TabIndex = 1;
            this.lbTenDN.Text = "Tên đăng nhập";
            // 
            // Login
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Login";
            this.Text = "Quản lý đăng nhập";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.TextBox txtTenDN;
        private System.Windows.Forms.Label lbMatKhau;
        private System.Windows.Forms.Label lbTenDN;
    }
}