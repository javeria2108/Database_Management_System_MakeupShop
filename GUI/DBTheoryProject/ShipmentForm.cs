using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DBTheoryProject
{
    public partial class ShipmentForm : Form
    {
        private string connectionString = @"Data Source=DESKTOP-546PB2I\SQLEXPRESS;Initial Catalog=YourDatabaseName;Integrated Security=True";
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private SqlCommandBuilder commandBuilder;

        public ShipmentForm()
        {
            InitializeComponent();
        }
        private void btnBackToDashboard_Click(object sender, EventArgs e)
        {
            // Close the current form
            this.Close();

            // Show the DashboardForm
            DashboardForm dashboardForm = new DashboardForm(LoginForm.username, LoginForm.password);
            dashboardForm.Show();
        }

        private void ShipmentForm_Load(object sender, EventArgs e)
        {
            try
            {
                var datasource = @"DESKTOP-546PB2I\SQLEXPRESS";
                var database = "CosmeticsDatabaseProject";
                var thisUsername = LoginForm.username;
                var thisPassword = LoginForm.password;
                string connString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=" + thisUsername + ";Password=" + thisPassword;
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            var datasource = @"DESKTOP-546PB2I\SQLEXPRESS";
            var database = "CosmeticsDatabaseProject";
            var thisUsername = LoginForm.username;
            var thisPassword = LoginForm.password;
            string connString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=" + thisUsername + ";Password=" + thisPassword;
            SqlConnection connection = new SqlConnection(connString);

            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO Shipment (orderID, shipment_date, address, city, state, country, zip_code) VALUES (" + txtOrderID.Text + ", '" + shipmentDate.Value.ToString("yyyy-MM-dd") + "', '" + txtAddress.Text + "', '" + txtCity.Text + "', '" + txtState.Text + "', '" + txtCountry.Text + "', '" + txtZipCode.Text + "')";
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Shipment inserted successfully.");
                btnView_Click(sender, e);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) // Foreign key constraint violation
                {
                    MessageBox.Show("Foreign key constraint violation. Please check the OrderID.");
                }
                else
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            var datasource = @"DESKTOP-546PB2I\SQLEXPRESS";
            var database = "CosmeticsDatabaseProject";
            var thisUsername = LoginForm.username;
            var thisPassword = LoginForm.password;
            string connString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=" + thisUsername + ";Password=" + thisPassword;
            SqlConnection connection = new SqlConnection(connString);

            try
            {
                connection.Open();
                command.Connection = connection;
                int shipmentIDToUpdate;
                if (int.TryParse(txtShipmentID.Text, out shipmentIDToUpdate))
                {
                    command.CommandText = "UPDATE Shipment SET orderID = " + txtOrderID.Text + ", shipment_date = '" + shipmentDate.Value.ToString("yyyy-MM-dd") + "', address = '" + txtAddress.Text + "', city = '" + txtCity.Text + "', state = '" + txtState.Text + "', country = '" + txtCountry.Text + "', zip_code = '" + txtZipCode.Text + "' WHERE shipment_id = " + shipmentIDToUpdate;
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Shipment updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Shipment with the specified ID not found.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Shipment ID");
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) // Foreign key constraint violation
                {
                    MessageBox.Show("Foreign key constraint violation. Please check the OrderID.");
                }
                else
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ShipmentView.DataSource = null;
            try
            {
                SqlCommand command = new SqlCommand();
                var datasource = @"DESKTOP-546PB2I\SQLEXPRESS";
                var database = "CosmeticsDatabaseProject";
                var thisUsername = LoginForm.username;
                var thisPassword = LoginForm.password;
                string connString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=" + thisUsername + ";Password=" + thisPassword;
                SqlConnection connection = new SqlConnection(connString);
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Shipment";
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ShipmentView.DataSource = dt;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            var datasource = @"DESKTOP-546PB2I\SQLEXPRESS";
            var database = "CosmeticsDatabaseProject";
            var thisUsername = LoginForm.username;
            var thisPassword = LoginForm.password;
            string connString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=" + thisUsername + ";Password=" + thisPassword;
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            command.Connection = connection;

            int shipmentIDToDelete;
            if (int.TryParse(textBoxDel.Text, out shipmentIDToDelete))
            {
                command.CommandText = "DELETE FROM Shipment WHERE shipment_id = " + shipmentIDToDelete;

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Shipment deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Shipment with the specified ID not found.");
                }

                connection.Close();
            }
            else
            {
                MessageBox.Show("Invalid Shipment ID");
            }
        }
    }
}
