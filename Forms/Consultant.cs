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
    public partial class Consultant : Form
    {
        Form1 _loginform;
        public Consultant(Form1 loginform)
        {
            InitializeComponent();
            _loginform = loginform;
            getSupportTicketStatus();
            GetAvailableTickets();
            GetAssignedTickets();

        }
        Dictionary<string, string> TicketStatus = new Dictionary<string, string>();
        private void EnterTicketButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemented");
        }

        private void Consultant_Load(object sender, EventArgs e)
        {

        }
        private void getSupportTicketStatus()
        {
            string TicketStatusName = null;
            string TicketStatusID = null;
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `supportticketstatus`;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    TicketStatusID = reader.GetInt32("StatusID").ToString();
                    TicketStatusName = reader.GetString("Name");
                    TicketStatus.Add(TicketStatusID, TicketStatusName);
                }
            }

            foreach (KeyValuePair<string, string> entry in TicketStatus)
            {
                TicketStatusComboBox.Items.Add(entry.Value);
            }
        }
        private void GetAvailableTickets()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TicketID");
            dt.Columns.Add("Subject");
            dt.Columns.Add("Description");
            dt.Columns.Add("StatusID");
            dt.Columns.Add("Status");
            
            dt.Columns.Add("CreatedDate");
           
            dt.Columns.Add("CustomerID");
            dt.Columns.Add("EmployeeID");

            


            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `supportticketassignment` LEFT JOIN `supportticket` ON `supportticketassignment`.`TicketID` = `supportticket`.`TicketID`";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            

            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
              
                while(reader.Read())
                {
                    dt.Rows.Add(reader.GetInt32("TicketID").ToString(), reader.GetString("Subject"), reader.GetString("Description"), reader.GetInt32("StatusID").ToString(), TicketStatus.FirstOrDefault(x => x.Key == reader.GetInt32("StatusID").ToString()).Value, reader.GetDateTime("CreatedDate").ToString(), reader.GetInt32("CustomerID").ToString());
                }
            }
            AvailableTicketsGridView.DataSource = dt;
        }
        private void GetAssignedTickets()
        {
            DataTable dt = new DataTable();
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `supportticketassignment` LEFT JOIN `supportticket` ON `supportticketassignment`.`TicketID` = `supportticket`.`TicketID`  WHERE `EmployeeID` = @EmployeeID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@EmployeeID", _loginform._EmployeeID);
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                dt.Load(reader);
                AssignedTicketGridView.DataSource = dt;
            }
        }

        private void AcceptTicketButton_Click(object sender, EventArgs e)
        {
            if (AvailableTicketsGridView.SelectedRows.Count > 0)
            {
                AcceptTicket();
                GetAvailableTickets();
                GetAssignedTickets();
            }
            else
            {
                MessageBox.Show("Select Ticket");
            }

        }
        private void AcceptTicket()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "UPDATE `supportticketassignment` SET `EmployeeID` = @EmployeeID WHERE `TicketID` = @TicketID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@EmployeeID", _loginform._EmployeeID);
            parameters.Add("@TicketID", AvailableTicketsGridView.SelectedRows[0].Cells[0].Value.ToString());
            sQL.ExecuteNonQueries(query, parameters);
        }

        private void UnAssignButton_Click(object sender, EventArgs e)
        {
            if (AssignedTicketGridView.SelectedRows.Count > 0)
            {
                UnAssignTicket();
                GetAvailableTickets();
                GetAssignedTickets();
            }
            else
            {
                MessageBox.Show("Select Ticket");
            }

        }
        private void UnAssignTicket()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "UPDATE `supportticketassignment` SET `EmployeeID` = @EmployeeID WHERE `TicketID` = @TicketID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@TicketID", AssignedTicketGridView.SelectedRows[0].Cells["TicketID"].Value.ToString());
            parameters.Add("@EmployeeID", null);
            sQL.ExecuteNonQueries(query, parameters);
        }

        private void ChangeStatusButton_Click(object sender, EventArgs e)
        {

            if (AssignedTicketGridView.SelectedRows.Count > 0)
            {
                ChangeSelectedTicketStatus();
                GetAvailableTickets();
                GetAssignedTickets();
            }
            else
            {
                MessageBox.Show("Select Ticket");
            }
        }
        private void ChangeSelectedTicketStatus()
        {
            SQL sQL = new SQL(Form1.DataBaseType);
            string TicketStatusID = TicketStatus.FirstOrDefault(x => x.Value == TicketStatusComboBox.SelectedItem.ToString()).Key;
            
            string query = "UPDATE `supportticket` SET `StatusID` = @StatusID WHERE `TicketID` = @TicketID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@StatusID", TicketStatusID);
            parameters.Add("@TicketID", AssignedTicketGridView.SelectedRows[0].Cells[0].Value.ToString());
            sQL.ExecuteNonQueries(query, parameters);
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            GetAvailableTickets();
            GetAssignedTickets();
        }

        private void Consultant_FormClosing(object sender, FormClosingEventArgs e)
        {
            _loginform.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _loginform.Show();
            this.Close();
        }
    }
}
