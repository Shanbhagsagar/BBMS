﻿using System;
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
    public partial class emp_viewDonor : Form
    {
        public emp_viewDonor()
        {
            InitializeComponent();
        }

        private void emp_viewDonor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bbmsDBDataSetDonor.donor' table. You can move, or remove it, as needed.
            this.donorTableAdapter.Fill(this.bbmsDBDataSetDonor.donor);
        }
    }
}