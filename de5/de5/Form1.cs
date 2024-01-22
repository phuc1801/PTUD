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
namespace de5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadHienThi();
        }
        string str = @"Data Source=DESKTOP-5NL0O53;Initial Catalog=K;Integrated Security=True";
        SqlDataAdapter da;
        DataTable dt;
        void loadHienThi()
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(str))
                {
                    conn.Open();
                    string query = "select MaHangHoa, TenHangHoa, GhiChu from HangHoa";
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
                txtMaHH.Text = dgvHienThi.Rows[i].Cells[0].Value.ToString();
                txtTenHH.Text = dgvHienThi.Rows[i].Cells[1].Value.ToString();               
                txtGhiChu.Text = dgvHienThi.Rows[i].Cells[2].Value.ToString();
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
                        string query = "insert HangHoa(TenHangHoa, GhiChu) values (@TenHH, @GhiChu)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@TenHH", txtTenHH.Text);
                            cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);
                            cmd.ExecuteNonQuery();
                        }
                        loadHienThi();
                    }
                }
            }catch(Exception ex)
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
                        string query = "update HangHoa set TenHangHoa = @TenHH, GhiChu = @GhiChu where MaHangHoa = @MaHH";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaHH", int.Parse(txtMaHH.Text));
                            cmd.Parameters.AddWithValue("@TenHH", txtTenHH.Text);
                            cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);
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
                    string query = "delete from HangHoa where MaHangHoa = @MaHH";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaHH", int.Parse(txtMaHH.Text));                        
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
            if(txtTenHH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ten khong duoc de trong");
                return false;
            }
            if (txtTenHH.Text.Trim().Length > 30)
            {
                MessageBox.Show("Ten khong duoc vuot qua 30 ky tu");
                return false;
            }
            if(int.TryParse(txtTenHH.Text, out int ten))
            {
                MessageBox.Show("Ten khong duoc la so");
                return false;
            }
            if (txtGhiChu.Text.Trim().Length > 100)
            {
                MessageBox.Show("Ghi khong duoc vuot qua 100 ky tu");
                return false;
            }
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                string query = "select count(*) from HangHoa where MaHangHoa = @MaHH";
               if(int.TryParse(txtMaHH.Text, out int ma))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaHH", ma);
                        int count = (int)cmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("MaHH va Ten HH da co trong CSDL");
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
                    if(int.TryParse(txtTimKiem.Text, out int ma)){
                        using (SqlConnection conn = new SqlConnection(str))
                        {
                            conn.Open();
                            string query = "select MaHangHoa, TenHangHoa, GhiChu from HangHoa where MaHangHoa = @MaHH";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@MaHH", ma);
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
                            string query = "select MaHangHoa, TenHangHoa, GhiChu from HangHoa where TenHangHoa like '%'+@TenHH + '%'";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@TenHH", txtTimKiem.Text);
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
