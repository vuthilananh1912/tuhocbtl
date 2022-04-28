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
    public partial class QuanLyHoaDon : Form
    {
        string dataSource = ConfigurationManager.ConnectionStrings["KinhDoanhMayTinh"].ConnectionString;
        string currentSDT, currentMaNV, currentMaHang, currentTime;


        public QuanLyHoaDon()
        {
            InitializeComponent();
            gvChiTietHoaDon.ColumnCount = 4;
            gvChiTietHoaDon.Columns[0].HeaderText = "Mã hàng";
            gvChiTietHoaDon.Columns[1].HeaderText = "Mặt hàng";
            gvChiTietHoaDon.Columns[2].HeaderText = "Số lượng";
            gvChiTietHoaDon.Columns[3].HeaderText = "Đơn giá";
        }
        private void QuanLyHoaDon_Load(object sender, EventArgs e)
        {
            currentTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            LoadMaHD();
            LoadNgayLap();
            LoadTenKH();
            LoadTenNV();
            LoadTenMH();
        }

        private void LoadTenKH()
        {
            using (SqlConnection connection = new SqlConnection(dataSource))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblKhachHang", connection))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        DataView view = new DataView(table);
                        view.Sort = "sTenKH";
                        view.Sort = "sSDTKH";
                        cbTenKhachHang.DataSource = view;
                        cbTenKhachHang.DisplayMember = "sTenKH";

                    }
                }
            }
        }

        private void LoadTenNV()
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
                        view.Sort = "sTenNV";
                        cbTenNhanVien.DataSource = view;
                        cbTenNhanVien.DisplayMember = "sTenNV";
                    }
                }
            }
        }

        private void LoadTenMH()
        {
            using (SqlConnection connection = new SqlConnection(dataSource))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblSanPham", connection))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        DataView view = new DataView(table);
                        view.Sort = "sTenSP";
                        cbTenMatHang.DataSource = view;
                        cbTenMatHang.DisplayMember = "sTenSP";
                    }
                }
            }
        }

        private void LoadMaHD()
        {
            labelMaHD.Text = (DateTimeOffset.Now.ToUnixTimeMilliseconds() - 1650700000000).ToString();
        }

        private void LoadNgayLap()
        {
            labelThoiGianLap.Text = DateTime.Now.Date.ToString("MM/dd/yyyy");
        }

        private void cbTenNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            string queryString = "pro_timmanvtheoten";
            using (SqlConnection connection = new SqlConnection(dataSource))
            {
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sTenNV", cbTenNhanVien.Text);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            string sMaNV = row["sMaNV"].ToString();
                            currentMaNV = sMaNV;
                        }
                    }
                    connection.Close();
                }
            }
        }

        private void cbTenKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string queryString = "pro_timsdtkhachhangtheoten";
            using (SqlConnection connection = new SqlConnection(dataSource))
            {
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sTenKH", cbTenKhachHang.Text);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            string sdt = row["sSDTKH"].ToString();
                            currentSDT = sdt;
                        }
                    }


                    connection.Close();
                }
            }
        }

        private void cbTenMatHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string queryString = "pro_giasanphamtheomasp";
            using (SqlConnection connection = new SqlConnection(dataSource))
            {
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sTenSP", cbTenMatHang.Text);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            string giaTien = row["fGiaTien"].ToString();
                            string maSP = row["sMaSP"].ToString();
                            labelDonGia.Text = giaTien;
                            currentMaHang = maSP;
                        }
                    }


                    connection.Close();
                }
            }
        }

        private void deleteRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.gvChiTietHoaDon.Rows[this.rowIndex].IsNewRow)
            {
                this.gvChiTietHoaDon.Rows.RemoveAt(this.rowIndex);
            }
        }

        private int rowIndex = 0;
        private void gvChiTietHoaDon_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                this.gvChiTietHoaDon.Rows[e.RowIndex].Selected = true;
                this.rowIndex = e.RowIndex;
                this.gvChiTietHoaDon.CurrentCell = this.gvChiTietHoaDon.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip1.Show(this.gvChiTietHoaDon, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void gvChiTietHoaDon_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            gvChiTietHoaDon.Rows[0].HeaderCell.Value = "Mặt hàng";
            gvChiTietHoaDon.Rows[0].HeaderCell.Value = "Số lượng";
            gvChiTietHoaDon.Rows[0].HeaderCell.Value = "Đơn giá";
        }

        private void btnAddView_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = (DataGridViewRow)gvChiTietHoaDon.Rows[0].Clone();
            row.Cells[0].Value = currentMaHang;
            row.Cells[1].Value = cbTenMatHang.Text;
            row.Cells[2].Value = numSoLuong.Value.ToString();
            row.Cells[3].Value = labelDonGia.Text;

            if (numSoLuong.Value <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0");
            }
            else
            {
                int count = 0;
                foreach (DataGridViewRow row1 in gvChiTietHoaDon.Rows)
                {
                    if (gvChiTietHoaDon.Rows[row1.Index].Cells[0].Value == currentMaHang)
                    {
                        gvChiTietHoaDon.Rows[row1.Index].Cells[2].Value = Convert.ToInt32(gvChiTietHoaDon.Rows[row1.Index].Cells[2].Value) + numSoLuong.Value ;
                        count++;
                    }

                    //More code here
                }
                if(count == 0)
                {
                    gvChiTietHoaDon.Rows.Add(row);
                }


                long tongtien = 0;
                foreach (DataGridViewRow row1 in gvChiTietHoaDon.Rows)
                {
                    if (gvChiTietHoaDon.Rows[row1.Index].Cells[3].Value != null)
                    {

                        tongtien += long.Parse(gvChiTietHoaDon.Rows[row1.Index].Cells[3].Value.ToString()) * int.Parse(gvChiTietHoaDon.Rows[row1.Index].Cells[2].Value.ToString());
                    }

                    //More code here
                }
                labelTongTien.Text = tongtien.ToString();

            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvChiTietHoaDon.Rows.Count == 1)
                {
                    MessageBox.Show("Vui lòng thêm sản phẩm!");
                }
                else
                {
                    string queryString = "pro_ThemHoaDon";
                    using (SqlConnection connection = new SqlConnection(dataSource))
                    {
                        using (SqlCommand cmd = new SqlCommand(queryString, connection))
                        {
                            connection.Open();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@sMaHD", labelMaHD.Text);
                            cmd.Parameters.AddWithValue("@dThoiGianLap", currentTime);
                            cmd.Parameters.AddWithValue("@dThoiGianThanhToan", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
                            cmd.Parameters.AddWithValue("@sMaNV", currentMaNV);
                            cmd.Parameters.AddWithValue("@sSDTKH", currentSDT);

                            cmd.ExecuteNonQuery();
                            connection.Close();
                        }
                    }



                    string[,] DataValue = new string[gvChiTietHoaDon.Rows.Count, gvChiTietHoaDon.Columns.Count];
                    foreach (DataGridViewRow row in gvChiTietHoaDon.Rows)
                    {
                        foreach (DataGridViewColumn col in gvChiTietHoaDon.Columns)
                        {
                            if (gvChiTietHoaDon.Rows[row.Index].Cells[col.Index].Value != null)
                            {
                                DataValue[row.Index, col.Index] = gvChiTietHoaDon.Rows[row.Index].Cells[col.Index].Value.ToString();
                            }
                        }

                        //More code here
                    }


                    for (int i = 0; i < gvChiTietHoaDon.Rows.Count; i++)
                    {

                        if (DataValue[i, 0] != null)
                        {
                            string queryString2 = "pro_ThemChiTietHoaDon";
                            using (SqlConnection connection = new SqlConnection(dataSource))
                            {
                                using (SqlCommand cmd = new SqlCommand(queryString2, connection))
                                {
                                    connection.Open();
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@sMaHD", labelMaHD.Text);
                                    cmd.Parameters.AddWithValue("@sMaSP", DataValue[i, 0]);
                                    cmd.Parameters.AddWithValue("@iSoLuong", DataValue[i, 2]);

                                    cmd.ExecuteNonQuery();
                                    connection.Close();
                                }
                            }
                        }
                    }
                    MessageBox.Show("Thêm thành công!");
                    FormInHoaDon formInHoaDon = new FormInHoaDon(labelMaHD.Text);
                    formInHoaDon.Show();
                    this.Close();
                    gvChiTietHoaDon.Rows.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
