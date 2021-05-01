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
    public partial class admin_editemployees : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-R8MTFBR;Initial Catalog=bbms;Integrated Security=True");
        public admin_editemployees()
        {
            InitializeComponent();
        }

        private void admin_editemployees_Load(object sender, EventArgs e)
        {

        }

        private void t1_TextChanged(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
                con.Open();
            if (t1.Text != "") {
                string qry = "select eName,eAge,ePhone,eAddress,eAdhaar,eGender,eEmail,eUsername,ePassword from employee where eID =@eID";
                SqlCommand cmd = new SqlCommand(qry,con);
                cmd.Parameters.AddWithValue("@eID",Int16.Parse(t1.Text));
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read()) {
                    t2.Text = dr.GetValue(0).ToString();
                    gunaNumeric1.Value = Convert.ToInt64(dr.GetValue(1).ToString());
                    t4.Text = dr.GetValue(2).ToString();
                    t5.Text = dr.GetValue(3).ToString();
                    t6.Text = dr.GetValue(4).ToString();
                    c1.SelectedItem = dr.GetValue(5).ToString();
                    t8.Text = dr.GetValue(6).ToString();
                    t9.Text = dr.GetValue(7).ToString();
                    t10.Text = dr.GetValue(8).ToString();
                }
          }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Fetching Values from textbox
                string id = t1.Text;
                string name = t2.Text;
                int age = Convert.ToInt16(gunaNumeric1.Value);
                string phone = t4.Text;
                string address = t5.Text;
                string adhaar = t6.Text;
                string gender = c1.SelectedItem.ToString();
                string email = t8.Text;
                string username = t9.Text;
                string password = t10.Text;

                if (!string.IsNullOrEmpty(name.Trim()) && !string.IsNullOrEmpty(phone.Trim()) && !string.IsNullOrEmpty(address.Trim()) && !string.IsNullOrEmpty(adhaar.Trim()) && !string.IsNullOrEmpty(gender.Trim()) && !string.IsNullOrEmpty(email.Trim()) && !string.IsNullOrEmpty(username.Trim()) && !string.IsNullOrEmpty(password.Trim()))
                {
                    //Update Data into Database
                    string query = "Update employee set eName = @eName, eAge = @eAge, ePhone = @ePhone, eAddress = @eAddress, eAdhaar = @eAdhaar, eGender = @eGender, eEmail = @eEmail, eUsername = @eUsername, ePassword = @ePassword where eID = @eID";
                    SqlCommand cmd1 = new SqlCommand(query, con);
                    cmd1.Parameters.AddWithValue("@eID", id);
                    cmd1.Parameters.AddWithValue("@eName", name);
                    cmd1.Parameters.AddWithValue("@eAge", age);
                    cmd1.Parameters.AddWithValue("@ePhone", phone);
                    cmd1.Parameters.AddWithValue("@eAddress", address);
                    cmd1.Parameters.AddWithValue("@eAdhaar", adhaar);
                    cmd1.Parameters.AddWithValue("@eGender", gender);
                    cmd1.Parameters.AddWithValue("@eEmail", email);
                    cmd1.Parameters.AddWithValue("@eUsername", username);
                    cmd1.Parameters.AddWithValue("@ePassword", password);
                    con.Open();
                    int result = cmd1.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MessageBox.Show("Details updated successfully");
                        t1.Clear();
                        t2.Clear();
                        gunaNumeric1.Value = 18;
                        t4.Clear();
                        t5.Clear();
                        c1.SelectedItem = null;
                        t6.Clear();
                        t8.Clear();
                        t9.Clear();
                        t10.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Error : Details not updated");
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter all valid values!!");
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string id = t1.Text;

            //Delete Data from Database
            string query1 = "delete from employee where eID = @eID";
            SqlCommand cmd2 = new SqlCommand(query1, con);
            cmd2.Parameters.AddWithValue("@eID", id);
            con.Open();
            int result1 = cmd2.ExecuteNonQuery();
            if (result1 == 1)
            {
               MessageBox.Show("Details deleted successfully");
                t1.Clear();
                t2.Clear();
                gunaNumeric1.Value = 18;
                t4.Clear();
                t5.Clear();
                c1.SelectedItem = null;
                t6.Clear();
                t8.Clear();
                t9.Clear();
                t10.Clear();
            }
            else
            {
               MessageBox.Show("Error : Details not deleted");
            }
            con.Close();
        }

        private void dashboard_Click(object sender, EventArgs e)
        {
            admin_dashboard ad = new admin_dashboard();
            ad.Show();
            this.Hide();

        }

        private void addEmp_Click(object sender, EventArgs e)
        {
            admin_employees ae = new admin_employees();
            ae.Show();
            this.Hide();

        }

        private void editEmp_Click(object sender, EventArgs e)
        {
            admin_editemployees aee = new admin_editemployees();
            aee.Show();
            this.Hide();

        }

        private void viewEmp_Click(object sender, EventArgs e)
        {
            admin_viewemployees ave = new admin_viewemployees();
            ave.Show();
            this.Hide();

        }
        private void admin_analysis_Click(object sender, EventArgs e)
        {
            admin_analysis aa = new admin_analysis();
            aa.Show();
            this.Hide();
        }
        private void logoutEmp_Click(object sender, EventArgs e)
        {
            admin_Login al = new admin_Login();
            al.Show();
            this.Close();

        }
    }
}
