namespace DBTheoryProject
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnInvoices = new System.Windows.Forms.Button();
            this.btnCart = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnOrderDetails = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnProductCategories = new System.Windows.Forms.Button();
            this.btnCartDetails = new System.Windows.Forms.Button();
            this.btnShipment = new System.Windows.Forms.Button();
            this.btnReviews = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(142)))), ((int)(((byte)(164)))));
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCustomer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCustomer.Location = new System.Drawing.Point(312, 45);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(132, 23);
            this.btnCustomer.TabIndex = 1;
            this.btnCustomer.Text = "Customer";
            this.btnCustomer.UseVisualStyleBackColor = false;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // btnInvoices
            // 
            this.btnInvoices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(142)))), ((int)(((byte)(164)))));
            this.btnInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInvoices.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnInvoices.Location = new System.Drawing.Point(312, 132);
            this.btnInvoices.Name = "btnInvoices";
            this.btnInvoices.Size = new System.Drawing.Size(132, 23);
            this.btnInvoices.TabIndex = 2;
            this.btnInvoices.Text = "Invoices";
            this.btnInvoices.UseVisualStyleBackColor = false;
            this.btnInvoices.Click += new System.EventHandler(this.btnInvoices_Click);
            // 
            // btnCart
            // 
            this.btnCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(142)))), ((int)(((byte)(164)))));
            this.btnCart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCart.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCart.Location = new System.Drawing.Point(312, 277);
            this.btnCart.Name = "btnCart";
            this.btnCart.Size = new System.Drawing.Size(132, 23);
            this.btnCart.TabIndex = 4;
            this.btnCart.Text = "Cart";
            this.btnCart.UseVisualStyleBackColor = false;
            this.btnCart.Click += new System.EventHandler(this.btnCart_Click);
            // 
            // btnOrders
            // 
            this.btnOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(142)))), ((int)(((byte)(164)))));
            this.btnOrders.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOrders.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOrders.Location = new System.Drawing.Point(312, 74);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(132, 23);
            this.btnOrders.TabIndex = 6;
            this.btnOrders.Text = "Orders";
            this.btnOrders.UseVisualStyleBackColor = false;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(142)))), ((int)(((byte)(164)))));
            this.btnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProducts.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnProducts.Location = new System.Drawing.Point(312, 161);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(132, 23);
            this.btnProducts.TabIndex = 7;
            this.btnProducts.Text = "Products";
            this.btnProducts.UseVisualStyleBackColor = false;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // btnOrderDetails
            // 
            this.btnOrderDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(142)))), ((int)(((byte)(164)))));
            this.btnOrderDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOrderDetails.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOrderDetails.Location = new System.Drawing.Point(312, 103);
            this.btnOrderDetails.Name = "btnOrderDetails";
            this.btnOrderDetails.Size = new System.Drawing.Size(132, 23);
            this.btnOrderDetails.TabIndex = 8;
            this.btnOrderDetails.Text = "Order Details";
            this.btnOrderDetails.UseVisualStyleBackColor = false;
            this.btnOrderDetails.Click += new System.EventHandler(this.btnOrderDetails_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sylfaen", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(306, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 31);
            this.label1.TabIndex = 10;
            this.label1.Text = "Select Table:";
            // 
            // btnProductCategories
            // 
            this.btnProductCategories.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(142)))), ((int)(((byte)(164)))));
            this.btnProductCategories.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProductCategories.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnProductCategories.Location = new System.Drawing.Point(312, 190);
            this.btnProductCategories.Name = "btnProductCategories";
            this.btnProductCategories.Size = new System.Drawing.Size(132, 23);
            this.btnProductCategories.TabIndex = 11;
            this.btnProductCategories.Text = "Product Categories";
            this.btnProductCategories.UseVisualStyleBackColor = false;
            this.btnProductCategories.Click += new System.EventHandler(this.btnProductCategories_Click);
            // 
            // btnCartDetails
            // 
            this.btnCartDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(142)))), ((int)(((byte)(164)))));
            this.btnCartDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCartDetails.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCartDetails.Location = new System.Drawing.Point(312, 248);
            this.btnCartDetails.Name = "btnCartDetails";
            this.btnCartDetails.Size = new System.Drawing.Size(132, 23);
            this.btnCartDetails.TabIndex = 12;
            this.btnCartDetails.Text = "Cart Details";
            this.btnCartDetails.UseVisualStyleBackColor = false;
            this.btnCartDetails.Click += new System.EventHandler(this.btnCartDetails_Click);
            // 
            // btnShipment
            // 
            this.btnShipment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(142)))), ((int)(((byte)(164)))));
            this.btnShipment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShipment.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnShipment.Location = new System.Drawing.Point(312, 306);
            this.btnShipment.Name = "btnShipment";
            this.btnShipment.Size = new System.Drawing.Size(132, 23);
            this.btnShipment.TabIndex = 13;
            this.btnShipment.Text = "Shipment";
            this.btnShipment.UseVisualStyleBackColor = false;
            this.btnShipment.Click += new System.EventHandler(this.btnShipment_Click);
            // 
            // btnReviews
            // 
            this.btnReviews.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(142)))), ((int)(((byte)(164)))));
            this.btnReviews.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReviews.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReviews.Location = new System.Drawing.Point(312, 219);
            this.btnReviews.Name = "btnReviews";
            this.btnReviews.Size = new System.Drawing.Size(132, 23);
            this.btnReviews.TabIndex = 14;
            this.btnReviews.Text = "Reviews";
            this.btnReviews.UseVisualStyleBackColor = false;
            this.btnReviews.Click += new System.EventHandler(this.btnReviews_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(142)))), ((int)(((byte)(164)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBack.Location = new System.Drawing.Point(147, 17);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 15;
            this.btnBack.Text = "LOGOUT";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnReviews);
            this.Controls.Add(this.btnShipment);
            this.Controls.Add(this.btnCartDetails);
            this.Controls.Add(this.btnProductCategories);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOrderDetails);
            this.Controls.Add(this.btnProducts);
            this.Controls.Add(this.btnOrders);
            this.Controls.Add(this.btnCart);
            this.Controls.Add(this.btnInvoices);
            this.Controls.Add(this.btnCustomer);
            this.Name = "DashboardForm";
            this.Text = "DashboardForm";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnInvoices;
        private System.Windows.Forms.Button btnCart;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnOrderDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProductCategories;
        private System.Windows.Forms.Button btnCartDetails;
        private System.Windows.Forms.Button btnShipment;
        private System.Windows.Forms.Button btnReviews;
        private System.Windows.Forms.Button btnBack;
    }
}