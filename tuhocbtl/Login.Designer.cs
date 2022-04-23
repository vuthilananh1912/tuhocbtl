
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
            this.labelTenDN = new System.Windows.Forms.Label();
            this.labelMK = new System.Windows.Forms.Label();
            this.textBoxTenDN = new System.Windows.Forms.TextBox();
            this.textBoxMK = new System.Windows.Forms.TextBox();
            this.btnDN = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTenDN
            // 
            this.labelTenDN.AutoSize = true;
            this.labelTenDN.Location = new System.Drawing.Point(74, 109);
            this.labelTenDN.Name = "labelTenDN";
            this.labelTenDN.Size = new System.Drawing.Size(81, 13);
            this.labelTenDN.TabIndex = 0;
            this.labelTenDN.Text = "Tên đăng nhập";
            // 
            // labelMK
            // 
            this.labelMK.AutoSize = true;
            this.labelMK.Location = new System.Drawing.Point(77, 152);
            this.labelMK.Name = "labelMK";
            this.labelMK.Size = new System.Drawing.Size(52, 13);
            this.labelMK.TabIndex = 1;
            this.labelMK.Text = "Mật khẩu";
            // 
            // textBoxTenDN
            // 
            this.textBoxTenDN.Location = new System.Drawing.Point(210, 101);
            this.textBoxTenDN.Name = "textBoxTenDN";
            this.textBoxTenDN.Size = new System.Drawing.Size(151, 20);
            this.textBoxTenDN.TabIndex = 2;
            // 
            // textBoxMK
            // 
            this.textBoxMK.Location = new System.Drawing.Point(210, 144);
            this.textBoxMK.Name = "textBoxMK";
            this.textBoxMK.Size = new System.Drawing.Size(151, 20);
            this.textBoxMK.TabIndex = 3;
            // 
            // btnDN
            // 
            this.btnDN.Location = new System.Drawing.Point(164, 232);
            this.btnDN.Name = "btnDN";
            this.btnDN.Size = new System.Drawing.Size(75, 23);
            this.btnDN.TabIndex = 4;
            this.btnDN.Text = "Đăng nhập";
            this.btnDN.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(376, 231);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDN);
            this.Controls.Add(this.textBoxMK);
            this.Controls.Add(this.textBoxTenDN);
            this.Controls.Add(this.labelMK);
            this.Controls.Add(this.labelTenDN);
            this.Name = "Login";
            this.Text = "Quản lý đăng nhập";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTenDN;
        private System.Windows.Forms.Label labelMK;
        private System.Windows.Forms.TextBox textBoxTenDN;
        private System.Windows.Forms.TextBox textBoxMK;
        private System.Windows.Forms.Button btnDN;
        private System.Windows.Forms.Button btnThoat;
    }
}