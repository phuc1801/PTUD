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

namespace de4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadHienThi();
        }
        string str = @"Data Source=DESKTOP-5NL0O53;Initial Catalog=HH;Integrated Security=True";
        SqlDataAdapter da;
        DataTable dt;
        void loadHienThi()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    conn.Open();
                    string query = "select * from NhaCungCap";
                    da = new SqlDataAdapter(query, conn);
                    dt = new DataTable();
                    da.Fill(dt);
                    dgvHienThi.DataSource = dt; 
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=0 && e.RowIndex < dgvHienThi.Rows.Count)
            {
                int i = dgvHienThi.CurrentRow.Index;
                txtMaNCC.Text = dgvHienThi.Rows[i].Cells[0].Value.ToString();
                txtHoTen.Text = dgvHienThi.Rows[i].Cells[1].Value.ToString();
                txtDiaChi.Text = dgvHienThi.Rows[i].Cells[2].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (batLoi())
                {
                    using (SqlConnection conn = new SqlConnection(str))
                    {
                        conn.Open();
                        string query = "insert NhaCungCap(HoTen, DiaChi) values (@TenNCC, @DiaChi)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@TenNCC", txtHoTen.Text);
                            cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                            cmd.ExecuteNonQuery();
                        }
                        loadHienThi();
                    }
                }

            }catch(Exception ex) { 
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (batLoi())
                {
                    using (SqlConnection conn = new SqlConnection(str))
                    {
                        conn.Open();
                        string query = "update NhaCungCap set HoTen = @TenNCC, DiaChi = @DiaChi where MaNhaCungCap = @MaNCC";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaNCC", int.Parse(txtMaNCC.Text));
                            cmd.Parameters.AddWithValue("@TenNCC", txtHoTen.Text);
                            cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                            cmd.ExecuteNonQuery();
                        }
                        loadHienThi();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    conn.Open();
                    string query = "delete from NhaCungCap where MaNhaCungCap = @MaNCC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNCC", int.Parse(txtMaNCC.Text));                      
                        cmd.ExecuteNonQuery();
                    }
                    loadHienThi();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool batLoi()
        {
            if (txtHoTen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Tên không để trống");
                return false;
            }
            if (txtHoTen.Text.Trim().Length > 30)
            {
                MessageBox.Show("Tên không được vượt quá 30 ký tự");
                return false;
            }
            if (int.TryParse(txtHoTen.Text, out int val))
            {
                MessageBox.Show("Tên không được là số");
                return false;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("địa chỉ không để trống");
                return false;
            }
            if (txtDiaChi.Text.Trim().Length > 100)
            {
                MessageBox.Show("Tên không được vượt quá 100 ký tự");
                return false;
            }
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                string query = "Select Count(*) from NhaCungCap where MaNhaCungCap = @MaNCC";
               if(int.TryParse(txtMaNCC.Text, out int ma))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNCC", ma);
                        int count = (int)cmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Mã và tên NCC đã có trong CSDL");
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtTimKiem.Text.Trim().Length == 0)
                {
                    loadHienThi();
                }
                else
                {
                    if(int.TryParse(txtTimKiem.Text, out int ma))
                    {
                        using (SqlConnection conn = new SqlConnection(str))
                        {
                            conn.Open();
                            string query = "select * from NhaCungCap where MaNhaCungCap = @MaNCC";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@MaNCC", ma);
                                da = new SqlDataAdapter(cmd);
                                dt = new DataTable();
                                da.Fill(dt);
                                dgvHienThi.DataSource = dt;
                            }
                        }
                    }
                    else
                    {
                        using (SqlConnection conn = new SqlConnection(str))
                        {
                            conn.Open();
                            string query = "select * from NhaCungCap where HoTen like '%' + @TenNCC + '%'";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@TenNCC", txtTimKiem.Text);
                                da = new SqlDataAdapter(cmd);
                                dt = new DataTable();
                                da.Fill(dt);
                                dgvHienThi.DataSource = dt;
                            }
                        }
                    }
                }
            }catch(Exception ex) { 
                MessageBox.Show(ex.Message);
            }
        }
    }
}
