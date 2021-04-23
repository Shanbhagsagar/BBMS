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
    public partial class emp_viewPatient : Form
    {
        public emp_viewPatient()
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
        private void bloodStock_Click(object sender, EventArgs e)
        {
            emp_bloodStock ebs = new emp_bloodStock();
            ebs.Show();
            this.Hide();
        }

        private void t1_TextChanged(object sender, EventArgs e)
        {
            string search = t1.Text.Trim();
            SqlConnection con = new SqlConnection(@"Data Source=BEN;Initial Catalog=bbms;Integrated Security=True");
            string query = $"select * from patient where pName like '{search}%' OR pAge like '{search}%' OR pPhone like '{search}%' OR pAddress like '{search}%' OR pBT like '{search}%' OR pGender like '{search}%' OR pUnit like '{search}%' OR pDate like '{search}%' OR pCase like '{search}%'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            gunaDataGridView1.DataSource = dt;
            gunaDataGridView1.ColumnHeadersHeight = 30;
            Controls.Add(gunaDataGridView1);
            gunaDataGridView1.Columns[0].Width = 40;
            gunaDataGridView1.Columns[1].Width = 200;
            gunaDataGridView1.Columns[2].Width = 50;
            gunaDataGridView1.Columns[4].Width = 250;
            gunaDataGridView1.Columns[5].Width = 50;
            gunaDataGridView1.Columns[6].Width = 80;
            gunaDataGridView1.Columns[7].Width = 50;
            con.Close();
        }
    }
}
