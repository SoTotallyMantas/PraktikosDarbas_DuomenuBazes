using MobilusOperatorius.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobilusOperatorius.Forms
{
    public partial class Register : Form
    {
        Form1 _loginform;
        public Register(Form1 loginform)
        {
            InitializeComponent();
            _loginform = loginform;
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            
            AddUser();
            AddCustomer();
            AddAddress();
            _loginform._username = UsernameTextBox.Text;
            _loginform.ShowForm();
            this.Close();
        }
        private void IsTextBoxEmpty()
        {
            if(
                string.IsNullOrEmpty(UsernameTextBox.Text) ||
                string.IsNullOrEmpty(PasswordTextBox.Text) ||
                string.IsNullOrEmpty(FirstNameTextBox.Text) ||
                string.IsNullOrEmpty(LastNameTextBox.Text) ||
                string.IsNullOrEmpty(EmailTextBox.Text) ||
                    
                string.IsNullOrEmpty(PhoneNumberTextBox.Text) ||
                string.IsNullOrEmpty(CityTextBox.Text) ||
                string.IsNullOrEmpty(StreetAddressTextBox.Text) ||
                string.IsNullOrEmpty(CountryTextBox.Text) ||
                string.IsNullOrEmpty(PostalCodeTextBox.Text)
                )
            {
                MessageBox.Show("Please fill in all fields");
            }

        }
        private void AddUser()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "INSERT INTO users (Username, Password, UserType) VALUES (@UserName,@Password,@UserType);";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@UserName", UsernameTextBox.Text);
            parameters.Add("@Password", PasswordTextBox.Text);
            parameters.Add("@UserType", "1");
            sQL.ExecuteNonQueries(query, parameters);

        }
        private string getCustomerID()
        {
            string CustomerID = null;
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM 'customer' INNER Join 'user' ON 'customer'.'UserID' = 'user'.'UserID' WHERE 'Username' = '@Username';";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@Username", UsernameTextBox.Text);
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    CustomerID = reader.GetInt32("CustomerID").ToString();
                }
            }
            return CustomerID;
        }
        private void AddCustomer()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "INSERT INTO customer (FirstName, LastName, Email, PhoneNumber) VALUES (@FirstName,@LastName,@Email,@PhoneNumber;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@FirstName", FirstNameTextBox.Text);
            parameters.Add("@LastName", LastNameTextBox.Text);
            parameters.Add("@Email", EmailTextBox.Text);
            parameters.Add("@PhoneNumber", PhoneNumberTextBox.Text);

            sQL.ExecuteNonQueries(query, parameters);
        }
        private void AddAddress()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "INSERT INTO address (City, StreetAddress, Country, PostalCode,CustomerID) VALUES (@City,@Street,@Country,@Postalcode,@CustomerID);";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@City", CityTextBox.Text);
            parameters.Add("@Street", StreetAddressTextBox.Text);
            parameters.Add("@Country", CountryTextBox.Text);
            parameters.Add("CustomerID", getCustomerID());
            sQL.ExecuteNonQueries(query, parameters);
        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            _loginform.Show();

        }
    }
}
