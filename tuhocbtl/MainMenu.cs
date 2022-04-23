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
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KhachHang formKH = new KhachHang();
            formKH.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NhanVien formNV = new NhanVien();
            formNV.Show();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhanVien formNV = new NhanVien();
            formNV.Show();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KhachHang formKH = new KhachHang();
            formKH.Show();
        }

        private void quảnLýMặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MatHang formMH = new MatHang();
            formMH.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMK formDoiMK = new DoiMK();
            formDoiMK.Show();
        }

        private void quảnLýNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhaCC formNhaCC = new NhaCC();
            formNhaCC.Show();
        }
    }
}
