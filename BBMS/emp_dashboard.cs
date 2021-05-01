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
    public partial class emp_dashboard : Form
    {
        public emp_dashboard()
        {
            InitializeComponent();
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
        private void logoutEmp_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Close();

        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-R8MTFBR;Initial Catalog=bbms;Integrated Security=True");
        private void emp_dashboard_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from donor",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            gunaLabel2.Text = dt.Rows[0][0].ToString();
            sda.Dispose();dt.Reset();con.Close();
            con.Open();
            sda = new SqlDataAdapter("select count(*) from patient", con);
            sda.Fill(dt);
            gunaLabel3.Text = dt.Rows[0][0].ToString();
            sda.Dispose();dt.Reset(); con.Close();
            con.Open();
            sda = new SqlDataAdapter("select sum(bUnit) from bloodstock", con);
            sda.Fill(dt);
            int total = Convert.ToInt32(dt.Rows[0][0]);
            gunaLabel5.Text = total.ToString();
            sda.Dispose();dt.Reset(); con.Close();
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
            gunaLabel8.Text = "" + aplus;
            gunaLabel9.Text = "" + amin;
            gunaLabel10.Text = "" + bplus;
            gunaLabel11.Text = "" + bmin;
            gunaLabel12.Text = "" + abplus;
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
    }
}
