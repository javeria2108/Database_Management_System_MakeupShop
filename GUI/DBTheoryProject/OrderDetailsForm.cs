using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DBTheoryProject
{
    public partial class OrderDetailsForm : Form
    {
        private string connectionString = @"Data Source=DESKTOP-546PB2I\SQLEXPRESS;Initial Catalog=YourDatabaseName;Integrated Security=True";
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private SqlCommandBuilder commandBuilder;

        public OrderDetailsForm()
        {
            InitializeComponent();
        }

        private void OrderDetailsForm_Load(object sender, EventArgs e)
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
                int orderID;
                int productID;
                int quantity;

                if (int.TryParse(txtOrderID.Text, out orderID) && int.TryParse(txtProductID.Text, out productID) && int.TryParse(txtQuantity.Text, out quantity))
                {
                    command.CommandText = "INSERT INTO OrderDetails (OrderID, ProductID, Quantity) VALUES (" + orderID + "," + productID + "," + quantity + ")";
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("OrderDetail inserted successfully.");
                    btnView_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Invalid input. Please enter valid numbers for OrderID, ProductID, and Quantity.");
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) // Foreign key constraint violation
                {
                    MessageBox.Show("Foreign key constraint violation. Please check the OrderID or ProductID.");
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
                int orderDetailID;
                int orderID;
                int productID;
                int quantity;

                if (int.TryParse(txtOrderDetailID.Text, out orderDetailID) && int.TryParse(txtOrderID.Text, out orderID) && int.TryParse(txtProductID.Text, out productID) && int.TryParse(txtQuantity.Text, out quantity))
                {
                    command.CommandText = "UPDATE OrderDetails SET OrderID = " + orderID + ", ProductID = " + productID + ", Quantity = " + quantity + " WHERE OrderDetailID = " + orderDetailID;
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("OrderDetail updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("OrderDetail with the specified ID not found.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid input. Please enter valid numbers for OrderDetailID, OrderID, ProductID, and Quantity.");
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) // Foreign key constraint violation
                {
                    MessageBox.Show("Foreign key constraint violation. Please check the OrderID or ProductID.");
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
            OrderDetailsView.DataSource = null;
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
                command.CommandText = "SELECT * FROM OrderDetails";
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                OrderDetailsView.DataSource = dt;
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

            try
            {
                connection.Open();
                command.Connection = connection;
                int orderDetailID;

                if (int.TryParse(textBoxDel.Text, out orderDetailID))
                {
                    command.CommandText = "DELETE FROM OrderDetails WHERE OrderDetailID = " + orderDetailID;
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("OrderDetail deleted successfully.");
                        btnView_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("OrderDetail with the specified ID not found.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid OrderDetail ID");
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) // Foreign key constraint violation
                {
                    MessageBox.Show("Foreign key constraint violation. Please check the OrderID or ProductID.");
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
        private void btnBackToDashboard_Click(object sender, EventArgs e)
        {
            // Close the current form
            this.Close();

            // Show the DashboardForm
            DashboardForm dashboardForm = new DashboardForm(LoginForm.username, LoginForm.password);
            dashboardForm.Show();
        }
        private void btn_AuditsClick(object sender, EventArgs e)
        {
            // Clear the existing data in the DataGridView
            OrderDetailsView.DataSource = null;

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

                    // Define a SQL query to retrieve data from the OrderDetailsAudit table
                    string query = "SELECT * FROM OrderDetailsAudit";

                    // Create a new SqlCommand
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Create a SqlDataAdapter and a DataTable to store the results
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();

                        // Fill the DataTable with data from the query
                        dataAdapter.Fill(dataTable);

                        // Bind the DataTable to the DataGridView
                        OrderDetailsView.DataSource = dataTable;
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
