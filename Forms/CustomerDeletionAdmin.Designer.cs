namespace MobilusOperatorius.Forms
{
    partial class CustomerDeletionAdmin
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
            RefreshButton = new Button();
            PlanGrid = new DataGridView();
            DeleteButton = new Button();
            ((System.ComponentModel.ISupportInitialize)PlanGrid).BeginInit();
            SuspendLayout();
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
            // DeleteButton
            // 
            DeleteButton.Location = new Point(12, 258);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(75, 23);
            DeleteButton.TabIndex = 11;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // CustomerDeletionAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 379);
            Controls.Add(DeleteButton);
            Controls.Add(RefreshButton);
            Controls.Add(PlanGrid);
            Name = "CustomerDeletionAdmin";
            Text = "CustomerDeletionAdmin";
            ((System.ComponentModel.ISupportInitialize)PlanGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button RefreshButton;
        private DataGridView PlanGrid;
        private Button DeleteButton;
    }
}