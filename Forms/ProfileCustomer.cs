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
    public partial class ProfileCustomer : Form
    {
        public Form1 _loginform;
        public ProfileCustomer(Form1 loginform)
        {
            InitializeComponent();
            _loginform = loginform;
            GetAddressTexts();
            GetBillingAddressTexts();
            GetBillingInformationTexts();
            getPersonalDetails();
            getUserName();

        }
        private void getUserName()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `user` WHERE `UserID` = @UserID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@UserID", _loginform._userID);
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    UserNameText.Text = reader.GetString("Username");
                }
            }

        }
        private void getPersonalDetails()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `customer` WHERE `UserID` = @UserID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@UserID", _loginform._userID);
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    FirstNameText.Text = reader.GetString("FirstName");
                    LastNameText.Text = reader.GetString("LastName");
                    EmailText.Text = reader.GetString("Email");
                    PhoneNumberText.Text = reader.GetString("PhoneNumber");
                }
            }

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
        private void GetAddressTexts()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `address` WHERE `CustomerID` = @CustomerID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@CustomerID", getCustomerID());
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    StreetAddressTextBox.Text = reader.GetString("StreetAddress");
                    CityTextBox.Text = reader.GetString("City");
                    PostalCodeTextBox.Text = reader.GetString("PostalCode");
                    CountryTextBox.Text = reader.GetString("Country");
                }
            }

        }
        private string GetBillingID()
        {
            string BillingAddressID2 = null;
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `billinginformation` WHERE `CustomerID` = @CustomerID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@CustomerID", getCustomerID());
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    BillingAddressID2 = reader.GetInt32("BillingID").ToString();
                }
            }
            return BillingAddressID2;
        }
        private void GetBillingAddressTexts()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `billingaddress` WHERE `BillingInformationID` = @BillingInformationID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@BillingInformationID", GetBillingID());
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    BillingAddressTextBox.Text = reader.GetString("StreetAddress");
                    BillingCityTextBox.Text = reader.GetString("City");
                    BillingPostalCodeTextBox.Text = reader.GetString("PostalCode");
                    BillingCountryTextBox.Text = reader.GetString("Country");
                }
            }
        }
        private void GetBillingInformationTexts()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `billinginformation` WHERE `CustomerID` = @CustomerID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@CustomerID", getCustomerID());
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {

                    CardNumberTextBox.Text = reader.GetString("CardNumber");
                    ExpirationDateTextBox.Text = reader.GetString("ExpirationDate");
                    CVVTextBox.Text = reader.GetInt32("CVV").ToString();
                }
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
