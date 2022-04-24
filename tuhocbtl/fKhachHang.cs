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
    public partial class fKhachHang : Form
    {

        string constr = ConfigurationManager.ConnectionStrings["KinhDoanhMayTinh"].ConnectionString;
        public fKhachHang()
        {
            InitializeComponent();
        }

        public int checkIDKH(string id)
        {
            int check = 0;
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            using (SqlConnection cnn = new SqlConnection(constr))
            {
                string sql = $"select sMaKH from tblKhachHang where sMaKH = '{id}'";

                SqlDataAdapter mydata = new SqlDataAdapter(sql, cnn);
                DataTable tbl = new DataTable();

                mydata.Fill(tbl);
                if (tbl.Rows.Count > 0)
                {
                    check = 1;
                }
            }

            return check;
        }

        public int checkSDTKH(string sdt)
        {
            int check = 0;
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            using (SqlConnection cnn = new SqlConnection(constr))
            {
                string sql = $"select sMaKH from tblKhachHang where sSDTKH = '{sdt}'";

                SqlDataAdapter mydata = new SqlDataAdapter(sql, cnn);
                DataTable tbl = new DataTable();

                mydata.Fill(tbl);
                if (tbl.Rows.Count > 0)
                {
                    check = 1;
                }
            }

            return check;
        }

        public void hienKH()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from tblKhachHang where deletedAt is NULL", cnn))
                {
                    cnn.Open();
                    using (SqlDataAdapter adt = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adt.Fill(dt);
                        dtgvKhachHang.DataSource = dt;
                    }
                    dtgvKhachHang.Columns[0].HeaderText = "Họ tên";
                    dtgvKhachHang.Columns[1].HeaderText = "#";
                    dtgvKhachHang.Columns[2].HeaderText = "Số điện thoại";
                    dtgvKhachHang.Columns[3].HeaderText = "Email";
                    dtgvKhachHang.Columns[4].HeaderText = "Địa chỉ";
                    dtgvKhachHang.Columns[5].Visible = false;
                }
            }
        }

        private void fKhachHang_Load(object sender, EventArgs e)
        {
            hienKH();
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string timKiem = txtTimKiem.Text;
            try
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dtgvKhachHang.DataSource;
                bs.Filter = "sTenKH like '%" + timKiem + "%' " +
                            "or sMaKH like '%" + timKiem + "%' " +
                            "or sSDTKH like '%" + timKiem + "%'" +
                            "or sEmail like '%" + timKiem + "%' " +
                            "or sDiaChi like '%" + timKiem + "%' ";
                dtgvKhachHang.DataSource = bs.DataSource;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            txtHoTen.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            hienKH();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string id = "KH" + DateTime.Now.ToString("yyyyMMddHHmmss");


            if (txtHoTen.Text != "" && txtDiaChi.Text != "" && txtSDT.Text != "" && txtEmail.Text != "")
            {
                if (checkIDKH(id) == 1)
                {
                    MessageBox.Show(string.Format("Khách hàng đã tồn tại"), "Thông báo", MessageBoxButtons.OK);
                }
                else if (checkSDTKH(txtSDT.Text) == 1)
                {
                    MessageBox.Show(string.Format("Số điện thoại đã được đăng kí!"), "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    Console.OutputEncoding = Encoding.Unicode;
                    Console.InputEncoding = Encoding.Unicode;

                    using (SqlConnection cnn = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("themKH", cnn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@sMaKH", id);
                            cmd.Parameters.AddWithValue("@sTenKH", txtHoTen.Text);
                            cmd.Parameters.AddWithValue("@sDiaChi", txtDiaChi.Text);
                            cmd.Parameters.AddWithValue("@sSDTKH", txtSDT.Text);
                            cmd.Parameters.AddWithValue("@sEmail", txtEmail.Text);

                            cnn.Open();
                            int result = cmd.ExecuteNonQuery();
                            cnn.Close();

                            if (result > 0)
                            {
                                MessageBox.Show(string.Format("Bạn đã thêm thành công"), "Thông báo", MessageBoxButtons.OK);
                                hienKH();
                            }
                            else
                            {
                                MessageBox.Show(string.Format("Thêm không thành công"), "Thông báo", MessageBoxButtons.OK);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(string.Format("Thông tin chưa được điền đầy đủ!"), "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void dtgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            txtHoTen.Text = dtgvKhachHang.CurrentRow.Cells[0].Value.ToString();
            txtSDT.Text = dtgvKhachHang.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = dtgvKhachHang.CurrentRow.Cells[3].Value.ToString();
            txtDiaChi.Text = dtgvKhachHang.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có chắn chắn muốn sửa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dg == DialogResult.Yes)
            {
                if (txtSDT.Text != "")
                {
                    if (txtHoTen.Text != "" && txtDiaChi.Text != "" && txtEmail.Text != "")
                    {
                        using (SqlConnection cnn = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand("suaKH", cnn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@sTenKH", txtHoTen.Text);
                                cmd.Parameters.AddWithValue("@sSDTKH", txtSDT.Text);
                                cmd.Parameters.AddWithValue("@sEmail", txtEmail.Text);
                                cmd.Parameters.AddWithValue("@sDiaChi", txtDiaChi.Text);
                                int result = 0;
                                cnn.Open();
                                result = cmd.ExecuteNonQuery();
                                cnn.Close();


                                if (result > 0)
                                {
                                    MessageBox.Show(string.Format("Sửa thành công!"), "Thông báo", MessageBoxButtons.OK);
                                    hienKH();
                                }
                                else
                                {
                                    MessageBox.Show(string.Format("Sửa không thành công!"), "Thông báo", MessageBoxButtons.OK);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Thông tin chưa được điền đầy đủ!"), "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show(string.Format("Chọn khách hàng muốn sửa"), "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtSDT.Text == "")
            {
                MessageBox.Show("Chọn khách hàng muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                return;
            }
            else if (checkSDTKH(txtSDT.Text) != 1)
            {
                MessageBox.Show("Không tồn tại khách hàng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                return;
            }

            DialogResult dg = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dg == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        int result = 0;
                        DateTime deletedAt = DateTime.Now;

                        cmd.Connection = conn;
                        cmd.CommandText = "xoaKH";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@sSDTKH", txtSDT.Text);
                        cmd.Parameters.AddWithValue("@deletedAt", deletedAt);
                        conn.Open();
                        result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show(string.Format("Xóa thành công"), "Thông báo", MessageBoxButtons.OK);
                            hienKH();
                        }
                        else
                        {
                            MessageBox.Show(string.Format("Xóa không thành công"), "Thông báo", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void fKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng Form lại hay không?", "FormClosing", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                e.Cancel = false;// Đóng Form lại
            }
            else
                e.Cancel = true;//Không đóng Form nữa
        }
    }
}
