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

namespace BBMS
{
    public partial class emp_editPatient : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=BEN;Initial Catalog=bbms;Integrated Security=True");
        public emp_editPatient()
        {
            InitializeComponent();
        }

        private void t6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                if (t6.Text != "")
                {
                    string qry = "select * from patient where pID =@pID";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.Parameters.AddWithValue("@pID", Int16.Parse(t6.Text));
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        t1.Text = dr.GetValue(1).ToString();
                        t2.Text = dr.GetValue(2).ToString();
                        t3.Text = dr.GetValue(3).ToString();
                        t4.Text = dr.GetValue(4).ToString();
                        c1.SelectedItem = dr.GetValue(5).ToString();
                        c2.SelectedItem = dr.GetValue(6).ToString();
                        t5.Text = dr.GetValue(7).ToString();
                        t7.Text = dr.GetValue(9).ToString();
                    }
                }
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("Enter valid data"+ex.Message); }
        }

        private void b1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Int16.Parse(t6.Text.Trim());
                string name = t1.Text.Trim();
                int age = Int16.Parse(t2.Text.Trim());
                string phone = t3.Text.Trim();
                string address = t4.Text.Trim();
                int unit = Int16.Parse(t5.Text.Trim());
                string bt = c1.SelectedItem.ToString();
                string gender = c2.SelectedItem.ToString();
                string cases = t7.Text.Trim();
                int bstockUnit = 0;
                int dprevUnit = 0;
                int dfinalUnit = 0;

                if (name == "" || phone == "" || address == "" || cases =="")
                {
                    MessageBox.Show("Please enter all values");
                    return;
                }

                if (unit > 0)
                {
                    SqlConnection con1 = new SqlConnection(@"Data Source=BEN;Initial Catalog=bbms;Integrated Security=True");
                    string btsearch = "select bUnit from bloodstock where bType=@pBT";
                    SqlCommand cmd1 = new SqlCommand(btsearch, con1);
                    cmd1.Parameters.AddWithValue("@pBT", bt);
                    con1.Open();
                    SqlDataReader dr1 = cmd1.ExecuteReader();
                    while (dr1.Read())
                    {
                        bstockUnit = Int16.Parse(dr1.GetValue(0).ToString());
                    }
                    con1.Close();

                    string unitsearch = "select pUnit from patient where pID=@pID";
                    SqlCommand cmd2 = new SqlCommand(unitsearch, con1);
                    cmd2.Parameters.AddWithValue("@pID", id);
                    con1.Open();
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    while (dr2.Read())
                    {
                        dprevUnit = Int16.Parse(dr2.GetValue(0).ToString());
                    }
                    con1.Close();

                    dfinalUnit = dprevUnit - unit;
                    bstockUnit += dfinalUnit;
                    if (bstockUnit < 0)
                    {
                        MessageBox.Show("Insufficient stock, try again");
                        return;
                    }
                    string btupdate = "update bloodstock set bUnit=@bstockUnit where bType=@dBT";
                    SqlCommand cmd3 = new SqlCommand(btupdate, con1);
                    cmd3.Parameters.AddWithValue("@bstockUnit", bstockUnit);
                    cmd3.Parameters.AddWithValue("@dBT", bt);
                    con1.Open();
                    cmd3.ExecuteNonQuery();
                    con1.Close();

                    string query = "Update patient set pName = @dName, pAge = @dAge, pPhone = @dPhone, pAddress = @dAddress, pBT = @dBT, pGender = @dGender, pUnit = @dUnit, pCase=@pCase where pID = @dID";
                    SqlCommand cmd4 = new SqlCommand(query, con1);
                    cmd4.Parameters.AddWithValue("@dID", id);
                    cmd4.Parameters.AddWithValue("@dName", name);
                    cmd4.Parameters.AddWithValue("@dAge", age);
                    cmd4.Parameters.AddWithValue("@dPhone", phone);
                    cmd4.Parameters.AddWithValue("@dAddress", address);
                    cmd4.Parameters.AddWithValue("@dBT", bt);
                    cmd4.Parameters.AddWithValue("@dUnit", unit);
                    cmd4.Parameters.AddWithValue("@dGender", gender);
                    cmd4.Parameters.AddWithValue("@pCase", cases);
                    con1.Open();
                    int result = cmd4.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MessageBox.Show("Details updated successfully");
                        t1.Clear();
                        t2.Clear();
                        t3.Clear();
                        t4.Clear();
                        t5.Clear();
                        c1.SelectedItem = null;
                        c2.SelectedItem = null;
                        t6.Clear();
                        t7.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Error : Details not updated");
                    }
                    con1.Close();

                }
            }
            catch (Exception ex) { MessageBox.Show("Enter valid data"+ex.Message); }
        }

        private void b2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Int16.Parse(t6.Text);
                int unit = Int16.Parse(t5.Text);
                string bt = c1.SelectedItem.ToString();
                int bstockUnit = 0;
                int dprevUnit = 0;

                SqlConnection con1 = new SqlConnection(@"Data Source=BEN;Initial Catalog=bbms;Integrated Security=True");

                string btsearch = "select bUnit from bloodstock where bType=@dBT";
                SqlCommand cmd1 = new SqlCommand(btsearch, con1);
                cmd1.Parameters.AddWithValue("@dBT", bt);
                con1.Open();
                SqlDataReader dr1 = cmd1.ExecuteReader();
                while (dr1.Read())
                {
                    bstockUnit = Int16.Parse(dr1.GetValue(0).ToString());
                }
                con1.Close();

                string unitsearch = "select pUnit from patient where pID=@dID";
                SqlCommand cmd2 = new SqlCommand(unitsearch, con1);
                cmd2.Parameters.AddWithValue("@dID", id);
                con1.Open();
                SqlDataReader dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    dprevUnit = Int16.Parse(dr2.GetValue(0).ToString());
                }
                con1.Close();

                bstockUnit = bstockUnit + dprevUnit;

                if (bstockUnit < 0)
                {
                    MessageBox.Show("Not enough Units in Blood Stock");
                    return;
                }

                string btupdate = "update bloodstock set bUnit=@bstockUnit where bType=@dBT";
                SqlCommand cmd3 = new SqlCommand(btupdate, con1);
                cmd3.Parameters.AddWithValue("@bstockUnit", bstockUnit);
                cmd3.Parameters.AddWithValue("@dBT", bt);
                con1.Open();
                cmd3.ExecuteNonQuery();
                con1.Close();


                string query = "delete from patient where pID = @dID";
                SqlCommand cmd4 = new SqlCommand(query, con1);
                cmd4.Parameters.AddWithValue("@dID", id);
                con1.Open();
                int result = cmd4.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Details deleted successfully");
                    t1.Clear();
                    t2.Clear();
                    t3.Clear();
                    t4.Clear();
                    t5.Clear();
                    c1.SelectedItem = null;
                    c2.SelectedItem = null;
                    t6.Clear();
                }
                else
                {
                    MessageBox.Show("Error : Details not deleted");
                }
                con1.Close();
            }
            catch (Exception ex) { MessageBox.Show("Enter valid data"+ex.Message); }
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
