using MobilusOperatorius.Classes;

namespace MobilusOperatorius
{

    public partial class Form1 : Form
    {
        public static string DataBaseType = "DatabaseLocal"; // DatabaseLocal or DatabaseRemote
        public string _username;
        private string _password;
        private string _UserType;
        public string _userID;
        private string _PositionName;
        public string _FirstName;
        public string _LastName;
        public string _EmployeeID;


        public Form1()
        {
            InitializeComponent();
        }
        public void ClearTextBoxes()
        {
            UsernameTextBox.Text = "";
            PasswordTextBox.Text = "";
        }   

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;
            GetUserLogin(username, password);
            if (username == _username && password == _password)
            {
                switch (_UserType)
                {
                    case "1": // Customer
                        Forms.Customer customerForm = new Forms.Customer(this);
                        customerForm.Show();
                        this.Hide();

                        break;
                    case "2": // Employee
                        CheckEmployeePosition();
                        switch (_PositionName)
                        {
                            case "Admin":
                                Forms.Admin administratorForm = new Forms.Admin(this);
                                administratorForm.Show();
                                this.Hide();
                                break;
                            case "Consultant":
                                Forms.Consultant consultantForm = new Forms.Consultant(this);
                                consultantForm.Show();
                                this.Hide();
                                break;
                        }
                        break;
                }
                MessageBox.Show("Prisijungta");
            }
            else
            {
                MessageBox.Show("Neteisingi prisijungimo duomenys");
            }
        }
        private void CheckEmployeePosition()
        {
            SQL sql = new SQL(DataBaseType);
            string query = "SELECT * FROM `employee` INNER Join `employeeposition` ON `employee`.`PositionID` = `employeeposition`.`PositionID`  WHERE `UserID`=@userid;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@userid", _userID);
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sql.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    _FirstName = reader.GetString("FirstName");
                    _LastName = reader.GetString("LastName");
                    _EmployeeID = reader.GetInt32("EmployeeID").ToString();
                    _PositionName = reader.GetString("PositionName");
                }
            }
        }
        private void GetUserLogin(string username, string password)
        {
            SQL sql = new SQL(DataBaseType);
            string query = "SELECT * FROM `user` WHERE `Username`=@username AND `Password`=@password;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@username", username);
            parameters.Add("@password", password);
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sql.DataReader(query, parameters))
            {
                while (reader.Read())

                {
                    _userID = reader.GetInt32("UserID").ToString();
                    _username = reader.GetString("Username");
                    _password = reader.GetString("Password");
                    _UserType = reader.GetInt32("UserTypeID").ToString();
                }
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
           
            Forms.Register registerForm = new Forms.Register(this);
            registerForm.Show();
            this.Hide();
        }
        public  void ShowForm()
        {
            this.Show();
        }
    }
}
