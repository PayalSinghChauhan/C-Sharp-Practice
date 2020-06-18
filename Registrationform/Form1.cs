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
    public partial class Form1 : Form
    {
        long user_id;
        SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-OFTNCSA\SQLEXPRESS;Initial Catalog=Practice;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        public Form1(long id)
        {
            InitializeComponent();
            user_id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name, dob, gender = "", email, address, faculty = "", courses = "";
            long contact;
            name = textBox1.Text;
            dob = textBox2.Text;
            email = textBox4.Text;
            address = richTextBox1.Text;
            if (radioButton1.Checked == true)
            {
                gender = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                gender = radioButton2.Text;
            }

            if (radioButton3.Checked == true)
            {
                faculty = radioButton3.Text;
            }
            else if (radioButton4.Checked == true)
            {
                faculty = radioButton4.Text;
            }
            else if (radioButton5.Checked == true)
            {
                faculty = radioButton5.Text;
            }


            if (checkBox1.Checked == true)
            {
                courses = courses + checkBox1.Text;
            }
            if (checkBox2.Checked == true)
            {
                if (courses != "")
                {
                    courses = courses + " and " + checkBox2.Text;
                }
                else
                {
                    courses = courses + checkBox2.Text;
                }
            }
            if (checkBox3.Checked == true)
            {
                if (courses != "")
                {
                    courses = courses + " and " + checkBox3.Text;
                }
                else
                {
                    courses = courses + checkBox3.Text;
                }
            }

            //if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true)
            //{
            //    courses = checkBox1.Text + " and " + checkBox2.Text + " and " + checkBox3.Text;
            //}
            //else if ((checkBox1.Checked == true) && (checkBox2.Checked == true))
            //{
            //    courses = checkBox1.Text + " and " + checkBox2.Text;
            //}
            //else if ((checkBox1.Checked == true) && (checkBox3.Checked == true))
            //{
            //    courses = checkBox1.Text + " and " + checkBox3.Text;
            //}
            //else if ((checkBox2.Checked == true) && (checkBox3.Checked == true))
            //{
            //    courses = checkBox2.Text + " and " + checkBox3.Text;
            //}
            //else if (checkBox1.Checked == true)
            //{
            //    courses = checkBox1.Text;
            //}
            //else if (checkBox2.Checked == true)
            //{
            //    courses = checkBox2.Text;
            //}
            //else if (checkBox3.Checked == true)
            //{
            //    courses = checkBox3.Text;
            //}

            contact = long.Parse(textBox3.Text);
            MessageBox.Show("Name:" + name + "\nDOB:" + dob + "\nGender:" + gender + "\nEmail:" + email + "\nAddresss:" + address + "\nCourses:" + courses);
            sqlCon.Open();
            string query = "Insert into Registration (FirstName,DOB,Gender,Faculty,contact,Email,address,Courses) Values(@name, @dob, @gender, @faculty, @contact, @email,@address,@courses)";
            SqlCommand insertCommand = new SqlCommand(query, sqlCon);
            insertCommand.Parameters.AddWithValue("@name", textBox1.Text);
            insertCommand.Parameters.AddWithValue("@dob", textBox2.Text);
            insertCommand.Parameters.AddWithValue("@gender", gender);
            insertCommand.Parameters.AddWithValue("@faculty", faculty);
            insertCommand.Parameters.AddWithValue("@contact", textBox3.Text);
            insertCommand.Parameters.AddWithValue("@email", textBox4.Text);
            insertCommand.Parameters.AddWithValue("@address", richTextBox1.Text);
            insertCommand.Parameters.AddWithValue("@courses", courses);
            insertCommand.ExecuteNonQuery();

            sqlCon.Close();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int val = Convert.ToInt32(label8.Text);
            val = val + 1;
            label8.Text = val.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (user_id != null && user_id != 0)
            {
                //button1.Hide();
                button1.Visible = false;
                sqlCon.Open();
                string query = "Select * from Registration where id=" + user_id;
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(query, sqlCon);
                da.Fill(dt);
                sqlCon.Close();

                if (dt.Rows.Count > 0)
                {
                    textBox1.Text = dt.Rows[0]["FirstName"].ToString();

                }
            }
            else
            {
                button4.Hide();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            UserList userList = new UserList();
            userList.Show();

        }
    }
}
