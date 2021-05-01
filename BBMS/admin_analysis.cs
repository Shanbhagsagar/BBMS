using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CefSharp;
using CefSharp.WinForms;

namespace BBMS
{
   
    public partial class admin_analysis : Form
    {
        public ChromiumWebBrowser chromeBrowser;
        public admin_analysis()
        {
            InitializeComponent();
            InitializeChromium();
        }

        private void label8_Click(object sender, EventArgs e)
        {

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
        private void logoutEmp_Click(object sender, EventArgs e)
        {
            admin_Login al = new admin_Login();
            al.Show();
            this.Close();
       
        }

        private void admin_analysis_Load(object sender, EventArgs e)
        {
           
        }
 

        public void InitializeChromium()
        {
           
            // Create a browser component
            String page = @"F:\.net_project\BBMS\BBMS\index.html";
            chromeBrowser = new ChromiumWebBrowser(page);
            // Add it to the form and fill it to the form window.
            panel8.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }

    }
}
