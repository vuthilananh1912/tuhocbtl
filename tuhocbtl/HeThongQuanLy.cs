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
    public partial class HeThongQuanLy : Form
    {
        public HeThongQuanLy()
        {
            InitializeComponent();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login formLogin = new Login();
            formLogin.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn thoát khỏi chương trình ? ","Thông báo",
                MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                Close();
        }

        private void MenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MainMenu formMenu = new MainMenu();
            //formMenu.Show();
        }
    }
}
