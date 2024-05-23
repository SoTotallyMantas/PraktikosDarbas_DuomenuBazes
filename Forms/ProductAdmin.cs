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
    public partial class ProductAdmin : Form
    {
        public bool ClearedGrid = false;
        public ProductAdmin()
        {
            InitializeComponent();
            loadproducts();
            LoadCategories();
        }
        private void DeleteSelectedProduct()
        {

            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "DELETE FROM `product` WHERE `ProductID` = @ProductID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            foreach (DataGridViewRow row in ProductsGrid.SelectedRows)
            {
                parameters.Clear();
                parameters.Add("@ProductID", row.Cells["ProductID"].Value.ToString());
                sQL.ExecuteNonQueries(query, parameters);
            }

        }
        private void SaveProduct()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "UPDATE `product` SET `CategoryID` = @CategoryID, `Name` = @Name, `Description` = @Description, `Price` = @Price WHERE `ProductID` = @ProductID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataGridViewRow row in ProductsGrid.Rows)
            {
                if (row.Cells["ProductID"].Value != null)
                {
                    parameters.Clear();
                    parameters.Add("@ProductID", row.Cells["ProductID"].Value.ToString());
                    parameters.Add("@CategoryID", row.Cells["CategoryID"].Value.ToString());
                    parameters.Add("@Name", row.Cells["Name"].Value.ToString());
                    parameters.Add("@Description", row.Cells["Description"].Value.ToString());
                    parameters.Add("@Price", row.Cells["Price"].Value.ToString());
                    sQL.ExecuteNonQueries(query, parameters);
                }
            }
        }
        private void SetProduct()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "INSERT INTO `product` (`CategoryID`, `Name`, `Description`, `Price`) VALUES (@CategoryID, @Name, @Description, @Price);";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataGridViewRow row in ProductsGrid.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    parameters.Clear();

                    parameters.Add("@Name", row.Cells[0].Value.ToString());
                    parameters.Add("@CategoryID", row.Cells[1].Value.ToString());
                    parameters.Add("@Description", row.Cells[2].Value.ToString());
                    parameters.Add("@Price", row.Cells[3].Value.ToString());
                    sQL.ExecuteNonQueries(query, parameters);
                }
            }
        }
        private void loadproducts()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ProductID");
            dataTable.Columns[0].ReadOnly = true;
            dataTable.Columns.Add("CategoryID");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Description");
            dataTable.Columns.Add("Price");

            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `product`;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {

                    dataTable.Rows.Add(reader.GetInt32("ProductID").ToString(), reader.GetInt32("CategoryID").ToString(), reader.GetString("Name"), reader.GetString("Description"), reader.GetString("Price"));
                }
            }
            ProductsGrid.DataSource = dataTable;
        }
        private void LoadCategories()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("CategoryID");
            dataTable.Columns[0].ReadOnly = true;
            dataTable.Columns.Add("Name");
            dataTable.Columns[1].ReadOnly = true;
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `productcategory`;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        dataTable.Rows.Add(reader.GetInt32("CategoryID").ToString(), reader.GetString("Name"));
                    }
                }
            }
            CategoriesGrid.DataSource = dataTable;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            ClearedGrid = false;
            loadproducts();
            LoadCategories();


        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("CategoryID");
            dataTable.Columns.Add("Description");
            dataTable.Columns.Add("Price");
            ProductsGrid.DataSource = dataTable;
            ClearedGrid = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ClearedGrid == false)
            {
                SaveProduct();
                loadproducts();

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
                DeleteSelectedProduct();
                loadproducts();
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
                SetProduct();
                loadproducts();
                ClearedGrid = false;
            }
            else
            {
                MessageBox.Show("Clear Grid");
            }

        }

        private void ModifyCategoriesButton_Click(object sender, EventArgs e)
        {
            CategoriesAdmin categoriesAdmin = new CategoriesAdmin();
            categoriesAdmin.Show();


        }
    }
}
