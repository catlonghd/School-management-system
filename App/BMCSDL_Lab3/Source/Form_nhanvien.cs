using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;


namespace BMCSDL_Lab3.Source
{


    public partial class Form_nhanvien : Form
    {

        public Form_nhanvien()
        {
            InitializeComponent();
            Functions.InitConnection();

        }

        public void show_nhanvien()
        {
            //MessageBox.Show(Functions.manv);
            SqlCommand cmd = new SqlCommand("SP_SEL_PUBLIC_NHANVIEN '" + Functions.manv + "','" + Functions.passwd + "'", Functions.conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form_modifyStudent_Load(object sender, EventArgs e)
        {
            show_nhanvien();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            //SqlCommand cmd = new SqlCommand("SP_INS_SINHVIEN @MASV,@HOTEN,@NGAYSINH,@DIACHI,@MALOP,@TENDN", Functions.conn);
            SqlCommand cmd = new SqlCommand("SP_INS_PUBLIC_ENCRYPT_NHANVIEN @MANV,@HOTEN,@EMAIL,@LUONG,@TENDN,@MATKHAU,", Functions.conn);
            try
            {
                cmd.Parameters.Add("@MASV", SqlDbType.NVarChar).Value = textBox_manv.Text;
                cmd.Parameters.Add("@HOTEN", SqlDbType.NVarChar).Value = textBox_fullname.Text;
                cmd.Parameters.Add("@LUONG", SqlDbType.VarBinary).Value = Cryptography.RSA_Agl(textBox_luong.Text, textBox_passwd.Text, true);
                cmd.Parameters.Add("@EMAIL", SqlDbType.NVarChar).Value = textBox_email.Text;
                cmd.Parameters.Add("@TENDN", SqlDbType.NVarChar).Value = textBox_username.Text;
                cmd.Parameters.Add("@MATKHAU", SqlDbType.VarChar).Value = Cryptography.HashSHA1(textBox_passwd.Text);
                
                if (textBox_manv.Text != "" && cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm thành công");
                }
                else
                {
                    MessageBox.Show("Thao tác thêm không thể thực hiện");
                }

                show_nhanvien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("student_update_info " + Functions.manv + ",@MASV,@HOTEN,@NGAYSINH,@DIACHI,@MALOP,@TENDN", Functions.conn);
            try
            {
                cmd.Parameters.Add("@MASV", SqlDbType.NVarChar).Value = textBox_manv.Text;
                cmd.Parameters.Add("@HOTEN", SqlDbType.NVarChar).Value = textBox_fullname.Text;

                if (textBox_luong.Text == "")
                    cmd.Parameters.Add("@NGAYSINH", SqlDbType.DateTime).Value = "04/30/1975";
                else
                    cmd.Parameters.Add("@NGAYSINH", SqlDbType.DateTime).Value = textBox_luong.Text;

                cmd.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = textBox_email.Text;
                cmd.Parameters.Add("@MALOP", SqlDbType.NVarChar).Value = textBox_passwd.Text;
                cmd.Parameters.Add("@TENDN", SqlDbType.NVarChar).Value = textBox_username.Text;

                if (textBox_manv.Text != "" && cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Sửa thành công");
                }
                else
                {
                    MessageBox.Show("Thao tác sửa không thể thực hiện");
                }
                show_nhanvien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thao tác thêm không thể thực hiện");
                //MessageBox.Show(ex.Message);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("STUDENT_DELETE @MASV", Functions.conn);
            try
            {
                cmd.Parameters.Add("@MASV", SqlDbType.NVarChar).Value = textBox_manv.Text;
                if (textBox_manv.Text != "" && cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Xóa thành công");
                }
                else
                {
                    MessageBox.Show("Thao tác xóa không thể thực hiện");
                }
                show_nhanvien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thao tác thêm không thể thực hiện");
                //MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                textBox_manv.Text = selectedRow.Cells["Mã sinh viên"].Value.ToString();
                textBox_fullname.Text = selectedRow.Cells["Họ tên"].Value.ToString();
                textBox_passwd.Text = selectedRow.Cells["Mã lớp"].Value.ToString();
                textBox_luong.Text = selectedRow.Cells["Ngày sinh"].Value.ToString();
                textBox_email.Text = selectedRow.Cells["Địa chỉ"].Value.ToString();
                textBox_username.Text = selectedRow.Cells["Tên đăng nhập"].Value.ToString();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !dataGridView1.Rows[e.RowIndex].Selected)
            {
                DataGridViewRow clickedRow = dataGridView1.Rows[e.RowIndex];

                // Select the entire row
                clickedRow.Selected = true;
            }
        }


    }
}
