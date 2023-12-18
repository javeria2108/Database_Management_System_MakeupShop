using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DBTheoryProject
{
    public partial class CartForm : Form
    {
        private string connectionString = @"Data Source=DESKTOP-546PB2I\SQLEXPRESS;Initial Catalog=YourDatabaseName;Integrated Security=True";
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private SqlCommandBuilder commandBuilder;

        public CartForm()
        {
            InitializeComponent();
        }

        private void CartForm_Load(object sender, EventArgs e)
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
                command.CommandText = "INSERT INTO Cart (CustomerID, DateCreated) VALUES (" + txtCustomerID.Text + ", '" + DateTime.Now + "')";
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Cart inserted successfully.");
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

            try
            {
                connection.Open();
                command.Connection = connection;
                int cartIDToUpdate;
                if (int.TryParse(txtCartID.Text, out cartIDToUpdate))
                {
                    command.CommandText = "UPDATE Cart SET CustomerID = " + txtCustomerID.Text + " WHERE CartID = " + cartIDToUpdate;
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cart updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Cart with the specified ID not found.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Cart ID");
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
            CartView.DataSource = null;
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
                command.CommandText = "SELECT * FROM Cart";
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                CartView.DataSource = dt;
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

            int cartIDToDelete;
            if (int.TryParse(textBoxDel.Text, out cartIDToDelete))
            {
                command.CommandText = "DELETE FROM Cart WHERE CartID = " + cartIDToDelete;

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cart deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Cart with the specified ID not found.");
                }

                connection.Close();
            }
            else
            {
                MessageBox.Show("Invalid Cart ID");
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

    }
}
