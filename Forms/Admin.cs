using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobilusOperatorius.Forms
{
    public partial class Admin : Form
    {
        private Form1 _loginform;
        public Admin(Form1 loginform)
        {
            InitializeComponent();
            _loginform = loginform;
        }

        private void StoreLocationButton_Click(object sender, EventArgs e)
        {
            StoreLocation storeLocation = new StoreLocation();
            storeLocation.Show();
        }

        private void EmployeeButton_Click(object sender, EventArgs e)
        {
            EmployeeAdmin employeeAdmin = new EmployeeAdmin();
            employeeAdmin.Show();
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {

            Application.Exit();
        }

        private void ProductButton_Click(object sender, EventArgs e)
        {
            ProductAdmin productAdmin = new ProductAdmin();
            productAdmin.Show();
        }

        private void PlansButton_Click(object sender, EventArgs e)
        {

            PlansAdmin plansAdmin = new PlansAdmin();
            plansAdmin.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            _loginform.Show();
            this.Close();
        }

        private void Roamingpartnerbutton_Click(object sender, EventArgs e)
        {
            RoamingPartnerAdmin roamingPartnerAdmin = new RoamingPartnerAdmin();
            roamingPartnerAdmin.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Promotions promotions = new Promotions();
            promotions.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StatusesAdmin statusesAdmin = new StatusesAdmin();
            statusesAdmin.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            EmployeepositionAdmin employeepositionsAdmin = new EmployeepositionAdmin();
            employeepositionsAdmin.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            UserType userType = new UserType();
            userType.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CustomerDeletionAdmin customerDeletionAdmin     = new CustomerDeletionAdmin();
            customerDeletionAdmin.Show();

        }
    }
}
