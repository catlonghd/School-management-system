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
    public partial class Form_StudentList : Form
    {
        public Form_StudentList()
        {
            InitializeComponent();
        }

        private void LoadData_StudentList()
        {
            SqlCommand cmd = new SqlCommand("SELECT MASV, HOTEN, NGAYSINH, DIACHI, MALOP, TENDN, MATKHAU FROM SINHVIEN", Functions.conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView_StudentList.DataSource = dt;

            //Set font và tên cột
            dataGridView_StudentList.Font = new Font("Time New Roman", 8);
            dataGridView_StudentList.Columns[0].HeaderText = "Mã SV";
            dataGridView_StudentList.Columns[1].HeaderText = "Họ tên";
            dataGridView_StudentList.Columns[2].HeaderText = "Ngày sinh";
            dataGridView_StudentList.Columns[3].HeaderText = "Địa chỉ";
            dataGridView_StudentList.Columns[4].HeaderText = "Mã lớp";
            dataGridView_StudentList.Columns[5].HeaderText = "Tên đăng nhập";
            dataGridView_StudentList.Columns[6].HeaderText = "Mật khẩu";

            //Set font cho dữ liệu trong cột
            dataGridView_StudentList.DefaultCellStyle.Font = new Font("Time New Roman", 8);

            //Set kích thước cột
            dataGridView_StudentList.Columns[0].Width = 50;
            dataGridView_StudentList.Columns[1].Width = 100;
            dataGridView_StudentList.Columns[2].Width = 100;
            dataGridView_StudentList.Columns[3].Width = 150;
            dataGridView_StudentList.Columns[4].Width = 50;
            dataGridView_StudentList.Columns[5].Width = 100;
            dataGridView_StudentList.Columns[6].Width = 150;

            
        }
        private void Form_StudentList_Load(object sender, EventArgs e)
        {
            LoadData_StudentList();
        }

        private void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            MessageBox.Show(anError.RowIndex + " " + anError.ColumnIndex);
            MessageBox.Show("Error happened " + anError.Context.ToString());

            if (anError.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Commit error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("Cell change");
            }
            if (anError.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("parsing error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("leave control error");
            }

            if ((anError.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[anError.RowIndex].ErrorText = "an error";
                view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";

                anError.ThrowException = false;
            }
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label l = new Label();
            l.Location = new Point(222, 80);
            l.Size = new Size(99, 18);
            l.Text = "Select Id";

            // Adding this label to the form
            this.Controls.Add(l);

            // Creating and setting the properties of comboBox
            ComboBox mybox = new ComboBox();
            mybox.Location = new Point(327, 77);
            mybox.Size = new Size(216, 26);
            mybox.MaxLength = 3;
            mybox.DropDownStyle = ComboBoxStyle.DropDown;
            mybox.Items.Add(240);
            mybox.Items.Add(241);
            mybox.Items.Add(242);
            mybox.Items.Add(243);
            mybox.Items.Add(244);

            // Adding this ComboBox to the form
            this.Controls.Add(mybox);
        }
    }
}
