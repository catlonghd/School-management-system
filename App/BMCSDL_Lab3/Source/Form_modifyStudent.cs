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
                cmd.Parameters.Add("@NGAYSINH", SqlDbType.VarChar).Value = textBox_bday.Text;
                cmd.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = textBox_address.Text;
                cmd.Parameters.Add("@MALOP", SqlDbType.VarChar).Value = textBox_classid.Text;
                cmd.Parameters.Add("@TENDN", SqlDbType.VarChar).Value = textBox_username.Text;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BDay { get; set; }
        public string Address { get; set; }
        public string ClassId { get; set; }
        public string Username { get; set; }

    }
}
