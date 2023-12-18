using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DBTheoryProject
{
    public partial class ProductCategoriesForm : Form
    {
        private string connectionString = @"Data Source=DESKTOP-546PB2I\SQLEXPRESS;Initial Catalog=YourDatabaseName;Integrated Security=True";
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private SqlCommandBuilder commandBuilder;

        public ProductCategoriesForm()
        {
            InitializeComponent();
        }

        private void ProductCategoriesForm_Load(object sender, EventArgs e)
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
        private void btnBackToDashboard_Click(object sender, EventArgs e)
        {
            // Close the current form
            this.Close();

            // Show the DashboardForm
            DashboardForm dashboardForm = new DashboardForm(LoginForm.username, LoginForm.password);
            dashboardForm.Show();
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
                command.CommandText = "INSERT INTO ProductCategories (CategoryName, Description) VALUES ('" + txtName.Text + "','" + txtDescription.Text + "')";
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Product category inserted successfully.");
                btnView_Click(sender, e);
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
                int categoryID;

                if (int.TryParse(txtCategoryID.Text, out categoryID))
                {
                    command.CommandText = "UPDATE ProductCategories SET CategoryName = '" + txtName.Text + "', Description = '" + txtDescription.Text + "' WHERE CategoryID = " + categoryID;
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Product category updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Product category with the specified ID not found.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Category ID");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ProductCategoriesView.DataSource = null;
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
                command.CommandText = "SELECT * FROM ProductCategories";
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ProductCategoriesView.DataSource = dt;
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
                int categoryID;

                if (int.TryParse(textBoxDel.Text, out categoryID))
                {
                    command.CommandText = "DELETE FROM ProductCategories WHERE CategoryID = " + categoryID;
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Product category deleted successfully.");
                        btnView_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Product category with the specified ID not found.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Category ID");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
