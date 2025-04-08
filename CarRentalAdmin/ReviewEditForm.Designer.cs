namespace CarRentalAdmin
{
    partial class ReviewEditForm
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

        private void InitializeComponent()
        {
            this.lblReviewer = new System.Windows.Forms.Label();
            this.cmbReviewer = new System.Windows.Forms.ComboBox();
            this.lblReviewee = new System.Windows.Forms.Label();
            this.cmbReviewee = new System.Windows.Forms.ComboBox();
            this.lblRating = new System.Windows.Forms.Label();
            this.numRating = new System.Windows.Forms.NumericUpDown();
            this.lblReviewMessage = new System.Windows.Forms.Label();
            this.txtReviewMessage = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numRating)).BeginInit();
            this.SuspendLayout();
            // 
            // lblReviewer
            // 
            this.lblReviewer.AutoSize = true;
            this.lblReviewer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReviewer.Location = new System.Drawing.Point(15, 20);
            this.lblReviewer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReviewer.Name = "lblReviewer";
            this.lblReviewer.Size = new System.Drawing.Size(49, 15);
            this.lblReviewer.TabIndex = 0;
            this.lblReviewer.Text = "Értékelő";
            // 
            // cmbReviewer
            // 
            this.cmbReviewer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReviewer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReviewer.FormattingEnabled = true;
            this.cmbReviewer.Location = new System.Drawing.Point(98, 18);
            this.cmbReviewer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbReviewer.Name = "cmbReviewer";
            this.cmbReviewer.Size = new System.Drawing.Size(263, 23);
            this.cmbReviewer.TabIndex = 1;
            // 
            // lblReviewee
            // 
            this.lblReviewee.AutoSize = true;
            this.lblReviewee.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReviewee.Location = new System.Drawing.Point(15, 53);
            this.lblReviewee.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReviewee.Name = "lblReviewee";
            this.lblReviewee.Size = new System.Drawing.Size(46, 15);
            this.lblReviewee.TabIndex = 2;
            this.lblReviewee.Text = "Értékelt";
            // 
            // cmbReviewee
            // 
            this.cmbReviewee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReviewee.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReviewee.FormattingEnabled = true;
            this.cmbReviewee.Location = new System.Drawing.Point(98, 50);
            this.cmbReviewee.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbReviewee.Name = "cmbReviewee";
            this.cmbReviewee.Size = new System.Drawing.Size(263, 23);
            this.cmbReviewee.TabIndex = 3;
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRating.Location = new System.Drawing.Point(15, 85);
            this.lblRating.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(53, 15);
            this.lblRating.TabIndex = 4;
            this.lblRating.Text = "Értékelés";
            // 
            // numRating
            // 
            this.numRating.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRating.Location = new System.Drawing.Point(98, 84);
            this.numRating.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numRating.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numRating.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRating.Name = "numRating";
            this.numRating.Size = new System.Drawing.Size(45, 23);
            this.numRating.TabIndex = 5;
            this.numRating.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblReviewMessage
            // 
            this.lblReviewMessage.AutoSize = true;
            this.lblReviewMessage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReviewMessage.Location = new System.Drawing.Point(15, 118);
            this.lblReviewMessage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReviewMessage.Name = "lblReviewMessage";
            this.lblReviewMessage.Size = new System.Drawing.Size(97, 15);
            this.lblReviewMessage.TabIndex = 6;
            this.lblReviewMessage.Text = "Értékelés üzenete";
            // 
            // txtReviewMessage
            // 
            this.txtReviewMessage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReviewMessage.Location = new System.Drawing.Point(15, 142);
            this.txtReviewMessage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtReviewMessage.Multiline = true;
            this.txtReviewMessage.Name = "txtReviewMessage";
            this.txtReviewMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReviewMessage.Size = new System.Drawing.Size(346, 98);
            this.txtReviewMessage.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(112, 252);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Mentés";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(210, 252);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Mégse";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ReviewEditForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(375, 292);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtReviewMessage);
            this.Controls.Add(this.lblReviewMessage);
            this.Controls.Add(this.numRating);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.cmbReviewee);
            this.Controls.Add(this.lblReviewee);
            this.Controls.Add(this.cmbReviewer);
            this.Controls.Add(this.lblReviewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReviewEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Értékelés részletei";
            this.Load += new System.EventHandler(this.ReviewEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numRating)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblReviewer;
        private System.Windows.Forms.ComboBox cmbReviewer;
        private System.Windows.Forms.Label lblReviewee;
        private System.Windows.Forms.ComboBox cmbReviewee;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.NumericUpDown numRating;
        private System.Windows.Forms.Label lblReviewMessage;
        private System.Windows.Forms.TextBox txtReviewMessage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}