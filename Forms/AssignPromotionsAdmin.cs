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
    public partial class AssignPromotionsAdmin : Form
    {
        public bool ClearedGrid = false;
        public AssignPromotionsAdmin()
        {
            InitializeComponent();
            LoadPromotions();
            loadproducts();
            loadProductpromotion();
        }
        private void UpdateProductPromotion()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "UPDATE `productpromotion` SET `ProductID` = @ProductID, `PromotionID` = @PromotionID WHERE `ProductPromotionID` = @ProductPromotionID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataGridViewRow row in DataGrid.Rows)
            {
                if (row.Cells["ProductPromotionID"].Value != null && row.Cells["ProductID"].Value != null && row.Cells["PromotionID"].Value != null)
                {
                    parameters.Add("@ProductPromotionID", row.Cells["ProductPromotionID"].Value.ToString());

                    parameters.Add("@ProductID", row.Cells["ProductID"].Value.ToString());
                    parameters.Add("@PromotionID", row.Cells["PromotionID"].Value.ToString());

                    sQL.ExecuteNonQueries(query, parameters);
                    parameters.Clear();
                }
            }
        }
        private void DeleteProductPromotion()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "DELETE FROM `productpromotion` WHERE `ProductPromotionID` = @ProductPromotionID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataGridViewRow row in DataGrid.SelectedRows)
            {
                if (row.Cells["ProductPromotionID"].Value != null)
                {
                    parameters.Add("@ProductPromotionID", row.Cells["ProductPromotionID"].Value.ToString());
                    sQL.ExecuteNonQueries(query, parameters);
                    parameters.Clear();
                }
            }
        }
        private void AddProductPromotion()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "INSERT INTO `productpromotion` (`ProductID`, `PromotionID`) VALUES (@ProductID, @PromotionID);";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataGridViewRow row in DataGrid.Rows)
            {
                if (row.Cells["ProductID"].Value != null && row.Cells["PromotionID"].Value != null)
                {
                    parameters.Add("@ProductID", row.Cells["ProductID"].Value.ToString());
                    parameters.Add("@PromotionID", row.Cells["PromotionID"].Value.ToString());
                    sQL.ExecuteNonQueries(query, parameters);
                    parameters.Clear();
                }
               
            }
        }
    
            


        
        private void loadProductpromotion()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ProductPromotionID");
            dataTable.Columns.Add("ProductID");
            dataTable.Columns.Add("PromotionID");

            SQL sQL = new SQL(Form1.DataBaseType);

            string query = "SELECT * FROM `productpromotion`;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {

                    dataTable.Rows.Add(reader.GetInt32("ProductPromotionID").ToString(), reader.GetInt32("ProductID").ToString(), reader.GetInt32("PromotionID").ToString());
                }
            }
            DataGrid.DataSource = dataTable;
        }
        private void loadproducts()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ProductID");
            dataTable.Columns[0].ReadOnly = true;
            dataTable.Columns.Add("CategoryID");
            dataTable.Columns[1].ReadOnly = true;
            dataTable.Columns.Add("Name");
            dataTable.Columns[2].ReadOnly = true;
            dataTable.Columns.Add("Description");
            dataTable.Columns[3].ReadOnly = true;
            dataTable.Columns.Add("Price");
            dataTable.Columns[4].ReadOnly = true;

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
            ProductsView.DataSource = dataTable;
        }

        private void LoadPromotions()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("PromotionID");
            dataTable.Columns[0].ReadOnly = true;
            dataTable.Columns.Add("Name");
            dataTable.Columns[1].ReadOnly = true;
            dataTable.Columns.Add("Description");
            dataTable.Columns[2].ReadOnly = true;
            dataTable.Columns.Add("DiscountAmount");
            dataTable.Columns[3].ReadOnly = true;
            dataTable.Columns.Add("StartDate");
            dataTable.Columns[4].ReadOnly = true;
            dataTable.Columns.Add("EndDate");
            dataTable.Columns[5].ReadOnly = true;

            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `promotion`;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {

                while (reader.Read())
                {
                    dataTable.Rows.Add(reader.GetInt32("PromotionID").ToString(), reader.GetString("Name"), reader.GetString("Description"), reader.GetString("DiscountAmount"), reader.GetString("StartDate"), reader.GetString("EndDate"));
                }

            }
            PromotionsView.DataSource = dataTable;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (ClearedGrid == false)
            {
                UpdateProductPromotion();
                loadProductpromotion();
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
                DeleteProductPromotion();
                loadProductpromotion();
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
                AddProductPromotion();
                loadProductpromotion();
                ClearedGrid = false;
            }
            else
            {
                MessageBox.Show("Clear Grid");
            }

        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadPromotions();
            loadproducts();
            loadProductpromotion();
            ClearedGrid = false;

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            
            dataTable.Columns.Add("ProductID");
            dataTable.Columns.Add("PromotionID");

            DataGrid.DataSource = dataTable;
            ClearedGrid = true;

        }
    }
}
