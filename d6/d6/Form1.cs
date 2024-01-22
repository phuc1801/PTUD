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

namespace d6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadHienThi();
        }
        string str = @"Data Source=DESKTOP-5NL0O53;Initial Catalog=CC;Integrated Security=True";
        SqlDataAdapter da;
        DataTable dt;
        void loadHienThi()
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(str)) {
                    conn.Open();
                    string query = "select * from ChungChi";
                    da = new SqlDataAdapter(query, conn);   
                    dt = new DataTable();
                    da.Fill(dt);
                    dgvHienThi.DataSource = dt;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=0 && e.RowIndex < dgvHienThi.Rows.Count)
            {
                int i = dgvHienThi.CurrentRow.Index;
                txtMaCC.Text = dgvHienThi.Rows[i].Cells[0].Value.ToString();
                txtTenCC.Text = dgvHienThi.Rows[i].Cells[1].Value.ToString();
                txtThoiHan.Text = dgvHienThi.Rows[i].Cells[2].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (batLoiThem())
                {
                    using (SqlConnection conn = new SqlConnection(str))
                    {
                        conn.Open();
                        string query = "insert ChungChi values (@TenCC, @ThoiHan)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@TenCC", txtTenCC.Text);
                            cmd.Parameters.AddWithValue("@ThoiHan", int.Parse(txtThoiHan.Text));
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
                if (batLoiSua())
                {
                    using (SqlConnection conn = new SqlConnection(str))
                    {
                        conn.Open();
                        string query = "update ChungChi set TenChungchi = @TenCC, ThoiHan = @ThoiHan where MaChungChi = @MaCC";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaCC", int.Parse(txtMaCC.Text));
                            cmd.Parameters.AddWithValue("@TenCC", txtTenCC.Text);
                            cmd.Parameters.AddWithValue("@ThoiHan", int.Parse(txtThoiHan.Text));
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
                    string query = "delete from ChungChi where MaChungChi = @MaCC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaCC", int.Parse(txtMaCC.Text));                       
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

        bool batLoiThem()
        {
            if(txtTenCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Tên không được để trống");
                return false;
            }
            if (txtTenCC.Text.Trim().Length >30)
            {
                MessageBox.Show("Tên không được vượt 30 ký tự");
                return false;
            }
            if (int.TryParse(txtTenCC.Text, out int ten))
            {
                MessageBox.Show("Tên không được là số");
                return false;
            }
            if (txtThoiHan.Text.Trim().Length == 0)
            {
                MessageBox.Show("thời hạn không được để trống");
                return false;
            }

            if (!int.TryParse(txtThoiHan.Text, out int th))
            {
                MessageBox.Show("Thời hạn là số nguyên");
                return false;
            }
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                string query = "select count(*) from ChungChi where MaChungChi = @MaCC";
                if(int.TryParse(txtMaCC.Text, out int ma))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaCC", ma);
                        int count = (int)cmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Mã chứng chỉ hoặc tên chứng chỉ đã tồn tại trong CSDL");
                            return false;
                        }
                    }
                }
                
            }
            return true;
        }

        bool batLoiSua()
        {
            if (txtTenCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Tên không được để trống");
                return false;
            }
            if (txtTenCC.Text.Trim().Length > 30)
            {
                MessageBox.Show("Tên không được vượt 30 ký tự");
                return false;
            }
            if (int.TryParse(txtTenCC.Text, out int ten))
            {
                MessageBox.Show("Tên không được là số");
                return false;
            }
            if (txtThoiHan.Text.Trim().Length == 0)
            {
                MessageBox.Show("thời hạn không được để trống");
                return false;
            }

            if (!int.TryParse(txtThoiHan.Text, out int th))
            {
                MessageBox.Show("Thời hạn là số nguyên");
                return false;
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
                            string query = "select * from ChungChi where MaChungChi = @MaCC";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@MaCC", ma);
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
                            string query = "select * from ChungChi where TenChungChi like '%'+ @TenCC + '%'";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@TenCC", txtTimKiem.Text);
                                da = new SqlDataAdapter(cmd);
                                dt = new DataTable();
                                da.Fill(dt);
                                dgvHienThi.DataSource = dt;
                            }

                        }
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
