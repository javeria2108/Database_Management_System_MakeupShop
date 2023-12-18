using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBTheoryProject
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private string loggedInUsername;
        private string userRole;

        public DashboardForm(string username, string role)
        {
            InitializeComponent();
            
            userRole = username;
            InitializeButtonAccess();
        }
        private void InitializeButtonAccess()
        {
            // Disable all buttons by default
            btnCustomer.Enabled = false;
            btnOrders.Enabled = false;
            btnOrderDetails.Enabled = false;
            btnProducts.Enabled = false;
            btnProductCategories.Enabled = false;
            btnInvoices.Enabled = false;
            btnCart.Enabled = false;
            btnCartDetails.Enabled = false;
            btnShipment.Enabled = false;
            btnReviews.Enabled = false;

            // Enable buttons based on the user's role
            switch (userRole)
            {
                case "AdminUser":
                    // Admin has full access to all buttons
                    btnCustomer.Enabled = true;
                    btnOrders.Enabled = true;
                    btnOrderDetails.Enabled = true;
                    btnProducts.Enabled = true;
                    btnProductCategories.Enabled = true;
                    btnInvoices.Enabled = true;
                    btnCart.Enabled = true;
                    btnCartDetails.Enabled = true;
                    btnShipment.Enabled = true;
                    btnReviews.Enabled = true;
                    break;
                case "ProductManagerUser":
                    // Product Manager has access to specific buttons
                    btnProducts.Enabled = true;
                    btnProductCategories.Enabled = true;
                    break;
                case "SalesManagerUser":
                    // Sales Manager has access to specific buttons
                    btnOrders.Enabled = true;
                    btnOrderDetails.Enabled = true;
                    btnInvoices.Enabled = true;
                    break;
                case "CustomerSupportUser":
                    // Customer Support has access to specific buttons
                    btnCustomer.Enabled = true;
                    btnOrders.Enabled = true;
                    btnOrderDetails.Enabled = true;
                    btnReviews.Enabled = true;
                    btnShipment.Enabled = true;
                    break;
                case "FinanceManagerUser":
                    // Finance Manager has access to specific buttons
                    btnInvoices.Enabled = true;
                    btnOrders.Enabled = true;
                    break;
                default:
                    // Handle any other roles or errors here
                    break;
            }
        }

            private void DashboardForm_Load(object sender, EventArgs e)
        {

        }
       private void btnCustomers_Click(object sender, EventArgs e)
        {
            CustomersForm customersForm = new CustomersForm();
            customersForm.Show();
            this.Hide();
        }

          private void btnOrders_Click(object sender, EventArgs e)
         {
             OrdersForm ordersForm = new OrdersForm();
             ordersForm.Show();
             this.Hide();
         }
        
                 private void btnOrderDetails_Click(object sender, EventArgs e)
                 {
                     OrderDetailsForm orderDetailsForm = new OrderDetailsForm();
                     orderDetailsForm.Show();
                     this.Hide();
                 }
                 private void btnProducts_Click(object sender, EventArgs e)
                 {
                     ProductsForm productsForm = new ProductsForm();
                     productsForm.Show();
                     this.Hide();
                 }

                 private void btnProductCategories_Click(object sender, EventArgs e)
                 {
                     ProductCategoriesForm productCategoriesForm = new ProductCategoriesForm();
                     productCategoriesForm.Show();
                     this.Hide();        
                }

                 private void btnInvoices_Click(object sender, EventArgs e)
                 {
                     InvoicesForm invoicesForm = new InvoicesForm();
                     invoicesForm.Show();
                     this.Hide(); 
                 }

                 private void btnCart_Click(object sender, EventArgs e)
                 {
                     CartForm cartForm = new CartForm();
                     cartForm.Show();
                     this.Hide();  
                 }

                 private void btnCartDetails_Click(object sender, EventArgs e)
                 {
                     CartDetailsForm cartDetailsForm = new CartDetailsForm();
                     cartDetailsForm.Show();
                     this.Hide();
                 }

                private void btnShipment_Click(object sender, EventArgs e)
                 {
                     ShipmentForm shipmentForm = new ShipmentForm();
                     shipmentForm.Show();
                     this.Hide();
                 }

                 private void btnReviews_Click(object sender, EventArgs e)
                 {
                     ReviewsForm reviewsForm = new ReviewsForm();
                     reviewsForm.Show();
                     this.Hide();
                 }
        private void btnBack_Click(object sender, EventArgs e)
        {
            // Close the DashboardForm
            this.Close();
            // Show the LoginForm
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

    }
}