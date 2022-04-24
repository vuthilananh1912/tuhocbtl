using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;

namespace tuhocbtl
{
    public partial class NhaCC : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string constr = ConfigurationManager.ConnectionStrings["KinhDoanhMayTinh"].ConnectionString;

        //static string constr = "Data Source=ADMIN\\SQLEXPRESS;Initial Catalog=QLKDMAYTINH;Integrated Security=True";
        string str = " ";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public NhaCC()
        {
            InitializeComponent();
        }        

        private void NhaCC_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(constr);
            connection.Open();
            LoadDL();
        }
        private void LoadDL()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from tblNhaCC";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            NCC.DataSource = table;
            /*
            using (SqlConnection connection = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select *from tblNhaCC", connection))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        NCC.DataSource = dataTable;
                    }
                }
            }
            */
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtBoxTenNCC.Text == "" || txtBoxSdtNCC.Text == "" || txtBoxDiaChiNCC.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            else
            {
                try
                {
                    command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Them_NCC";
                    //command.Parameters.AddWithValue("@maNCC", txtBoxMaNCC.Text);
                    command.Parameters.AddWithValue("@tenNCC", txtBoxTenNCC.Text);
                    command.Parameters.AddWithValue("@sdtNCC", txtBoxSdtNCC.Text);
                    command.Parameters.AddWithValue("@diaChiNCC", txtBoxDiaChiNCC.Text);
                    command.ExecuteNonQuery();
                    cleartextbox();
                    LoadDL();
                }
                catch(Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }

            }

            /*
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Them_NCC";
            cmd.Parameters.AddWithValue("@tenNCC", txtBoxTenNCC.Text);
            cmd.Parameters.AddWithValue("@sdtNCC", txtBoxSdtNCC.Text);
            cmd.Parameters.AddWithValue("@diaChiNCC", txtBoxDiaChiNCC.Text);
            
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("thêm thành công nhà cung cấp");
            }
            else
                MessageBox.Show("đã tồn tại nhà cung cấp");
            conn.Close();
            LoadDL();
            */
        }



        private void NCC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //txtBoxTenNCC.ReadOnly = true;
            //int i;
            //i = NCC.CurrentRow.Index;
            ////txtBoxMaNCC.Text = NCC.Rows[i].Cells[0].Value.ToString();
            //txtBoxTenNCC.Text = NCC.Rows[i].Cells[0].Value.ToString();
            //txtBoxSdtNCC.Text = NCC.Rows[i].Cells[1].Value.ToString();
            //txtBoxDiaChiNCC.Text = NCC.Rows[i].Cells[2].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Sua_NCC";
                //command.Parameters.AddWithValue("@maNCC", txtBoxMaNCC.Text);
                command.Parameters.AddWithValue("@tenNCC", txtBoxTenNCC.Text);
                command.Parameters.AddWithValue("@sdtNCC", txtBoxSdtNCC.Text);
                command.Parameters.AddWithValue("@diaChiNCC", txtBoxDiaChiNCC.Text);
                command.ExecuteNonQuery();
                cleartextbox();
                LoadDL();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
        }

        private void NCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBoxTenNCC.ReadOnly = true;
            int i;
            i = NCC.CurrentRow.Index;
            //txtBoxMaNCC.Text = NCC.Rows[i].Cells[0].Value.ToString();
            txtBoxTenNCC.Text = NCC.Rows[i].Cells[0].Value.ToString();
            txtBoxSdtNCC.Text = NCC.Rows[i].Cells[1].Value.ToString();
            txtBoxDiaChiNCC.Text = NCC.Rows[i].Cells[2].Value.ToString();
        
        }
        private void cleartextbox()
        {
            txtBoxTenNCC.Text = "";
            txtBoxSdtNCC.Text = "";
            txtBoxDiaChiNCC.Text = "";
        }
    }
}
