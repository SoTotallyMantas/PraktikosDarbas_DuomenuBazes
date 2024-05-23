namespace MobilusOperatorius.Forms
{
    partial class AssignPromotionsAdmin
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
            AddButton = new Button();
            DeleteButton = new Button();
            UpdateButton = new Button();
            ClearButton = new Button();
            RefreshButton = new Button();
            DataGrid = new DataGridView();
            PromotionsView = new DataGridView();
            ProductsView = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)DataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PromotionsView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ProductsView).BeginInit();
            SuspendLayout();
            // 
            // AddButton
            // 
            AddButton.Location = new Point(174, 536);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(75, 23);
            AddButton.TabIndex = 17;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(93, 536);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(75, 23);
            DeleteButton.TabIndex = 16;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // UpdateButton
            // 
            UpdateButton.Location = new Point(12, 536);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(75, 23);
            UpdateButton.TabIndex = 15;
            UpdateButton.Text = "Update";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // ClearButton
            // 
            ClearButton.Location = new Point(93, 168);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(75, 23);
            ClearButton.TabIndex = 14;
            ClearButton.Text = "Clear";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // RefreshButton
            // 
            RefreshButton.Location = new Point(12, 168);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(75, 23);
            RefreshButton.TabIndex = 13;
            RefreshButton.Text = "Refresh";
            RefreshButton.UseVisualStyleBackColor = true;
            RefreshButton.Click += RefreshButton_Click;
            // 
            // DataGrid
            // 
            DataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGrid.Location = new Point(12, 12);
            DataGrid.Name = "DataGrid";
            DataGrid.Size = new Size(776, 150);
            DataGrid.TabIndex = 12;
            // 
            // PromotionsView
            // 
            PromotionsView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PromotionsView.Location = new Point(325, 199);
            PromotionsView.Name = "PromotionsView";
            PromotionsView.Size = new Size(463, 150);
            PromotionsView.TabIndex = 18;
            // 
            // ProductsView
            // 
            ProductsView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ProductsView.Location = new Point(325, 386);
            ProductsView.Name = "ProductsView";
            ProductsView.Size = new Size(463, 173);
            ProductsView.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(325, 368);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 20;
            label1.Text = "Products";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(325, 176);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 21;
            label2.Text = "Promotions";
            // 
            // AssignPromotionsAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 571);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ProductsView);
            Controls.Add(PromotionsView);
            Controls.Add(AddButton);
            Controls.Add(DeleteButton);
            Controls.Add(UpdateButton);
            Controls.Add(ClearButton);
            Controls.Add(RefreshButton);
            Controls.Add(DataGrid);
            Name = "AssignPromotionsAdmin";
            Text = "AssignPromotionsAdmin";
            ((System.ComponentModel.ISupportInitialize)DataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)PromotionsView).EndInit();
            ((System.ComponentModel.ISupportInitialize)ProductsView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddButton;
        private Button DeleteButton;
        private Button UpdateButton;
        private Button ClearButton;
        private Button RefreshButton;
        private DataGridView DataGrid;
        private DataGridView PromotionsView;
        private DataGridView ProductsView;
        private Label label1;
        private Label label2;
    }
}