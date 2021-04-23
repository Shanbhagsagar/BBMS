using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBMS
{
    public partial class emp_addPatient : Form
    {
        ErrorProvider errorProvider = new ErrorProvider();
        public emp_addPatient()
        {
            InitializeComponent();
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

        private void t2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(t2.Text.Trim()) || t2.Text.Trim().Any(char.IsLetter))
            {
                e.Cancel = true;
                t2.Focus();
                errorProvider.SetError(t2, "Please enter valid data");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(t2, null);
            }
        }

        private void t3_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(t3.Text.Trim()) || !Regex.Match(t3.Text.Trim(), @"^([0-9]{10})$").Success)
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
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string name = t1.Text.Trim();
                int age = Int16.Parse(t2.Text.Trim());
                string phone = t3.Text.Trim();
                string address = t4.Text.Trim();
                int unit = Int16.Parse(t5.Text.Trim());
                string case1 = t6.Text.Trim();
                string bt = c1.SelectedItem.ToString();
                string gender = c2.SelectedItem.ToString();
                int bstockUnit = 0;

                if (name == "" || phone == "" || address == "" || case1 == "")
                {
                    MessageBox.Show("Please enter all values");
                    return;
                }

                if (unit > 0)
                {
                    SqlConnection con = new SqlConnection(@"Data Source=BEN;Initial Catalog=bbms;Integrated Security=True");
                    string btsearch = "select bUnit from bloodstock where bType=@pBT";
                    SqlCommand cmd1 = new SqlCommand(btsearch, con);
                    cmd1.Parameters.AddWithValue("@pBT", bt);
                    con.Open();
                    SqlDataReader dr = cmd1.ExecuteReader();
                    while (dr.Read())
                    {
                        bstockUnit = Int16.Parse(dr.GetValue(0).ToString());
                    }
                    if (bstockUnit < unit)
                    {
                        con.Close();
                        MessageBox.Show("Requested BType unit value is "+bstockUnit+"\nPlease try again.");
                    }
                    else
                    {
                        int finalUnit = bstockUnit - unit;
                        con.Close();
                        string query = "insert into patient(pName,pAge,pPhone,pAddress,pBT,pGender,pUnit,pDate,pCase) values(@pName,@pAge,@pPhone,@pAddress,@pBT,@pGender,@pUnit,@pDate,@pCase)";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@pName", name);
                        cmd.Parameters.AddWithValue("@pAge", age);
                        cmd.Parameters.AddWithValue("@pPhone", phone);
                        cmd.Parameters.AddWithValue("@pAddress", address);
                        cmd.Parameters.AddWithValue("@pBT", bt);
                        cmd.Parameters.AddWithValue("@pGender", gender);
                        cmd.Parameters.AddWithValue("@pUnit", unit);
                        cmd.Parameters.AddWithValue("@pDate", DateTime.UtcNow.Date.Date);
                        cmd.Parameters.AddWithValue("@pCase", case1);
                        con.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result == 1)
                        {
                            con.Close();
                            string btupdate = "update bloodstock set bUnit=@finalUnit where bType=@pBT";
                            SqlCommand cmd2 = new SqlCommand(btupdate, con);
                            cmd2.Parameters.AddWithValue("@finalUnit", finalUnit);
                            cmd2.Parameters.AddWithValue("@pBT", bt);
                            con.Open();
                            result = cmd2.ExecuteNonQuery();
                            if (result == 1)
                            {
                                MessageBox.Show("Details inserted successfully");
                                t1.Clear();
                                t2.Clear();
                                t3.Clear();
                                t4.Clear();
                                t5.Clear();
                                t6.Clear();
                                c1.SelectedItem = null;
                                c2.SelectedItem = null;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Details not inserted successfully");
                        }
                        con.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter Blood Unit greater than 0");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Please enter valid Data\n" + err.Message);
            }
        }

        private void empDashboard_Click(object sender, EventArgs e)
        {
            emp_dashboard edb = new emp_dashboard();
            edb.Show();
            this.Hide();
        }
        private void addDoner_Click(object sender, EventArgs e)
        {
            emp_addDoner ead = new emp_addDoner();
            ead.Show();
            this.Hide();
        }
        private void editDonor_Click(object sender, EventArgs e)
        {
            emp_editDonor eed = new emp_editDonor();
            eed.Show();
            this.Hide();
        }
        private void viewDoner_Click(object sender, EventArgs e)
        {
            emp_viewDonor evd = new emp_viewDonor();
            evd.Show();
            this.Hide();
        }
        private void addPatient_Click(object sender, EventArgs e)
        {
            emp_addPatient eap = new emp_addPatient();
            eap.Show();
            this.Hide();
        }
        private void editPatient_Click(object sender, EventArgs e)
        {
            emp_editPatient eep = new emp_editPatient();
            eep.Show();
            this.Hide();
        }
        private void viewPatient_Click(object sender, EventArgs e)
        {
            emp_viewPatient evp = new emp_viewPatient();
            evp.Show();
            this.Hide();
        }
        private void bloodStock_Click(object sender, EventArgs e)
        {
            emp_bloodStock ebs = new emp_bloodStock();
            ebs.Show();
            this.Hide();
        }
    }
}
