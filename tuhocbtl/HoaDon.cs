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
    public partial class HoaDon : Form
    {
        static string dataSource = @"Data Source=LAPTOP-TU3A4J8A\SQLEXPRESS;Initial Catalog=QuanLyKinhDoanhMayTinh;Integrated Security=True";

        public HoaDon()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
            string queryString = "pro_locHoaDonTheoMaNV";
            using (SqlConnection connection = new SqlConnection(dataSource))
            {
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@sMaNV", cbMaNV.Text);
                    //cmd.ExecuteNonQuery();
                    using(SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        gvHoaDon.DataSource = dataTable;



                    }


                    connection.Close();
                }
            }
        }

        private void LoadDL()
        {
            using (SqlConnection connection = new SqlConnection(dataSource))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblHoaDon", connection))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        gvHoaDon.DataSource = dataTable;
                        layDSMaNV();


                        HoaDonReport objRpt = new HoaDonReport();
                        objRpt.SetDataSource(dataTable);
                        crystalReportViewer1.ReportSource = objRpt;
                        crystalReportViewer1.Refresh();
                        //
                    }
                }
            }
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            LoadDL();

        }

        private void gvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
