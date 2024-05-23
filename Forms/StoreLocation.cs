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
    public partial class StoreLocation : Form
    {
        public bool ClearedGrid = false;
        public StoreLocation()
        {
            InitializeComponent();
            LoadStoreLocation();
        }
        private void LoadStoreLocation()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("StoreID");
            dt.Columns[0].ReadOnly = true;
            dt.Columns.Add("Name");
            dt.Columns.Add("Address");
            dt.Columns.Add("PhoneNumber");
            dt.Columns.Add("OpeningHours");
            dt.Columns.Add("ClosingHours");
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `storelocation`;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    dt.Rows.Add(reader.GetInt32("StoreID").ToString(), reader.GetString("Name"), reader.GetString("Address"), reader.GetString("PhoneNumber"), reader.GetString("OpeningHours"), reader.GetString("ClosingHours"));
                }
            }
            StoreLocationGridView.DataSource = dt;

        }
        private void StoreLocation_Load(object sender, EventArgs e)
        {

        }

        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            SaveChanges();
            LoadStoreLocation();
        }
        private void SaveChanges()
        {
            DataTable dt = (DataTable)StoreLocationGridView.DataSource;
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "UPDATE `storelocation` SET `Name` = @Name, `Address` = @Address, `PhoneNumber` = @PhoneNumber, `OpeningHours` = @OpeningHours, `ClosingHours` = @ClosingHours WHERE `StoreID` = @StoreID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataRow row in dt.Rows)
            {
                parameters.Clear();
                parameters.Add("@StoreID", row["StoreID"].ToString());
                parameters.Add("@Name", row["Name"].ToString());
                parameters.Add("@Address", row["Address"].ToString());
                parameters.Add("@PhoneNumber", row["PhoneNumber"].ToString());
                parameters.Add("@OpeningHours", row["OpeningHours"].ToString());
                parameters.Add("@ClosingHours", row["ClosingHours"].ToString());
                sQL.ExecuteNonQueries(query, parameters);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Address");
            dataTable.Columns.Add("PhoneNumber");
                dataTable.Columns.Add("OpeningHours");
            dataTable.Columns.Add("ClosingHours");

            StoreLocationGridView.DataSource = dataTable;
            ClearedGrid = true;

        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadStoreLocation();
            ClearedGrid = false;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteSelectedRow();
            LoadStoreLocation();
        }
        private void DeleteSelectedRow()
        {
            if (StoreLocationGridView.SelectedRows.Count > 0)
            {
                if (ClearedGrid == false)
                { 
                SQL sQL = new SQL(Form1.DataBaseType);
                string query = "DELETE FROM `storelocation` WHERE `StoreID` = @StoreID;";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("@StoreID", StoreLocationGridView.SelectedRows[0].Cells[0].Value.ToString());
                sQL.ExecuteNonQueries(query, parameters);
                }
                else
                {
                    MessageBox.Show("Please Refresh the grid before deleting rows.");
                    
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if(ClearedGrid == true)
            {
                AddNewGridViewRowsToSQL();
                LoadStoreLocation();
                ClearedGrid = false;
            }
            else
            {
                MessageBox.Show("Please clear the grid before adding new rows.");
            }
            
        }
        private void AddNewGridViewRowsToSQL()
        {

            DataTable dt = (DataTable)StoreLocationGridView.DataSource;
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "INSERT INTO `storelocation` (`Name`, `Address`, `PhoneNumber`, `OpeningHours`, `ClosingHours`) VALUES (@Name, @Address, @PhoneNumber, @OpeningHours, @ClosingHours);";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataRow row in dt.Rows)
            {
                parameters.Clear();
                if (row["Name"].ToString() != "")
                {
                    parameters.Add("@Name", row["Name"].ToString());
                }
                else
                {
                    MessageBox.Show("Please enter a value to insert");
                    return ;
                }
                if (row["Address"].ToString() != "")
                {
                        
                    parameters.Add("@Address", row["Address"].ToString());
                }
                else
                {
                    MessageBox.Show("Please enter a value to insert");
                    return ;
                }
                if (row["PhoneNumber"].ToString() != "")
                {
                       parameters.Add("@PhoneNumber", row["PhoneNumber"].ToString());

                }
                else
                {
                    MessageBox.Show("Please enter a value to insert");
                    return ;
                }
                if (row["OpeningHours"].ToString() != "")
                {
                       parameters.Add("@OpeningHours", row["OpeningHours"].ToString());

                }
                else
                {
                       MessageBox.Show("Please enter a value to insert");
                    return ;
                }
                if (row["ClosingHours"].ToString() != "")
                {
                       parameters.Add("@ClosingHours", row["ClosingHours"].ToString());

                }
                else
                {
                       MessageBox.Show("Please enter a value to insert");
                    return ;
                }
                   
                   
                    sQL.ExecuteNonQueries(query, parameters);
                }
            }
        }

    }

