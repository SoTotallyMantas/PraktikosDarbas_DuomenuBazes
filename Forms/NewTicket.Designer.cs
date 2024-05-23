namespace MobilusOperatorius.Forms
{
    partial class NewTicket
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
            subjecttextbox = new TextBox();
            descriptionrichbox = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // subjecttextbox
            // 
            subjecttextbox.Location = new Point(39, 46);
            subjecttextbox.Name = "subjecttextbox";
            subjecttextbox.Size = new Size(257, 23);
            subjecttextbox.TabIndex = 0;
            // 
            // descriptionrichbox
            // 
            descriptionrichbox.Location = new Point(39, 95);
            descriptionrichbox.Name = "descriptionrichbox";
            descriptionrichbox.Size = new Size(257, 230);
            descriptionrichbox.TabIndex = 1;
            descriptionrichbox.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 28);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 2;
            label1.Text = "Subject";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 77);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 3;
            label2.Text = "Description";
            // 
            // button1
            // 
            button1.Location = new Point(132, 331);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // NewTicket
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(341, 374);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(descriptionrichbox);
            Controls.Add(subjecttextbox);
            Name = "NewTicket";
            Text = "NewTicket";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox subjecttextbox;
        private RichTextBox descriptionrichbox;
        private Label label1;
        private Label label2;
        private Button button1;
    }
}