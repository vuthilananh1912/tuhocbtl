using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tuhocbtl
{
    public partial class HoaDon2 : Form
    {
        static string dataSource = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=QLKDMAYTINH;Integrated Security=True";

        public HoaDon2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoadDL()
        {
            using (SqlConnection connection = new SqlConnection(dataSource))
            {
                string sql = "SELECT COUNT(*) AS 'SL' , tblHoaDon.sMaNV FROM tblHoaDon INNER JOIN tblNhanVien ON tblNhanVien.sMaNV = tblHoaDon.sMaNV GROUP BY tblHoaDon.sMaNV";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        gvSLHD.DataSource = dataTable;
                        layDSMaNV();
                    }
                }
            }
        }
        private void layDSMaNV()
        {
            using (SqlConnection connection = new SqlConnection(dataSource))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblNhanVien", connection))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        DataView view = new DataView(table);
                        view.Sort = "sMaNV";
                        cbMaNV.DataSource = view;
                        cbMaNV.DisplayMember = "sMaNV";




                    }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string queryString = "pro_thongkehoadontheonv";
            using (SqlConnection connection = new SqlConnection(dataSource))
            {
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sMaNV", cbMaNV.Text);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        gvSLHD.DataSource = dataTable;
                    }


                    connection.Close();
                }
            }
        }

        private void HoaDon2_Load(object sender, EventArgs e)
        {
            LoadDL();

        }

        private void gvSLHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
