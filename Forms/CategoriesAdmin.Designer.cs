namespace MobilusOperatorius.Forms
{
    partial class CategoriesAdmin
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
            CategoriesGrid = new DataGridView();
            AddButton = new Button();
            DeleteButton = new Button();
            SaveButton = new Button();
            ClearButton = new Button();
            RefreshButton = new Button();
            ((System.ComponentModel.ISupportInitialize)CategoriesGrid).BeginInit();
            SuspendLayout();
            // 
            // CategoriesGrid
            // 
            CategoriesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CategoriesGrid.Location = new Point(12, 12);
            CategoriesGrid.Name = "CategoriesGrid";
            CategoriesGrid.Size = new Size(570, 240);
            CategoriesGrid.TabIndex = 0;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(174, 416);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(75, 23);
            AddButton.TabIndex = 10;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(93, 416);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(75, 23);
            DeleteButton.TabIndex = 9;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(12, 416);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 8;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // ClearButton
            // 
            ClearButton.Location = new Point(93, 258);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(75, 23);
            ClearButton.TabIndex = 7;
            ClearButton.Text = "Clear";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // RefreshButton
            // 
            RefreshButton.Location = new Point(12, 258);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(75, 23);
            RefreshButton.TabIndex = 6;
            RefreshButton.Text = "Refresh";
            RefreshButton.UseVisualStyleBackColor = true;
            RefreshButton.Click += RefreshButton_Click;
            // 
            // CategoriesAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 450);
            Controls.Add(AddButton);
            Controls.Add(DeleteButton);
            Controls.Add(SaveButton);
            Controls.Add(ClearButton);
            Controls.Add(RefreshButton);
            Controls.Add(CategoriesGrid);
            Name = "CategoriesAdmin";
            Text = "CategoriesAdmin";
            ((System.ComponentModel.ISupportInitialize)CategoriesGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView CategoriesGrid;
        private Button AddButton;
        private Button DeleteButton;
        private Button SaveButton;
        private Button ClearButton;
        private Button RefreshButton;
    }
}