namespace MobilusOperatorius.Forms
{
    partial class ProductFeatures
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
            productfeaturegridview = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)productfeaturegridview).BeginInit();
            SuspendLayout();
            // 
            // productfeaturegridview
            // 
            productfeaturegridview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            productfeaturegridview.Location = new Point(12, 12);
            productfeaturegridview.Name = "productfeaturegridview";
            productfeaturegridview.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            productfeaturegridview.Size = new Size(776, 365);
            productfeaturegridview.TabIndex = 0;
            // 
            // ProductFeatures
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(productfeaturegridview);
            Name = "ProductFeatures";
            Text = "ProductFeatures";
            Load += ProductFeatures_Load;
            ((System.ComponentModel.ISupportInitialize)productfeaturegridview).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView productfeaturegridview;
    }
}