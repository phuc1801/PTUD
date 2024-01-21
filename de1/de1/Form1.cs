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

namespace de1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadHienThi();
        }

        string str = @"Data Source=DESKTOP-5NL0O53;Initial Catalog=QLPHIM;Integrated Security=True";
        SqlDataAdapter da;
        DataTable dt;
        void loadHienThi()
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(str))
                {
                    conn.Open();
                    string query = "Select * from DienVien";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    dt = new DataTable();
                    da.Fill(dt);
                    dgvHienThi.DataSource = dt;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (batloi())
                {
                    using (SqlConnection conn = new SqlConnection(str))
                    {
                        conn.Open();
                        string query = "insert into DienVien(HoTen, NgaySinh) values (@HoTen, @NgaySinh)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@HoTen", txtTenDV.Text);
                            cmd.Parameters.AddWithValue("@NgaySinh", DateTime.Parse(dtpNgaySinh.Text).Date);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    loadHienThi();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (batloi())
                {
                    using (SqlConnection conn = new SqlConnection(str))
                    {
                        conn.Open();
                        string query = "update DienVien set HoTen = @HoTen, NgaySinh = @NgaySinh where MaDV = @MaDV";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaDV", int.Parse(txtMaDV.Text));
                            cmd.Parameters.AddWithValue("@HoTen", txtTenDV.Text);
                            cmd.Parameters.AddWithValue("@NgaySinh", DateTime.Parse(dtpNgaySinh.Text).Date);
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
                    string query = "delete from DienVien where MaDV = @MaDV";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDV", int.Parse(txtMaDV.Text));
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTimKiem.Text.Trim() == "")
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
                            string query = "select * from DienVien where MaDV = @MaDV";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@MaDV", ma);
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
                            string query = "select * from DienVien where HoTen like '%' + @HoTen + '%'";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@HoTen", txtTimKiem.Text);
                                da = new SqlDataAdapter(cmd);
                                dt = new DataTable();
                                da.Fill(dt);
                                dgvHienThi.DataSource = dt;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.RowIndex < dgvHienThi.Rows.Count) {
                int i = dgvHienThi.CurrentRow.Index;
                txtMaDV.Text = dgvHienThi.Rows[i].Cells[0].Value.ToString();
                txtTenDV.Text = dgvHienThi.Rows[i].Cells[1].Value.ToString();
                dtpNgaySinh.Text = dgvHienThi.Rows[i].Cells[2].Value.ToString();
            }
        }
        // bat loi
        bool batloi()
        {
            if(txtTenDV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Tên diễn viên không được để trống");
                return false;
            }
            if(txtTenDV.Text.Trim().Length > 30)
            {
                MessageBox.Show("Tên diễn viên không được vượt quá 30 ký tự");
                return false;
            }
            DateTime NgaySinh = dtpNgaySinh.Value.Date;
            if(DateTime.Compare(NgaySinh.AddYears(18), DateTime.Now) > 0)
            {
                MessageBox.Show("Ngày sinh phải trên 18 tuổi");
                return false;
            }

            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                string query = "Select Count(*) from DienVien where MaDV = @MaDV";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDV", int.Parse(txtMaDV.Text));
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Diễn Viên đã có trong CSDL");
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
