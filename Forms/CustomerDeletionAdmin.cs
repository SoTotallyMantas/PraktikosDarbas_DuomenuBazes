using MobilusOperatorius.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobilusOperatorius.Forms
{
    public partial class CustomerDeletionAdmin : Form
    {
        public CustomerDeletionAdmin()
        {
            InitializeComponent();
            LoadCustomer();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadCustomer();

        }
        private void LoadCustomer()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("CustomerID");
            dataTable.Columns[0].ReadOnly = true;
            dataTable.Columns.Add("FirstName");
            dataTable.Columns.Add("LastName");
            dataTable.Columns.Add("Email");
            dataTable.Columns.Add("PhoneNumber");
            dataTable.Columns.Add("UserID");

            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `customer`;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    dataTable.Rows.Add(reader.GetInt32("CustomerID").ToString(), reader.GetString("FirstName"), reader.GetString("LastName"), reader.GetString("Email"), reader.GetString("PhoneNumber"), reader.GetInt32("UserID").ToString());

                }
            }
            PlanGrid.DataSource = dataTable;
        }



        private void DeleteBillingAddress(string BillingID)
        {
            try
            {
                SQL sQL = new SQL(Form1.DataBaseType);
                string query2 = "SELECT * FROM `billingaddress` WHERE `BillingInformationID` = @BillingInformationID;";
                Dictionary<string, string> parameters2 = new Dictionary<string, string>();
                parameters2.Add("@BillingInformationID", BillingID);
                using (MySql.Data.MySqlClient.MySqlDataReader reader2 = sQL.DataReader(query2, parameters2))
                {
                   if(reader2!=null)
                    {
                        string query = "DELETE FROM `billingaddress` WHERE `BillingInformationID` = @BillingInformationID;";
                        Dictionary<string, string> parameters = new Dictionary<string, string>();
                        parameters.Add("@BillingInformationID", BillingID);
                        sQL.ExecuteNonQueries(query, parameters);
                        parameters.Clear();

                    }
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DeleteCustomerBillinginformation(string BillingID)
        {
            try
            {
                SQL sQL = new SQL(Form1.DataBaseType);
                string query = "DELETE FROM `billinginformation` WHERE `BillingID` = @BillingID;";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("@BillingID", BillingID);
                sQL.ExecuteNonQueries(query, parameters);
                parameters.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void DeleteCustomerAddress(string CustomerID)
        {
            try
            {
                SQL sQL = new SQL(Form1.DataBaseType);
                string query = "DELETE FROM `address` WHERE `CustomerID` = @CustomerID;";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("@CustomerID", CustomerID);
                sQL.ExecuteNonQueries(query, parameters);
                parameters.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void DeleteSupportTicket(string ticket)
        {
            try
            {
                SQL sQL = new SQL(Form1.DataBaseType);
                string query = "DELETE FROM `supportticket` WHERE `TicketID` = @TicketID;";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("@TicketID", ticket);
                sQL.ExecuteNonQueries(query, parameters);
                parameters.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void Deletesupportticketassignments(string TicketID)
        {
            try
            {
                SQL sQL = new SQL(Form1.DataBaseType);
                string query = "DELETE FROM `supportticketassignment` WHERE `TicketID` = @TicketID;";
                Dictionary<string, string> parameters = new Dictionary<string, string>();


                parameters.Add("@TicketID", TicketID);
                sQL.ExecuteNonQueries(query, parameters);
                parameters.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }
        


        private void DeleteSubscription(string SubscriptionID)
        {
            try
            {
                SQL sQL = new SQL(Form1.DataBaseType);
                string query = "DELETE FROM `subscription` WHERE `SubscriptionID` = @SubscriptionID;";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("@SubscriptionID", SubscriptionID);
                sQL.ExecuteNonQueries(query, parameters);
                parameters.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void DeleteMobileUsageData(string SubscriptionItemID)
        {
            try
            {
                

                SQL sQL = new SQL(Form1.DataBaseType);
                string query2 = "SELECT * FROM `mobileusagedata` WHERE `SubscriptionItemID` = @SubscriptionItemID;";
                Dictionary<string, string> parameters2 = new Dictionary<string, string>();
                parameters2.Add("@SubscriptionItemID", SubscriptionItemID);
                using (MySql.Data.MySqlClient.MySqlDataReader reader2 = sQL.DataReader(query2, parameters2))
                {
                    if (reader2 != null)
                    {
                        reader2.Close();
                        string query = "DELETE FROM `mobileusagedata` WHERE `SubscriptionItemID` = @SubscriptionItemID;";
                        Dictionary<string, string> parameters = new Dictionary<string, string>();
                        parameters.Add("@SubscriptionItemID", SubscriptionItemID);
                        sQL.ExecuteNonQueries(query, parameters);
                        parameters.Clear();

                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void DeleteCustomerSubscriptionItems(string SubscriptionID)
        {
            try
            {
                SQL sQL = new SQL(Form1.DataBaseType);
                string query2 = "SELECT * FROM `subscriptionitem` WHERE `SubscriptionID` = @SubscriptionID;";
                Dictionary<string, string> parameters2 = new Dictionary<string, string>();
                parameters2.Add("@SubscriptionID", SubscriptionID);
                using (MySql.Data.MySqlClient.MySqlDataReader reader2 = sQL.DataReader(query2, parameters2))
                {
                    if (reader2 != null)
                    {
                        reader2.Close();
                        string query = "DELETE FROM `subscriptionitem` WHERE `SubscriptionID` = @SubscriptionID;";
                        Dictionary<string, string> parameters = new Dictionary<string, string>();
                        parameters.Add("@SubscriptionID", SubscriptionID);
                        sQL.ExecuteNonQueries(query, parameters);
                        parameters.Clear();

                    }
                    
                    
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void DeleteCustomer(string CustomerID)
        {
            try
            {
                SQL sQL = new SQL(Form1.DataBaseType);
                string query = "DELETE FROM `customer` WHERE `CustomerID` = @CustomerID;";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("@CustomerID", CustomerID);
                sQL.ExecuteNonQueries(query, parameters);
                parameters.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DeleteCustomerUser(string UserID)
        {
            try
            {
                SQL sQL = new SQL(Form1.DataBaseType);
                string query = "DELETE FROM `user` WHERE `UserID` = @UserID;";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("@UserID", UserID);
                sQL.ExecuteNonQueries(query, parameters);
                parameters.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }



        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (PlanGrid.SelectedRows.Count > 0)
            {
                string userID;
                string customerID;
                string BillingID;
                string[] TicketID = new string[100];
                string subscriptionID;
                foreach (DataGridViewRow row in PlanGrid.SelectedRows)
                {
                    customerID = row.Cells["CustomerID"].Value.ToString();
                    userID = row.Cells["UserID"].Value.ToString();
                   

                    BillingID = GetCustomerBillingInformation(customerID);
                    // Delete Billing
                    if (BillingID != null)
                    {
                        DeleteBillingAddress(BillingID);
                        DeleteCustomerBillinginformation(customerID);
                        
                    }
                    // Delete Address
                    DeleteCustomerAddress(customerID);
                    // Delete Support Ticket
                     TicketID = GetCustomerSupportTickets(customerID);
                    foreach(string ticket in TicketID)
                    {
                        if (ticket != null)
                        {
                            Deletesupportticketassignments(ticket);
                            DeleteSupportTicket(ticket);
                        }
                    }
                    
                    
                   // GetSubscriptionItems
                   subscriptionID= GetCustomerSubscription(customerID);
                   
                    if(subscriptionID!=null)
                    {
                       
                        // Delete Subscription Mobile Usage Data
                        foreach (string item in GetSubscriptionItems(subscriptionID))
                        {
                            if (item != null)
                            {
                                DeleteMobileUsageData(item);
                            }
                        }
                        // Delete Subscription Items
                        DeleteCustomerSubscriptionItems(subscriptionID);
                        // Delete Subscription
                        DeleteSubscription(subscriptionID);
                    }
                    
                    DeleteCustomer(customerID);
                    // Delete User Table Entry
                    if (userID != null)
                    {
                        DeleteCustomerUser(userID);
                    }

                }
                LoadCustomer();
            }
            else
            {
                MessageBox.Show("Please select a row to delete");
            }

        }
        private string GetCustomerSubscription(string CustomerID)
        {

            string subscriptionID = null;

            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `subscription` WHERE `CustomerID` = @CustomerID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@CustomerID", CustomerID);
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    subscriptionID = reader.GetInt32("SubscriptionID").ToString();

                }
            }
            return subscriptionID;
        }


        private string[] GetSubscriptionItems(string SubscriptionID)
        {

            SQL sQL = new SQL(Form1.DataBaseType);
            string[] SubscriptionItemID = new string[100];
            string query = "SELECT * FROM `subscriptionitem` WHERE `SubscriptionID` = @SubscriptionID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@SubscriptionID", SubscriptionID);
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                int i = 0;
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        SubscriptionItemID[i] = reader.GetInt32("SubscriptionItemID").ToString();
                        i++;
                    }
                }
            }
            return SubscriptionItemID;
        }


        private string[] GetCustomerSupportTickets(string CustomerID)
        {
            

                string[] TicketID = new string[100];
                SQL sQL = new SQL(Form1.DataBaseType);
                string query = "SELECT * FROM `supportticket` WHERE `CustomerID` = @CustomerID;";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("@CustomerID", CustomerID);
                using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        TicketID[i] = reader.GetInt32("TicketID").ToString();
                        i++;
                       

                    }
                }
                return TicketID;
                
            
        }
        private string GetCustomerBillingInformation(string CustomerID)
        {
            string BillingID = null ;
                SQL sQL = new SQL(Form1.DataBaseType);
                string query = "SELECT * FROM `billinginformation` WHERE `CustomerID` = @CustomerID;";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("@CustomerID", CustomerID);
                using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
                {
                    while (reader.Read())
                    {
                        BillingID = reader.GetInt32("BillingID").ToString();
                    }
                }
                
            
            return BillingID;
        }


    }
}

