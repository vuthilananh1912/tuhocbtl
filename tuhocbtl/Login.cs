using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tuhocbtl
{
    public partial class Login : Form
    {
        string constr = ConfigurationManager.ConnectionStrings["KinhDoanhMayTinh"].ConnectionString;
        int count = 0;
        public Login()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTenDN.Text;
            string matKhau = txtMatKhau.Text;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                string sql = $"select * from tblNhanVien where sTenDN = '{taiKhoan}' and sMatKhau = '{matKhau}'";

                SqlDataAdapter mydata = new SqlDataAdapter(sql, cnn);
                DataTable tbl = new DataTable();

                mydata.Fill(tbl);
                if (tbl.Rows.Count > 0)
                {
                    MainMenu menu = new MainMenu(taiKhoan);
                    menu.Show();
                    this.Hide();
                } else
                {
                    count++;
                    MessageBox.Show(string.Format("Tên đăng nhập hoặc mật khẩu không đúng!"), "Thông báo", MessageBoxButtons.OK);
                }
            }

            if(count == 3)
            {
                MessageBox.Show("Ban da nhap sai qua 3 lan");
            }
        }
    }
}
