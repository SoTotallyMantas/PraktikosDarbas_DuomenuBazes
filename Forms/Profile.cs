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

    public partial class Profile : Form
    {
        public string StreetAddress;
        public string City;
        public string PostalCode;
        public string Country;
        public string BillingAddressID;
        public string CreditCardNumber;
        public string ExpirationDate;
        public string CVV;

        public Form1 _loginform = null;
        public Profile(Form1 loginform)
        {
            InitializeComponent();
            
            _loginform = loginform;
            getPersonalDetails();
            GetBillingAddressTexts();
            GetBillingInformationTexts();
            GetAddressTexts();

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

        private void SaveAddressButton_Click(object sender, EventArgs e)
        {
            GetAddress();
            SaveAddress();

        }
        private void GetBillingInformation()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `billinginformation` WHERE `CustomerID` = @CustomerID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@CustomerID", getCustomerID());
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {

                    CreditCardNumber = reader.GetString("CardNumber");
                    ExpirationDate = reader.GetString("ExpirationDate");
                    CVV = reader.GetInt32("CVV").ToString();
                }
            }
        }
        private void SaveBillingInformation()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "INSERT INTO `billinginformation` (`CustomerID`, `CardNumber`, `ExpirationDate`, `CVV`) VALUES (@CustomerID, @CardNumber, @ExpirationDate, @CVV);";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@CustomerID", getCustomerID());
            parameters.Add("@CardNumber", CardNumberTextBox.Text);
            parameters.Add("@ExpirationDate", ExpirationDateTextBox.Text);
            parameters.Add("@CVV", CVVTextBox.Text);
            sQL.ExecuteNonQueries(query, parameters);
        }
        private void UpdateBillingInformation()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "Update `billinginformation` SET `CardNumber` = @CardNumber, `ExpirationDate` = @ExpirationDate, `CVV` = @CVV WHERE `CustomerID` = @CustomerID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (CardNumberTextBox.Text != "")
            {
                parameters.Add("@CardNumber", CardNumberTextBox.Text);
            }
            else
            {
                MessageBox.Show("Please fill in all fields");
            }
            if (ExpirationDateTextBox.Text != "")
            {
                parameters.Add("@ExpirationDate", ExpirationDateTextBox.Text);
            }
            else
            {
                MessageBox.Show("Please fill in all fields");
            }
            if (CVVTextBox.Text != "")
            {
                parameters.Add("@CVV", CVVTextBox.Text);
            }
            else
            {
                MessageBox.Show("Please fill in all fields");
            }
            parameters.Add("@CustomerID", getCustomerID());

            sQL.ExecuteNonQueries(query, parameters);
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
        private void GetBillingAddress()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `billingaddress` WHERE `BillingInformationID` = @BillingInformationID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@BillingInformationID", GetBillingID());
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    StreetAddress = reader.GetString("StreetAddress");
                    City = reader.GetString("City");
                    PostalCode = reader.GetString("PostalCode");
                    Country = reader.GetString("Country");
                }
            }
        }
        private void SetBillingAddress()
        {
            SQL sql = new SQL(Form1.DataBaseType);
            string query = "INSERT INTO `billingaddress` (`StreetAddress`, `City`, `PostalCode`, `Country`,`BillingInformationID`) VALUES (@StreetAddress, @City, @PostalCode, @Country, @BillingInformationID);";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@StreetAddress", StreetAddressTextBox.Text);
            parameters.Add("@City", CityTextBox.Text);
            parameters.Add("@PostalCode", PostalCodeTextBox.Text);
            parameters.Add("@Country", CountryTextBox.Text);
            parameters.Add("@BillingInformationID", GetBillingID());



            sql.ExecuteNonQueries(query, parameters);
        }
        private void UpdateBillingAddress()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "Update `billingaddress` SET `StreetAddress` = @StreetAddress, `City` = @City, `PostalCode` = @PostalCode, `Country` = @Country WHERE `BillingInformationID` = @BillingInformationID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (StreetAddressTextBox.Text != "")
            {
                parameters.Add("@StreetAddress", StreetAddressTextBox.Text);
            }
            else
            {
                MessageBox.Show("Please fill in all fields");
            }
            if (CityTextBox.Text != "")
            {
                parameters.Add("@City", CityTextBox.Text);
            }
            else
            {
                MessageBox.Show("Please fill in all fields");
            }
            if (PostalCodeTextBox.Text != "")
            {
                parameters.Add("@PostalCode", PostalCodeTextBox.Text);
            }
            else
            {
                MessageBox.Show("Please fill in all fields");
            }
            if (CountryTextBox.Text != "")
            {
                parameters.Add("@Country", CountryTextBox.Text);
            }
            else
            {
                MessageBox.Show("Please fill in all fields");
            }
            parameters.Add("@BillingInformationID", GetBillingID());

            sQL.ExecuteNonQueries(query, parameters);
        }
        private void GetAddress()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `address` WHERE `CustomerID` = @CustomerID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@CustomerID", getCustomerID());
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    StreetAddress = reader.GetString("StreetAddress");
                    City = reader.GetString("City");
                    PostalCode = reader.GetString("PostalCode");
                    Country = reader.GetString("Country");
                }
            }
        }
        private void SaveAddress()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "Update `address` SET `StreetAddress` = @StreetAddress, `City` = @City, `PostalCode` = @PostalCode, `Country` = @Country WHERE `CustomerID` = @CustomerID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (StreetAddressTextBox.Text != "")
            {
                parameters.Add("@StreetAddress", StreetAddressTextBox.Text);
            }
            else
            {
                MessageBox.Show("Please fill in all fields");
            }
            if (CityTextBox.Text != "")
            {
                parameters.Add("@City", CityTextBox.Text);
            }
            else
            {
                MessageBox.Show("Please fill in all fields");
            }
            if (PostalCodeTextBox.Text != "")
            {
                parameters.Add("@PostalCode", PostalCodeTextBox.Text);
            }
            else
            {
                MessageBox.Show("Please fill in all fields");
            }
            if (CountryTextBox.Text != "")
            {
                parameters.Add("@Country", CountryTextBox.Text);
            }
            else
            {
                MessageBox.Show("Please fill in all fields");
            }
            parameters.Add("@CustomerID", getCustomerID());

            sQL.ExecuteNonQueries(query, parameters);
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

        private void SavePasswordButton_Click(object sender, EventArgs e)
        {
            if (PasswordTextBox.Text != " ")
            {
                SavePassword();
            }
            else
            {
                MessageBox.Show("Please fill in all fields");
            }
        }
        private void SavePassword()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "Update `user` SET `Password` = @Password WHERE `UserID` = @UserID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@Password", PasswordTextBox.Text);
            parameters.Add("@UserID", _loginform._userID);
            sQL.ExecuteNonQueries(query, parameters);
        }

        private void SaveBillingButton_Click(object sender, EventArgs e)
        {
            GetBillingInformation();
            if (CreditCardNumber == null)
            {
                SaveBillingInformation();

                SetBillingAddress();

            }
            else
            {

                UpdateBillingInformation();
                GetBillingAddress();
                if (City == null)
                {
                    SetBillingAddress();
                }
                else
                {
                    UpdateBillingAddress();
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
        private void SavePersonalDetails()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "Update `user` SET `FirstName` = @FirstName, `LastName` = @LastName, `Email` = @Email, `PhoneNumber` = @PhoneNumber WHERE `UserID` = @UserID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@FirstName", FirstNameText.Text);
            parameters.Add("@LastName", LastNameText.Text);
            parameters.Add("@Email", EmailText.Text);
            parameters.Add("@PhoneNumber", PhoneNumberText.Text);

            parameters.Add("@UserID", _loginform._userID);
        }
        

        private void SavePersonalDetailsButton_Click(object sender, EventArgs e)
        {
            SavePersonalDetails();
        }
    }
}
