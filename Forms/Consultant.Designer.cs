namespace MobilusOperatorius.Forms
{
    partial class Consultant
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
            AvailableTicketsGridView = new DataGridView();
            ChangeStatusButton = new Button();
            TicketStatusComboBox = new ComboBox();
            AssignedTicketGridView = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            EnterTicketButton = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            AcceptTicketButton = new Button();
            label6 = new Label();
            UnAssignButton = new Button();
            label7 = new Label();
            Refresh = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)AvailableTicketsGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AssignedTicketGridView).BeginInit();
            SuspendLayout();
            // 
            // AvailableTicketsGridView
            // 
            AvailableTicketsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AvailableTicketsGridView.Location = new Point(12, 41);
            AvailableTicketsGridView.Name = "AvailableTicketsGridView";
            AvailableTicketsGridView.Size = new Size(651, 138);
            AvailableTicketsGridView.TabIndex = 0;
            // 
            // ChangeStatusButton
            // 
            ChangeStatusButton.Location = new Point(12, 415);
            ChangeStatusButton.Name = "ChangeStatusButton";
            ChangeStatusButton.Size = new Size(75, 23);
            ChangeStatusButton.TabIndex = 1;
            ChangeStatusButton.Text = "Change";
            ChangeStatusButton.UseVisualStyleBackColor = true;
            ChangeStatusButton.Click += ChangeStatusButton_Click;
            // 
            // TicketStatusComboBox
            // 
            TicketStatusComboBox.FormattingEnabled = true;
            TicketStatusComboBox.Location = new Point(12, 386);
            TicketStatusComboBox.Name = "TicketStatusComboBox";
            TicketStatusComboBox.Size = new Size(121, 23);
            TicketStatusComboBox.TabIndex = 2;
            // 
            // AssignedTicketGridView
            // 
            AssignedTicketGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AssignedTicketGridView.Location = new Point(12, 230);
            AssignedTicketGridView.Name = "AssignedTicketGridView";
            AssignedTicketGridView.Size = new Size(651, 150);
            AssignedTicketGridView.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 203);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 4;
            label1.Text = "Assigned Tickets";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 23);
            label2.Name = "label2";
            label2.Size = new Size(94, 15);
            label2.TabIndex = 5;
            label2.Text = "Available Tickets";
            // 
            // EnterTicketButton
            // 
            EnterTicketButton.Location = new Point(703, 231);
            EnterTicketButton.Name = "EnterTicketButton";
            EnterTicketButton.Size = new Size(75, 23);
            EnterTicketButton.TabIndex = 6;
            EnterTicketButton.Text = "Enter";
            EnterTicketButton.UseVisualStyleBackColor = true;
            EnterTicketButton.Click += EnterTicketButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(703, 204);
            label3.Name = "label3";
            label3.Size = new Size(68, 15);
            label3.TabIndex = 7;
            label3.Text = "Enter Ticket";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Red;
            label4.Location = new Point(785, 235);
            label4.Name = "label4";
            label4.Size = new Size(107, 15);
            label4.TabIndex = 8;
            label4.Text = "Ne implementuota";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(139, 389);
            label5.Name = "label5";
            label5.Size = new Size(83, 15);
            label5.TabIndex = 9;
            label5.Text = "Change Status";
            // 
            // AcceptTicketButton
            // 
            AcceptTicketButton.Location = new Point(703, 42);
            AcceptTicketButton.Name = "AcceptTicketButton";
            AcceptTicketButton.Size = new Size(75, 23);
            AcceptTicketButton.TabIndex = 10;
            AcceptTicketButton.Text = "Accept";
            AcceptTicketButton.UseVisualStyleBackColor = true;
            AcceptTicketButton.Click += AcceptTicketButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(703, 24);
            label6.Name = "label6";
            label6.Size = new Size(64, 15);
            label6.TabIndex = 11;
            label6.Text = "Take Ticket";
            // 
            // UnAssignButton
            // 
            UnAssignButton.Location = new Point(703, 295);
            UnAssignButton.Name = "UnAssignButton";
            UnAssignButton.Size = new Size(75, 23);
            UnAssignButton.TabIndex = 12;
            UnAssignButton.Text = "UnAssign";
            UnAssignButton.UseVisualStyleBackColor = true;
            UnAssignButton.Click += UnAssignButton_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(703, 277);
            label7.Name = "label7";
            label7.Size = new Size(91, 15);
            label7.TabIndex = 13;
            label7.Text = "UnAssign Ticket";
            // 
            // Refresh
            // 
            Refresh.Location = new Point(703, 157);
            Refresh.Name = "Refresh";
            Refresh.Size = new Size(75, 23);
            Refresh.TabIndex = 14;
            Refresh.Text = "Refresh All";
            Refresh.UseVisualStyleBackColor = true;
            Refresh.Click += Refresh_Click;
            // 
            // button1
            // 
            button1.Location = new Point(817, 416);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 15;
            button1.Text = "Logout";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Consultant
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(918, 450);
            Controls.Add(button1);
            Controls.Add(Refresh);
            Controls.Add(label7);
            Controls.Add(UnAssignButton);
            Controls.Add(label6);
            Controls.Add(AcceptTicketButton);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(EnterTicketButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(AssignedTicketGridView);
            Controls.Add(TicketStatusComboBox);
            Controls.Add(ChangeStatusButton);
            Controls.Add(AvailableTicketsGridView);
            Name = "Consultant";
            Text = "Consultant";
            FormClosing += Consultant_FormClosing;
            Load += Consultant_Load;
            ((System.ComponentModel.ISupportInitialize)AvailableTicketsGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)AssignedTicketGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView AvailableTicketsGridView;
        private Button ChangeStatusButton;
        private ComboBox TicketStatusComboBox;
        private DataGridView AssignedTicketGridView;
        private Label label1;
        private Label label2;
        private Button EnterTicketButton;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button AcceptTicketButton;
        private Label label6;
        private Button UnAssignButton;
        private Label label7;
        private Button Refresh;
        private Button button1;
    }
}