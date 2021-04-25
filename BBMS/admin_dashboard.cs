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
    public partial class admin_dashboard : Form
    {
        public admin_dashboard()
        {
            InitializeComponent();
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

        private void gunaLabel6_Click(object sender, EventArgs e)
        {

        }

        private void gunaCircleProgressBar4_Click(object sender, EventArgs e)
        {

        }

        SqlConnection con = new SqlConnection(@"Data Source=BEN;Initial Catalog=bbms;Integrated Security=True");
        private void admin_dashboard_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from donor", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            gunaLabel2.Text = dt.Rows[0][0].ToString();
            sda.Dispose(); dt.Reset(); con.Close();
            con.Open();
            sda = new SqlDataAdapter("select count(*) from patient", con);
            sda.Fill(dt);
            gunaLabel3.Text = dt.Rows[0][0].ToString();
            sda.Dispose(); dt.Reset(); con.Close();
            con.Open();
            sda = new SqlDataAdapter("select count(*) from employee", con);
            sda.Fill(dt);
            gunaLabel5.Text = dt.Rows[0][0].ToString();
            sda.Dispose(); dt.Reset(); con.Close();
            con.Open();
            sda = new SqlDataAdapter("select sum(bUnit) from bloodstock", con);
            sda.Fill(dt);
            int total = Convert.ToInt32(dt.Rows[0][0]);
            gunaLabel8.Text = total.ToString();
            sda.Dispose(); dt.Reset(); con.Close();
            con.Open();
            sda = new SqlDataAdapter("select * from bloodstock", con);
            sda.Fill(dt);
            int aplus = Convert.ToInt32(dt.Rows[0][1]);
            int amin = Convert.ToInt32(dt.Rows[1][1]);
            int bplus = Convert.ToInt32(dt.Rows[2][1]);
            int bmin = Convert.ToInt32(dt.Rows[3][1]);
            int abplus = Convert.ToInt32(dt.Rows[4][1]);
            int abmin = Convert.ToInt32(dt.Rows[5][1]);
            int oplus = Convert.ToInt32(dt.Rows[6][1]);
            int omin = Convert.ToInt32(dt.Rows[7][1]);
            gunaLabel17.Text = "" + aplus;
            gunaLabel12.Text = "" + amin;
            gunaLabel10.Text = "" + bplus;
            gunaLabel11.Text = "" + bmin;
            gunaLabel16.Text = "" + abplus;
            gunaLabel13.Text = "" + abmin;
            gunaLabel14.Text = "" + oplus;
            gunaLabel15.Text = "" + omin;
            gunaCircleProgressBar1.Maximum = total;
            gunaCircleProgressBar2.Maximum = total;
            gunaCircleProgressBar3.Maximum = total;
            gunaCircleProgressBar4.Maximum = total;
            gunaCircleProgressBar5.Maximum = total;
            gunaCircleProgressBar6.Maximum = total;
            gunaCircleProgressBar7.Maximum = total;
            gunaCircleProgressBar8.Maximum = total;
            gunaCircleProgressBar1.Value = aplus;
            gunaCircleProgressBar2.Value = amin;
            gunaCircleProgressBar3.Value = bplus;
            gunaCircleProgressBar4.Value = bmin;
            gunaCircleProgressBar5.Value = abplus;
            gunaCircleProgressBar6.Value = abmin;
            gunaCircleProgressBar7.Value = oplus;
            gunaCircleProgressBar8.Value = omin;
            sda.Dispose(); dt.Reset(); con.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
