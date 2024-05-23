using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class PlansAdmin : Form
    {
        public bool ClearedGrid = false;
        public PlansAdmin()
        {
            InitializeComponent();
        }
        private void SaveMobilePlan()
        {


            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "UPDATE `mobileplanfeature` SET `DataLimit` = @DataLimit, `VoiceMinutes` = @VoiceMinutes, `SMSLimit` = @SMSLimit, `Price` = @Price WHERE `MobilePlanFeatureID` = @MobilePlanFeatureID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                foreach (DataGridViewRow row in PlanGrid.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[1].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null && row.Cells[4].Value != null)
                    {
                        parameters.Clear();
                        parameters.Add("@MobilePlanFeatureID", row.Cells["MobilePlanFeatureID"].Value.ToString());
                        parameters.Add("@DataLimit", row.Cells["DataLimit"].Value.ToString());
                        parameters.Add("@VoiceMinutes", row.Cells["VoiceMinutes"].Value.ToString());
                        parameters.Add("@SMSLimit", row.Cells["SMSLimit"].Value.ToString());
                        parameters.Add("@Price", row.Cells["Price"].Value.ToString());

                        sQL.ExecuteNonQueries(query, parameters);
                    }
                    else
                    {
                        MessageBox.Show("Please fill all the fields");
                    }
                }

            }
        }
        private void SaveInternetPlan()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "UPDATE `internetplanfeature` SET `DownloadSpeed` = @DownloadSpeed, `UploadSpeed` = @UploadSpeed, `Price` = @Price WHERE `InternetPlanFeatureID` = @InternetPlanFeatureID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                foreach (DataGridViewRow row in PlanGrid.Rows)
                {
                    
                    if (row.Cells[0].Value != null && row.Cells[1].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null)
                    {
                        parameters.Clear();
                        parameters.Add("@InternetPlanFeatureID", row.Cells["InternetPlanFeatureID"].Value.ToString());
                        parameters.Add("@DownloadSpeed", row.Cells["DownloadSpeed"].Value.ToString());
                        parameters.Add("@UploadSpeed", row.Cells["UploadSpeed"].Value.ToString());
                        parameters.Add("@Price", row.Cells["Price"].Value.ToString());
                        sQL.ExecuteNonQueries(query, parameters);
                    }
                    else
                    {
                        MessageBox.Show("Please fill all the fields");
                    }
                }

            }

        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            ClearedGrid = false;
            if (comboBox1.SelectedItem == "MobilePlan")
            {
                GetMobilePlan();

            }
            else if (comboBox1.SelectedItem == "InternetPlan")
            {
                GetInternetPlan();
            }

        }
        private void GetMobilePlan()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("MobilePlanFeatureID");
            dataTable.Columns[0].ReadOnly = true;
            dataTable.Columns.Add("DataLimit");
            dataTable.Columns.Add("VoiceMinutes");
            dataTable.Columns.Add("SMSLimit");
            dataTable.Columns.Add("Price");

            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `mobileplanfeature`;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {

                while (reader.Read())
                {
                    dataTable.Rows.Add(reader.GetInt32("MobilePlanFeatureID").ToString(), reader.GetString("DataLimit"), reader.GetString("VoiceMinutes"), reader.GetString("SMSLimit"), reader.GetString("Price"));


                }
            }

            PlanGrid.DataSource = dataTable;



        }
        private void GetInternetPlan()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("InternetPlanFeatureID");
            dataTable.Columns[0].ReadOnly = true;
            dataTable.Columns.Add("DownloadSpeed");
            dataTable.Columns.Add("UploadSpeed");
            dataTable.Columns.Add("Price");

            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `internetplanfeature`;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {

                while (reader.Read())
                {
                    dataTable.Rows.Add(reader.GetInt32("InternetPlanFeatureID").ToString(), reader.GetString("DownloadSpeed"), reader.GetString("UploadSpeed"), reader.GetString("Price"));
                }
            }
            PlanGrid.DataSource = dataTable;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearedGrid = false;
            if (comboBox1.SelectedItem == "MobilePlan")
            {
                GetMobilePlan();

            }
            else if (comboBox1.SelectedItem == "InternetPlan")
            {
                GetInternetPlan();
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearedGrid = true;
            if (comboBox1.SelectedItem == "MobilePlan")
            {
                DataTable dataTable = new DataTable();


                dataTable.Columns.Add("DataLimit");
                dataTable.Columns.Add("VoiceMinutes");
                dataTable.Columns.Add("SMSLimit");
                dataTable.Columns.Add("Price");
                PlanGrid.DataSource = dataTable;

            }
            else if (comboBox1.SelectedItem == "InternetPlan")
            {
                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("DownloadSpeed");
                dataTable.Columns.Add("UploadSpeed");
                dataTable.Columns.Add("Price");
                PlanGrid.DataSource = dataTable;

            }

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "MobilePlan")
            {

                SaveMobilePlan();

                GetMobilePlan();

            }
            else if (comboBox1.SelectedItem == "InternetPlan")
            {
                SaveInternetPlan();
                GetInternetPlan();

            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "MobilePlan")
            {
                DeleteSelectedMobilePlan();
                GetMobilePlan();
            }
            else if (comboBox1.SelectedItem == "InternetPlan")
            {
                DeleteSelectedInternetPlan();
                GetInternetPlan();
            }
        }
        private void DeleteSelectedMobilePlan()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "DELETE FROM `mobileplanfeature` WHERE `MobilePlanFeatureID` = @MobilePlanFeatureID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                foreach (DataGridViewRow row in PlanGrid.SelectedRows)
                {
                    if (row.Cells["MobilePlanFeatureID"].Value != null)
                    {
                        parameters.Clear();
                        parameters.Add("@MobilePlanFeatureID", row.Cells["MobilePlanFeatureID"].Value.ToString());
                        sQL.ExecuteNonQueries(query, parameters);
                    }
                }

            }

        }
        private void DeleteSelectedInternetPlan()
        {

            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "DELETE FROM `internetplanfeature` WHERE `InternetPlanFeatureID` = @InternetPlanFeatureID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                foreach (DataGridViewRow row in PlanGrid.SelectedRows)
                {
                    if (row.Cells["InternetPlanFeatureID"].Value != null)
                    {
                        parameters.Clear();
                        parameters.Add("@InternetPlanFeatureID", row.Cells["InternetPlanFeatureID"].Value.ToString());
                        sQL.ExecuteNonQueries(query, parameters);
                    }
                }

            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (ClearedGrid == true)
            {
                if (comboBox1.SelectedItem == "MobilePlan")
                {
                    AddMobilePlan();
                   GetMobilePlan();
                }
                else if (comboBox1.SelectedItem == "InternetPlan")
                {
                    AddInternetPlan();
                   GetInternetPlan();
                }
            } else
            {
                   MessageBox.Show("Please clear the grid before adding new plans");
            }

        }
        private void AddMobilePlan()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "INSERT INTO `mobileplanfeature` (`DataLimit`, `VoiceMinutes`, `SMSLimit`, `Price`) VALUES (@DataLimit, @VoiceMinutes, @SMSLimit, @Price);";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                foreach (DataGridViewRow row in PlanGrid.Rows)
                {
                    if (row.Cells["DataLimit"].Value != null && row.Cells["VoiceMinutes"].Value != null && row.Cells["SMSLimit"].Value != null && row.Cells["Price"].Value != null)
                    {
                        parameters.Clear();
                        parameters.Add("@DataLimit", row.Cells["DataLimit"].Value.ToString());
                        parameters.Add("@VoiceMinutes", row.Cells["VoiceMinutes"].Value.ToString());
                        parameters.Add("@SMSLimit", row.Cells["SMSLimit"].Value.ToString());
                        parameters.Add("@Price", row.Cells["Price"].Value.ToString());
                        sQL.ExecuteNonQueries(query, parameters);
                        
                    }
                    else
                    {
                        MessageBox.Show("Please fill all the fields");
                    }
                }

            }
        }
        private void AddInternetPlan()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "INSERT INTO `internetplanfeature` (`DownloadSpeed`, `UploadSpeed`, `Price`) VALUES (@DownloadSpeed, @UploadSpeed, @Price);";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                foreach (DataGridViewRow row in PlanGrid.Rows)
                {
                    if (row.Cells["DownloadSpeed"].Value != null && row.Cells["UploadSpeed"].Value !=null && row.Cells["Price"].Value !=null)
                    {
                        parameters.Clear();
                        parameters.Add("@DownloadSpeed", row.Cells["DownloadSpeed"].Value.ToString());
                        parameters.Add("@UploadSpeed", row.Cells["UploadSpeed"].Value.ToString());
                        parameters.Add("@Price", row.Cells["Price"].Value.ToString());
                        sQL.ExecuteNonQueries(query, parameters);
                    }
                }

            }

        }

        private void OpenRoamingButton_Click(object sender, EventArgs e)
        {

            RoamingAdmin roamingAdmin = new RoamingAdmin();
            roamingAdmin.Show();
        }
    }
}
