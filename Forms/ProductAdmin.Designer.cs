namespace MobilusOperatorius.Forms
{
    partial class ProductAdmin
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
            ProductsGrid = new DataGridView();
            RefreshButton = new Button();
            ClearButton = new Button();
            SaveButton = new Button();
            DeleteButton = new Button();
            AddButton = new Button();
            CategoriesGrid = new DataGridView();
            ModifyCategoriesButton = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)ProductsGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CategoriesGrid).BeginInit();
            SuspendLayout();
            // 
            // ProductsGrid
            // 
            ProductsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ProductsGrid.Location = new Point(12, 12);
            ProductsGrid.Name = "ProductsGrid";
            ProductsGrid.Size = new Size(776, 239);
            ProductsGrid.TabIndex = 0;
            // 
            // RefreshButton
            // 
            RefreshButton.Location = new Point(12, 257);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(75, 23);
            RefreshButton.TabIndex = 1;
            RefreshButton.Text = "Refresh";
            RefreshButton.UseVisualStyleBackColor = true;
            RefreshButton.Click += RefreshButton_Click;
            // 
            // ClearButton
            // 
            ClearButton.Location = new Point(93, 257);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(75, 23);
            ClearButton.TabIndex = 2;
            ClearButton.Text = "Clear";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(12, 415);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 3;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(93, 415);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(75, 23);
            DeleteButton.TabIndex = 4;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(174, 415);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(75, 23);
            AddButton.TabIndex = 5;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // CategoriesGrid
            // 
            CategoriesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CategoriesGrid.Location = new Point(548, 288);
            CategoriesGrid.Name = "CategoriesGrid";
            CategoriesGrid.Size = new Size(240, 150);
            CategoriesGrid.TabIndex = 6;
            // 
            // ModifyCategoriesButton
            // 
            ModifyCategoriesButton.Location = new Point(420, 415);
            ModifyCategoriesButton.Name = "ModifyCategoriesButton";
            ModifyCategoriesButton.Size = new Size(122, 23);
            ModifyCategoriesButton.TabIndex = 7;
            ModifyCategoriesButton.Text = "Modify Categories";
            ModifyCategoriesButton.UseVisualStyleBackColor = true;
            ModifyCategoriesButton.Click += ModifyCategoriesButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(548, 265);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 8;
            label1.Text = "Categories";
            // 
            // ProductAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(ModifyCategoriesButton);
            Controls.Add(CategoriesGrid);
            Controls.Add(AddButton);
            Controls.Add(DeleteButton);
            Controls.Add(SaveButton);
            Controls.Add(ClearButton);
            Controls.Add(RefreshButton);
            Controls.Add(ProductsGrid);
            Name = "ProductAdmin";
            Text = "ProductAdmin";
            ((System.ComponentModel.ISupportInitialize)ProductsGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)CategoriesGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView ProductsGrid;
        private Button RefreshButton;
        private Button ClearButton;
        private Button SaveButton;
        private Button DeleteButton;
        private Button AddButton;
        private DataGridView CategoriesGrid;
        private Button ModifyCategoriesButton;
        private Label label1;
    }
}