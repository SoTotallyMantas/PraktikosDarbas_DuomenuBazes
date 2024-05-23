using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilusOperatorius.Classes
{
    internal class SQL
    {
        private readonly MySqlConnection _connection;

        string DatabaseLocal = "server=localhost;database=mobilaus_operatorius;username=Mantas;password=;port=3306";
        string DatabaseRemote = "server=78.157.85.177;database=mobilaus_operatorius;username=Mantas;password=;port=3306";
        public SQL(string DatabaseType)
        {
            switch(DatabaseType)
            {
                case "DatabaseLocal":
                    _connection = new MySqlConnection(DatabaseLocal);
                    break;
                case "DatabaseRemote":
                    _connection = new MySqlConnection(DatabaseRemote);
                    break;
            }
            
        }

        public void OpenConnection()
        {
            try
            {
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void CloseConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }
        // MODIFY DATA
        public void ExecuteNonQueries(string query, Dictionary<string, string> parameters)
        {

            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                OpenConnection();
                try
                {
                    foreach (var item in parameters)
                    {
                        command.Parameters.AddWithValue(item.Key, item.Value);
                    }
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                
            }
        }
        public void ExecuteNonQueries(string query)
        {

            ExecuteNonQueries(query, new Dictionary<string, string>());
        }
        // READ DATA
        // READER
        public MySqlDataReader DataReader(string query, Dictionary<string, string> parameters)
        {

            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                OpenConnection();
                try
                {
                    foreach (var item in parameters)
                    {
                        command.Parameters.AddWithValue(item.Key, item.Value);
                    }
                    return command.ExecuteReader();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return null;
                }
            }
        }

        public MySqlDataReader DataReader(string query)
        {
            return DataReader(query, new Dictionary<string, string>());
        }
        // ADAPTER
        public MySqlDataAdapter DataAdapter(string query, Dictionary<string, string> parameters)
        {
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, _connection))
            {
                OpenConnection();
                try
                {
                    foreach (var item in parameters)
                    {
                        adapter.SelectCommand.Parameters.AddWithValue(item.Key, item.Value);
                    }
                    return adapter;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return null;
                }
            }
        }
        public MySqlDataAdapter DataAdapter(string query)
        {
            return DataAdapter(query, new Dictionary<string, string>());
        }
    }
}
