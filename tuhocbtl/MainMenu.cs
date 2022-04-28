using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tuhocbtl
{
    public partial class MainMenu : Form
    {
        DateTime thoigiandangnhap;
        string tendangnhap;
        public MainMenu(string tendn)
        {
            InitializeComponent();
            tendangnhap = tendn;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            fNhanVien formNV = new fNhanVien();
            formNV.Show();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fNhanVien formNV = new fNhanVien();
            formNV.Show();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fKhachHang kh = new fKhachHang();
            kh.Show();
        }

        private void quảnLýMặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fSanPham formMH = new fSanPham();
            formMH.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMK formDoiMK = new DoiMK(tendangnhap);
            formDoiMK.Show();
        }

        private void quảnLýNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhaCC formNhaCC = new NhaCC();
            formNhaCC.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Close();
        }

        private void thanhToánHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyHoaDon hd = new QuanLyHoaDon();
            hd.Show();
            
        }

        private void tìmKiếmHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTimKiemHoaDon hd = new FormTimKiemHoaDon();
            hd.Show();
            
        }

        private void tìmKiếmHóaĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormTimKiemHoaDon hd = new FormTimKiemHoaDon();
            hd.Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            thoigiandangnhap = DateTime.Now;
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(string.Format("Bạn có muốn đóng chương trình quản lí nhân viên?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
            //int timestamp;
            //timestamp = DateTime.Now.Minute - thoigiandangnhap.Minute;
            //MessageBox.Show(timestamp.ToString());
        }
    }
}
