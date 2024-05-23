using MobilusOperatorius.Classes;
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
    public partial class NewTicket : Form
    {
        Form1 _loginform;
        Customer _customer;
        public NewTicket(Form1 loginform,Customer customer)
        {
            InitializeComponent();
            _loginform = loginform;
            _customer = customer;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(subjecttextbox.Text) || string.IsNullOrEmpty(descriptionrichbox.Text))
            {
                MessageBox.Show("Please fill in all fields");
                return;
            }
            SubmitTicket();
            MessageBox.Show("Ticket submited");
            _customer.LoadTickets();
            this.Close();
        }
        private string getCustomerID()
        {
            string CustomerID = null;
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `customer` INNER Join `user` ON `customer`.`UserID` = `user`.`UserID` WHERE `Username` = @Username;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@Username", _loginform._username);
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    CustomerID = reader.GetInt32("CustomerID").ToString();
                }
            }
            return CustomerID;
        }
        private void SubmitTicket()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "INSERT INTO supportticket (CustomerID, Subject, Description, StatusID,CreatedDate) VALUES (@CustomerID,@Subject,@Description,@StatusID,@CreatedDate);";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@CustomerID", getCustomerID());
            parameters.Add("@Subject", subjecttextbox.Text);
            parameters.Add("@Description", descriptionrichbox.Text);
            parameters.Add("@StatusID", "1");
            parameters.Add("@CreatedDate", DateTime.Now.ToString("yyyy/MM/dd"));
            sQL.ExecuteNonQueries(query, parameters);
        }
    }
}
