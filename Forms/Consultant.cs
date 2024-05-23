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
            string query = "SELECT * FROM 'supportticketstatus';";
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
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM 'supportticketassigned'  WHERE 'EmployeeID' = '0';";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                dt.Load(reader);
                AvailableTicketsGridView.DataSource = dt;
            }
        }
        private void GetAssignedTickets()
        {
            DataTable dt = new DataTable();
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM 'supportticketassigned'  WHERE 'EmployeeID' = '@EmployeeID';";
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
            string query = "UPDATE 'supportticketassigned' SET 'EmployeeID' = '@EmployeeID' WHERE 'TicketID' = '@TicketID';";
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
            string query = "UPDATE 'supportticketassigned' SET 'EmployeeID' = '0' WHERE 'TicketID' = '@TicketID';";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@TicketID", AssignedTicketGridView.SelectedRows[0].Cells[0].Value.ToString());
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
            string query = "UPDATE 'supportticketassigned' SET 'StatusID' = '@StatusID' WHERE 'TicketID' = '@TicketID';";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@StatusID", TicketStatus.FirstOrDefault(x => x.Value == TicketStatusComboBox.SelectedItem.ToString()).Key);
            parameters.Add("@TicketID", AssignedTicketGridView.SelectedRows[0].Cells[0].Value.ToString());
            sQL.ExecuteNonQueries(query, parameters);
        }
    }
}
