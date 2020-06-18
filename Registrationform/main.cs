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
    public partial class main : Form
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-OFTNCSA\SQLEXPRESS;Initial Catalog=Practice;Integrated Security=True");
        public main()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidateName() && ValidatePass())
            {
                string username = textBox1.Text;
                string password = textBox2.Text;
                sqlCon.Open();
                string query = "Select * from UserLogin where Username='" + username + "' and password='" + password + "'";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(query, sqlCon);
                da.Fill(dt);
                sqlCon.Close();
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Login Successful", "Information");
                    this.Hide();
                    Form1 ss = new Form1();
                    ss.Show();
                }
                else
                {
                    MessageBox.Show("Username or Password wrong.");
                }
            }
        }

        //This is for validation of name or to check if name field is empty
        private bool ValidateName()
        {
            bool bStatus = true;
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Please enter your Name");
                bStatus = false;
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
            }
            return bStatus;
        }

        //This is for validation of password or to check if password field is empty
        private bool ValidatePass()
        {
            bool bStatus = true;
            if (textBox2.Text == "")
            {
                errorProvider1.SetError(textBox2, "Please enter your Password");
                bStatus = false;
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
            }
            return bStatus;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            sqlCon.Open();
            string query = "Insert into UserLogin values('" + username + "','" + password + "')";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();
        }
    }
}
