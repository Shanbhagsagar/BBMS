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

namespace BBMS
{
    public partial class admin_employees : Form
    {
        public admin_employees()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //Fetching Values from textbox
            string name = t1.Text;
            int age = Int16.Parse(t2.Text);
            string phone = t3.Text;
            string address = t4.Text;
            string adhaar = t5.Text;
            string gender = c1.SelectedItem.ToString();
            string email = t7.Text;
            string username = t8.Text;
            string password = t9.Text;

            //Insert Data into Database
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-R8MTFBR;Initial Catalog=bbms;Integrated Security=True");
            
            string query = "insert into employee(eName,eAge,ePhone,eAddress,eAdhaar,eGender,eEmail,eUsername,ePassword) values(@eName,@eAge,@ePhone,@eAddress,@eAdhaar,@eGender,@eEmail,@eUsername,@ePassword)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@eName", name);
            cmd.Parameters.AddWithValue("@eAge", age);
            cmd.Parameters.AddWithValue("@ePhone", phone);
            cmd.Parameters.AddWithValue("@eAddress", address);
            cmd.Parameters.AddWithValue("@eAdhaar",adhaar);
            cmd.Parameters.AddWithValue("@eGender", gender);
            cmd.Parameters.AddWithValue("@eEmail", email);
            cmd.Parameters.AddWithValue("@eUsername", username);
            cmd.Parameters.AddWithValue("@ePassword", password);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                MessageBox.Show("Details inserted successfully");
                t1.Clear();
                t2.Clear();
                t3.Clear();
                t4.Clear();
                t5.Clear();
                c1.SelectedItem = null;
                t7.Clear();
                t8.Clear();
                t9.Clear();
            }
            else
            {
             MessageBox.Show("Details not inserted successfully");
            }
            con.Close();

        }
    }
}
