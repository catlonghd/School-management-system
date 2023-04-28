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

    
    public partial class Form_modifyStudent : Form
    {

        public Form_modifyStudent()
        {
            InitializeComponent();
            Functions.InitConnection();
            
        }

        public void show_student()
        {
            //MessageBox.Show(Functions.manv);
            SqlCommand cmd = new SqlCommand("class_list_nhanvien '" + Functions.manv + "'", Functions.conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form_modifyStudent_Load(object sender, EventArgs e)
        {
            show_student();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SP_INS_SINHVIEN @MASV,@HOTEN,@NGAYSINH,@DIACHI,@MALOP,@TENDN", Functions.conn);
            try
            {
                cmd.Parameters.Add("@MASV", SqlDbType.NVarChar).Value = textBox_stuId.Text;
                cmd.Parameters.Add("@HOTEN", SqlDbType.NVarChar).Value = textBox_fullname.Text;
                cmd.Parameters.Add("@NGAYSINH", SqlDbType.DateTime).Value = textBox_bday.Text;
                cmd.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = textBox_address.Text;
                cmd.Parameters.Add("@MALOP", SqlDbType.VarChar).Value = textBox_classid.Text;
                cmd.Parameters.Add("@TENDN", SqlDbType.NVarChar).Value = textBox_username.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công");
                show_student();
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
                cmd.Parameters.Add("@MASV", SqlDbType.NVarChar).Value = textBox_stuId.Text;
                cmd.Parameters.Add("@HOTEN", SqlDbType.NVarChar).Value = textBox_fullname.Text;

                if (!DateTime.TryParse(textBox_bday.Text, out DateTime DateValue)){
                    MessageBox.Show("Invalid date time format.");
                }
                else {
                    cmd.Parameters.Add("@NGAYSINH", SqlDbType.DateTime).Value = DateValue;
                }
                cmd.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = textBox_address.Text;
                cmd.Parameters.Add("@MALOP", SqlDbType.VarChar).Value = textBox_classid.Text;
                cmd.Parameters.Add("@TENDN", SqlDbType.NVarChar).Value = textBox_username.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update thành công");
                show_student();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("STUDENT_DELETE @MASV", Functions.conn);
            try
            {
                cmd.Parameters.Add("@MASV", SqlDbType.NVarChar).Value = textBox_stuId.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công");
                show_student();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                textBox_stuId.Text = selectedRow.Cells["Mã sinh viên"].Value.ToString();
                textBox_fullname.Text = selectedRow.Cells["Họ tên"].Value.ToString();
                textBox_classid.Text = selectedRow.Cells["Mã lớp"].Value.ToString();
                textBox_bday.Text = selectedRow.Cells["Ngày sinh"].Value.ToString();
                textBox_address.Text = selectedRow.Cells["Địa chỉ"].Value.ToString();
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
