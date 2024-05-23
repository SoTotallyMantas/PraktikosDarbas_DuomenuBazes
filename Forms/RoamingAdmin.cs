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


    public partial class RoamingAdmin : Form
    {
        public bool ClearedGrid = false;
        public RoamingAdmin()
        {
            InitializeComponent();
            LoadRoamingPartner();
            LoadMobilePlan();
            LoadRoamingAgreements();

        }
        private void LoadMobilePlan()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("MobilePlanFeatureID");
            dataTable.Columns[0].ReadOnly = true;
            dataTable.Columns.Add("DataLimit");
            dataTable.Columns[1].ReadOnly = true;
            dataTable.Columns.Add("VoiceMinutes");
            dataTable.Columns[2].ReadOnly = true;
            dataTable.Columns.Add("SMSLimit");
            dataTable.Columns[3].ReadOnly = true;
            dataTable.Columns.Add("Price");
            dataTable.Columns[4].ReadOnly = true;

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

            MobilePlanGrid.DataSource = dataTable;



        }
        private void LoadRoamingAgreements()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("AgreementID");
            dataTable.Columns[0].ReadOnly = true;
            dataTable.Columns.Add("PartnerID");
            dataTable.Columns.Add("MobilePlanID");
            dataTable.Columns.Add("StartDate");
            dataTable.Columns.Add("EndDate");
            dataTable.Columns.Add("DataAllowance");

            dataTable.Columns.Add("AdditionalCharges");





            SQL sql = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `roamingagreement`";


            using (MySql.Data.MySqlClient.MySqlDataReader reader = sql.DataReader(query))
            {
                while (reader.Read())
                {
                    dataTable.Rows.Add(reader.GetInt32("AgreementID").ToString(), reader.GetInt32("PartnerID").ToString(), reader.GetInt32("MobilePlanID").ToString(), reader.GetString("StartDate"), reader.GetString("EndDate"), reader.GetString("DataAllowance"), reader.GetString("AdditionalCharges"));

                }

            }
            RoamingAgreementGrid.DataSource = dataTable;
        }
        private void LoadRoamingPartner()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns[0].ReadOnly = true;
            dataTable.Columns.Add("Name");
            dataTable.Columns[1].ReadOnly = true;
            dataTable.Columns.Add("Country");
            dataTable.Columns[2].ReadOnly = true;

            SQL sql = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `roamingpartner`";


            using (MySql.Data.MySqlClient.MySqlDataReader reader = sql.DataReader(query))
            {
                while (reader.Read())
                {
                    dataTable.Rows.Add(reader.GetInt32("PartnerID"), reader.GetString("Name"), reader.GetString("Country"));

                }

            }
            RoamingPartnersGrid.DataSource = dataTable;


        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            ClearedGrid = false;
            LoadRoamingAgreements();
        }


        private void ClearButton_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("PartnerID");
            dataTable.Columns.Add("MobilePlanID");
            dataTable.Columns.Add("StartDate");
            dataTable.Columns.Add("EndDate");
            dataTable.Columns.Add("DataAllowance");
            dataTable.Columns.Add("AdditionalCharges");
            RoamingAgreementGrid.DataSource = dataTable;
            ClearedGrid = true;

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(ClearedGrid == false)
            {
                SaveChangesToDB();
                LoadRoamingAgreements();
            }
            else
            {
                MessageBox.Show("Refresh Grid");
            }
            
        }
        private void SaveChangesToDB()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "UPDATE `roamingagreement` SET `PartnerID` = @PartnerID, `MobilePlanID` = @MobilePlanID, `StartDate` = @StartDate, `EndDate` = @EndDate, `DataAllowance` = @DataAllowance, `AdditionalCharges` = @AdditionalCharges WHERE `AgreementID` = @AgreementID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataGridViewRow row in RoamingAgreementGrid.Rows)
            {
                foreach(DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null)
                    {
                        
                        return;
                    }
                }
                parameters.Clear();
                parameters.Add("@AgreementID", row.Cells["AgreementID"].Value.ToString());
                parameters.Add("@PartnerID", row.Cells["PartnerID"].Value.ToString());
                parameters.Add("@MobilePlanID", row.Cells["MobilePlanID"].Value.ToString());
                parameters.Add("@StartDate", row.Cells["StartDate"].Value.ToString());
                parameters.Add("@EndDate", row.Cells["EndDate"].Value.ToString());
                parameters.Add("@DataAllowance", row.Cells["DataAllowance"].Value.ToString());
                parameters.Add("@AdditionalCharges", row.Cells["AdditionalCharges"].Value.ToString());
                
                sQL.ExecuteNonQueries(query, parameters);
            }



        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (ClearedGrid == false)
            {
                DeleteSelection();
                LoadRoamingAgreements();

                ClearedGrid = false;
            }
            else
            {
                MessageBox.Show("Refresh Grid");
            }
        }
        private void DeleteSelection()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "DELETE FROM `roamingagreement` WHERE `AgreementID` = @AgreementID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if(RoamingAgreementGrid.SelectedRows.Count <0)
            {
                MessageBox.Show("Select a row to delete");
                return;
            }
            foreach (DataGridViewRow row in RoamingAgreementGrid.SelectedRows)
            {
                parameters.Clear();
                parameters.Add("@AgreementID", row.Cells["AgreementID"].Value.ToString());
                sQL.ExecuteNonQueries(query, parameters);
            }

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (ClearedGrid == true)
            {
                AddNewAgreement();
                LoadRoamingAgreements();
                ClearedGrid = false;
            }
            else
            {
                MessageBox.Show("Clear Grid");
            }
        }
        private void AddNewAgreement()
        {
            SQL sQL     = new SQL(Form1.DataBaseType);
            string query = "INSERT INTO `roamingagreement` (`PartnerID`, `MobilePlanID`, `StartDate`, `EndDate`, `DataAllowance`, `AdditionalCharges`) VALUES (@PartnerID, @MobilePlanID, @StartDate, @EndDate, @DataAllowance, @AdditionalCharges);";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
           
            foreach (DataGridViewRow row in RoamingAgreementGrid.Rows)
            {
                foreach( DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null)
                    {
                        
                        return;
                    }
                }
                parameters.Add("@PartnerID", row.Cells["PartnerID"].Value.ToString());
                parameters.Add("@MobilePlanID", row.Cells["MobilePlanID"].Value.ToString());
                parameters.Add("@StartDate", row.Cells["StartDate"].Value.ToString());
                parameters.Add("@EndDate", row.Cells["EndDate"].Value.ToString());
                parameters.Add("@DataAllowance", row.Cells["DataAllowance"].Value.ToString());
                parameters.Add("@AdditionalCharges", row.Cells["AdditionalCharges"].Value.ToString());
                sQL.ExecuteNonQueries(query, parameters);
            }
           

            

        }
    }
}
