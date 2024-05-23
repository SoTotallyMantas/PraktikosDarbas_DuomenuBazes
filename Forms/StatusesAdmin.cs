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
    public partial class StatusesAdmin : Form
    {
        public bool Cleare = false;
        public StatusesAdmin()
        {
            InitializeComponent();
        }
        private void loadsupporTicketStatus()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("StatusID");
            dataTable.Columns[0].ReadOnly = true;
            dataTable.Columns.Add("Name");
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `supportticketstatus`;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    dataTable.Rows.Add(reader.GetInt32("StatusID").ToString(), reader.GetString("Name"));
                }
            }
            DataGrid.DataSource = dataTable;
        }
        private void loadPaymentMethods()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("PaymentMethodID");
            dataTable.Columns[0].ReadOnly = true;
            dataTable.Columns.Add("PaymentName");
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `paymentmethod`;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    dataTable.Rows.Add(reader.GetInt32("PaymentMethodID").ToString(), reader.GetString("PaymentName"));
                }
            }
            DataGrid.DataSource = dataTable;
        }
        private void loadSubscriptionStatus()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("SubscriptionStatusID");
            dataTable.Columns[0].ReadOnly = true;
            dataTable.Columns.Add("Name");

            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `subscriptionstatus`;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    dataTable.Rows.Add(reader.GetInt32("SubscriptionStatusID").ToString(), reader.GetString("Name"));
                }
            }
            DataGrid.DataSource = dataTable;

        }
        private void DeleteSubscriptionStatus()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "DELETE FROM `subscriptionstatus` WHERE `SubscriptionStatusID` = @SubscriptionStatusID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (DataGrid.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in DataGrid.SelectedRows)
                {
                    if (row.Cells["SubscriptionStatusID"].Value != null)
                    {
                        parameters.Add("@SubscriptionStatusID", row.Cells["SubscriptionStatusID"].Value.ToString());
                        sQL.ExecuteNonQueries(query, parameters);
                        parameters.Clear();
                    }

                }
            }
            else
            {
                MessageBox.Show("Select Row");
            }
        }
        private void DeletePaymentMethod()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "DELETE FROM `paymentmethod` WHERE `PaymentMethodID` = @PaymentMethodID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (DataGrid.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in DataGrid.SelectedRows)
                {
                    if (row.Cells["PaymentMethodID"].Value != null)
                    {

                        parameters.Add("@PaymentMethodID", row.Cells["PaymentMethodID"].Value.ToString());
                        sQL.ExecuteNonQueries(query, parameters);
                        parameters.Clear();
                    }

                }
            }
            else
            {
                MessageBox.Show("Select Row");
            }

        }
        private void DeleteSupportTicketStatus()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "DELETE FROM `supportticketstatus` WHERE `StatusID` = @StatusID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (DataGrid.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in DataGrid.SelectedRows)
                {
                    if (row.Cells["StatusID"].Value != null)
                    {
                        parameters.Add("@StatusID", row.Cells["StatusID"].Value.ToString());
                        sQL.ExecuteNonQueries(query, parameters);
                        parameters.Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show("Select Row");
            }
        }
        private void DeleteButton_Click_1(object sender, EventArgs e)
        {
            if (Cleare == false)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:

                        DeleteSubscriptionStatus();
                        loadSubscriptionStatus();
                        break;
                    case 1:
                        DeletePaymentMethod();
                        loadPaymentMethods();
                        break;
                    case 2:
                        DeleteSupportTicketStatus();
                        loadsupporTicketStatus();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Refresh Grid");
            }
        }
        private void AddSubscriptionStatus()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "INSERT INTO `subscriptionstatus` (`Name`) VALUES (@Name);";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataGridViewRow row in DataGrid.Rows)
            {
                if (row.Cells["Name"].Value != null)
                {
                    parameters.Add("@Name", row.Cells["Name"].Value.ToString());
                    sQL.ExecuteNonQueries(query, parameters);
                    parameters.Clear();
                }
            }
        }
        private void AddPaymentMethod()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "INSERT INTO `paymentmethod` (`PaymentName`) VALUES (@PaymentName);";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataGridViewRow row in DataGrid.Rows)
            {
                if (row.Cells["PaymentName"].Value != null)
                {
                    parameters.Add("@PaymentName", row.Cells["PaymentName"].Value.ToString());
                    sQL.ExecuteNonQueries(query, parameters);
                    parameters.Clear();
                }

            }
        }
        private void AddSupportTicketStatus()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "INSERT INTO `supportticketstatus` (`Name`) VALUES (@Name);";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataGridViewRow row in DataGrid.Rows)
            {
                if (row.Cells["Name"].Value != null)
                {
                    parameters.Add("@Name", row.Cells["Name"].Value.ToString());
                    sQL.ExecuteNonQueries(query, parameters);
                    parameters.Clear();
                }

            }
        }
        private void AddButton_Click_1(object sender, EventArgs e)
        {
            if (Cleare == true)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        AddSubscriptionStatus();
                        loadSubscriptionStatus();

                        break;
                    case 1:
                        AddPaymentMethod();
                        loadPaymentMethods();
                        break;
                    case 2:
                        AddSupportTicketStatus();
                        loadsupporTicketStatus();
                        break;
                }
                Cleare = false;
            }
            else
            {
                MessageBox.Show("Clear Grid");
            }
        }
        private void UpdateSubscriptionStatus()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "UPDATE `subscriptionstatus` SET `Name` = @Name WHERE `SubscriptionStatusID` = @SubscriptionStatusID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataGridViewRow row in DataGrid.Rows)
            {
                if (row.Cells["SubscriptionStatusID"].Value != null && row.Cells["Name"].Value != null)
                {

                    parameters.Add("@Name", row.Cells["Name"].Value.ToString());
                    parameters.Add("@SubscriptionStatusID", row.Cells["SubscriptionStatusID"].Value.ToString());
                    sQL.ExecuteNonQueries(query, parameters);
                    parameters.Clear();
                }
            }
        }
        private void UpdatePaymentMethod()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "UPDATE `paymentmethod` SET `PaymentName` = @PaymentName WHERE `PaymentMethodID` = @PaymentMethodID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataGridViewRow row in DataGrid.Rows)
            {
                if (row.Cells["PaymentName"].Value != null && row.Cells["PaymentMethodID"].Value != null)
                {

                    parameters.Add("@PaymentName", row.Cells["PaymentName"].Value.ToString());
                    parameters.Add("@PaymentMethodID", row.Cells["PaymentMethodID"].Value.ToString());
                    sQL.ExecuteNonQueries(query, parameters);
                    parameters.Clear();
                }
            }
        }
        private void UpdateSupportTicketStatus()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "UPDATE `supportticketstatus` SET `Name` = @Name WHERE `StatusID` = @StatusID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataGridViewRow row in DataGrid.Rows)
            {
                if (row.Cells["Name"].Value != null && row.Cells["StatusID"].Value != null)
                {
                    parameters.Add("@Name", row.Cells["Name"].Value.ToString());
                    parameters.Add("@StatusID", row.Cells["StatusID"].Value.ToString());
                    sQL.ExecuteNonQueries(query, parameters);
                    parameters.Clear();
                }
            }
        }
        private void UpdateButton_Click_1(object sender, EventArgs e)
        {
            if (Cleare == false)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        UpdateSubscriptionStatus();
                        loadSubscriptionStatus();
                        break;
                    case 1:
                        UpdatePaymentMethod();
                        loadPaymentMethods();
                        break;
                    case 2:
                        UpdateSupportTicketStatus();
                        loadsupporTicketStatus();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Refresh Grid");
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    if (Cleare == false)
                    {
                        loadSubscriptionStatus();
                    }
                    else
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Columns.Add("Name");
                        DataGrid.DataSource = dataTable;

                    }

                    break;
                case 1:
                    if (Cleare == false)
                    {
                        loadPaymentMethods();
                    }
                    else
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Columns.Add("PaymentName");
                        DataGrid.DataSource = dataTable;

                    }
                    break;
                case 2:
                    if (Cleare == false)
                    {
                        loadsupporTicketStatus();
                    }
                    else
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Columns.Add("Name");
                        DataGrid.DataSource = dataTable;

                    }

                    break;
            }
        }



        private void ClearButton_Click_1(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:


                    DataTable dataTable1 = new DataTable();
                    dataTable1.Columns.Add("Name");
                    DataGrid.DataSource = dataTable1;
                    Cleare = true;

                    break;
                case 1:


                    DataTable dataTable2 = new DataTable();
                    dataTable2.Columns.Add("PaymentName");
                    DataGrid.DataSource = dataTable2;
                    Cleare = true;

                    break;
                case 2:

                    DataTable dataTable3 = new DataTable();
                    dataTable3.Columns.Add("Name");
                    DataGrid.DataSource = dataTable3;

                    Cleare = true;

                    break;
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                   
                        loadSubscriptionStatus();
                    
                 

                    break;
                case 1:
                    
                        loadPaymentMethods();
                    
                    
                    break;
                case 2:
                    
                        loadsupporTicketStatus();
                    
                   

                    break;
            }
        }
    }
}
