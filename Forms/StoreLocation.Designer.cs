namespace MobilusOperatorius.Forms
{
    partial class StoreLocation
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
            StoreLocationGridView = new DataGridView();
            SaveChangesButton = new Button();
            DeleteButton = new Button();
            label1 = new Label();
            label2 = new Label();
            CreateButton = new Button();
            RefreshButton = new Button();
            ClearButton = new Button();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)StoreLocationGridView).BeginInit();
            SuspendLayout();
            // 
            // StoreLocationGridView
            // 
            StoreLocationGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            StoreLocationGridView.Location = new Point(12, 12);
            StoreLocationGridView.Name = "StoreLocationGridView";
            StoreLocationGridView.Size = new Size(776, 340);
            StoreLocationGridView.TabIndex = 0;
            // 
            // SaveChangesButton
            // 
            SaveChangesButton.Location = new Point(12, 415);
            SaveChangesButton.Name = "SaveChangesButton";
            SaveChangesButton.Size = new Size(75, 23);
            SaveChangesButton.TabIndex = 1;
            SaveChangesButton.Text = "Save";
            SaveChangesButton.UseVisualStyleBackColor = true;
            SaveChangesButton.Click += SaveChangesButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(304, 415);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(75, 23);
            DeleteButton.TabIndex = 2;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(304, 397);
            label1.Name = "label1";
            label1.Size = new Size(114, 15);
            label1.TabIndex = 3;
            label1.Text = "Select Row to Delete";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 397);
            label2.Name = "label2";
            label2.Size = new Size(127, 15);
            label2.TabIndex = 4;
            label2.Text = "Change Data And Save";
            // 
            // CreateButton
            // 
            CreateButton.Location = new Point(455, 415);
            CreateButton.Name = "CreateButton";
            CreateButton.Size = new Size(149, 23);
            CreateButton.TabIndex = 5;
            CreateButton.Text = "Create New";
            CreateButton.UseVisualStyleBackColor = true;
            CreateButton.Click += CreateButton_Click;
            // 
            // RefreshButton
            // 
            RefreshButton.Location = new Point(12, 358);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(75, 23);
            RefreshButton.TabIndex = 6;
            RefreshButton.Text = "Refresh";
            RefreshButton.UseMnemonic = false;
            RefreshButton.UseVisualStyleBackColor = true;
            RefreshButton.Click += RefreshButton_Click;
            // 
            // ClearButton
            // 
            ClearButton.Location = new Point(93, 358);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(75, 23);
            ClearButton.TabIndex = 7;
            ClearButton.Text = "Clear";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(455, 397);
            label3.Name = "label3";
            label3.Size = new Size(201, 15);
            label3.TabIndex = 8;
            label3.Text = "Clear DataGrid And Enter New Inputs";
            // 
            // StoreLocation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(864, 450);
            Controls.Add(label3);
            Controls.Add(ClearButton);
            Controls.Add(RefreshButton);
            Controls.Add(CreateButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(DeleteButton);
            Controls.Add(SaveChangesButton);
            Controls.Add(StoreLocationGridView);
            Name = "StoreLocation";
            Text = "StoreLocation";
            Load += StoreLocation_Load;
            ((System.ComponentModel.ISupportInitialize)StoreLocationGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView StoreLocationGridView;
        private Button SaveChangesButton;
        private Button DeleteButton;
        private Label label1;
        private Label label2;
        private Button CreateButton;
        private Button RefreshButton;
        private Button ClearButton;
        private Label label3;
    }
}