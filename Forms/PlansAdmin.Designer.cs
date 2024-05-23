namespace MobilusOperatorius.Forms
{
    partial class PlansAdmin
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
            comboBox1 = new ComboBox();
            PlanGrid = new DataGridView();
            RefreshButton = new Button();
            ClearButton = new Button();
            SaveButton = new Button();
            DeleteButton = new Button();
            AddButton = new Button();
            OpenRoamingButton = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)PlanGrid).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "MobilePlan", "InternetPlan" });
            comboBox1.Location = new Point(12, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // PlanGrid
            // 
            PlanGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PlanGrid.Location = new Point(12, 88);
            PlanGrid.Name = "PlanGrid";
            PlanGrid.Size = new Size(776, 185);
            PlanGrid.TabIndex = 1;
            // 
            // RefreshButton
            // 
            RefreshButton.Location = new Point(12, 279);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(75, 23);
            RefreshButton.TabIndex = 2;
            RefreshButton.Text = "Refresh";
            RefreshButton.UseVisualStyleBackColor = true;
            RefreshButton.Click += RefreshButton_Click;
            // 
            // ClearButton
            // 
            ClearButton.Location = new Point(93, 279);
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
            DeleteButton.Location = new Point(93, 415);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(75, 23);
            DeleteButton.TabIndex = 5;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(174, 415);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(75, 23);
            AddButton.TabIndex = 6;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // OpenRoamingButton
            // 
            OpenRoamingButton.Location = new Point(623, 415);
            OpenRoamingButton.Name = "OpenRoamingButton";
            OpenRoamingButton.Size = new Size(142, 23);
            OpenRoamingButton.TabIndex = 7;
            OpenRoamingButton.Text = "Roaming Agreements";
            OpenRoamingButton.UseVisualStyleBackColor = true;
            OpenRoamingButton.Click += OpenRoamingButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(600, 397);
            label1.Name = "label1";
            label1.Size = new Size(188, 15);
            label1.TabIndex = 8;
            label1.Text = "Mobile Plan Roaming Agreements";
            // 
            // PlansAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(OpenRoamingButton);
            Controls.Add(AddButton);
            Controls.Add(DeleteButton);
            Controls.Add(SaveButton);
            Controls.Add(ClearButton);
            Controls.Add(RefreshButton);
            Controls.Add(PlanGrid);
            Controls.Add(comboBox1);
            Name = "PlansAdmin";
            Text = "PlansAdmin";
            ((System.ComponentModel.ISupportInitialize)PlanGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private DataGridView PlanGrid;
        private Button RefreshButton;
        private Button ClearButton;
        private Button SaveButton;
        private Button DeleteButton;
        private Button AddButton;
        private Button OpenRoamingButton;
        private Label label1;
    }
}