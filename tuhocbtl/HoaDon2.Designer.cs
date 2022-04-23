
namespace tuhocbtl
{
    partial class HoaDon2
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
            this.gvSLHD = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMaNV = new System.Windows.Forms.ComboBox();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvSLHD)).BeginInit();
            this.SuspendLayout();
            // 
            // gvSLHD
            // 
            this.gvSLHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSLHD.Location = new System.Drawing.Point(12, 78);
            this.gvSLHD.Name = "gvSLHD";
            this.gvSLHD.Size = new System.Drawing.Size(701, 150);
            this.gvSLHD.TabIndex = 0;
            this.gvSLHD.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvSLHD_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã Nhân Viên";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbMaNV
            // 
            this.cbMaNV.FormattingEnabled = true;
            this.cbMaNV.Location = new System.Drawing.Point(93, 22);
            this.cbMaNV.Name = "cbMaNV";
            this.cbMaNV.Size = new System.Drawing.Size(121, 21);
            this.cbMaNV.TabIndex = 2;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(242, 20);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "Submit";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // HoaDon2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 504);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.cbMaNV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gvSLHD);
            this.Name = "HoaDon2";
            this.Text = "HoaDon2";
            this.Load += new System.EventHandler(this.HoaDon2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvSLHD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvSLHD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMaNV;
        private System.Windows.Forms.Button btnPrint;
    }
}