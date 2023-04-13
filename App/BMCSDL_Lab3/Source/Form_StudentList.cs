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
            Functions.InitConnection();
            List<string> classNames = new List<string>();
            using (SqlCommand cmd = new SqlCommand("class_list", Functions.conn))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        classNames.Add(dr["MALOP"].ToString());
                }
            }
            
            comboBox1.DataSource = classNames;
        }
        
        private DataTable LoadData_StudentList(string classname)
        {
            SqlCommand cmd = new SqlCommand("student_list '" + classname + "'", Functions.conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView_StudentList.DataSource = dt;

            return dt;
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

        private void comboBox1_SelectionChanged(object sender, EventArgs e)
        {
            string className = comboBox1.SelectedItem.ToString();

            DataTable data = LoadData_StudentList(className);

            bindingSource.DataSource = data;
        }
    }
}
