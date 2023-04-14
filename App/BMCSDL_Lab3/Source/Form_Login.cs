using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Threading;

namespace BMCSDL_Lab3
{
    public partial class Form_Login : Form
    {
        
        Thread t;
        String uname = "", passwd = "";
        public Form_Login()
        {
            InitializeComponent();
        }
        private void Login()
        {
            try
            {
                Functions.InitConnection();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public void open_FormMain(object obj)
        {

            Application.Run(new Source.Form_Main(uname));
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            Login();


            uname = textBox_uname.Text;
            passwd = textBox_passwd.Text;
            SqlCommand cmd = new SqlCommand("SELECT TENDN, MATKHAU, MANV FROM NHANVIEN WHERE TENDN='" + uname + "' AND MATKHAU=HASHBYTES('SHA1',N'" + passwd + "')", Functions.conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            
            DataTable dt = new DataTable("NHANVIEN");

            da.Fill(dt);
            
            if (dt.Rows.Count > 0)
            {
                
                Functions.manv = Convert.ToString(dt.Rows[0]["MANV"]);
                this.Close();
                t = new Thread(open_FormMain);
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không hợp lệ");
            }

            Functions.conn.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Convert.ToChar(13)))
            {
                btn_Login_Click(sender, e);
            }
        }

    }
}
