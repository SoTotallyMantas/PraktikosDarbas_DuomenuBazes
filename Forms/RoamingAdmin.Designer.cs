namespace MobilusOperatorius.Forms
{
    partial class RoamingAdmin
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
            RoamingPartnersGrid = new DataGridView();
            RoamingAgreementGrid = new DataGridView();
            RefreshButton = new Button();
            ClearButton = new Button();
            SaveButton = new Button();
            DeleteButton = new Button();
            AddButton = new Button();
            label1 = new Label();
            MobilePlanGrid = new DataGridView();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)RoamingPartnersGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RoamingAgreementGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MobilePlanGrid).BeginInit();
            SuspendLayout();
            // 
            // RoamingPartnersGrid
            // 
            RoamingPartnersGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RoamingPartnersGrid.Location = new Point(394, 288);
            RoamingPartnersGrid.Name = "RoamingPartnersGrid";
            RoamingPartnersGrid.Size = new Size(360, 150);
            RoamingPartnersGrid.TabIndex = 0;
            // 
            // RoamingAgreementGrid
            // 
            RoamingAgreementGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RoamingAgreementGrid.Location = new Point(12, 12);
            RoamingAgreementGrid.Name = "RoamingAgreementGrid";
            RoamingAgreementGrid.Size = new Size(1206, 211);
            RoamingAgreementGrid.TabIndex = 1;
            // 
            // RefreshButton
            // 
            RefreshButton.Location = new Point(12, 229);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(75, 23);
            RefreshButton.TabIndex = 2;
            RefreshButton.Text = "Refresh";
            RefreshButton.UseVisualStyleBackColor = true;
            RefreshButton.Click += RefreshButton_Click;
            // 
            // ClearButton
            // 
            ClearButton.Location = new Point(93, 229);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(75, 23);
            ClearButton.TabIndex = 3;
            ClearButton.Text = "Clear";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(12, 415);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 4;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(130, 415);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(75, 23);
            DeleteButton.TabIndex = 5;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(240, 415);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(75, 23);
            AddButton.TabIndex = 6;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(394, 260);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 7;
            label1.Text = "RoamingPartners";
            // 
            // MobilePlanGrid
            // 
            MobilePlanGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            MobilePlanGrid.Location = new Point(760, 288);
            MobilePlanGrid.Name = "MobilePlanGrid";
            MobilePlanGrid.Size = new Size(458, 150);
            MobilePlanGrid.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(760, 260);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 9;
            label2.Text = "Mobile Plans";
            // 
            // RoamingAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1230, 450);
            Controls.Add(label2);
            Controls.Add(MobilePlanGrid);
            Controls.Add(label1);
            Controls.Add(AddButton);
            Controls.Add(DeleteButton);
            Controls.Add(SaveButton);
            Controls.Add(ClearButton);
            Controls.Add(RefreshButton);
            Controls.Add(RoamingAgreementGrid);
            Controls.Add(RoamingPartnersGrid);
            Name = "RoamingAdmin";
            Text = "RoamingAdmin";
            ((System.ComponentModel.ISupportInitialize)RoamingPartnersGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)RoamingAgreementGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)MobilePlanGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView RoamingPartnersGrid;
        private DataGridView RoamingAgreementGrid;
        private Button RefreshButton;
        private Button ClearButton;
        private Button SaveButton;
        private Button DeleteButton;
        private Button AddButton;
        private Label label1;
        private DataGridView MobilePlanGrid;
        private Label label2;
    }
}