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
    public partial class Subscription : Form
    {
        public string SubscriptionID;
        public string StartDate;
        public string EndDate;
        public string SubscriptionStatusID;
        public string PaymentMethod;
        public string SubscriptionStatus;
        public DataTable UsageGrid1 = new DataTable();
        
        public int TotalPrice;
        public DataTable FinalGrid = new DataTable();
        Form1 _loginform;
        public Subscription(Form1 loginform)
        {
            InitializeComponent();
            _loginform = loginform;
            loadsubscriptions();
            if (SubscriptionID != null)
            {

                GetPaymentMethods();

                loadsubscriptionItems();
                subscriptionStatus();
                setTotalPriceInSubscription();
                Price.Text = TotalPrice.ToString();
                GetPaymentMethod();
                PaymentCombo.SelectedIndex = PaymentCombo.FindStringExact(PaymentMethod);
                PrepeareDataGrid();

            }
            else
            {
                MessageBox.Show("No Subscription Found");
                this.Close();
            }
        }
        private void GetPaymentMethod()
        {
           SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `paymentmethod` WHERE `PaymentMethodID` = @PaymentMethodID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@PaymentMethodID", PaymentMethod);
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    PaymentMethod = reader.GetString("PaymentName");
                }
            }
        }
        private void GetPaymentMethods()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `paymentmethod`;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    PaymentCombo.Items.Add(reader.GetString("PaymentName"));
                }
            }
        }
        private void setTotalPriceInSubscription()
        {
            CycleDataTable();
            SQL sQL = new SQL(Form1.DataBaseType);

            string query = "UPDATE `subscription` SET `TotalPrice` = @TotalPrice WHERE `SubscriptionID` = @SubscriptionID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@TotalPrice", TotalPrice.ToString());
            parameters.Add("@SubscriptionID", SubscriptionID);
            sQL.ExecuteNonQueries(query, parameters);

        }
        private string getCustomerID()
        {
            string CustomerID = null;
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `customer` INNER Join `user` ON `customer`.`UserID` = `user`.`UserID` WHERE `Username` = @Username;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@Username", _loginform._username);
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    CustomerID = reader.GetInt32("CustomerID").ToString();
                }
            }
            return CustomerID;
        }
        private void loadsubscriptions()
        {
            string CustomerID = getCustomerID();    

            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `subscription` WHERE `CustomerID` = @CustomerID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@CustomerID", CustomerID);
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    SubscriptionID = reader.GetInt32("SubscriptionID").ToString();
                    StartDate = reader.GetDateTime("StartDate").ToString();
                    EndDate = reader.GetDateTime("EndDate").ToString();
                    SubscriptionStatusID = reader.GetInt32("SubscriptionStatusID").ToString();
                    PaymentMethod = reader.GetInt32("PaymentMethodID").ToString();
                }
            }
            
            

        }
        private void subscriptionStatus()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `subscriptionstatus` WHERE SubscriptionStatusID = @SubscriptionStatusID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@SubscriptionStatusID", SubscriptionID);
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    SubscriptionStatus = reader.GetString("Name");
                }
            }
        }
        private void LoadMobileUsage(string Name1,string SubscriptionItemID)
        {
            UsageGrid1 = new DataTable();
            UsageGrid1.Columns.Add("Product");
            UsageGrid1.Columns.Add("DataUsed");
            UsageGrid1.Columns.Add("VoiceMinutes");
            UsageGrid1.Columns.Add("SMSCount");


            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `mobileusagedata` WHERE `SubscriptionItemID` = @SubscriptionItemID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@SubscriptionItemID", SubscriptionItemID);
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UsageGrid1.Rows.Add(Name1,reader.GetString("DataUsed"), reader.GetString("VoiceMinutes"), reader.GetString("SMSCount"));
                    }
                }
            }
        }
        private DataTable loadsubscriptionItems()
        {
            DataTable SubscriptionItems = new DataTable();
            SubscriptionItems.Columns.Add("SubscriptionItemID");
            SubscriptionItems.Columns.Add("ProductID");
            SubscriptionItems.Columns.Add("MobilePlanID");
            SubscriptionItems.Columns.Add("InternetPlanID");
            


            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `subscriptionitem` WHERE `SubscriptionID` = @SubscriptionID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@SubscriptionID", SubscriptionID);
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        int subscriptionItemID = reader.IsDBNull(reader.GetOrdinal("SubscriptionItemID")) ? 0 : reader.GetInt32("SubscriptionItemID");
                        int productID = reader.IsDBNull(reader.GetOrdinal("ProductID")) ? 0 : reader.GetInt32("ProductID");
                        int mobilePlanID = reader.IsDBNull(reader.GetOrdinal("MobilePlanID")) ? 0 : reader.GetInt32("MobilePlanID");
                        int internetPlanID = reader.IsDBNull(reader.GetOrdinal("InternetPlanID")) ? 0 : reader.GetInt32("InternetPlanID");

                        SubscriptionItems.Rows.Add(subscriptionItemID.ToString(), productID.ToString(), mobilePlanID.ToString(), internetPlanID.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("No Subscription Items Found");
                }
            }
            return SubscriptionItems;
        }
        private void SetTotalPriceFromMobilePlan(string MobilePlanID)
        {
            string TempPrice = null;
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `mobileplanfeature` WHERE `MobilePlanFeatureID` = @MobilePlanID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@MobilePlanID", MobilePlanID);
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {

                    TempPrice = reader.GetString("Price");
                    TotalPrice += Convert.ToInt32(TempPrice);
                }
            }
        }
        private void SetTotalPriceFromInternetPlan(string InternetPlanID)
        {

            string TempPrice = null;
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `internetplanfeature` WHERE `InternetPlanFeatureID` = @InternetPlanID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@InternetPlanID", InternetPlanID);
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    TempPrice = reader.GetString("Price");
                    TotalPrice += Convert.ToInt32(TempPrice);
                }
            }
        }
        private void CycleDataTable()
        {
            DataTable SubscriptionItem = new DataTable();
            SubscriptionItem = loadsubscriptionItems();

            foreach (DataRow row in SubscriptionItem.Rows)
            {
                if (row["MobilePlanID"].ToString() != "0")
                {
                    SetTotalPriceFromMobilePlan(row["MobilePlanID"].ToString());
                }
                if (row["InternetPlanID"].ToString() != "0")
                {
                    SetTotalPriceFromInternetPlan(row["InternetPlanID"].ToString());
                }
            }
        }
        private void PrepeareDataGrid()
        {
            DataTable SubscriptionItem= new DataTable();
            SubscriptionItem = loadsubscriptionItems();
            string Name = null;
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("DataLimit");
            dt1.Columns.Add("VoiceMinutes");
            dt1.Columns.Add("SMSLimit");
            dt1.Columns.Add("Price");
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("DownloadSpeed");
            dt2.Columns.Add("UploadSpeed");
            dt2.Columns.Add("Price");
            loadsubscriptionItems();
            FinalGrid.Columns.Add("ProductName");
            
            FinalGrid.Columns.Add("DataLimit");
            FinalGrid.Columns.Add("VoiceMinutes");
            FinalGrid.Columns.Add("SMSLimit");
            FinalGrid.Columns.Add("MobilePrice");
            
            FinalGrid.Columns.Add("DownloadSpeed");
            FinalGrid.Columns.Add("UploadSpeed");
            FinalGrid.Columns.Add("InternetPrice");
            foreach (DataRow row in SubscriptionItem.Rows)
            {
                if (row["ProductID"].ToString() != "0")
                {
                    Name = (ProductFromSubscriptionItem(row["ProductID"].ToString()));
                }
                if (row["MobilePlanID"].ToString() != "0")
                {
                    LoadMobileUsage(Name,row["SubscriptionItemID"].ToString());
                    dt1 = MobilePlanFromSubscriptionItem(row["MobilePlanID"].ToString());

                    FinalGrid.Rows.Add(Name, dt1.Rows[0]["DataLimit"], dt1.Rows[0]["VoiceMinutes"], dt1.Rows[0]["SMSLimit"], dt1.Rows[0]["Price"], null, null, null);

                }
                if (row["InternetPlanID"].ToString() != "0")
                {
                    dt2 = InternetPlanFromSubscriptionItem(row["InternetPlanID"].ToString());
                       
                    FinalGrid.Rows.Add(Name, null, null, null, null, dt2.Rows[0]["DownloadSpeed"], dt2.Rows[0]["UploadSpeed"], dt2.Rows[0]["Price"]);
                }
                
            }
            subscriptiongrid.DataSource = FinalGrid;
            UsageGrid.DataSource = UsageGrid1;

        }
        private string ProductFromSubscriptionItem(String ProductID)
        {
            string Name = null;
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `product` WHERE `ProductID` = @ProductID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@ProductID", ProductID);
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    Name = reader.GetString("Name");
                }
            }
            return Name;

        }
        private DataTable MobilePlanFromSubscriptionItem(String MobilePlanID)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DataLimit");
            dt.Columns.Add("VoiceMinutes");
            dt.Columns.Add("SMSLimit");
            dt.Columns.Add("Price");
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `mobileplanfeature` WHERE `MobilePlanFeatureID` = @MobilePlanID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@MobilePlanID", MobilePlanID);
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    dt.Rows.Add(reader.GetString("DataLimit"), reader.GetString("VoiceMinutes"), reader.GetString("SMSLimit"), reader.GetString("Price"));

                }
            }
            return dt;

        }
        private DataTable InternetPlanFromSubscriptionItem(String InternetPlanID)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("DownloadSpeed");
            dataTable.Columns.Add("UploadSpeed");
            dataTable.Columns.Add("Price");
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `internetplanfeature` WHERE `InternetPlanFeatureID` = @InternetPlanID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@InternetPlanID", InternetPlanID);
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {

                    dataTable.Rows.Add( reader.GetString("DownloadSpeed"), reader.GetString("UploadSpeed"), reader.GetString("Price"));

                }
            }
            return dataTable;

        }

        private void PaymentButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemented");
        }
    }



}
