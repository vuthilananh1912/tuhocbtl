
namespace tuhocbtl
{
    partial class QuanLyHoaDon
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
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labelTongTien = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.gvChiTietHoaDon = new System.Windows.Forms.DataGridView();
            this.btnAddView = new System.Windows.Forms.Button();
            this.labelDonGia = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.cbTenMatHang = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbTenNhanVien = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.labelThoiGianLap = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelMaHD = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTenKhachHang = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvChiTietHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1011, 515);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 13);
            this.label12.TabIndex = 47;
            this.label12.Text = "VNĐ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(766, 263);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 46;
            this.label11.Text = "VNĐ";
            // 
            // labelTongTien
            // 
            this.labelTongTien.AutoSize = true;
            this.labelTongTien.Location = new System.Drawing.Point(929, 515);
            this.labelTongTien.Name = "labelTongTien";
            this.labelTongTien.Size = new System.Drawing.Size(13, 13);
            this.labelTongTien.TabIndex = 45;
            this.labelTongTien.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(821, 515);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 44;
            this.label9.Text = "Tổng tiền";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(966, 550);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(75, 23);
            this.btnThanhToan.TabIndex = 43;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // gvChiTietHoaDon
            // 
            this.gvChiTietHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvChiTietHoaDon.Location = new System.Drawing.Point(151, 350);
            this.gvChiTietHoaDon.Name = "gvChiTietHoaDon";
            this.gvChiTietHoaDon.Size = new System.Drawing.Size(890, 150);
            this.gvChiTietHoaDon.TabIndex = 42;
            this.gvChiTietHoaDon.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvChiTietHoaDon_RowValidated);
            // 
            // btnAddView
            // 
            this.btnAddView.Location = new System.Drawing.Point(508, 307);
            this.btnAddView.Name = "btnAddView";
            this.btnAddView.Size = new System.Drawing.Size(75, 23);
            this.btnAddView.TabIndex = 41;
            this.btnAddView.Text = "Thêm";
            this.btnAddView.UseVisualStyleBackColor = true;
            this.btnAddView.Click += new System.EventHandler(this.btnAddView_Click);
            // 
            // labelDonGia
            // 
            this.labelDonGia.AutoSize = true;
            this.labelDonGia.Location = new System.Drawing.Point(715, 263);
            this.labelDonGia.Name = "labelDonGia";
            this.labelDonGia.Size = new System.Drawing.Size(13, 13);
            this.labelDonGia.TabIndex = 40;
            this.labelDonGia.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(672, 263);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 39;
            this.label10.Text = "Giá:";
            // 
            // numSoLuong
            // 
            this.numSoLuong.Location = new System.Drawing.Point(508, 260);
            this.numSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(120, 20);
            this.numSoLuong.TabIndex = 38;
            this.numSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(395, 263);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Số lượng";
            // 
            // cbTenMatHang
            // 
            this.cbTenMatHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTenMatHang.FormattingEnabled = true;
            this.cbTenMatHang.Location = new System.Drawing.Point(240, 260);
            this.cbTenMatHang.Name = "cbTenMatHang";
            this.cbTenMatHang.Size = new System.Drawing.Size(121, 21);
            this.cbTenMatHang.TabIndex = 36;
            this.cbTenMatHang.SelectedIndexChanged += new System.EventHandler(this.cbTenMatHang_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(148, 267);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Tên mặt hàng";
            // 
            // cbTenNhanVien
            // 
            this.cbTenNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTenNhanVien.FormattingEnabled = true;
            this.cbTenNhanVien.Location = new System.Drawing.Point(752, 141);
            this.cbTenNhanVien.Name = "cbTenNhanVien";
            this.cbTenNhanVien.Size = new System.Drawing.Size(121, 21);
            this.cbTenNhanVien.TabIndex = 34;
            this.cbTenNhanVien.SelectedIndexChanged += new System.EventHandler(this.cbTenNhanVien_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(672, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Nhân viên";
            // 
            // labelThoiGianLap
            // 
            this.labelThoiGianLap.AutoSize = true;
            this.labelThoiGianLap.Location = new System.Drawing.Point(505, 149);
            this.labelThoiGianLap.Name = "labelThoiGianLap";
            this.labelThoiGianLap.Size = new System.Drawing.Size(35, 13);
            this.labelThoiGianLap.TabIndex = 32;
            this.labelThoiGianLap.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(408, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(395, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Thời gian lập";
            // 
            // labelMaHD
            // 
            this.labelMaHD.AutoSize = true;
            this.labelMaHD.Location = new System.Drawing.Point(237, 149);
            this.labelMaHD.Name = "labelMaHD";
            this.labelMaHD.Size = new System.Drawing.Size(35, 13);
            this.labelMaHD.TabIndex = 29;
            this.labelMaHD.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(148, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Mã hóa đơn";
            // 
            // cbTenKhachHang
            // 
            this.cbTenKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTenKhachHang.FormattingEnabled = true;
            this.cbTenKhachHang.Location = new System.Drawing.Point(240, 196);
            this.cbTenKhachHang.Name = "cbTenKhachHang";
            this.cbTenKhachHang.Size = new System.Drawing.Size(121, 21);
            this.cbTenKhachHang.TabIndex = 27;
            this.cbTenKhachHang.SelectedIndexChanged += new System.EventHandler(this.cbTenKhachHang_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Khách Hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(363, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(433, 55);
            this.label1.TabIndex = 25;
            this.label1.Text = "Quản lý mua hàng";
            // 
            // QuanLyHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 616);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.labelTongTien);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.gvChiTietHoaDon);
            this.Controls.Add(this.btnAddView);
            this.Controls.Add(this.labelDonGia);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.numSoLuong);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbTenMatHang);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbTenNhanVien);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelThoiGianLap);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelMaHD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbTenKhachHang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "QuanLyHoaDon";
            this.Text = "QuanLyHoaDon";
            this.Load += new System.EventHandler(this.QuanLyHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvChiTietHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelTongTien;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.DataGridView gvChiTietHoaDon;
        private System.Windows.Forms.Button btnAddView;
        private System.Windows.Forms.Label labelDonGia;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbTenMatHang;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbTenNhanVien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelThoiGianLap;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelMaHD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTenKhachHang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}