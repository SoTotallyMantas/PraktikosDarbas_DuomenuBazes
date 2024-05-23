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
    public partial class CategoriesAdmin : Form
    {
        public bool ClearedGrid = false;
        public CategoriesAdmin()
        {
            InitializeComponent();
            LoadCategories();

        }
        private void SaveCategoriesToDB()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "UPDATE `productcategory` SET `Name` = @Name, `Description` = @Description WHERE `CategoryID` = @CategoryID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataGridViewRow row in CategoriesGrid.Rows)
            {
                if (row.Cells["CategoryID"].Value != null)
                {
                    parameters.Clear();
                    parameters.Add("@CategoryID", row.Cells["CategoryID"].Value.ToString());
                    parameters.Add("@Name", row.Cells["Name"].Value.ToString());
                    parameters.Add("@Description", row.Cells["Description"].Value.ToString());
                    sQL.ExecuteNonQueries(query, parameters);
                }
              
            }
        }
        private void DeleteSelectedCategoriesToDB()
        {
                
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "DELETE FROM `productcategory` WHERE `CategoryID` = @CategoryID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataGridViewRow row in CategoriesGrid.SelectedRows)
            {
                if (row.Cells["CategoryID"].Value != null)
                {
                    parameters.Clear();
                    parameters.Add("@CategoryID", row.Cells["CategoryID"].Value.ToString());
                    sQL.ExecuteNonQueries(query, parameters);
                }
            }
        }
        private void AddCategoriesToDB()
        {

            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "INSERT INTO `productcategory` (`Name`, `Description`) VALUES (@Name, @Description);";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataGridViewRow row in CategoriesGrid.Rows)
            {
                if (row.Cells["Name"].Value != null && row.Cells["Description"].Value != null)
                {
                    parameters.Clear();
                    parameters.Add("@Name", row.Cells["Name"].Value.ToString());
                    parameters.Add("@Description", row.Cells["Description"].Value.ToString());
                    sQL.ExecuteNonQueries(query, parameters);
                }
               
            }
        }
        private void LoadCategories()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("CategoryID");
            dataTable.Columns[0].ReadOnly = true;
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Description");
           
            SQL sQL = new SQL(Form1.DataBaseType);  
            string query = "SELECT * FROM `productcategory`;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
                using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                if (reader != null)
                    {
                    while (reader.Read())
                    {
                        dataTable.Rows.Add(reader.GetInt32("CategoryID").ToString(), reader.GetString("Name"), reader.GetString("Description"));

                    }
                }
            }
                CategoriesGrid.DataSource = dataTable;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            ClearedGrid = false;
            LoadCategories();


        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Description");
            CategoriesGrid.DataSource = dataTable;
            ClearedGrid = true;

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(ClearedGrid == false)
            {

                SaveCategoriesToDB();
                LoadCategories();
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
                DeleteSelectedCategoriesToDB();
                LoadCategories();
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
                AddCategoriesToDB();
                LoadCategories();
                ClearedGrid = false;
            }
            else
            {
                MessageBox.Show("Clear Grid");
            }

        }
    }
}
