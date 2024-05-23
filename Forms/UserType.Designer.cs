namespace MobilusOperatorius.Forms
{
    partial class UserType
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
            SaveButton = new Button();
            ClearButton = new Button();
            RefreshButton = new Button();
            PlanGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)PlanGrid).BeginInit();
            SuspendLayout();
            // 
            // AddButton
            // 
            AddButton.Location = new Point(174, 339);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(75, 23);
            AddButton.TabIndex = 12;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(93, 339);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(75, 23);
            DeleteButton.TabIndex = 11;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(12, 339);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 10;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // ClearButton
            // 
            ClearButton.Location = new Point(93, 203);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(75, 23);
            ClearButton.TabIndex = 9;
            ClearButton.Text = "Clear";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // RefreshButton
            // 
            RefreshButton.Location = new Point(12, 203);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(75, 23);
            RefreshButton.TabIndex = 8;
            RefreshButton.Text = "Refresh";
            RefreshButton.UseVisualStyleBackColor = true;
            RefreshButton.Click += RefreshButton_Click;
            // 
            // PlanGrid
            // 
            PlanGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PlanGrid.Location = new Point(12, 12);
            PlanGrid.Name = "PlanGrid";
            PlanGrid.Size = new Size(776, 185);
            PlanGrid.TabIndex = 7;
            // 
            // UserType
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 380);
            Controls.Add(AddButton);
            Controls.Add(DeleteButton);
            Controls.Add(SaveButton);
            Controls.Add(ClearButton);
            Controls.Add(RefreshButton);
            Controls.Add(PlanGrid);
            Name = "UserType";
            Text = "UserType";
            ((System.ComponentModel.ISupportInitialize)PlanGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button AddButton;
        private Button DeleteButton;
        private Button SaveButton;
        private Button ClearButton;
        private Button RefreshButton;
        private DataGridView PlanGrid;
    }
}