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

namespace Registrationform
{
    public partial class UserList : Form
    {
        public UserList()
        {
            InitializeComponent();
        }

        SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-OFTNCSA\SQLEXPRESS;Initial Catalog=Practice;Integrated Security=True");

        private void UserList_Load(object sender, EventArgs e)
        {
            sqlCon.Open();
            string query = "Select * from Registration";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, sqlCon);
            da.Fill(dt);
            //directly show all columns and data from database table
            //dataGridView1.DataSource = dt;

            for(int i=0;i<dt.Rows.Count;i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["SN"].Value = i+1;
                dataGridView1.Rows[i].Cells["ID"].Value = dt.Rows[i]["id"].ToString();
                dataGridView1.Rows[i].Cells["Name"].Value = dt.Rows[i]["FirstName"].ToString();
                dataGridView1.Rows[i].Cells["Gender"].Value = dt.Rows[i]["Gender"].ToString();
                dataGridView1.Rows[i].Cells["Edit"].Value = "Edit Details";
            }

            sqlCon.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==4)
            {
                long id= Convert.ToInt64(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
                MessageBox.Show("Success Id: " + dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
                //open new form and pass id
                Form1 form = new Form1(id);
                form.Show();
            }
        }
    }
}
