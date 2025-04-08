namespace CarRentalAdmin
{
    partial class CommentManageForm
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
            this.btnToggleFlag = new System.Windows.Forms.Button();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblRating = new System.Windows.Forms.Label();
            this.cmbRating = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnDeleteComment = new System.Windows.Forms.Button();
            this.btnEditComment = new System.Windows.Forms.Button();
            this.btnAddComment = new System.Windows.Forms.Button();
            this.panelData = new System.Windows.Forms.Panel();
            this.dgvComments = new System.Windows.Forms.DataGridView();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.txtCommentMessage = new System.Windows.Forms.TextBox();
            this.lblCommentDetails = new System.Windows.Forms.Label();
            this.panelControls.SuspendLayout();
            this.panelData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComments)).BeginInit();
            this.panelDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControls
            // 
            this.panelControls.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelControls.Controls.Add(this.btnToggleFlag);
            this.panelControls.Controls.Add(this.lblCategory);
            this.panelControls.Controls.Add(this.cmbCategory);
            this.panelControls.Controls.Add(this.lblRating);
            this.panelControls.Controls.Add(this.cmbRating);
            this.panelControls.Controls.Add(this.btnSearch);
            this.panelControls.Controls.Add(this.txtSearch);
            this.panelControls.Controls.Add(this.btnDeleteComment);
            this.panelControls.Controls.Add(this.btnEditComment);
            this.panelControls.Controls.Add(this.btnAddComment);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControls.Location = new System.Drawing.Point(0, 0);
            this.panelControls.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(712, 49);
            this.panelControls.TabIndex = 0;
            // 
            // btnToggleFlag
            // 
            this.btnToggleFlag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(151)))), ((int)(((byte)(78)))));
            this.btnToggleFlag.FlatAppearance.BorderSize = 0;
            this.btnToggleFlag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleFlag.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToggleFlag.ForeColor = System.Drawing.Color.White;
            this.btnToggleFlag.Location = new System.Drawing.Point(675, 12);
            this.btnToggleFlag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnToggleFlag.Name = "btnToggleFlag";
            this.btnToggleFlag.Size = new System.Drawing.Size(22, 24);
            this.btnToggleFlag.TabIndex = 9;
            this.btnToggleFlag.Text = "🚩";
            this.btnToggleFlag.UseVisualStyleBackColor = false;
            this.btnToggleFlag.Click += new System.EventHandler(this.btnToggleFlag_Click);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(554, 3);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(108, 15);
            this.lblCategory.TabIndex = 8;
            this.lblCategory.Text = "Értékelési kategória";
            // 
            // cmbCategory
            // 
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            AppResources.RatingCategoryhu[0],
            AppResources.RatingCategoryhu[1],
            AppResources.RatingCategoryhu[2],
            AppResources.RatingCategoryhu[3],
            AppResources.RatingCategoryhu[4],
            AppResources.RatingCategoryhu[5]});
            this.cmbCategory.Location = new System.Drawing.Point(541, 22);
            this.cmbCategory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(121, 23);
            this.cmbCategory.TabIndex = 7;
            this.cmbCategory.Text = "Összes";
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRating.Location = new System.Drawing.Point(457, 3);
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
            this.cmbRating.Location = new System.Drawing.Point(460, 20);
            this.cmbRating.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbRating.Name = "cmbRating";
            this.cmbRating.Size = new System.Drawing.Size(77, 23);
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
            this.btnSearch.Location = new System.Drawing.Point(384, 11);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(69, 24);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Keresés";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(259, 12);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(121, 23);
            this.txtSearch.TabIndex = 3;
            // 
            // btnDeleteComment
            // 
            this.btnDeleteComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(100)))), ((int)(((byte)(70)))));
            this.btnDeleteComment.FlatAppearance.BorderSize = 0;
            this.btnDeleteComment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteComment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteComment.ForeColor = System.Drawing.Color.White;
            this.btnDeleteComment.Location = new System.Drawing.Point(176, 3);
            this.btnDeleteComment.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeleteComment.Name = "btnDeleteComment";
            this.btnDeleteComment.Size = new System.Drawing.Size(79, 44);
            this.btnDeleteComment.TabIndex = 2;
            this.btnDeleteComment.Text = "Hozzászólás törlése";
            this.btnDeleteComment.UseVisualStyleBackColor = false;
            this.btnDeleteComment.Click += new System.EventHandler(this.btnDeleteComment_Click);
            // 
            // btnEditComment
            // 
            this.btnEditComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnEditComment.FlatAppearance.BorderSize = 0;
            this.btnEditComment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditComment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditComment.ForeColor = System.Drawing.Color.White;
            this.btnEditComment.Location = new System.Drawing.Point(94, 2);
            this.btnEditComment.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEditComment.Name = "btnEditComment";
            this.btnEditComment.Size = new System.Drawing.Size(78, 45);
            this.btnEditComment.TabIndex = 1;
            this.btnEditComment.Text = "Hozzászólás szerkesztése";
            this.btnEditComment.UseVisualStyleBackColor = false;
            this.btnEditComment.Click += new System.EventHandler(this.btnEditComment_Click);
            // 
            // btnAddComment
            // 
            this.btnAddComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.btnAddComment.FlatAppearance.BorderSize = 0;
            this.btnAddComment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddComment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddComment.ForeColor = System.Drawing.Color.White;
            this.btnAddComment.Location = new System.Drawing.Point(11, 3);
            this.btnAddComment.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddComment.Name = "btnAddComment";
            this.btnAddComment.Size = new System.Drawing.Size(79, 44);
            this.btnAddComment.TabIndex = 0;
            this.btnAddComment.Text = "Hozzászólás hozzáadása";
            this.btnAddComment.UseVisualStyleBackColor = false;
            this.btnAddComment.Click += new System.EventHandler(this.btnAddComment_Click);
            // 
            // panelData
            // 
            this.panelData.Controls.Add(this.dgvComments);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Location = new System.Drawing.Point(0, 49);
            this.panelData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelData.Name = "panelData";
            this.panelData.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.panelData.Size = new System.Drawing.Size(712, 309);
            this.panelData.TabIndex = 1;
            // 
            // dgvComments
            // 
            this.dgvComments.AllowUserToAddRows = false;
            this.dgvComments.AllowUserToDeleteRows = false;
            this.dgvComments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvComments.BackgroundColor = System.Drawing.Color.White;
            this.dgvComments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvComments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvComments.Location = new System.Drawing.Point(11, 12);
            this.dgvComments.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvComments.MultiSelect = false;
            this.dgvComments.Name = "dgvComments";
            this.dgvComments.ReadOnly = true;
            this.dgvComments.RowHeadersWidth = 51;
            this.dgvComments.RowTemplate.Height = 24;
            this.dgvComments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComments.Size = new System.Drawing.Size(690, 285);
            this.dgvComments.TabIndex = 0;
            this.dgvComments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComments_CellClick);
            // 
            // panelDetails
            // 
            this.panelDetails.Controls.Add(this.txtCommentMessage);
            this.panelDetails.Controls.Add(this.lblCommentDetails);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDetails.Location = new System.Drawing.Point(0, 358);
            this.panelDetails.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.panelDetails.Size = new System.Drawing.Size(712, 162);
            this.panelDetails.TabIndex = 2;
            // 
            // txtCommentMessage
            // 
            this.txtCommentMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommentMessage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommentMessage.Location = new System.Drawing.Point(11, 37);
            this.txtCommentMessage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCommentMessage.Multiline = true;
            this.txtCommentMessage.Name = "txtCommentMessage";
            this.txtCommentMessage.ReadOnly = true;
            this.txtCommentMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCommentMessage.Size = new System.Drawing.Size(691, 114);
            this.txtCommentMessage.TabIndex = 1;
            // 
            // lblCommentDetails
            // 
            this.lblCommentDetails.AutoSize = true;
            this.lblCommentDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommentDetails.Location = new System.Drawing.Point(11, 12);
            this.lblCommentDetails.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCommentDetails.Name = "lblCommentDetails";
            this.lblCommentDetails.Size = new System.Drawing.Size(151, 19);
            this.lblCommentDetails.TabIndex = 0;
            this.lblCommentDetails.Text = "Hozzászólás részletei";
            // 
            // CommentManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 520);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.panelDetails);
            this.Controls.Add(this.panelControls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CommentManageForm";
            this.Text = "Hozzászólás kezelés";
            this.Load += new System.EventHandler(this.CommentManageForm_Load);
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            this.panelData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComments)).EndInit();
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Button btnAddComment;
        private System.Windows.Forms.Button btnEditComment;
        private System.Windows.Forms.Button btnDeleteComment;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbRating;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Button btnToggleFlag;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.DataGridView dgvComments;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Label lblCommentDetails;
        private System.Windows.Forms.TextBox txtCommentMessage;
    }
}