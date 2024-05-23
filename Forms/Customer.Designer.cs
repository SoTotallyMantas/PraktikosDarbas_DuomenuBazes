namespace MobilusOperatorius.Forms
{
    partial class Customer
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
            OpenTicketButton = new Button();
            TicketGridView = new DataGridView();
            label1 = new Label();
            NewTicketButton = new Button();
            ChangeProfileButton = new Button();
            ProductGridView = new DataGridView();
            label2 = new Label();
            button1 = new Button();
            CheckSubscriptionButton = new Button();
            ProductCategories = new ComboBox();
            label3 = new Label();
            LogoutButton = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)TicketGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ProductGridView).BeginInit();
            SuspendLayout();
            // 
            // OpenTicketButton
            // 
            OpenTicketButton.Location = new Point(12, 415);
            OpenTicketButton.Name = "OpenTicketButton";
            OpenTicketButton.Size = new Size(86, 23);
            OpenTicketButton.TabIndex = 0;
            OpenTicketButton.Text = "Open Ticket";
            OpenTicketButton.UseVisualStyleBackColor = true;
            OpenTicketButton.Click += OpenTicketButton_Click;
            // 
            // TicketGridView
            // 
            TicketGridView.AllowUserToAddRows = false;
            TicketGridView.AllowUserToDeleteRows = false;
            TicketGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TicketGridView.Location = new Point(12, 244);
            TicketGridView.Name = "TicketGridView";
            TicketGridView.ReadOnly = true;
            TicketGridView.Size = new Size(458, 150);
            TicketGridView.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 226);
            label1.Name = "label1";
            label1.Size = new Size(101, 15);
            label1.TabIndex = 2;
            label1.Text = "Submitted Tickets";
            // 
            // NewTicketButton
            // 
            NewTicketButton.Location = new Point(104, 415);
            NewTicketButton.Name = "NewTicketButton";
            NewTicketButton.Size = new Size(75, 23);
            NewTicketButton.TabIndex = 3;
            NewTicketButton.Text = "New Ticket";
            NewTicketButton.UseVisualStyleBackColor = true;
            NewTicketButton.Click += NewTicketButton_Click;
            // 
            // ChangeProfileButton
            // 
            ChangeProfileButton.Location = new Point(1204, 34);
            ChangeProfileButton.Name = "ChangeProfileButton";
            ChangeProfileButton.Size = new Size(114, 23);
            ChangeProfileButton.TabIndex = 4;
            ChangeProfileButton.Text = "Change Profile";
            ChangeProfileButton.UseVisualStyleBackColor = true;
            ChangeProfileButton.Click += ChangeProfileButton_Click;
            // 
            // ProductGridView
            // 
            ProductGridView.AllowUserToAddRows = false;
            ProductGridView.AllowUserToDeleteRows = false;
            ProductGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ProductGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            ProductGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ProductGridView.Location = new Point(12, 42);
            ProductGridView.Name = "ProductGridView";
            ProductGridView.ReadOnly = true;
            ProductGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            ProductGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ProductGridView.Size = new Size(903, 181);
            ProductGridView.TabIndex = 5;

            ProductGridView.CellContentClick += ProductGridView_CellContentClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 16);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 6;
            label2.Text = "Products";
            // 
            // button1
            // 
            button1.Location = new Point(939, 200);
            button1.Name = "button1";
            button1.Size = new Size(164, 23);
            button1.TabIndex = 7;
            button1.Text = "More Information";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // CheckSubscriptionButton
            // 
            CheckSubscriptionButton.Location = new Point(1189, 415);
            CheckSubscriptionButton.Name = "CheckSubscriptionButton";
            CheckSubscriptionButton.Size = new Size(126, 23);
            CheckSubscriptionButton.TabIndex = 10;
            CheckSubscriptionButton.Text = "Check Subscription";
            CheckSubscriptionButton.UseVisualStyleBackColor = true;
            CheckSubscriptionButton.Click += CheckSubscriptionButton_Click;
            // 
            // ProductCategories
            // 
            ProductCategories.FormattingEnabled = true;
            ProductCategories.Location = new Point(939, 42);
            ProductCategories.Name = "ProductCategories";
            ProductCategories.Size = new Size(173, 23);
            ProductCategories.TabIndex = 11;
            ProductCategories.SelectedIndexChanged += ProductCategories_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(939, 24);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 12;
            label3.Text = "Category";
            // 
            // LogoutButton
            // 
            LogoutButton.Location = new Point(1226, 65);
            LogoutButton.Name = "LogoutButton";
            LogoutButton.Size = new Size(75, 23);
            LogoutButton.TabIndex = 13;
            LogoutButton.Text = "Logout";
            LogoutButton.UseVisualStyleBackColor = true;
            LogoutButton.Click += LogoutButton_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1204, 9);
            button2.Name = "button2";
            button2.Size = new Size(114, 23);
            button2.TabIndex = 14;
            button2.Text = "Profile";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Customer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1327, 464);
            Controls.Add(button2);
            Controls.Add(LogoutButton);
            Controls.Add(label3);
            Controls.Add(ProductCategories);
            Controls.Add(CheckSubscriptionButton);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(ProductGridView);
            Controls.Add(ChangeProfileButton);
            Controls.Add(NewTicketButton);
            Controls.Add(label1);
            Controls.Add(TicketGridView);
            Controls.Add(OpenTicketButton);
            Name = "Customer";
            Text = "Customer";
            FormClosing += Customer_FormClosing;
            Load += Customer_Load;
            ((System.ComponentModel.ISupportInitialize)TicketGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)ProductGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button OpenTicketButton;
        private DataGridView TicketGridView;
        private Label label1;
        private Button NewTicketButton;
        private Button ChangeProfileButton;
        private DataGridView ProductGridView;
        private Label label2;
        private Button button1;
        private Button CheckSubscriptionButton;
        private ComboBox ProductCategories;
        private Label label3;
        private Button LogoutButton;
        private Button button2;
    }
}