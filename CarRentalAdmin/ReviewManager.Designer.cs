namespace CarRentalAdmin
{
    partial class ReviewManageForm
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
            this.panelControls = new System.Windows.Forms.Panel();
            this.lblRating = new System.Windows.Forms.Label();
            this.cmbRating = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnDeleteReview = new System.Windows.Forms.Button();
            this.btnEditReview = new System.Windows.Forms.Button();
            this.btnAddReview = new System.Windows.Forms.Button();
            this.panelData = new System.Windows.Forms.Panel();
            this.dgvReviews = new System.Windows.Forms.DataGridView();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.txtReviewMessage = new System.Windows.Forms.TextBox();
            this.lblReviewDetails = new System.Windows.Forms.Label();
            this.panelControls.SuspendLayout();
            this.panelData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReviews)).BeginInit();
            this.panelDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControls
            // 
            this.panelControls.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelControls.Controls.Add(this.lblRating);
            this.panelControls.Controls.Add(this.cmbRating);
            this.panelControls.Controls.Add(this.btnSearch);
            this.panelControls.Controls.Add(this.txtSearch);
            this.panelControls.Controls.Add(this.btnDeleteReview);
            this.panelControls.Controls.Add(this.btnEditReview);
            this.panelControls.Controls.Add(this.btnAddReview);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControls.Location = new System.Drawing.Point(0, 0);
            this.panelControls.Margin = new System.Windows.Forms.Padding(2);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(712, 49);
            this.panelControls.TabIndex = 0;
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRating.Location = new System.Drawing.Point(569, 15);
            this.lblRating.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(53, 15);
            this.lblRating.TabIndex = 6;
            this.lblRating.Text = "Értékelés";
            // 
            // cmbRating
            // 
            this.cmbRating.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRating.FormattingEnabled = true;
            this.cmbRating.Items.AddRange(new object[] {
            "Összes",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbRating.Location = new System.Drawing.Point(626, 13);
            this.cmbRating.Margin = new System.Windows.Forms.Padding(2);
            this.cmbRating.Name = "cmbRating";
            this.cmbRating.Size = new System.Drawing.Size(76, 23);
            this.cmbRating.TabIndex = 5;
            this.cmbRating.Text = "Összes";
            this.cmbRating.SelectedIndexChanged += new System.EventHandler(this.cmbRating_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(505, 12);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 24);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Keresés";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(304, 12);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(197, 23);
            this.txtSearch.TabIndex = 3;
            // 
            // btnDeleteReview
            // 
            this.btnDeleteReview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(100)))), ((int)(((byte)(70)))));
            this.btnDeleteReview.FlatAppearance.BorderSize = 0;
            this.btnDeleteReview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteReview.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteReview.ForeColor = System.Drawing.Color.White;
            this.btnDeleteReview.Location = new System.Drawing.Point(199, 2);
            this.btnDeleteReview.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteReview.Name = "btnDeleteReview";
            this.btnDeleteReview.Size = new System.Drawing.Size(90, 43);
            this.btnDeleteReview.TabIndex = 2;
            this.btnDeleteReview.Text = "Értékelés törlése";
            this.btnDeleteReview.UseVisualStyleBackColor = false;
            this.btnDeleteReview.Click += new System.EventHandler(this.btnDeleteReview_Click);
            // 
            // btnEditReview
            // 
            this.btnEditReview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnEditReview.FlatAppearance.BorderSize = 0;
            this.btnEditReview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditReview.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditReview.ForeColor = System.Drawing.Color.White;
            this.btnEditReview.Location = new System.Drawing.Point(105, 2);
            this.btnEditReview.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditReview.Name = "btnEditReview";
            this.btnEditReview.Size = new System.Drawing.Size(90, 43);
            this.btnEditReview.TabIndex = 1;
            this.btnEditReview.Text = "Értékelés szerkesztése";
            this.btnEditReview.UseVisualStyleBackColor = false;
            this.btnEditReview.Click += new System.EventHandler(this.btnEditReview_Click);
            // 
            // btnAddReview
            // 
            this.btnAddReview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.btnAddReview.FlatAppearance.BorderSize = 0;
            this.btnAddReview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddReview.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddReview.ForeColor = System.Drawing.Color.White;
            this.btnAddReview.Location = new System.Drawing.Point(11, 2);
            this.btnAddReview.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddReview.Name = "btnAddReview";
            this.btnAddReview.Size = new System.Drawing.Size(90, 43);
            this.btnAddReview.TabIndex = 0;
            this.btnAddReview.Text = "Értékelés hozzáadása";
            this.btnAddReview.UseVisualStyleBackColor = false;
            this.btnAddReview.Click += new System.EventHandler(this.btnAddReview_Click);
            // 
            // panelData
            // 
            this.panelData.Controls.Add(this.dgvReviews);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Location = new System.Drawing.Point(0, 49);
            this.panelData.Margin = new System.Windows.Forms.Padding(2);
            this.panelData.Name = "panelData";
            this.panelData.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.panelData.Size = new System.Drawing.Size(712, 309);
            this.panelData.TabIndex = 1;
            // 
            // dgvReviews
            // 
            this.dgvReviews.AllowUserToAddRows = false;
            this.dgvReviews.AllowUserToDeleteRows = false;
            this.dgvReviews.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReviews.BackgroundColor = System.Drawing.Color.White;
            this.dgvReviews.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReviews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReviews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReviews.Location = new System.Drawing.Point(11, 12);
            this.dgvReviews.Margin = new System.Windows.Forms.Padding(2);
            this.dgvReviews.MultiSelect = false;
            this.dgvReviews.Name = "dgvReviews";
            this.dgvReviews.ReadOnly = true;
            this.dgvReviews.RowHeadersWidth = 51;
            this.dgvReviews.RowTemplate.Height = 24;
            this.dgvReviews.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReviews.Size = new System.Drawing.Size(690, 285);
            this.dgvReviews.TabIndex = 0;
            this.dgvReviews.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReviews_CellClick);
            // 
            // panelDetails
            // 
            this.panelDetails.Controls.Add(this.txtReviewMessage);
            this.panelDetails.Controls.Add(this.lblReviewDetails);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDetails.Location = new System.Drawing.Point(0, 358);
            this.panelDetails.Margin = new System.Windows.Forms.Padding(2);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.panelDetails.Size = new System.Drawing.Size(712, 162);
            this.panelDetails.TabIndex = 2;
            // 
            // txtReviewMessage
            // 
            this.txtReviewMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReviewMessage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReviewMessage.Location = new System.Drawing.Point(11, 37);
            this.txtReviewMessage.Margin = new System.Windows.Forms.Padding(2);
            this.txtReviewMessage.Multiline = true;
            this.txtReviewMessage.Name = "txtReviewMessage";
            this.txtReviewMessage.ReadOnly = true;
            this.txtReviewMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReviewMessage.Size = new System.Drawing.Size(691, 114);
            this.txtReviewMessage.TabIndex = 1;
            // 
            // lblReviewDetails
            // 
            this.lblReviewDetails.AutoSize = true;
            this.lblReviewDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReviewDetails.Location = new System.Drawing.Point(11, 12);
            this.lblReviewDetails.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReviewDetails.Name = "lblReviewDetails";
            this.lblReviewDetails.Size = new System.Drawing.Size(129, 19);
            this.lblReviewDetails.TabIndex = 0;
            this.lblReviewDetails.Text = "Értékelés részletei";
            // 
            // ReviewManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 520);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.panelDetails);
            this.Controls.Add(this.panelControls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ReviewManageForm";
            this.Text = "Értékelés kezelés";
            this.Load += new System.EventHandler(this.ReviewManageForm_Load);
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            this.panelData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReviews)).EndInit();
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Button btnAddReview;
        private System.Windows.Forms.Button btnEditReview;
        private System.Windows.Forms.Button btnDeleteReview;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbRating;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.DataGridView dgvReviews;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Label lblReviewDetails;
        private System.Windows.Forms.TextBox txtReviewMessage;
    }
}