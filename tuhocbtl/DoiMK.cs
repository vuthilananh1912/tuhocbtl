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
    public partial class DoiMK : Form
    {
        string constr = ConfigurationManager.ConnectionStrings["KinhDoanhMayTinh"].ConnectionString;
        public DoiMK(string tendn)
        {
            InitializeComponent();
            txtTenDN.Text = tendn;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE tblNhanVien SET sMatKhau = '" + txtMatKhau.Text.Trim() + "' WHERE sTenDN = '" + txtTenDN.Text +"'" , conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        conn.Open();
                        int i = cmd.ExecuteNonQuery();
                        if(i > 0)
                        {
                            MessageBox.Show("Câp nhật mật khẩu thành công!");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi gì đó rồi!");
                        }

                    }
                }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
