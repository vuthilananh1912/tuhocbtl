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
    public partial class fSanPham : Form
    {
        string constr = ConfigurationManager.ConnectionStrings["KinhDoanhMayTinh"].ConnectionString;
        public fSanPham()
        {
            InitializeComponent();
        }

        public void SanPham_Load()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from tblSanPham where deletedAt is NULL", cnn))
                {
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        ad.Fill(dt);
                        dtgvSanPham.DataSource = dt;

                    }
                    dtgvSanPham.Columns[0].HeaderText = "Mã sản phẩm";
                    dtgvSanPham.Columns[1].HeaderText = "Tên sản phẩm";
                    dtgvSanPham.Columns[2].HeaderText = "Hãng sản xuất";
                    dtgvSanPham.Columns[3].HeaderText = "Năm sản xuất";
                    dtgvSanPham.Columns[4].HeaderText = "Mã nhà cung cấp";
                    dtgvSanPham.Columns[5].HeaderText = "Đơn vị tính";
                    dtgvSanPham.Columns[6].HeaderText = "Đơn giá";

                    dtgvSanPham.Columns[7].Visible = false;
                }
            }
        }

        private void fSanPham_Load(object sender, EventArgs e)
        {
            SanPham_Load();
        }

        private void dtgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dtgvSanPham.CurrentRow.Index;
            txtMa.Text = dtgvSanPham.Rows[i].Cells[0].Value.ToString();
            txtTenSP.Text = dtgvSanPham.Rows[i].Cells[1].Value.ToString();
            txtHangsx.Text = dtgvSanPham.Rows[i].Cells[2].Value.ToString();
            txtnamsx.Text = dtgvSanPham.Rows[i].Cells[3].Value.ToString();
            txtMaNCC.Text = dtgvSanPham.Rows[i].Cells[4].Value.ToString();
            txtDonvitinh.Text = dtgvSanPham.Rows[i].Cells[5].Value.ToString();
            txtDonGia.Text = dtgvSanPham.Rows[i].Cells[6].Value.ToString();
        }

        private bool KiemTra()
        {
            if (txtMa.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMa.Focus();
                return false;
            }
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNCC.Focus();
                return false;
            }
            if (txtTenSP.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenSP.Focus();
                return false;
            }
            if (txtDonGia.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDonGia.Focus();
                return false;
            }
            if (txtHangsx.Text == "")
            {
                MessageBox.Show("Vui lòng nhập hãng sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHangsx.Focus();
                return false;
            }
            if (txtnamsx.Text == "")
            {
                MessageBox.Show("Vui lòng nhập năm sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtnamsx.Focus();
                return false;
            }
            if (txtDonvitinh.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đơn vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDonvitinh.Focus();
                return false;
            }

            return true;
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                try
                {
                    using (SqlConnection cnn = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = cnn.CreateCommand())
                        {
                            cmd.Connection = cnn;
                            cmd.CommandText = "ThemSP";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@sMaSP", txtMa.Text);
                            cmd.Parameters.AddWithValue("@sTenSP", txtTenSP.Text);
                            cmd.Parameters.AddWithValue("@sHangSX", txtHangsx.Text);
                            cmd.Parameters.AddWithValue("@iNamSX", txtnamsx.Text);
                            cmd.Parameters.AddWithValue("@sMaNCC", txtMaNCC.Text);
                            cmd.Parameters.AddWithValue("@sDonviTinh", txtDonvitinh.Text);
                            cmd.Parameters.AddWithValue("@fDonGia", txtDonGia.Text);
                            cnn.Open();
                            cmd.ExecuteNonQuery();
                            fSanPham_Load(sender, e);
                            MessageBox.Show("Thêm sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    MessageBox.Show("Bạn có chắc muốn sửa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    cmd.Connection = cnn;
                    cmd.CommandText = "SuaSP";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sMaSP", txtMa.Text);
                    cmd.Parameters.AddWithValue("@sTenSP", txtTenSP.Text);
                    cmd.Parameters.AddWithValue("@sHangSX", txtHangsx.Text);
                    cmd.Parameters.AddWithValue("@iNamSX", txtnamsx.Text);
                    cmd.Parameters.AddWithValue("@sMaNCC", txtMaNCC.Text);
                    cmd.Parameters.AddWithValue("@sDonviTinh", txtDonvitinh.Text);
                    cmd.Parameters.AddWithValue("@fDonGia", txtDonGia.Text);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    fSanPham_Load(sender, e);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    MessageBox.Show("Bạn có chắc muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    int result = 0;
                    DateTime deletedAt = DateTime.Now;

                    cmd.Connection = cnn;
                    cmd.CommandText = "XoaSP";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sMaSP", txtMa.Text);
                    cmd.Parameters.AddWithValue("@deletedAt", deletedAt);
                    cnn.Open();
                    result = cmd.ExecuteNonQuery();
                    //fSanPham_Load(sender, e);
                    if (result > 0)
                    {
                        MessageBox.Show(string.Format("Xóa sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information));
                        fSanPham_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Xóa sản phẩm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information));
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMa.ResetText();
            txtTenSP.ResetText();
            txtHangsx.ResetText();
            txtnamsx.ResetText();
            txtMaNCC.ResetText();
            txtDonvitinh.ResetText();
            txtDonGia.ResetText();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtTimkiemsp_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dtgvSanPham.DataSource;

                bs.Filter = "sMaSP like '%" + txtTimkiemsp.Text + "%'" +
                             "or sTenSP like '%" + txtTimkiemsp.Text + "%'" +
                             "or sHangSX like '%" + txtTimkiemsp.Text + "%'" +
                            "or sMaNCC like '%" + txtTimkiemsp.Text + "%'" +
                            "or sDonviTinh like '%" + txtTimkiemsp.Text + "%'";
                dtgvSanPham.DataSource = bs.DataSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
