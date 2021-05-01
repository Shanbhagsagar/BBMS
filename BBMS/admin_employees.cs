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
using System.Text.RegularExpressions;

namespace BBMS
{
    public partial class admin_employees : Form
    {
        ErrorProvider errorProvider = new ErrorProvider();
        Regex mRegxExpression;
        public admin_employees()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Fetching Values from textbox
                string name = t1.Text;
                int age = Convert.ToInt16(gunaNumeric1.Value);
                string phone = t3.Text;
                string address = t4.Text;
                string adhaar = t5.Text;
                string gender = c1.SelectedItem.ToString();
                string email = t7.Text;
                string username = t8.Text;
                string password = t9.Text;

                if (!string.IsNullOrEmpty(name.Trim()) && !string.IsNullOrEmpty(phone.Trim()) && !string.IsNullOrEmpty(address.Trim()) && !string.IsNullOrEmpty(adhaar.Trim()) && !string.IsNullOrEmpty(gender.Trim()) && !string.IsNullOrEmpty(email.Trim()) && !string.IsNullOrEmpty(username.Trim()) && !string.IsNullOrEmpty(password.Trim()))
                {

                    //Insert Data into Database
                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-R8MTFBR;Initial Catalog=bbms;Integrated Security=True");

                    string query = "insert into employee(eName,eAge,ePhone,eAddress,eAdhaar,eGender,eEmail,eUsername,ePassword) values(@eName,@eAge,@ePhone,@eAddress,@eAdhaar,@eGender,@eEmail,@eUsername,@ePassword)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@eName", name);
                    cmd.Parameters.AddWithValue("@eAge", age);
                    cmd.Parameters.AddWithValue("@ePhone", phone);
                    cmd.Parameters.AddWithValue("@eAddress", address);
                    cmd.Parameters.AddWithValue("@eAdhaar", adhaar);
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
                        gunaNumeric1.Value = 18;
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
            catch (Exception err)
            {
                MessageBox.Show("Please enter all valid values!!");
            }

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

        private void t1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(t1.Text.Trim()) || t1.Text.Trim().Any(char.IsNumber))
            {
                e.Cancel = true;
                t1.Focus();
                errorProvider.SetError(t1, "Please enter valid data");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(t1, null);
            }
        }

        private void t3_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(t3.Text.Trim()))
            {
                e.Cancel = true;
                t3.Focus();
                errorProvider.SetError(t3, "Please enter valid data");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(t3, null);
            }
        }

        private void t4_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(t4.Text.Trim()))
            {
                e.Cancel = true;
                t4.Focus();
                errorProvider.SetError(t4, "Please enter valid data");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(t4, null);
            }
        }

        private void c1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(c1.Text.Trim()))
            {
                e.Cancel = true;
                c1.Focus();
                errorProvider.SetError(c1, "Please enter valid data");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(c1, null);
            }
        }

        private void t7_Validating(object sender, CancelEventArgs e)
        {
            mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
            if (string.IsNullOrEmpty(t7.Text.Trim()) || !mRegxExpression.IsMatch(t7.Text.Trim()))
            {
                e.Cancel = true;
                t7.Focus();
                errorProvider.SetError(t7, "Please enter valid data");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(t7, null);
            }
        }

        private void t8_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(t8.Text.Trim()))
            {
                e.Cancel = true;
                t8.Focus();
                errorProvider.SetError(t8, "Please enter valid data");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(t8, null);
            }
        }

        private void t9_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(t9.Text.Trim()))
            {
                e.Cancel = true;
                t9.Focus();
                errorProvider.SetError(t9, "Please enter valid data");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(t9, null);
            }
        }

        private void t5_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(t5.Text.Trim()))
            {
                e.Cancel = true;
                t5.Focus();
                errorProvider.SetError(t5, "Please enter valid data");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(t5, null);
            }
        }
    }
}
