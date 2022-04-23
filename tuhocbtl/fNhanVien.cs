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
    public partial class fNhanVien : Form
    {

        string constr = ConfigurationManager.ConnectionStrings["KinhDoanhMayTinh"].ConnectionString;
        public fNhanVien()
        {
            InitializeComponent();
        }

        public void hienNV()
        {
            using (SqlConnection sqlConnection = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from tblNhanVien where deletedAt is null", sqlConnection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvNhanVien.DataSource = dt;
                    }
                }
            }
            dgvNhanVien.Columns[11].Visible = false; //an column DeletedAt
        }

        public int checkMaNV(string ma)
        {
            int check = 0;
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            using (SqlConnection cnn = new SqlConnection(constr))
            {
                string sql = $"select * from tblNhanVien where sMaNV = '{ma}'";

                SqlDataAdapter mydata = new SqlDataAdapter(sql, cnn);
                DataTable dt = new DataTable();

                mydata.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    check = 1;
                }
            }
            return check;
        }

        private void fNhanVien_Load(object sender, EventArgs e)
        {
            hienNV();
        }

        private void btnAddNV_Click(object sender, EventArgs e)
        {
            string gioiTinh = "Nữ";
            if (radioBtnNam.Checked == true)
            {
                gioiTinh = "Nam";
            }
            else
                gioiTinh = "Nữ";

            if (checkMaNV(txtsMaNV.Text) != 1)
            {
                Console.OutputEncoding = Encoding.Unicode;
                Console.InputEncoding = Encoding.Unicode;

                using (SqlConnection cnn = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("prInserNV", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@manv", txtsMaNV.Text);
                        cmd.Parameters.AddWithValue("@tennv", txtsTenNV.Text);
                        cmd.Parameters.AddWithValue("@ngaysinh", (DateTime.Parse(dNgaySinh.Text)).ToString("yyyyMMdd"));
                        cmd.Parameters.AddWithValue("@gioitinh", gioiTinh);
                        cmd.Parameters.AddWithValue("@diachi", txtsDiaChi.Text);
                        cmd.Parameters.AddWithValue("@sdt", txtsSDT.Text);
                        cmd.Parameters.AddWithValue("@hsl", txtHeSoLuong.Text);
                        cmd.Parameters.AddWithValue("@luongcb", txtLuongCoBan.Text);
                        cmd.Parameters.AddWithValue("@ngayvaolam", (DateTime.Parse(dNgayvaolam.Text)).ToString("yyyyMMdd"));
                        cmd.Parameters.AddWithValue("@tendn", txtsTenNV.Text);
                        cmd.Parameters.AddWithValue("@matkhau", txtMatKhau.Text);

                        cnn.Open();
                        int result = cmd.ExecuteNonQuery();
                        cnn.Close();

                        if (result > 0)
                        {
                            MessageBox.Show(string.Format("Bạn đã thêm thành công"), "Thông báo", MessageBoxButtons.OK);
                            hienNV();
                        }
                        else
                        {
                            MessageBox.Show(string.Format("Thêm không thành công"), "Thông báo", MessageBoxButtons.OK);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(string.Format("Nhân viên đã tồn tại !"), "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvNhanVien.Rows[e.RowIndex];
                txtsMaNV.Text = row.Cells[0].Value.ToString();
                txtsTenNV.Text = row.Cells[1].Value.ToString();
                dNgaySinh.Text = row.Cells[2].Value.ToString();
                if (row.Cells[3].Value.ToString() == "Nam")
                {
                    radioBtnNam.Checked = true;
                }
                else
                    radioBtnNu.Checked = true;
                txtsDiaChi.Text = row.Cells[4].Value.ToString();
                txtsSDT.Text = row.Cells[5].Value.ToString();
                txtHeSoLuong.Text = row.Cells[6].Value.ToString();
                txtLuongCoBan.Text = row.Cells[7].Value.ToString();
                dNgayvaolam.Text = row.Cells[8].Value.ToString();
                txtTenDangNhap.Text = row.Cells[9].Value.ToString();
                txtMatKhau.Text = row.Cells[10].Value.ToString();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dgvNhanVien.DataSource;
                bs.Filter = "sMaNV like '%" + txtTimKiem.Text + "%' " +
                            "or sTenNV like '%" + txtTimKiem.Text + "%' ";
                dgvNhanVien.DataSource = bs.DataSource;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            if (txtsMaNV.Text == "")
            {
                MessageBox.Show("Chọn nhân viên muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                return;
            }
            else if (checkMaNV(txtsMaNV.Text) != 1)
            {
                MessageBox.Show("Không tồn tại nhân viên?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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
                        cmd.CommandText = "xoaNV";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@manv", txtsMaNV.Text);
                        cmd.Parameters.AddWithValue("@deletedAt", deletedAt);
                        conn.Open();
                        result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show(string.Format("Xóa thành công"), "Thông báo", MessageBoxButtons.OK);
                            hienNV();
                        }
                        else
                        {
                            MessageBox.Show(string.Format("Xóa không thành công"), "Thông báo", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có chắn chắn muốn sửa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dg == DialogResult.Yes)
            {
                if (txtsMaNV.Text != "")
                {
                    string gioiTinh = "";
                    if (radioBtnNam.Checked == true)
                    {
                        gioiTinh = "Nam";
                    }
                    else
                        gioiTinh = "Nữ";

                    if (txtsTenNV.Text != "" && gioiTinh != "" && txtsDiaChi.Text != "" && txtsSDT.Text != "" && txtHeSoLuong.Text != "" && txtLuongCoBan.Text != "" && txtTenDangNhap.Text != "" && txtMatKhau.Text != "")
                    {
                        using (SqlConnection cnn = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand("prSuaNV", cnn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@manv", txtsMaNV.Text);
                                cmd.Parameters.AddWithValue("@tennv", txtsTenNV.Text);
                                cmd.Parameters.AddWithValue("@ngaysinh", (DateTime.Parse(dNgaySinh.Text)).ToString("yyyyMMdd"));
                                cmd.Parameters.AddWithValue("@gioitinh", gioiTinh);
                                cmd.Parameters.AddWithValue("@diachi", txtsDiaChi.Text);
                                cmd.Parameters.AddWithValue("@sdt", txtsSDT.Text);
                                cmd.Parameters.AddWithValue("@hsl", txtHeSoLuong.Text);
                                cmd.Parameters.AddWithValue("@luongcb", txtLuongCoBan.Text);
                                cmd.Parameters.AddWithValue("@ngayvaolam", (DateTime.Parse(dNgayvaolam.Text)).ToString("yyyyMMdd"));
                                cmd.Parameters.AddWithValue("@tendn", txtTenDangNhap.Text);
                                cmd.Parameters.AddWithValue("@matkhau", txtMatKhau.Text);

                                int result = 0;
                                cnn.Open();
                                result = cmd.ExecuteNonQuery();
                                cnn.Close();


                                if (result > 0)
                                {
                                    MessageBox.Show(string.Format("Sửa thành công!"), "Thông báo", MessageBoxButtons.OK);
                                    hienNV();
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
                    MessageBox.Show(string.Format("Chọn nhân viên muốn sửa"), "Thông báo", MessageBoxButtons.OK);
                }
            }
        }
    }
}
