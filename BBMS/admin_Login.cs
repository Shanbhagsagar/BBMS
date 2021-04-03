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
        public admin_Login()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
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
            else {
                MessageBox.Show("Check your Username and Password");
            }
        }
    }
}
