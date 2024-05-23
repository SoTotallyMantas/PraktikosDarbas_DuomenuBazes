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
    public partial class EmployeeAdmin : Form
    {
        public bool ClearGrid = false;
        public EmployeeAdmin()
        {
            InitializeComponent();
            LoadEmployees();
            GetStoreLocations();
            GetPositions();
        }
        private void LoadEmployees()
        {
            string[] User;
            DataTable dt = new DataTable();
            DataTable EmployeeLocations = new DataTable();
            dt.Columns.Add("EmployeeID");
            dt.Columns[0].ReadOnly = true;

            dt.Columns.Add("FirstName");
            dt.Columns.Add("LastName");
            dt.Columns.Add("Position");
            dt.Columns.Add("UserID");
            dt.Columns.Add("Login");
            dt.Columns.Add("Password");
            dt.Columns.Add("StoreID");
            string employeeLocationID = null;

            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `employee`;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {

                while (reader.Read())
                {
                    User = GetLogins(reader.GetInt32("UserID").ToString());
                    employeeLocationID = getEmployeeLocationID(reader.GetInt32("EmployeeID").ToString());
                    dt.Rows.Add(reader.GetInt32("EmployeeID").ToString(), reader.GetString("FirstName"), reader.GetString("Lastname"), Position(reader.GetInt32("PositionID").ToString()), User[0] ,User[1], User[2], employeeLocationID);
                }
            }
            EmployeeData.DataSource = dt;


        }
        private void GetStoreLocations()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("StoreID");

            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Address");
            dataTable.Columns.Add("PhoneNumber");
            dataTable.Columns.Add("OpeningHours");
            dataTable.Columns.Add("ClosingHours");

            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `storelocation`;";

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    dataTable.Rows.Add(reader.GetInt32("StoreID").ToString(), reader.GetString("Name"), reader.GetString("Address"), reader.GetString("PhoneNumber"), reader.GetString("OpeningHours"), reader.GetString("ClosingHours"));
                }
            }
            StoreLocations.DataSource = dataTable;
        }
        private string GetEmployeeStoreLocation(string StoreLocationID)
        {

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("StoreID");
            dataTable.Columns[0].ReadOnly = true;
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Address");
            dataTable.Columns.Add("PhoneNumber");
            dataTable.Columns.Add("OpeningHours");
            dataTable.Columns.Add("ClosingHours");
            string locationID = null;
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `storelocation` WHERE `StoreID` = @StoreLocationID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@StoreLocationID", StoreLocationID);
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    locationID = reader.GetInt32("StoreID").ToString();
                }
                }
            return locationID;
        }
        private string getEmployeeLocationID(string EmployeeID)
        {
            DataTable dataTable = new DataTable();
            string employeelocation=null;
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT `StoreLocationID` FROM `employeestorelocation` WHERE `EmployeeID` = @EmployeeID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@EmployeeID", EmployeeID);
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                   employeelocation = GetEmployeeStoreLocation(reader.GetInt32("StoreLocationID").ToString());
                }
            }
            return employeelocation;
        }
        private string[] GetLogins(string UserID)
        {
            string[] Logins = new string[3];
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `user` WHERE `UserID` = @UserID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@UserID", UserID);
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    Logins[0] = reader.GetInt32("UserID").ToString();
                    Logins[1] = reader.GetString("Username");
                    Logins[2] = reader.GetString("Password");
                }
            }
            return Logins;
        }
        private string Position(string PositionID)
        {
            string Position = "";
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `employeeposition` WHERE `PositionID` = @PositionID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@PositionID", PositionID);
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    Position = reader.GetString("PositionName");
                }
            }
            return Position;

        }
        private void GetPositions()
        {

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("PositionID");
            dataTable.Columns[0].ReadOnly = true;
            dataTable.Columns.Add("PositionName");

            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `employeeposition`;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    dataTable.Rows.Add(reader.GetInt32("PositionID").ToString(), reader.GetString("PositionName"));
                }
            }
            PositionsGrid.DataSource = dataTable;
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();

            dt.Columns.Add("FirstName");
            dt.Columns.Add("LastName");
            dt.Columns.Add("Login");
            dt.Columns.Add("Password");

            EmployeeData.DataSource = dt;
            ClearGrid = true;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            ClearGrid = false;
            LoadEmployees();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ClearGrid == false)
            {
                SaveChanges();
                LoadEmployees();
            }
            else
            {
                MessageBox.Show("Refresh Grid");
            }
            

        }
        private void SaveChanges()
        {
            DataTable dt = (DataTable)EmployeeData.DataSource;
            SQL sQL = new SQL(Form1.DataBaseType);
            string PositionName;
            int rowIndex;
                string rowIndexString=null;
            string query = "UPDATE `employee` SET `FirstName` = @FirstName, `LastName` = @LastName, `PositionID` = @PositionID WHERE `EmployeeID` = @EmployeeID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataRow row in dt.Rows)
            {
                PositionName = row["Position"].ToString();
                DataGridViewRow targetRow = PositionsGrid.Rows
                .Cast<DataGridViewRow>()
                .FirstOrDefault(r => r.Cells["PositionName"].Value.ToString() == PositionName);
                if(targetRow !=null)
                {
                     rowIndex = PositionsGrid.Rows.IndexOf(targetRow);
                    rowIndex++;
                    rowIndexString = rowIndex.ToString();
                }

                parameters.Clear();
                parameters.Add("@EmployeeID", row["EmployeeID"].ToString());
                parameters.Add("@FirstName", row["FirstName"].ToString());
                parameters.Add("@LastName", row["LastName"].ToString());
                parameters.Add("@PositionID", rowIndexString);
                SaveChangeToUser();
                SaveChangesToEmployeeStoreLocation();
                sQL.ExecuteNonQueries(query, parameters);
            }
        }
        private void SaveChangeToUser()
        {
            DataTable dt = (DataTable)EmployeeData.DataSource;
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "UPDATE `user` SET `Username` = @Username, `Password` = @Password WHERE `UserID` = @UserID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataRow row in dt.Rows)
            {
                parameters.Clear();
                parameters.Add("@UserID", row["UserID"].ToString());
                parameters.Add("@Username", row["Login"].ToString());
                parameters.Add("@Password", row["Password"].ToString());

                sQL.ExecuteNonQueries(query, parameters);
            }
        }
        private void SaveChangesToEmployeeStoreLocation()
        {
            DataTable dt = (DataTable)EmployeeData.DataSource;
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "UPDATE `employeestorelocation` SET `StoreLocationID` = @StoreLocationID WHERE `EmployeeID` = @EmployeeID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataRow row in dt.Rows)
            {
                parameters.Clear();
                parameters.Add("@EmployeeID", row["EmployeeID"].ToString());
                parameters.Add("@StoreLocationID", row["StoreID"].ToString());
                sQL.ExecuteNonQueries(query, parameters);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(ClearGrid == false)
            {
                DeleteEmployeeStoreLocation();
                DeleteEmployee();
                DeleteUser();
                
                LoadEmployees();
                ClearGrid = false;
            }
            else
            {
                MessageBox.Show("Refresh Grid");
            }
           
        }
        private void DeleteEmployee()
        {
            if (EmployeeData.SelectedRows.Count > 0)
            {
                DataTable dt = (DataTable)EmployeeData.DataSource;
                SQL sQL = new SQL(Form1.DataBaseType);
                string query = "DELETE FROM `employee` WHERE `EmployeeID` = @EmployeeID;";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                foreach (DataGridViewRow row in EmployeeData.SelectedRows)
                {
                    parameters.Clear();
                    parameters.Add("@EmployeeID", row.Cells["EmployeeID"].Value.ToString());
                    sQL.ExecuteNonQueries(query, parameters);
                }
            }
        }
        private void DeleteUser()
        {
            if (EmployeeData.SelectedRows.Count > 0)
            {
                DataTable dt = (DataTable)EmployeeData.DataSource;
                SQL sQL = new SQL(Form1.DataBaseType);
                string query = "DELETE FROM `user` WHERE `UserID` = @UserID;";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                foreach (DataGridViewRow row in EmployeeData.SelectedRows)
                {
                    parameters.Clear();
                    parameters.Add("@UserID", FindEmployeeUserID());
                    sQL.ExecuteNonQueries(query, parameters);
                }
            }
        }
        private void DeleteEmployeeStoreLocation()
        {
            if (EmployeeData.SelectedRows.Count > 0)
            {
                DataTable dt = (DataTable)EmployeeData.DataSource;
                SQL sQL = new SQL(Form1.DataBaseType);
                string query = "DELETE FROM `employeestorelocation` WHERE `EmployeeID` = @EmployeeID;";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                foreach (DataGridViewRow row in EmployeeData.SelectedRows)
                {
                    parameters.Clear();
                    parameters.Add("@EmployeeID", row.Cells["EmployeeID"].Value.ToString());
                    sQL.ExecuteNonQueries(query, parameters);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(ClearGrid == true)
            {
                try
                {
                    if(PositionsGrid.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Select Position");
                    }
                    else
                    {
                        AddNewUser();
                    }
                    if(StoreLocations.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Select Store Location");
                    }
                    else
                    {
                        AddEmployeeDB();
                        AddNewEmployeeStoreLocation();
                        
                    }
                    LoadEmployees();
                    ClearGrid = false;

                }
                catch
                (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
               MessageBox.Show("Clear Grid");
            }
            
            
        }
        private void AddEmployeeDB()
        {

            DataTable dt = (DataTable)EmployeeData.DataSource;
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "INSERT INTO `employee` (`FirstName`, `LastName`, `PositionID`,`UserID`) VALUES (@FirstName, @LastName, @PositionID,@UserID);";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataRow row in dt.Rows)
            {
                parameters.Clear();
                parameters.Add("@FirstName", row["FirstName"].ToString());
                parameters.Add("@LastName", row["LastName"].ToString());
                parameters.Add("@PositionID", PositionsGrid.SelectedRows[0].Cells[0].Value.ToString());
                parameters.Add("@UserID", FindEmployeeUserID());
                sQL.ExecuteNonQueries(query, parameters);
            }
            
        }
        private string FindEmployeeUserIDByUserNameAndPassword(string Username, string Password)
        {
            string UserID = null;
         
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT `UserID` FROM `user` WHERE `Username` = @Username AND `Password` = @Password;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            
                parameters.Clear();
                parameters.Add("@Username",Username);
                parameters.Add("@Password", Password);
                using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
                {
                    while (reader.Read())
                    {
                        UserID = reader.GetInt32("UserID").ToString();
                    }
                }

            
            return UserID;
        }
        private string FindEmployeeUserID()
        {
            string UserID=null;
            DataTable dt = (DataTable)EmployeeData.DataSource;
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT `UserID` FROM `user` WHERE `Username` = @Username AND `Password` = @Password;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataRow row in dt.Rows)
            {
                parameters.Clear();
                parameters.Add("@Username", row["Login"].ToString());
                parameters.Add("@Password", row["Password"].ToString());
                using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
                {
                    while (reader.Read())
                    {
                        UserID = reader.GetInt32("UserID").ToString();
                    }
                }
                
            }
            return UserID;
        }
        private string FindEmployeeByUserID()
        {

            string EmployeeID = null;
            DataTable dt = (DataTable)EmployeeData.DataSource;
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT `EmployeeID` FROM `employee` WHERE `UserID` = @UserID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataRow row in dt.Rows)
            {
                parameters.Clear();
                parameters.Add("@UserID", FindEmployeeUserID());
                using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
                {
                    while (reader.Read())
                    {
                        EmployeeID = reader.GetInt32("EmployeeID").ToString();
                    }
                }
            }
            return EmployeeID;
        }
        private void AddNewEmployeeStoreLocation()
        {

            DataTable dt = (DataTable)EmployeeData.DataSource;
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "INSERT INTO `employeestorelocation` (`EmployeeID`, `StoreLocationID`) VALUES (@EmployeeID, @StoreLocationID);";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataRow row in dt.Rows)
            {
                parameters.Clear();
                parameters.Add("@EmployeeID", FindEmployeeByUserID());
                parameters.Add("@StoreLocationID", StoreLocations.SelectedRows[0].Cells[0].Value.ToString());
                sQL.ExecuteNonQueries(query, parameters);
            }
        }
        private void AddNewUser()
        {
            DataTable dt = (DataTable)EmployeeData.DataSource;
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "INSERT INTO `user` (`Username`, `Password`,`UserTypeID`) VALUES (@Username, @Password,@UserTypeID);";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataRow row in dt.Rows)
            {
                if (PositionsGrid.SelectedRows.Count == 0)
                {

                    throw new Exception("Select Position");
                }
                else
                {
                    parameters.Clear();
                    parameters.Add("@Username", row["Login"].ToString());
                    parameters.Add("@Password", row["Password"].ToString());
                    parameters.Add("@UserTypeID", PositionsGrid.SelectedRows[0].Cells[0].Value.ToString());
                    sQL.ExecuteNonQueries(query, parameters);
                }
            }
        }
    }
}
