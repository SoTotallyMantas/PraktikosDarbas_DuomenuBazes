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
    public partial class EmployeepositionAdmin : Form
    {
        public bool ClearedGrid = false;
        public EmployeepositionAdmin()
        {
            InitializeComponent();
            LoadEmployeePosition();
        }
        private void LoadEmployeePosition()
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
            DataGrid.DataSource = dataTable;

        }
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadEmployeePosition();
            ClearedGrid = false;
        }

        private void UpdateEmployeePosition()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "UPDATE `employeeposition` SET `PositionName` = @PositionName WHERE `PositionID` = @PositionID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataGridViewRow row in DataGrid.Rows)
            {
                if (row.Cells["PositionID"].Value != null && row.Cells["PositionName"].Value != null)
                {
                    parameters.Add("@PositionID", row.Cells["PositionID"].Value.ToString());
                    parameters.Add("@PositionName", row.Cells["PositionName"].Value.ToString());
                    sQL.ExecuteNonQueries(query, parameters);
                    parameters.Clear();
                }
            }
        }
        private void DeleteSelectedEmployeePosition()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "DELETE FROM `employeeposition` WHERE `PositionID` = @PositionID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if(DataGrid.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in DataGrid.SelectedRows)
                {
                    if (row.Cells["PositionID"].Value != null)
                    {
                        parameters.Add("@PositionID", row.Cells["PositionID"].Value.ToString());
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
        private void InsertEmployeePosition()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "INSERT INTO `employeeposition` (`PositionName`) VALUES (@PositionName);";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (DataGrid.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in DataGrid.Rows)
                {
                    if (row.Cells["PositionName"].Value != null)
                    {
                        parameters.Add("@PositionName", row.Cells["PositionName"].Value.ToString());
                        sQL.ExecuteNonQueries(query, parameters);
                        parameters.Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a value to insert");
            }
        }


        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if(ClearedGrid == false)
            {
                UpdateEmployeePosition();
                LoadEmployeePosition();
            }
            else
            {
                MessageBox.Show("Refresh Grid");
            }

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if(ClearedGrid == false)
            {
                DeleteSelectedEmployeePosition();
                LoadEmployeePosition();
            }
            else
            {
                MessageBox.Show("Refresh Grid");
            }

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if(ClearedGrid == true)
            { 
                InsertEmployeePosition();
                LoadEmployeePosition();
                ClearedGrid = false;
            }
            else
            {
                MessageBox.Show("Clear Grid");
            }
          
        }

       

        private void ClearButton_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("PositionName");
            DataGrid.DataSource = dataTable;
            ClearedGrid = true;

        }
    }
}
