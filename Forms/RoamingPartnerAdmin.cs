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
    public partial class RoamingPartnerAdmin : Form
    {
        public bool ClearedGrid = false;
        public RoamingPartnerAdmin()
        {
            InitializeComponent();
            loadRoamingpartners();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ClearedGrid == false)
            {
                updateroamingpartners();
                loadRoamingpartners();
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
                InsertRoamingPartners();
                loadRoamingpartners();
                ClearedGrid = false;
            }
            else
            {
                MessageBox.Show("Clear Grid");
            }

        }
        private void InsertRoamingPartners()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "INSERT INTO `roamingpartner` (`Name`, `Country`) VALUES (@Name, @Country);";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataGridViewRow row in PartnersGrid.Rows)
            {
                
                if (row.Cells["Name"].Value != null && row.Cells["Country"].Value != null)
                {
                    parameters.Add("@Name", row.Cells["Name"].Value.ToString());
                    parameters.Add("@Country", row.Cells["Country"].Value.ToString());
                    sQL.ExecuteNonQueries(query, parameters);
                    parameters.Clear();
                }
                
            }
        }
        private void DeleteRoamingPartners()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "DELETE FROM `roamingpartner` WHERE `PartnerID` = @PartnerID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataGridViewRow row in PartnersGrid.SelectedRows)
            {
                if (row.Cells["PartnerID"].Value != null)
                {
                    parameters.Add("@PartnerID", row.Cells["PartnerID"].Value.ToString());
                    sQL.ExecuteNonQueries(query, parameters);
                    parameters.Clear();
                }
            }

        }
        private void updateroamingpartners()
        {
            SQL sQl = new SQL(Form1.DataBaseType);
            string query = "UPDATE `roamingpartner` SET `Name` = @Name, `Country` = @Country WHERE `PartnerID` = @PartnerID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (DataGridViewRow row in PartnersGrid.Rows)
            {
                if (row.Cells["PartnerID"].Value != null && row.Cells["Name"].Value != null && row.Cells["Country"].Value != null)
                {


                    parameters.Add("@PartnerID", row.Cells["PartnerID"].Value.ToString());
                    parameters.Add("@Name", row.Cells["Name"].Value.ToString());
                    parameters.Add("@Country", row.Cells["Country"].Value.ToString());
                    sQl.ExecuteNonQueries(query, parameters);
                    parameters.Clear();
                }
                }


            }
        private void loadRoamingpartners()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("PartnerID");
            dataTable.Columns[0].ReadOnly = true;
            dataTable.Columns.Add("Name");

            dataTable.Columns.Add("Country");

            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `roamingpartner`;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    dataTable.Rows.Add(reader.GetInt32("PartnerID").ToString(), reader.GetString("Name"), reader.GetString("Country"));
                }
            }
            PartnersGrid.DataSource = dataTable;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (ClearedGrid == false)
            {
                DeleteRoamingPartners();
                loadRoamingpartners();
            }
            else
            {
                MessageBox.Show("Refresh Grid");
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Country");
            PartnersGrid.DataSource = dataTable;
            ClearedGrid = true;

        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            ClearedGrid = false;
            loadRoamingpartners();

        }
    }
}
