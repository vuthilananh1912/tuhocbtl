using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace tuhocbtl
{
    public partial class MatHang : Form
    {

        SqlConnection connection;
        SqlCommand command;
        static string constr = "Data Source=ADMIN\\SQLEXPRESS;Initial Catalog=QLKDMAYTINH;Integrated Security=True";
        string str = " ";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public MatHang()
        {
            InitializeComponent();
        }

        private void MH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MatHang_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(constr);
            connection.Open();
            LoadDLMH();


        }

        private void LoadDLMH()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT *FROM tblSanPham";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            MH.DataSource = table;
        }

    }
}
