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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace MobilusOperatorius.Forms
{
    public partial class Customer : Form
    {
        Form1 _loginform;
        Dictionary<string, string> ProductCategoriesDic = new Dictionary<string, string>();
        public Customer(Form1 loginform)
        {
            InitializeComponent();
            _loginform = loginform;
        }

        private void OpenTicketButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemented");
        }

        private void NewTicketButton_Click(object sender, EventArgs e)
        {
            NewTicket newTicket = new NewTicket(_loginform, this);
            newTicket.Show();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            LoadTickets();
            GetCategories();



        }
        public void LoadTickets()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TicketID");
            dt.Columns.Add("Subject");
            dt.Columns.Add("Description");
            dt.Columns.Add("StatusID");
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = @"SELECT * 
                 FROM `supportticket` 
                 WHERE `CustomerID` = (SELECT `CustomerID` FROM `customer` WHERE `UserID` = @UserID)";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@UserID", _loginform._userID);
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {

                        dt.Rows.Add(reader.GetInt32("TicketID").ToString(), reader.GetString("Subject"), reader.GetString("Description"), GetTicketStatusName(reader.GetInt32("StatusID").ToString()));
                    }

                }

            }
            TicketGridView.DataSource = dt;

        }
        private string GetTicketStatusName(string StatusID)
        {
            string TicketStatusName = null;
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `supportticketstatus` WHERE `StatusID` = @StatusID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@StatusID", StatusID);
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    TicketStatusName = reader.GetString("Name");
                }
            }
            return TicketStatusName;
        }
        private void GetCategories()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `productcategory`;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    ProductCategoriesDic.Add(reader.GetInt32("CategoryID").ToString(), reader.GetString("Name"));
                }
            }
            foreach (KeyValuePair<string, string> entry in ProductCategoriesDic)
            {
                ProductCategories.Items.Add(entry.Value);
            }
        }
        private void LoadProducts()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductID");

            dt.Columns.Add("Name");
            dt.Columns.Add("Description");
            dt.Columns.Add("Price");

            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `product`;";

            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query))
            {
                while (reader.Read())
                {
                    dt.Rows.Add(reader.GetString("Name"), reader.GetString("Description"), reader.GetString("Price"));
                }
            }
            ProductGridView.DataSource = dt;

        }

        private void LoadProductsByCategory()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductID");
            dt.Columns.Add("Name");
            dt.Columns.Add("Description");
            dt.Columns.Add("Price");
            dt.Columns.Add("PromotionName");
            dt.Columns.Add("PromotionDescription");
            dt.Columns.Add("PromotionDiscount");
            dt.Columns.Add("PromotionStartDate");
            dt.Columns.Add("PromotionEndDate");
            string[] productID = new string[100];
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT p.*, pp.PromotionID, prm.Name AS PromotionName, prm.Description AS PromotionDescription, prm.DiscountAmount , prm.StartDate, prm.EndDate FROM `product` p JOIN `productpromotion` pp ON p.ProductID = pp.ProductID JOIN `Promotion` prm ON pp.PromotionID = prm.PromotionID WHERE p.CategoryID = @CategoryID";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@CategoryID", ProductCategoriesDic.FirstOrDefault(x => x.Value == ProductCategories.SelectedItem.ToString()).Key);
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                if (reader != null)
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        dt.Rows.Add(productID[i] = reader.GetInt32("ProductID").ToString(), reader.GetString("Name"), reader.GetString("Description"), reader.GetString("Price"), reader.GetString("PromotionName"), reader.GetString("PromotionDescription"), reader.GetString("DiscountAmount"), reader.GetString("StartDate"), reader.GetString("EndDate"));
                        i++;
                    }
                }
            }
            string query2 = "SELECT * FROM `product` WHERE `CategoryID` = @CategoryID;";
            Dictionary<string, string> parameters2 = new Dictionary<string, string>();
            parameters2.Add("@CategoryID", ProductCategoriesDic.FirstOrDefault(x => x.Value == ProductCategories.SelectedItem.ToString()).Key);
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query2, parameters2))
            {
                if (reader != null)
                {
                    foreach (string product in productID)
                    {

                        while (reader.Read())
                            
                        {
                            if (product != reader.GetInt32("ProductID").ToString())

                            {
                                dt.Rows.Add(reader.GetInt32("ProductID").ToString(), reader.GetString("Name"), reader.GetString("Description"), reader.GetString("Price"), "", "", "", "", "");

                            }
                        }
                    }
                    }
                }


            ProductGridView.DataSource = dt;
            ProductGridView.Columns["ProductID"].Visible = false;

        }

        private void ProductCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProductsByCategory();
            ProductGridView.Columns[0].Visible = false;
        }

        private void Customer_FormClosing(object sender, FormClosingEventArgs e)
        {
            _loginform.Show();
            _loginform.ClearTextBoxes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ProductGridView.SelectedRows.Count == 1)
            {
                string ProductID = ProductGridView.SelectedRows[0].Cells[0].Value.ToString();
                ProductFeatures productFeatures = new ProductFeatures(ProductID);
                productFeatures.Show();
            }
        }

        private void ChangeProfileButton_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile(_loginform);
            profile.Show();
        }

        private void CheckSubscriptionButton_Click(object sender, EventArgs e)
        {
            Subscription subscription = new Subscription(_loginform);
            subscription.Show();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            _loginform.Show();
            _loginform.ClearTextBoxes();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProfileCustomer profile = new ProfileCustomer(_loginform);
            profile.Show();
        }

        private void ProductGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
    }

