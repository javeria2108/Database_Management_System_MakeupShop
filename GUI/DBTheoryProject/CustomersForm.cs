using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBTheoryProject
{
    public partial class CustomersForm : Form
    {
        private string connectionString = @"Data Source=DESKTOP-546PB2I\SQLEXPRESS;Initial Catalog=YourDatabaseName;Integrated Security=True";
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private SqlCommandBuilder commandBuilder;
        public CustomersForm()
        {
            InitializeComponent();
        }
        private void CustomersForm_Load(object sender, EventArgs e)
        {
               try             {
                var datasource = @"DESKTOP-546PB2I\SQLEXPRESS"; var database = "CosmeticsDatabaseProject";
            var thisUsername = LoginForm.username; var thisPassword = LoginForm.password;
            string connString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=" + thisUsername + ";Password=" + thisPassword;
            SqlConnection conn = new SqlConnection(connString); conn.Open();
             conn.Close();

        } 
 
            catch (Exception ex) 
            {
                MessageBox.Show("Error: " + ex.Message);
            }

}
        private void btnInsert_Click(object sender, EventArgs e)
        {
            // Add a new row to the DataTable
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
                command.CommandText = "insert into Customers ( Username, Email, Password, RegistrationDate, LastLoginDate) values('"  + txtUsername.Text + "','" + txtEmail.Text + "','" + txtPassword.Text + "','" + DateTime.Now + "', NULL)";
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Customer inserted successfully.");
                btnView_Click(sender, e);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) // Foreign key constraint violation
                {
                    MessageBox.Show("Foreign key constraint violation. Please check the CustomerID.");
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

            // Use the customer ID from txtID.Text for updating
            try
            {
                connection.Open();
                command.Connection = connection;
                int customerIdToUpdate;
                if (int.TryParse(txtID.Text, out customerIdToUpdate))
                {
                    command.CommandText = "UPDATE Customers SET Username = '" + txtUsername.Text + "', Email = '" + txtEmail.Text + "', Password = '" + txtPassword.Text + "', RegistrationDate = '" + DateTime.Now + "', LastLoginDate = NULL WHERE CustomerID = " + customerIdToUpdate;
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Customer updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Customer with the specified ID not found.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Customer ID");
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) // Foreign key constraint violation
                {
                    MessageBox.Show("Foreign key constraint violation. Please check the CustomerID.");
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

            CustomersView.DataSource = null;
            try
            {
                SqlCommand command = new SqlCommand();
                var datasource = @"DESKTOP-546PB2I\SQLEXPRESS"; var database = "CosmeticsDatabaseProject";
                var thisUsername = LoginForm.username; var thisPassword = LoginForm.password;
                string connString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=" + thisUsername + ";Password=" + thisPassword;
                SqlConnection connection = new SqlConnection(connString);
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from Customers";
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable(); da.Fill(dt);

                CustomersView.DataSource = dt;
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
            var datasource = @"DESKTOP-546PB2I\SQLEXPRESS"; var database = "CosmeticsDatabaseProject";
            var thisUsername = LoginForm.username; var thisPassword = LoginForm.password;
            string connString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=" + thisUsername + ";Password=" + thisPassword;
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            command.Connection = connection;

            // Use the CustomerID from textBoxDel for deletion
            int customerIdToDelete;
            if (int.TryParse(textBoxDel.Text, out customerIdToDelete))
            {
                command.CommandText = "DELETE FROM Customers WHERE CustomerID = " + customerIdToDelete;

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Customer deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Customer with the specified ID not found.");
                }

                connection.Close();
            }
            else
            {
                MessageBox.Show("Invalid Customer ID");
            }
        }

        private void btnBackToDashboard_Click(object sender, EventArgs e)
        {
            // Close the current form
            this.Close();

            // Show the DashboardForm
            DashboardForm dashboardForm = new DashboardForm(LoginForm.username, LoginForm.password);
            dashboardForm.Show();
        }

        private void btnAudits_Click(object sender, EventArgs e)
        {
            // Clear the existing data in the DataGridView
            CustomersView.DataSource = null;

            try
            {
                // Create a new SqlConnection using your connection string
                var datasource = @"DESKTOP-546PB2I\SQLEXPRESS";
                var database = "CosmeticsDatabaseProject";
                var thisUsername = LoginForm.username;
                var thisPassword = LoginForm.password;
                string connString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=" + thisUsername + ";Password=" + thisPassword;
                SqlConnection connection = new SqlConnection(connString);

                
                    connection.Open();

                    // Define a SQL query to retrieve data from the CustomersAudit table
                    string query = "SELECT * FROM CustomersAudit";

                    // Create a new SqlCommand
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Create a SqlDataAdapter and a DataTable to store the results
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();

                        // Fill the DataTable with data from the query
                        dataAdapter.Fill(dataTable);

                        // Bind the DataTable to the DataGridView
                        CustomersView.DataSource = dataTable;
                    }

                    connection.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}
 