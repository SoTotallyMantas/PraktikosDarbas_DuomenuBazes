namespace MobilusOperatorius.Forms
{
    partial class EmployeeAdmin
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
            EmployeeData = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            RefreshButton = new Button();
            ClearButton = new Button();
            StoreLocations = new DataGridView();
            PositionsGrid = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)EmployeeData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StoreLocations).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PositionsGrid).BeginInit();
            SuspendLayout();
            // 
            // EmployeeData
            // 
            EmployeeData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            EmployeeData.Location = new Point(12, 12);
            EmployeeData.Name = "EmployeeData";
            EmployeeData.Size = new Size(1127, 249);
            EmployeeData.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(12, 415);
            button1.Name = "button1";
            button1.RightToLeft = RightToLeft.No;
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(143, 415);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(279, 415);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 3;
            button3.Text = "Add";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // RefreshButton
            // 
            RefreshButton.Location = new Point(12, 267);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(75, 23);
            RefreshButton.TabIndex = 4;
            RefreshButton.Text = "Refresh";
            RefreshButton.UseVisualStyleBackColor = true;
            RefreshButton.Click += RefreshButton_Click;
            // 
            // ClearButton
            // 
            ClearButton.Location = new Point(93, 267);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(75, 23);
            ClearButton.TabIndex = 5;
            ClearButton.Text = "Clear";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // StoreLocations
            // 
            StoreLocations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            StoreLocations.Location = new Point(452, 288);
            StoreLocations.Name = "StoreLocations";
            StoreLocations.Size = new Size(346, 150);
            StoreLocations.TabIndex = 6;
            // 
            // PositionsGrid
            // 
            PositionsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PositionsGrid.Location = new Point(816, 288);
            PositionsGrid.Name = "PositionsGrid";
            PositionsGrid.Size = new Size(316, 150);
            PositionsGrid.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(452, 267);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 8;
            label1.Text = "Store Locations";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(816, 271);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 9;
            label2.Text = "Positions";
            // 
            // EmployeeAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1144, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(PositionsGrid);
            Controls.Add(StoreLocations);
            Controls.Add(ClearButton);
            Controls.Add(RefreshButton);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(EmployeeData);
            Name = "EmployeeAdmin";
            Text = "EmployeeAdmin";
            ((System.ComponentModel.ISupportInitialize)EmployeeData).EndInit();
            ((System.ComponentModel.ISupportInitialize)StoreLocations).EndInit();
            ((System.ComponentModel.ISupportInitialize)PositionsGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView EmployeeData;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button RefreshButton;
        private Button ClearButton;
        private DataGridView StoreLocations;
        private DataGridView PositionsGrid;
        private Label label1;
        private Label label2;
    }
}