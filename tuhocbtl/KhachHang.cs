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
    public partial class KhachHang : Form
    {
        SqlConnection connection;
        SqlCommand command;
        static string constr = "Data Source=ADMIN\\SQLEXPRESS;Initial Catalog=QLKDMAYTINH;Integrated Security=True";
        string str = " ";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public KhachHang()
        {
            InitializeComponent();
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(constr);
            connection.Open();
            LoadDLKH();
        }
        private void LoadDLKH()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT *FROM tblKhachHang";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            KH.DataSource = table;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Them_KH";
            command.Parameters.AddWithValue("@tenKH", txtBoxTenKH.Text);
            command.Parameters.AddWithValue("@maKH", txtBoxMaKH.Text);
            command.Parameters.AddWithValue("@sdtKH", txtBoxSdt.Text);
            command.Parameters.AddWithValue("@emailKH", txtBoxEmail.Text);
            command.Parameters.AddWithValue("@diaChiKH", txtBoxDiachi.Text);
            command.ExecuteNonQuery();
            LoadDLKH();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "suaKH";

            command.Parameters.AddWithValue("@tenKH", txtBoxTenKH.Text);
            command.Parameters.AddWithValue("@maKH", txtBoxMaKH.Text);
            command.Parameters.AddWithValue("@sdtKH", txtBoxSdt.Text);
            command.Parameters.AddWithValue("@emailKH", txtBoxEmail.Text);
            command.Parameters.AddWithValue("@diaChiKH", txtBoxDiachi.Text);
            command.ExecuteNonQuery();
            LoadDLKH();
        }

        private void KH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            txtBoxSdt.ReadOnly = true;
            int i;
            i = KH.CurrentRow.Index;
            txtBoxMaKH.Text = KH.Rows[i].Cells[0].Value.ToString();
            txtBoxTenKH.Text = KH.Rows[i].Cells[1].Value.ToString();
            txtBoxSdt.Text = KH.Rows[i].Cells[2].Value.ToString();
            txtBoxDiachi.Text = KH.Rows[i].Cells[3].Value.ToString();
            txtBoxEmail.Text = KH.Rows[i].Cells[4].Value.ToString();
        }
    }
}
