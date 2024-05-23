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
    public partial class ProductFeatures : Form
    { string _productID;
        public ProductFeatures(string ProductID)
        {
            InitializeComponent();
            _productID = ProductID;
        }

        private void ProductFeatures_Load(object sender, EventArgs e)
        {
            LoadProductFeatures();
        }
        private void LoadProductFeatures()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Description");
            SQL sQL = new SQL(Form1.DataBaseType);
            string query = "SELECT * FROM `productfeatureassociation` LEFT Join `productfeature` ON `productfeature`.`FeatureID` = `productfeatureassociation`.`FeatureID` WHERE `ProductID` = @ProductID;";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@ProductID", _productID);
            using (MySql.Data.MySqlClient.MySqlDataReader reader = sQL.DataReader(query, parameters))
            {
                while (reader.Read())
                {
                    dt.Rows.Add(reader.GetString("Name"), reader.GetString("Description"));
                }
            }
            productfeaturegridview.DataSource = dt;
        }
    }
}
