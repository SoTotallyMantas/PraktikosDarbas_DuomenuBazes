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
    public partial class UserType : Form
    {
        public bool ClearedGrid = false;
        public UserType()
        {
            InitializeComponent();
            loadUserTypes();
        }
        private void loadUserTypes()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("UserTypeID");
            dataTable.Columns[0].ReadOnly = true;
            dataTable.Columns.Add("Name");

            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `usertype`;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    
                    
                    dataTable.Rows.Add(reader.GetInt32("UserTypeID").ToString(), reader.GetString("Name"));
                   
                }
            }
            PlanGrid.DataSource = dataTable;
        }
        private void DeleteSelectedUserType()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "DELETE FROM `usertype` WHERE `UserTypeID` = @UserTypeID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (PlanGrid.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in PlanGrid.SelectedRows)
                {
                    if (row.Cells["UserTypeID"].Value != null)
                    {
                        parameters.Add("@UserTypeID", row.Cells["UserTypeID"].Value.ToString());
                        sQL.ExecuteNonQueries(query, parameters);
                        parameters.Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete");

            }

        }
        private void UpdateUserType()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "UPDATE `usertype` SET `Name` = @Name WHERE `UserTypeID` = @UserTypeID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataGridViewRow row in PlanGrid.Rows)
            {
                if (row.Cells["UserTypeID"].Value != null && row.Cells["Name"].Value !=null)
                {
                    parameters.Add("@UserTypeID", row.Cells["UserTypeID"].Value.ToString());
                    parameters.Add("@Name", row.Cells["Name"].Value.ToString());
                    sQL.ExecuteNonQueries(query, parameters);
                    parameters.Clear();
                }
                
            }
        }

        private void InsertUserType()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "INSERT INTO `usertype` (`Name`) VALUES (@Name);";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataGridViewRow row in PlanGrid.Rows)
            {
                if (row.Cells["Name"].Value !=null)
                {
                    parameters.Add("@Name", row.Cells["Name"].Value.ToString());
                    sQL.ExecuteNonQueries(query, parameters);
                    parameters.Clear();
                }
            }
        }


        private void RefreshButton_Click(object sender, EventArgs e)
        {

            loadUserTypes();
            ClearedGrid = false;

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Name");
            PlanGrid.DataSource = dataTable;
            ClearedGrid = true;

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ClearedGrid ==false)
            {
                UpdateUserType();
               loadUserTypes();

            }
            else
            {
                MessageBox.Show("Refresh Grid");
            }
            


        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (ClearedGrid == false)
            {
                DeleteSelectedUserType();
                loadUserTypes();
            }
            else
            {
                MessageBox.Show("Refresh Grid");
            }

        }
       
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (ClearedGrid == true)
            {
                InsertUserType();
                loadUserTypes();
                ClearedGrid = false;
            }
            else
            {
                MessageBox.Show("Clear Grid");
            }

        }
    }
}
