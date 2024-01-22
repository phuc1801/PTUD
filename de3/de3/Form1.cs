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

namespace de3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadHienThi();
        }

        string str = @"Data Source=DESKTOP-5NL0O53;Initial Catalog=NN;Integrated Security=True";
        SqlDataAdapter da;
        DataTable dt;
        void loadHienThi()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    conn.Open();
                    string query = "Select * from NgoaiNgu";
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
                txtMaNN.Text = dgvHienThi.Rows[i].Cells[0].Value.ToString();
                txtTenNN.Text = dgvHienThi.Rows[i].Cells[1].Value.ToString();
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
                        string query = "insert NgoaiNgu values (@TenNN)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@TenNN", txtTenNN.Text);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    loadHienThi();
                }
            }catch (Exception ex)
            {
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
                        string query = "update NgoaiNgu set TenNgoaiNgu = @TenNN where MaNgoaiNgu = @MaNN";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaNN", int.Parse(txtMaNN.Text));
                            cmd.Parameters.AddWithValue("@TenNN", txtTenNN.Text);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    loadHienThi();
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
                    string query = "delete from NgoaiNgu where MaNgoaiNgu = @MaNN";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNN", int.Parse(txtMaNN.Text));                 
                        cmd.ExecuteNonQuery();
                    }
                }
                loadHienThi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool batLoi()
        {
            if(txtTenNN.Text.Trim().Length == 0) {
                MessageBox.Show("Tên không được để trống");
                return false;
            }
            if (txtTenNN.Text.Trim().Length > 30)
            {
                MessageBox.Show("Tên không được vượt quá 30 ký tự");
                return false;
            }
            if(int.TryParse(txtTenNN.Text, out int num))
            {
                MessageBox.Show("Tên không được là số");
                return false;
            }
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                string query = "select count(*) from NgoaiNgu where MaNgoaiNgu = @MaNN";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNN", int.Parse(txtMaNN.Text));
                    int count = (int)cmd.ExecuteScalar();
                    if(count > 0)
                    {
                        MessageBox.Show("Mã NN và Tên NN đã có trong CSDL");
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTimKiem.Text.Trim().Length == 0)
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
                            string query = "select * from NgoaiNgu where MaNgoaiNgu = @MaNN";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@MaNN", ma);
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
                            string query = "select * from NgoaiNgu where TenNgoaiNgu like '%'+ @TenNN + '%'";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@TenNN", txtTenNN.Text);
                                da = new SqlDataAdapter(cmd);
                                dt = new DataTable();
                                da.Fill(dt);
                                dgvHienThi.DataSource = dt;
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
