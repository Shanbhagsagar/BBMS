using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBMS
{
    public partial class emp_addDoner : Form
    {
        ErrorProvider errorProvider = new ErrorProvider();
        public emp_addDoner()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void jMetroTextBox1_Validating(object sender, CancelEventArgs e)
        {
            
            if (string.IsNullOrEmpty(jMetroTextBox1.Text.Trim()) ||jMetroTextBox1.Text.Trim().Any(char.IsNumber))
            {
                e.Cancel = true;
                jMetroTextBox1.Focus();
                errorProvider.SetError(jMetroTextBox1, "Please enter valid data");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(jMetroTextBox1, null);
            }
                
        }

        private void jMetroTextBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(jMetroTextBox2.Text.Trim()) ||jMetroTextBox2.Text.Trim().Any(char.IsLetter))
            {
                e.Cancel = true;
                jMetroTextBox2.Focus();
                errorProvider.SetError(jMetroTextBox2, "Please enter valid data");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(jMetroTextBox2, null);
            }
        }

        private void jMetroTextBox3_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(jMetroTextBox3.Text.Trim())|| !Regex.Match(jMetroTextBox3.Text.Trim(), @"^([0-9]{10})$").Success)
            {
                e.Cancel = true;
                jMetroTextBox3.Focus();
                errorProvider.SetError(jMetroTextBox3, "Please enter valid data");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(jMetroTextBox3, null);
            }
        }

        private void jMetroTextBox4_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(jMetroTextBox4.Text.Trim()))
            {
                e.Cancel = true;
                jMetroTextBox4.Focus();
                errorProvider.SetError(jMetroTextBox4, "Please enter valid data");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(jMetroTextBox4, null);
            }
        }
    }
}
