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
    public partial class FormInHoaDon : Form
    {
        string dataSource = ConfigurationManager.ConnectionStrings["KinhDoanhMayTinh"].ConnectionString;
        string maHoaDon;
        public FormInHoaDon(string maHD)
        {
            InitializeComponent();
            maHoaDon = maHD;
        }

        private void FormInHoaDon_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(dataSource))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "pro_timkiemhoadontheoma";
                    cmd.Parameters.AddWithValue("@sMaHD", maHoaDon);


                    using (SqlDataAdapter ad = new SqlDataAdapter())
                    {
                        ad.SelectCommand = cmd;
                        DataTable tb = new System.Data.DataTable();
                        ad.Fill(tb);


                        //fill vao crystal report
                        TimKiemHoaDonReport rpt = new TimKiemHoaDonReport();
                        rpt.SetDataSource(tb);
                        crystalReportViewer1.ReportSource = rpt;
                        crystalReportViewer1.Refresh();
                    }

                }
            }
        }
    }
}
