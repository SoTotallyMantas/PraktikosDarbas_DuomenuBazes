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
    public partial class Promotions : Form
    {
        public bool ClearedGrid = false;
        public Promotions()
        {
            InitializeComponent();
            LoadPromotions();
        }
        private void LoadPromotions()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("PromotionID");
            dataTable.Columns[0].ReadOnly = true;
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Description");
            dataTable.Columns.Add("DiscountAmount");
            dataTable.Columns.Add("StartDate");
            dataTable.Columns.Add("EndDate");

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
            DataGrid.DataSource = dataTable;
        }
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadPromotions();
            ClearedGrid = false;

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Description");
            dataTable.Columns.Add("DiscountAmount");
            dataTable.Columns.Add("StartDate");
            dataTable.Columns.Add("EndDate");

            DataGrid.DataSource = dataTable;
            ClearedGrid = true;

        }
        private void UpdatePromotion()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "UPDATE `promotion` SET `Name` = @Name, `Description` = @Description, `DiscountAmount` = @DiscountAmount, `StartDate` = @StartDate, `EndDate` = @EndDate WHERE `PromotionID` = @PromotionID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataGridViewRow row in DataGrid.Rows)
            {
                if (row.Cells["PromotionID"].Value != null && row.Cells["Name"].Value != null && row.Cells["Description"].Value != null && row.Cells["DiscountAmount"].Value != null && row.Cells["StartDate"].Value != null && row.Cells["EndDate"].Value != null)
                {

                    parameters.Add("@PromotionID", row.Cells["PromotionID"].Value.ToString());
                    parameters.Add("@Name", row.Cells["Name"].Value.ToString());
                    parameters.Add("@Description", row.Cells["Description"].Value.ToString());
                    parameters.Add("@DiscountAmount", row.Cells["DiscountAmount"].Value.ToString());
                    parameters.Add("@StartDate", row.Cells["StartDate"].Value.ToString());
                    parameters.Add("@EndDate", row.Cells["EndDate"].Value.ToString());

                    sQL.ExecuteNonQueries(query, parameters);
                    parameters.Clear();
                }
            }

        }
        private void DeleteSelectedPromotions()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "DELETE FROM `promotion` WHERE `PromotionID` = @PromotionID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataGridViewRow row in DataGrid.SelectedRows)
            {
                if (row.Cells["PromotionID"].Value != null)
                {
                    parameters.Add("@PromotionID", row.Cells["PromotionID"].Value.ToString());
                    sQL.ExecuteNonQueries(query, parameters);
                }
            }

        }
        private void AddPromotion()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "INSERT INTO `promotion` (`Name`, `Description`, `DiscountAmount`, `StartDate`, `EndDate`) VALUES (@Name, @Description, @DiscountAmount, @StartDate, @EndDate);";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataGridViewRow row in DataGrid.Rows)
            {
                if (row.Cells["Name"].Value != null && row.Cells["Description"].Value != null && row.Cells["DiscountAmount"].Value != null && row.Cells["StartDate"].Value != null && row.Cells["EndDate"].Value != null)
                {

                    parameters.Add("@Name", row.Cells["Name"].Value.ToString());
                    parameters.Add("@Description", row.Cells["Description"].Value.ToString());
                    parameters.Add("@DiscountAmount", row.Cells["DiscountAmount"].Value.ToString());
                    parameters.Add("@StartDate", row.Cells["StartDate"].Value.ToString());
                    parameters.Add("@EndDate", row.Cells["EndDate"].Value.ToString());
                    sQL.ExecuteNonQueries(query, parameters);
                }
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (ClearedGrid == false)
            {
                UpdatePromotion();
                LoadPromotions();
                
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
                DeleteSelectedPromotions();
                LoadPromotions();
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
                AddPromotion();
                LoadPromotions();
                ClearedGrid = false;
            }
            else
            {
                MessageBox.Show("Clear Grid");
            }

        }

        private void AssignButton_Click(object sender, EventArgs e)
        {
            AssignPromotionsAdmin assignPromotionsAdmin = new AssignPromotionsAdmin();  
            assignPromotionsAdmin.Show();
        }
    }
}
