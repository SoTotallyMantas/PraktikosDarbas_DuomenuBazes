namespace MobilusOperatorius.Forms
{
    partial class RoamingPartnerAdmin
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
            PartnersGrid = new DataGridView();
            RefreshButton = new Button();
            ClearButton = new Button();
            button3 = new Button();
            DeleteButton = new Button();
            AddButton = new Button();
            ((System.ComponentModel.ISupportInitialize)PartnersGrid).BeginInit();
            SuspendLayout();
            // 
            // PartnersGrid
            // 
            PartnersGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PartnersGrid.Location = new Point(12, 12);
            PartnersGrid.Name = "PartnersGrid";
            PartnersGrid.Size = new Size(513, 150);
            PartnersGrid.TabIndex = 0;
            // 
            // RefreshButton
            // 
            RefreshButton.Location = new Point(12, 168);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(75, 23);
            RefreshButton.TabIndex = 1;
            RefreshButton.Text = "Refresh";
            RefreshButton.UseVisualStyleBackColor = true;
            RefreshButton.Click += RefreshButton_Click;
            // 
            // ClearButton
            // 
            ClearButton.Location = new Point(93, 168);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(75, 23);
            ClearButton.TabIndex = 2;
            ClearButton.Text = "Clear";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // button3
            // 
            button3.Location = new Point(12, 280);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 3;
            button3.Text = "Update";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(93, 280);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(75, 23);
            DeleteButton.TabIndex = 4;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(174, 280);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(75, 23);
            AddButton.TabIndex = 5;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // RoamingPartnerAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(569, 324);
            Controls.Add(AddButton);
            Controls.Add(DeleteButton);
            Controls.Add(button3);
            Controls.Add(ClearButton);
            Controls.Add(RefreshButton);
            Controls.Add(PartnersGrid);
            Name = "RoamingPartnerAdmin";
            Text = "RoamingPartnerAdmin";
            ((System.ComponentModel.ISupportInitialize)PartnersGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView PartnersGrid;
        private Button RefreshButton;
        private Button ClearButton;
        private Button button3;
        private Button DeleteButton;
        private Button AddButton;
    }
}