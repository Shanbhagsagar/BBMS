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
    public partial class admin_Login : Form
    {

        ErrorProvider errorProvider = new ErrorProvider();

        public admin_Login()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (pass.Text.Trim().Length == 5)
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-R8MTFBR;Initial Catalog=bbms;Integrated Security=True");
                string query = "Select * from admin where username='" + uname.Text.Trim() + "' and password='" + pass.Text.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);

                if (dtbl.Rows.Count == 1)
                {
                    admin_dashboard ad = new admin_dashboard();
                    this.Hide();
                    ad.Show();
                }
                else
                {
                    MessageBox.Show("Check your Username and Password");
                }
            }
            else {
                MessageBox.Show("Check your Username and Password");
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();
        }

        private void uname_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(uname.Text.Trim()) || uname.Text.Trim().Any(char.IsNumber))
            {
                e.Cancel = true;
                uname.Focus();
                errorProvider.SetError(uname, "Please enter valid data");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(uname, null);
            }
        }

        private void pass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(pass.Text.Trim()))
            {
                e.Cancel = true;
                pass.Focus();
                errorProvider.SetError(pass, "Please enter valid data");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(pass, null);
            }
        }
    }
}
