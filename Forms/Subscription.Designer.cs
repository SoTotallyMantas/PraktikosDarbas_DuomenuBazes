namespace MobilusOperatorius.Forms
{
    partial class Subscription
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
            subscriptiongrid = new DataGridView();
            label1 = new Label();
            PaymentButton = new Button();
            PaymentCombo = new ComboBox();
            label2 = new Label();
            Price = new Label();
            label4 = new Label();
            UsageGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)subscriptiongrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UsageGrid).BeginInit();
            SuspendLayout();
            // 
            // subscriptiongrid
            // 
            subscriptiongrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            subscriptiongrid.Location = new Point(12, 12);
            subscriptiongrid.Name = "subscriptiongrid";
            subscriptiongrid.Size = new Size(776, 291);
            subscriptiongrid.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 342);
            label1.Name = "label1";
            label1.Size = new Size(141, 15);
            label1.TabIndex = 1;
            label1.Text = "Payment for Subscription";
            // 
            // PaymentButton
            // 
            PaymentButton.Location = new Point(12, 415);
            PaymentButton.Name = "PaymentButton";
            PaymentButton.Size = new Size(75, 23);
            PaymentButton.TabIndex = 2;
            PaymentButton.Text = "Pay";
            PaymentButton.UseVisualStyleBackColor = true;
            PaymentButton.Click += PaymentButton_Click;
            // 
            // PaymentCombo
            // 
            PaymentCombo.FormattingEnabled = true;
            PaymentCombo.Location = new Point(12, 386);
            PaymentCombo.Name = "PaymentCombo";
            PaymentCombo.Size = new Size(121, 23);
            PaymentCombo.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 368);
            label2.Name = "label2";
            label2.Size = new Size(99, 15);
            label2.TabIndex = 4;
            label2.Text = "Payment Method";
            // 
            // Price
            // 
            Price.AutoSize = true;
            Price.Location = new Point(159, 342);
            Price.Name = "Price";
            Price.Size = new Size(33, 15);
            Price.TabIndex = 7;
            Price.Text = "Price";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(159, 316);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 8;
            label4.Text = "Total Price";
            // 
            // UsageGrid
            // 
            UsageGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            UsageGrid.Location = new Point(357, 329);
            UsageGrid.Name = "UsageGrid";
            UsageGrid.Size = new Size(431, 80);
            UsageGrid.TabIndex = 9;
            // 
            // Subscription
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(UsageGrid);
            Controls.Add(label4);
            Controls.Add(Price);
            Controls.Add(label2);
            Controls.Add(PaymentCombo);
            Controls.Add(PaymentButton);
            Controls.Add(label1);
            Controls.Add(subscriptiongrid);
            Name = "Subscription";
            Text = "Subscription";
            ((System.ComponentModel.ISupportInitialize)subscriptiongrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)UsageGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView subscriptiongrid;
        private Label label1;
        private Button PaymentButton;
        private ComboBox PaymentCombo;
        private Label label2;
        private Label Price;
        private Label label4;
        private DataGridView UsageGrid;
    }
}