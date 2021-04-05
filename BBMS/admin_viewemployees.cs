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
    }
}
