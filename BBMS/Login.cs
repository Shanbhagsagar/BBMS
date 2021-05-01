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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-R8MTFBR;Initial Catalog=bbms;Integrated Security=True");
            string query = "Select * from employee where eUsername='" + uname.Text.Trim() + "' and ePassword='" + pass.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);

            if (dtbl.Rows.Count == 1)
            {
                emp_dashboard ed = new emp_dashboard();
                this.Hide();
                ed.Show();
            }
            else
            {
                MessageBox.Show("Check your Username and Password");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            admin_Login ad = new admin_Login();
            this.Hide();
            ad.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
