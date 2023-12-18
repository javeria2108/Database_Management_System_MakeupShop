using System;
using System.CodeDom.Compiler;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DBTheoryProject
{
    public partial class InvoicesForm : Form
    {
        private string connectionString = @"Data Source=DESKTOP-546PB2I\SQLEXPRESS;Initial Catalog=YourDatabaseName;Integrated Security=True";
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private SqlCommandBuilder commandBuilder;

        public InvoicesForm()
        {
            InitializeComponent();
        }

        private void InvoicesForm_Load(object sender, EventArgs e)
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
                command.CommandText = "DECLARE @Total INT\r\n "
                    + "SET @Total = exec CalculateTotalAmountProcedure "+txtOrderID.Text;
                // Declare and set the OrderID parameter
                SqlParameter orderIdParam = new SqlParameter("@OrderID", SqlDbType.Int);
                orderIdParam.Value = int.Parse(txtOrderID.Text); // Assuming OrderID is an INT in your database
                command.Parameters.Add(orderIdParam);
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO Invoices ( OrderID, InvoiceDate, TotalAmount, PaymentDetails) VALUES ("+ txtOrderID.Text + ",'" + dtInvoiceDate.Value.ToString("yyyy-MM-dd") + "'," + "(SELECT SUM(Products.Price * OrderDetails.Quantity) FROM OrderDetails INNER JOIN Products ON OrderDetails.ProductID = Products.ProductID   WHERE OrderDetails.OrderID = @OrderID)" + ",'" + txtPaymentDetails.Text + "')";
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Invoice inserted successfully.");
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
                int invoiceID;

                if (int.TryParse(txtInvoiceID.Text, out invoiceID))
                {
                    command.CommandText = "UPDATE Invoices SET OrderID = " + txtOrderID.Text + ", InvoiceDate = '" + dtInvoiceDate.Value.ToString("yyyy-MM-dd") + "', TotalAmount = " + txtTotalAmount.Text + ", PaymentDetails = '" + txtPaymentDetails.Text + "' WHERE InvoiceID = " + invoiceID;
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Invoice updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Invoice with the specified ID not found.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Invoice ID");
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
            InvoicesView.DataSource = null;
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
                command.CommandText = "SELECT * FROM Invoices";
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                InvoicesView.DataSource = dt;
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
                int invoiceID;

                if (int.TryParse(textBoxDel.Text, out invoiceID))
                {
                    command.CommandText = "DELETE FROM Invoices WHERE InvoiceID = " + invoiceID;
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Invoice deleted successfully.");
                        btnView_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Invoice with the specified ID not found.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Invoice ID");
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

    }
}
