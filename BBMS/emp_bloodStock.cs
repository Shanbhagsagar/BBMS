using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBMS
{
    public partial class emp_bloodStock : Form
    {
        public emp_bloodStock()
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
    }
}
