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
    public partial class admin_viewemployees : Form
    {
        public admin_viewemployees()
        {
            InitializeComponent();
        }

        private void admin_viewemployees_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bbmsDataSet.employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.bbmsDataSet.employee);

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
    }
}
